#!/bin/bash

DAT=$(date "+%u")               #variable qui affichera le jour de la semaine : 1 = lundi, 2 = mardi ,etc.
tar -czvf /root/backup/save-nginx.$DAT.tar.gz /etc/nginx
rsync -r /root/backup/ root@192.168.20.3:/root/backup/frontend
echo "Sauvegarde effectuee"
