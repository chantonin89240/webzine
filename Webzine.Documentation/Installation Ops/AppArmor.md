# Installation

`apt install apparmor-ultis -y`

Listez l’ensemble des processus qui pourraient recevoir un renforcement sur votre machine (qui ont un port d’écoute ouvert) : `aa-unconfied`

Création du répertoire `mkdir /var/lib/snapd/apparmor/snap-confine` pour utiliser la command `aa-autodep <nom_du_service>`

Pour l'instant tout est autoriser.
* * *
## Service Sshd :

```bash
aa-autodep sshd
```

Emplacement du profile : `/etc/apparmor.d/usr.sbin.sshd`

Il existe de type de mode **enforce** et **complain**

- Enforce : Le système applique les règles et signale toute violation dans le syslog. La poursuite de l’opération ne sera pas autorisée.
- Complain : Le système ne fait pas respecter les règles, mais enregistre seulement les violations.

Changement du mode du profil sécurisé de `uncofined` à `complain`.
```bash
aa-complain usr.sbin.sshd
```
Redémarage du service sshd
[Man aa-logprof](https://manpages.debian.org/stretch/apparmor-utils/aa-logprof.8.en.html)
```bash
aa-logprof
```
* * *
## Service Nginx :

```bash
aa-autodep nginx
```

Emplacement du profile : `/etc/apparmor.d/usr.sbin.nginx`

Changement du mode du profil sécurisé de `uncofined` à `complain`.
```bash
aa-complain usr.sbin.ngnix
```
Redémarage du service ngnix
```bash
aa-logprof
```
* * *
## Service Apache2 :

```bash
aa-autodep apache2
```

Emplacement du profile : `/etc/apparmor.d/usr.sbin.apache2`

Changement du mode du profil sécurisé de `uncofined` à `complain`.
```bash
aa-complain usr.sbin.apache2
```
Redémarage du service apache2
```bash
aa-logprof
```
* * *
## Service Zabbix_agentd :

```bash
aa-autodep zabbix_agentd
```

Emplacement du profile : `/etc/apparmor.d/usr.sbin.zabbix_agentd`

Changement du mode du profil sécurisé de `uncofined` à `complain`.
```bash
aa-complain usr.sbin.zabbix_agentd
```
Redémarage du service zabbix_agentd
```bash
aa-logprof
```
* * *
## Service Zabbix_server :

```bash
aa-autodep zabbix_server
```

Emplacement du profile : `/etc/apparmor.d/usr.sbin.zabbix_server`

Changement du mode du profil sécurisé de `uncofined` à `complain`.
```bash
aa-complain usr.sbin.zabbix_server
```
Redémarage du service zabbix_server
```bash
aa-logprof
```
* * *
## Service Postgres:

```bash
aa-autodep /usr/lib/postgresql/13/bin/postgres
```

Emplacement du profile : `/etc/apparmor.d/usr.sbin.postgres`

Changement du mode du profil sécurisé de `uncofined` à `complain`.
```bash
aa-complain usr.lib.postgresql.13.bin.postgres
```
Redémarage du service postgres
```bash
aa-logprof
```
* * *