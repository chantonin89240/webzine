# Création des clusters apache et bdd 
1. [Cluster Apache](#Cluster-Apache)
2. [Cluster BDD](#Cluster-BDD)

## Cluster Apache
### Installation de keepalived
Tout d'abord, assurez vous d'avoir une machine à l'identique !
Il faut que le fichier `/etc/apache2/apache2.conf` et le fichier `/etc/apache2/sites-available/apache.conf` soit identique sur les deux machines !

Une fois ces prérequis prit en compte, il faudra installer keepalived <b>sur les deux machines:</b>
```
apt install keepalived
```
Il faudra ensuite créer le fichier `/etc/keepalived/keepalived.conf`et y intégrer cette configuration :

<b> Configuration pour le Master :</b>
```
vrrp_instance VI_1 {

        state MASTER
        interface eth0
        virtual_router_id 10
        priority 255
        advert_int 1
        authentication {
              auth_type PASS
              auth_pass 12345
        }
        virtual_ipaddress {
              192.168.10.10/24
        }
}
```
L'adresse ip virtuelle sera la même sur les deux machines, car c'est grâce à elle que la haute-disponibilité est possible.

Redémarrez votre service keepalived :
```
systemctl restart keepalived.service
```
<b> Configuration pour le Slave :</b>

```
vrrp_instance VI_1 {
        state BACKUP
        interface eth0
        virtual_router_id 10
        priority 254
        advert_int 1
        authentication {
              auth_type PASS
              auth_pass 12345
        }
        virtual_ipaddress {
              192.168.10.10/24
        }
}
```
Redémarrez votre service keepalived :
```
systemctl restart keepalived.service
```
Maintenant, il faut vérifier si l'adresse ip virtuelle est bien prise en compte par le <b> Master :</b>
```
ip a
```
Si elle est effective, nous devrions avoir quelque chose qui ressemble à ceci :
```
eth0: <BROADCAST,MULTICAST,UP,LOWER_UP> mtu 1500 qdisc mq state UP group default qlen 1000
    link/ether 00:15:5d:00:8d:18 brd ff:ff:ff:ff:ff:ff
    inet 192.168.10.2/24 brd 192.168.10.255 scope global eth0
       valid_lft forever preferred_lft forever
    inet 192.168.10.10/24 scope global secondary eth0
       valid_lft forever preferred_lft forever
    inet6 fe80::215:5dff:fe00:8d18/64 scope link
       valid_lft forever preferred_lft forever
```
Cette adresse n'apparait pas sur le slave car la Master fonctionne, mais vous verrez qu'elle apparaitra dès l'instant où la Master sera éteinte.

Il est temps d'éteindre la Master pour vérifier si la haute disponibilité fonctionne.

Sur la machine <b >Master </b> :
```
poweroff
```
<b> Retournez sur le Slave </b> et vérifier que l'adresse ip virtuelle à bien été transférée sur la machine : 
```
ip a
```
Si l'adresse ip <b> 192.168.10.10 </b> apparait, alors la haute disponibilité fonctionne.

## Cluster BDD
### Installation de keepalived
Pour l'installation de keepalived, la procédure est la même à la seule différence qu'il faudra <b>modifier l'adresse ip virtuelle et le virtual_router_id </b> pour éviter les confusions au sein du réseau.
```
vrrp_instance VI_1 {

        state MASTER
        interface eth0
        virtual_router_id 11
        priority 255
        advert_int 1
        authentication {
              auth_type PASS
              auth_pass 12345
        }
        virtual_ipaddress {
              192.168.10.15/24
        }
}
```
```
vrrp_instance VI_1 {
        state BACKUP
        interface eth0
        virtual_router_id 11
        priority 254
        advert_int 1
        authentication {
              auth_type PASS
              auth_pass 12345
        }
        virtual_ipaddress {
              192.168.10.15/24
        }
}
```
Dans cette configuration, le <b>virtual_router_id</b> est passé à 11 et <b>l'adresse ip virtuelle</b> est 192.168.10.15/24. Ce sont bien des éléments différents de la configuration d'apache donc il n'y aura pas de confusion.

### Mise en place de la réplication de la BDD

#### Pré-requis :
- Avoir postgresql sur le cluster BDD

Nous utilision un mode de réplication en Master/Slave.

Lorsque le Master reçoit une requête SQL, toutes les modifications de données sont enregistrées dans des journaux de transactions : les WAL (Write-Ahead Log) xlogs. Ces journaux sont transférés au Slave (log shipping), qui les rejoue continuellement de façon à retrouver le même état que le Master. Cette restauration continue lui permet d'être prêt à prendre la relève en cas de défaillance du Master : on dit du Slave qu'il est en standby.

## 1. Mise en place du fichier de configuration
Dans un premier temps, on va modifier le fichier de configuration principal `/etc/postgresql/13/main/postgresql.conf` exactement de la 
même manière <b>sur le Master et le Slave. </b>
```
wal_level = hot_standby
max_wal_senders = 5
hot_standby = on
```
## 2. Sur la machine Master
On crée un utilisateur dédié à la réplication :
```
sudo -u postgres psql -c "CREATE USER replication REPLICATION LOGIN CONNECTION LIMIT -1 ENCRYPTED PASSWORD 'motdepasse';"
```
Rendez vous ensuite dans le fichier `/etc/postgesql/13/main/pg_hba.conf` et ajoutez cette ligne à la fin du fichier :
```
host replication replication ip_du_slave/32 md5
```

On redémarre le servise postgresql :
```
systemctl restart postgresql
```
## 3. Sur la machine Slave
On modifie `/etc/postgresql/13/main/pg_hba.conf` :
```
host replication replication ip_du_master/32 md5
```
On va maintenant faire la base backup, sauvegarde complète des bases :
```
sudo -u postgres rm -fr /var/lib/postgresql/13/main
sudo -u postgres pg_basebackup -h ip_du_master -D /var/lib/postgresql/13/main -U replication -Fp -R -v
```
Dans le ficher `/etc/postgresql/13/main/postgresql.conf`, on décommente les lignes :
```
primary_conninfo = 'host=ip_du_master port=5432 user=replication password=motdepasse' 	
promote_trigger_file = '/var/lib/postgresql/13/postgresql.trigger'

```
Redémarrez le service postgresql : 
```
systemctl restart postgresql
```
## 4. Test de la réplication
Les deux machines sont prêtes, il est temps de vérifier si la réplication fonctionne. 

On va créer une table temporaire sur le Master :
```
sudo -u postgres psql

CREATE TABLE rep_test (test varchar(40));
INSERT INTO rep_test VALUES ('test');

```
On s'assure qu'elle est bien répliquée sur le Slave :
```
 sudo -u postgres psql

SELECT * FROM rep_test;
```
Si la table s'affiche, alors la réplication fonctionne.

Vous pouvez la supprimer sur la <b>Master</b> et vérifier si elle a bien été effacé sur la <b>Slave</b>.