#!/bin/bash

DAT=$(date "+%u")               #variable qui affichera le jour de la semaine : 1 = lundi, 2 = mardi ,etc.
tar -czvf /root/backup/save-apache.$DAT.tar.gz /etc/apache2
rsync -r /root/backup/ root@192.168.20.3:/root/backup/apache
echo "Sauvegarde effectuee"
