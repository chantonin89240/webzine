#!/bin/bash

DAT=$(date "+%u")               #variable qui affichera le jour de la semaine : 1 = lundi, 2 = mardi ,etc.
tar -czvf /root/backup/save-webzine.$DAT.tar.gz /var/lib/docker/volumes
rsync -r /root/backup/ root@192.168.20.3:/root/backup/webzine
echo "Sauvegarde effectuee"
