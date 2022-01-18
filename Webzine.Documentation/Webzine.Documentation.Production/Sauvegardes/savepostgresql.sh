#!/bin/bash

DAT=$(date "+%u")               #variable qui affichera le jour de la semaine : 1 = lundi, 2 = mardi ,etc.
su postgres pg_dump zabbix > /tmp/zabbix.sql
tar -czvf /root/backup/save-zabbix.$DAT.sql.tar.gz /tmp/zabbix.sql
rsync -r /root/backup/ root@192.168.20.3:/root/backup/postgresql
echo "Sauvegarde effectuee"
