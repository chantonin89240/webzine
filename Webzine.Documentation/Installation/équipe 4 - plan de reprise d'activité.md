# Plan de Reprise d'Activité 

Pour les besoins du client, il est nécessaire d'établir un plan de reprise d'activité pour s'assurer du retour à la normale le plus rapidement possible en cas de problème.

Ces problèmes peuvent être d'ordre environnemental ou criminel, et nécessite un plan d'action pour s'en prémunir.

Pour se faire, des scénarios seront créés, les voici : 
## Scénarios 
### Pannes : 
1. [Panne du reverse proxy](#Panne-du-reverse-proxy)
2. [Panne de la base de données](#Panne-de-la-base-données)
### Cause environnemental :
3. [Incendie](#Incendie)
### Cause criminel :
4. [Rançongiciel](#Rançongiciel)

Mais d'abord, vous devez savoir comment est représenté le réseau :


## Que faire en cas de panne ? 

## **1. Panne du reverse proxy**

Le reverse proxy est un élément essentiel du réseau car c'est par lui que l'on passe pour pouvoir accéder à une interface web, que ce soit Zabbix, ELK ou Webzine.

Il est donc plus que nécessaire de réagir rapidement si celui-ci venait à tomber car son état défini l'accès aux interfaces.

- **En premier lieu, il faut effectuer des sauvegardes journalières**

Il sera important d'effectuer régulièrement une sauvegarde des fichiers de configuration du reverse proxy. Pour cela, la machine **srvbackup** sera nécessaire car c'est sur cette machine que la sauvegarde sera stockéé.

**Nous utiliserons un script qui sera lancé depuis la machine qui possède le reverse proxy vers le serveur de backup**. Ce script sera évidemment répliqué sur le serveur de backup pour que l'on puisse le retrouver même en cas de panne du reverse proxy.

&rarr; Sur la machine **frontnginx** (celle du reverse proxy) : le script se situe dans le répertoire `/root/savefrontend.sh`

&rarr; Sur la machine **srvbackup** : le script se situe dans le répertoire `/root/scripts/savefrontend.sh`

&rarr; Une copie du script est également placé sur l'ordinateur d'un ops et sur le cloud.

**Voici le script :**
```
#!/bin/bash

DAT=$(date "+%u")               #variable qui affichera le jour de la semaine : 1 = lundi, 2 = mardi ,etc.
tar -czvf /root/backup/save-nginx.$DAT.tar.gz /etc/nginx
rsync -r /root/backup/ root@[ @ip de la machine cible]:/root/backup/frontend
echo "Sauvegarde effectuee"
```
Ce script créé une sauvegarde compréssée du répertoire `/etc/nginx` et l'envoie dans le répertoire `/root/backup/frontend` de la machine **srvbackup**.

- **La machine frontnginx tombe en panne**

&rarr; Tout d'abord, il faudra récréé une machine virtuelle **possédant la même adresse IP et le même nom** que la machine frontnginx. 

&rarr; Puis il faudra installer le serveur web Nginx :
```
apt install nginx -y
```

&rarr; Ensuite, l'objectif sera d'injecter la sauvegarde sur la machine créée (à savoir la nouvelle machine frontnginx).

Pour se faire, on utilise la commande :
```
Commande à faire sur srvbackup :

rsync -r /root/backup/frontend root@[ @ip de la machine cible]:/etc/nginx
```
&rarr; Une fois la sauvegarde envoyée, rendez vous dans le répertoire `/etc/nginx` (sur la machine frontnginx) pour voir si elle est bien présente.

Si c'est le cas, faites la commande suivante :
```
tar -xvfz save-nginx.$DAT.tar.gz
```
&rarr; Vérifiez si la décompression a fonctionnée et rentrez la ligne suivante dans l'url de votre navigateur :[http://10.4.40.249](http://10.4.40.249).

**Si cette ligne url vous renvoi vers l'application Webzine, alors le reverse proxy est de nouveau opérationnel.**

## 2. **Panne de la base de données**

La base de données permet de stocker les données du serveur Zabbix. Si celle ci venait à tomber, la fonctionnalité du serveur serait alors compromise.

Il est donc très important d'avoir une base de donnée opérationnelle et disponible.

- **Mise en place d'un script pour sauvegarder la base de données**

Une base de données est constamment utilisé, notamment par Zabbix qui lui envoie les métriques de chaque serveur du réseau. C'est donc elle qui va stocker ces métriques. 

 La sauvegarder régulièrement est donc une priorité car elle se remplit un peu plus chaque jour.

**Nous utiliserons un script qui sera lancé depuis la machine bddsrv vers le serveur de backup**. Ce script sera évidemment répliqué sur le serveur de backup pour que l'on puisse le retrouver même en cas de panne de la base de donnée

&rarr; Sur la machine **bddsrv** : le script se situe dans le répertoire `/root/savepostgresql.sh`

&rarr; Sur la machine **srvbackup** : le script se situe dans le répertoire `/root/scripts/savepostgresql.sh`

&rarr; Une copie du script est également placé sur l'ordinateur d'un ops et sur le cloud.

**Voici le script :**
```
#!/bin/bash

DAT=$(date "+%u")               #variable qui affichera le jour de la semaine : 1 = lundi, 2 = mardi ,etc.
su postgres pg_dump zabbix > /tmp/zabbix.sql
tar -czvf /root/backup/save-zabbix.$DAT.sql.tar.gz /tmp/zabbix.sql
rsync -r /root/backup/ root@[@IP de la cible ]:/root/backup/postgresql
echo "Sauvegarde effectuee"
```
Ce script créé une sauvegarde compréssée de la base de données de la machine **bddsrv** sur le répertoire `/root/backup/postgresql` de la machine **srvbackup**.

- **Création d'un cluster pour la base de données.**

En prévision d'un problème sur la machine **bddsrv**, un cluster de celle-ci à été mis en place. 

Un cluster est une machine secondaire identique qui prendra automatiquement le relai si la machine principal vient à s'éteindre ou tomber en panne.

&rarr; Tout d'abord, les deux machines doivent posséder les mêmes caractéristiques.

&rarr; La base de données principal devra répliquer ses données sur la base de données du cluster de manière continue et en direct.

&rarr; L'utilisation de keepalived pour la haute-disponibilité sera nécessaire.

- **La machine bddsrv tombe en panne**

&rarr; La machine cluster prendra automatiquement le relai grâce à keepalived. Cependant la base de donnée secondaire ne permet pas l'écriture dans notre configuration. 

<span style="color:Red">**Il faudra donc être très réactif pour perdre le moins de données possible durant la remise en place de bddsrv**</span>.

&rarr; Il va falloir créer une machine ayant **la même configuration et la même adresse IP que bddsrv**.

&rarr; Ensuite, l'objectif sera d'injecter la sauvegarde sur la machine créée (à savoir la nouvelle machine frontnginx).

Pour se faire, on utilise la commande :
```
Commande à faire sur srvbackup :

rsync -r /root/backup/frontend root@[ @ip de la machine cible]:/root/backup
```
&rarr; Une fois la sauvegarde envoyée, rendez vous dans le répertoire `/root/backup`(sur la machine bddsrv) pour voir si elle est bien présente.

Si c'est le cas, faites la commande suivante :
```
tar -xvfz save-zabbix.$DAT.tar.gz

psql -U zabbix zabbix < nomdufichier.sql
```
Si la commande réussi, c'est que la base de données à été correctement envoyé.

&rarr; Il ne reste plus qu'à redemarrer la nouvelle machine **bddsrv** pour qu'elle reprenne sa place de base de données principale.
## Que faire en cas de problème environnemental ?
## **3. Incendie** 

Même si l'on peut essayer de se prémunir au mieux contre un incendie, le risque zéro n'existe pas et nous ne sommes pas à l'abri d'un tel incident.

Un serveur de sauvegarde situé physiquement à un autre endroit est donc de mise pour ce genre de problème.

- **Utilisation d'un serveur de backup (srvbackup) situé en dehors de la zone de travail**

Le serveur **srvbackup** sera situé dans une zone différente du batiment pour garantir la conservation des sauvegardes et ainsi pouvoir les réinjecter en cas d'incendie.

&rarr; Toutes les sauvegardes des serveurs du réseau sont situés dans le répertoire `/root/backup`. Elles sont effectués de façon journalière pour permettre une meilleure intégrité des données.

- **Un incendie s'est déclaré** 

&rarr; Le premier objectif sera de **recréer les machines avec les installations de base de chaque machine**.

&rarr; Il faudra ensuite réinjecter les sauvegardes sur chaques machines.

On utilisera la commande suivante : 
```
rsync -r /root/backup/[fichier de sauvegarde] root@[ @ip de la machine cible]:[/répertoire cible]
```
&rarr; Une fois la sauvegarde envoyée, rendez vous dans le répertoire `[/répertoire cible`] (sur chaque machine que l'on recréée) pour voir si elle est bien présente.

Si c'est le cas, faites la commande suivante :
```
tar -xvfz [nom du fichier de sauvegarde]
```

&rarr; Vérifier une par une les machines et si leurs services sont fonctionnelles. 

Grâce aux sauvegardes, les données sont de nouveaux présentes et le réseau pourra de nouveau être opérationnel.

## Que faire en cas de problème criminel  ?
## **4. Rançongiciel**

Un rançongiciel est une attaque malveillante dont le but est de vous soutirer de l'argent en échange de la récupération de vos données.

En plus d'une demande d'une grosse somme d'argent, il se peut que l'attaquant ne vous rende pas vos données malgré le fait d'avoir payé la rançon.

Si ce genre de situation arrivait, il serait nécessaire d'avoir des sauvegardes des données importantes pour pouvoir les récupérer rapidement et sans payer la rançon demandée par les attaquants.

- **Mise en place de scripts pour sauvegarder les données importantes**

&rarr; Chaque machine disposera d'un script permettant la sauvegarde des fichier les plus importants et des données sensible (notamment la base de données) 

&rarr; Ces sauvegardes seront envoyées sur **srvbackup** dans le répertoire `/root/backup`.

- **Recréer le réseau et réinjecter les données**

&rarr; Comme nous avons les **sauvegardes de toute les machines de notre réseau**, <span style="color:Red">**il faudra refuser de payer la rançon et recréer le réseau avec nos sauvegardes**</span>.

&rarr; Tout d'abord, il faudra **recréer les machines avec les installations de base de chaque machine**.

&rarr; Ensuite, nous devrons réinjecter les sauvegardes sur chaques machines.

On utilisera la commande suivante : 
```
rsync -r /root/backup/[fichier de sauvegarde] root@[ @ip de la machine cible]:[/répertoire cible]
```
&rarr; Une fois la sauvegarde envoyée, rendez vous dans le répertoire `[/répertoire cible`] (sur chaque machine que l'on recréée) pour voir si elle est bien présente.

Si c'est le cas, faites la commande suivante :
```
tar -xvfz [nom du fichier de sauvegarde]
```
**Pour la base de données (bddsrv)**, il y a une commande supplémentaire :
```
psql -U zabbix zabbix < nomdufichier.sql
```
&rarr; Vérifier une par une les machines et si leurs services sont fonctionnelles. 

Grâce aux sauvegardes, les données sont de nouveaux présentes et le réseau pourra de nouveau être opérationnel.