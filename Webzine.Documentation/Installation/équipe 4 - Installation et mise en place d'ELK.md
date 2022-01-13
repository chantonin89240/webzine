# Installation et mise en place d'ELK
### Table des matières 
1. Installation d'ELK
2. Installation de l'agent FileBeat 

## Téléchargement et installation d'ELK 
Tout d'abord, il est nécessaire d'installer Docker : 
```
apt install docker -y
```
Ensuite, il faudra installer docker-compose :
```
apt install docker-compose -y
```
Docker étant installé, vous pouvez télécherger le repository suivant :
```http
https://github.com/deviantony/docker-elk
```
Une fois celui-ci télécharger, rendez vous dans le dossier racine du repository.
Lancez la commande : 
```
docker-compose up -d
```
Vous pouvez maintenant vous connecter sur l'interface de gestion :
```http
http://localhost:5601
```
Les identifiants pour se connecter sont :
```yml
user: elastic
password: changeme
```

## Installation de l'agent FileBeat

Vous pouvez maintenant télécharger l'agent FileBeat qui pourra communiquer directement avec ELK.

Lien pour filebeat :
```bash
curl -L -O https://artifacts.elastic.co/downloads/beats/filebeat/filebeat-7.16.2-amd64.deb
dpkg -i filebeat-7.16.2-amd64.deb
```
Au démarrage de la machine, activez l'agent avec la commande :
```bash
systemctl enable filebeat.service
```
Une fois l'agent activé, vous pouvez le paramétrer en vous rendant dans le fichier de configuration :
```bash
nano /etc/filebeat/filebeat.yml
```
Dans la section `setup.kibana`, décommentez et ajoutez l'adresse IP de votre server ELK :
```yml
#host: "localhost:5601"  (Ancienne valeur)
host: "192.168.20.2:5601"
```
A la section : `output.elasticsearch:` :  
```yml 
#hosts: ["localhost:9200"] (Ancienne valeur)
hosts: ["192.168.20.2:9200"]
username: "elastic"
password: "changeme"
```
Une fois le fichier correctement configuré, vous pouvez lister tous les modules proposés par l'agent : 
```bash
filebeat modules list
```
Activez le module dédié à Nginx :
```bash
filebeat modules enable nginx
```
Editez ensuite le fichier :
```bash
nano /etc/filebeat/modules.d/apache.yml
```
Décommenter pour la partie `access` et `error` et ajoutez :
```yml
# Access logs
#var.paths:(Ancienne valeur)
var.paths: ["/var/log/apache2/access*.log*"]
# Error logs
#var.paths: (Ancienne valeur)
var.paths: ["/var/log/apache2/error*.log*"]
```
Vous pouvez maintenant tester votre configuration : 
```bash
filebeat test config
```
Il faudra maintenant redémarrer l'agent pour qu'il prenne en compte la configuration :
```
systemctl restart filebeat.service
```
Pour créer une structure de filtres, d'indexation et de dashboard automatiquement par l'agent lui-même :
```bash
filebeat setup -e
```