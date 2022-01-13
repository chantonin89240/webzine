

## Installer Zabbix sur 3 VM

Conditions requises:

- 3 VMS ( Debian11) en état de marche, à jour et qui accèdent à internet
- date/heure correct
- Accès ssh en root
- Wget installé
 
# 1) Ajout des dépots de zabbix


```bash
wget https://repo.zabbix.com/zabbix/5.0/debian/pool/main/z/zabbix-release/zabbix-release_5.0-2+debian11_all.deb
dpkg -i zabbix-release_5.0-2+debian11_all.deb
apt update
```
# 2)  VM BDD

Installation de postgreSQL:
```bash
apt install postgresql postgresql-contrib
```

Création de la BDD zabbix et ajout de l'utilisateur zabbix dans postgreSQL:
```bash
sudo -u postgres createuser --pwprompt zabbix
saisir zabbix comme mdp 
sudo -u postgres createdb -O zabbix zabbix
```

Si erreur: créer user zabbix:
```bash
adduser zabbix
```
Mdp user: zabbix

Télécharger le fichier suivant qui contient le lien du squeltte de la BDD:
https://groupesbtest-my.sharepoint.com/:u:/g/personal/hugo_zahn_diiage_org/ERr_RjfmRpFOrAyweUZZdvIBk2XpLmTnMQgzPXf47U5Lcw?e=1aqpbT

L'envoyer sur la machine de BDD dans le répertoire /tmp avec winscp par exemple .
Puis taper la commande suivante:
```bash
zcat create.sql.gz | sudo -u zabbix psql zabbix
```

Autorisation des connexion à distance pour postgreSQL:
```bash
nano /etc/postgresql/13/main/postgresql.conf
listen_addresses ='*'

nano /etc/postgresql/13/main/pg_hba.conf
host all all @IP[front] md5

systemctl restart postgresql
systemctl enable postgresql
```

# 3) VM FRONT

Installer les paquets pour le front:
```bash
apt install zabbix-frontend-php zabbix-apache-conf php7.4-pgsql
```
Copier le fichier de configuration de zabbix et le mettre dans le répertoire de configuration d'apache:
```bash
cp /etc/zabbix/apache.conf /etc/apache2/sites-available/
mv /etc/apache2/sites-available/000-default.conf /tmp
mv /etc/apache2/sites-available/default_ssl.conf /tmp
```

Editer les fichier suivant:
```bash
nano /etc/php/7.4/apache2/php.ini 
[Date] 
;Defines the default timezone used by the date functions 
;http://php.net/date.timezone 
date.timezone = Europe/Paris
```
Autre fichier de conf: Modifier les 2 valeurs !!!
```bash
nano /etc/zabbix/apache.conf 
php_value date.timezone Europe/Paris 
systemctl restart apache2
systemctl enable apache2
```


# 4) VM BACK

Installer les paquets pour le serveur zabbix
```bash
apt install zabbix-server-pgsql
```

Editer le fichier de configuration de zabbix server:
```bash
nano /etc/zabbix/zabbix_server.conf
DBPassword=zabbix
DBHost=@IP[BDD]
systemctl restart zabbix-server	
```

# 5) Configuration web

- Accès: @IP[front]/zabbix
- Vérification que tout est en vert
- Configuration de la BDD:
    Database host: @IP[BDD]
    Password: zabbix
- Configuration server:
     Host: @IP[ZABBIXSERVER]
     Name: Nom du zabbix ( like you want)
- Suivant
- ID de co: Admin/zabbix


