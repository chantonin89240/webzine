# Récap ressource infra et mdp 

1. [Récapitulatif des ressources ](#Récapitulatif-des-ressources)
2. [Mot de passe](#Mot-de-passe)

## Récapitulatif des ressources 

Voici les ressources que nous avions à disposition pour ce projet :

- **Serveur physique** :

&rarr; **OS** : Windows Server 2019.

&rarr; **RAM** : 16Go de Ram.

&rarr; **vCPU assigné** : Intel(R) Core(TM) i5-6400 CPU @ 2.70GHz, 2701 MHz, 4 coeurs, 4 processeurs logiques.

&rarr; **Disque dur** : Disque HDD 1 To.

&rarr; **Carte réseau** : 1 carte réseau.

- **Hyper-v : 9 machines virtuelles**

&rarr; **Frontnginx** : 4 cartes réseaux, 1024Mo de RAM.

&rarr; **Frontapache** : 1 carte réseau, 1024Mo de RAM.

&rarr; **Srvzabbix** : 1 carte réseau, 512Mo de RAM.

&rarr; **Bddsrv** : 2 cartes réseaux, 512Mo de RAM.

&rarr; **Cluster apache** : 1 carte réseau, 1024Mo de RAM.

&rarr; **Cluster bddsrv** : 2 cartes réseaux, 512Mo de RAM.

&rarr; **ELK** : 1 carte réseau, 3072Mo de RAM.

&rarr; **Backupsrv** : 1 carte réseau, 512Mo de RAM.

&rarr; **Webzine** : 2 cartes réseaux, 2048Mo de RAM.

## Mot de passe : 

Pour les machines virtuelles, nous avons décidés d'utiliser un générateur de mot de passe complexe.

**Nom du générateur : apg**

Pour générer un mot de passe, il suffit de lancer la commande :
```
apg -m 8

HaggEtye
smakVevAr
coydEcmy
OmoabItNa
Pracnokpey
sulRytlus7
```

Voici un assortiment de mot de passe fort généré par **apg**.

- Mot de passe machine :

&rarr; **frontnginx** : yuc9ocix5

&rarr; **Frontapache** : crivogIn

&rarr; **Srvzabbix** : shtafKag

&rarr; **Bddsrv** : vadaynIm

&rarr; **Cluster apache** : noDreinro

&rarr; **Cluster bddsrv** : Konn5droot

&rarr; **ELK** : CoptItna

&rarr; **Backupsrv** : JotdeHybna

&rarr; **Webzine** :PhansIk8

- Mot de passe Zabbix :

&rarr; Pour l'utilisateur Zabbix : /@bl3ix

&rarr; Pour l'utilisateur diiage_T : l3il3i><