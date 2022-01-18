# AppArmor
## Installation

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

Contenu du profil :
```bash
# Last Modified: Tue Jan  4 12:40:52 2022
#include <tunables/global>

/usr/sbin/sshd flags=(complain) {
  #include <abstractions/authentication>
  #include <abstractions/base>
  #include <abstractions/consoles>
  #include <abstractions/dovecot-common>
  #include <abstractions/nameservice>
  #include <abstractions/openssl>
  #include <abstractions/wutmp>

  capability audit_write,
  capability sys_resource,

  /usr/sbin/sshd mrix,
  owner /etc/ssh/ssh_host_ecdsa_key r,
  owner /etc/ssh/ssh_host_ecdsa_key.pub r,
  owner /etc/ssh/ssh_host_ed25519_key r,
  owner /etc/ssh/ssh_host_ed25519_key.pub r,
  owner /etc/ssh/ssh_host_rsa_key r,
  owner /etc/ssh/ssh_host_rsa_key.pub r,
  owner /etc/ssh/sshd_config r,
  owner /etc/ssh/sshd_config.d/ r,
  owner /proc/*/fd/ r,
  owner /proc/*/oom_score_adj w,
  owner /proc/*/uid_map r,
  owner /proc/sys/kernel/ngroups_max r,

}
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
Contenu du profil :
```bash
# Last Modified Tue Jan  4 124702 2022
#include <tunables/global>

/usr/sbin/nginx flags=(complain) {
  #include <abstractions/base>
  #include <abstractions/dovecot-common>
  #include <abstractions/nameservice>
  #include <abstractions/openssl>
  #include <abstractions/web-data>

  capability dac_override,

  /usr/sbin/nginx mr,
  /usr/share/nginx/html/index.html r,
  /var/log/nginx/access.log w,
  /var/log/nginx/error.log w,
  owner /etc/nginx/conf.d/ r,
  owner /etc/nginx/mime.types r,
.
.
.
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
Contenu du profil :
```bash
# Last Modified: Tue Jan  4 13:02:12 2022
#include <tunables/global>

/usr/sbin/apache2 flags=(complain) {
  #include <abstractions/base>
  #include <abstractions/nameservice>
  #include <abstractions/php>

  /etc/gss/mech.d/ r,
  /usr/bin/wc mrix,
  /usr/sbin/apache2 mr,
.
.
.
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
Contenu du profil :
```bash
# Last Modified: Tue Jan  4 13:02:30 2022
#include <tunables/global>

/usr/sbin/zabbix_agentd flags=(complain) {
  #include <abstractions/base>
  #include <abstractions/nameservice>
  #include <abstractions/openssl>

  /dev/ r,
  /etc/zabbix/zabbix_agentd.conf r,
  /etc/zabbix/zabbix_agentd.d/ r,
  /proc/ r,
  /proc/*/cmdline r,
  /proc/*/net/dev r,
  /proc/loadavg r,
.
.
.
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
Contenu du profil :
```bash
# Last Modified: Fri Jan  7 09:54:27 2022
#include <tunables/global>

/usr/sbin/zabbix_server flags=(complain) {
  #include <abstractions/base>
  #include <abstractions/dovecot-common>
  #include <abstractions/nameservice>
  #include <abstractions/openssl>
  #include <abstractions/postfix-common>

  /etc/gss/mech.d/ r,
  /usr/sbin/zabbix_server mr,
  owner /etc/zabbix/zabbix_server.conf r,
  owner /run/zabbix/zabbix_server.pid wk,
  owner /var/log/zabbix/zabbix_server.log rw,

}
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
Contenu du profil :
```bash
# Last Modified: Tue Jan  4 13:17:21 2022
#include <tunables/global>

/usr/lib/postgresql/13/bin/postgres flags=(complain) {
  #include <abstractions/base>
  #include <abstractions/nameservice>
  #include <abstractions/openssl>
  #include <abstractions/ssl_certs>
  #include <abstractions/ssl_keys>

  /usr/lib/postgresql/13/bin/postgres mr,
  /usr/share/postgresql/13/timezonesets/Default r,
  owner /dev/shm/PostgreSQL.417983887 rw,
  owner /etc/postgresql/13/main/conf.d/ r,
  owner /etc/postgresql/13/main/pg_hba.conf r,
  owner /etc/postgresql/13/main/pg_ident.conf r,
  owner /etc/postgresql/13/main/postgresql.conf r,
  owner /proc/*/oom_score_adj w,
  .
  .
  .
```