# **Serveur FrontEnd NGINX**

## **I - Objectif**

Mise en place d'un serveur frontend web en utilisant le service nginx et en configurant des redirections.

---

## **II - Installation NGINX**

Mettre à jour aptitude :

`sudo apt update`

Télécharger et installer le packet nginx version 1.18 :

`sudo apt install nginx`

Vérification de la version :

`nginx -v`

---

## **III - Premier paramétrage de NGINX**

### a) Fixer l'erreur « Failed to read PID from file »

```bash
nginx.service: Failed to read PID from file /run/nginx.pid: Invalid argument
```

Création un répertoire *nginx.service.d* dans */etc/systemd/system/* :

`mkdir /etc/systemd/system/nginx.service.d`

Envoyer les données dans le *nginx.service.d*

`printf "[Service]\nExecStartPost=/bin/sleep 0.1\n" > /etc/systemd/system/nginx.service.d/override.conf`

Redémarer le démon puis NGINX

`systemctl daemon-reload && systemctl restart nginx`

---

## **IV - Mise en place du reverse proxy**

>Méthodologie basé sur l'article de IT-Connect écrit par **Mickael Dorigny** [*Configurer NGINX en tant que reverse proxy*](<https://www.it-connect.fr/configurer-nginx-en-tant-que-reverse-proxy/>).

Dans  /etc/nginx/sites-avaibles création des servers blocks *zabbix*, *elk* et *webzine* qui ont utiliserons le port forwarding.

Exemple de fichier :
```nginx
upstream nom_du_serveur_visé {
    server IP_serveur:Port_serveur;
}

server {
    listen Port_écouté;
    location / {
        proxy_pass http://nom_du_upstream;
        proxy_set_header    Host $host;

        proxy_connect_timeout 30;
        proxy_send_timeout 30;
    }
}
```

Pour finir il faut vérifier le fonctionnement du fichier de conf avec `nginx -t` puis, s'il n'y a pas d'erreurs relancer le service avec `systemctl reload nginx`.
