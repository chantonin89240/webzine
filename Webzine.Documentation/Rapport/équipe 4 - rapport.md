# Webzine
1. [Table des matières](#introduction)
2. [Introduction](#paragraph1)
3. [Organisation](#paragraph2)
4. [Jalon 1 :](#paragraph3)
	1. [Travail à réaliser](#subparagraph1)
	2. [Problèmes rencontrés](#subparagraph2)
	3. [Conclusion](#subparagraph3)
5. [Jalon 2 :](#paragraph4)
	1. [Travail à réaliser](#subparagraph4)
	2. [Problèmes rencontrés](#subparagraph5)
	3. [Conclusion](#subparagraph6)
6. [Jalon 3 :](#paragraph5)
	1. [Travail à réaliser](#subparagraph7)	
	2. [Problèmes rencontrés](#subparagraph8)	
	3. [Conclusion](#subparagraph9)
7. [Annexes](#paragraph6)


## Introduction 

Le projet est la création d'un site Webzine.
Le site webzine est magazine web entièrement dédié à la musique. Les visiteurs pourront lire des chroniques de leurs titres préférés.

Ce webzine est également interactif ; les visiteurs pourront donner leur avis sur chaque titre. Il y a aussi une partie administration avec la possibilité d'ajouter des titres, des artistes, des styles, et de les éditer ou de les supprimer. 

Une page contact est aussi présente pour avoir les informations nécessaires pour nous contacter en cas de besoins.
Ce projet est à réaliser en 4 semaines et est divisé en 3 jalons à remettre à une date précise.
## Organisation
Nous sommes le groupe 4, une équipe de 6 :

- 	4 développeurs : Vincent Simonin, Antonin Chataigner, Lucas Alves et Jean-Christophe Pouzin

- 	2 réseaux : Teddy Vitard et Axel Maucolot.
Les développeurs devront s'occuper de toute la partie wep application et les réseaux de l'infrastructure réseau qui accueillera l'application.
## Jalon 1 :
### Travail à réaliser
Le rendu attendu pour le jalon 1 :
&#8594; Est le squelette du webzine entièrement conçu.
&#8594; Les entités sont pleinement développées.
&#8594; L’IHM doit être terminé.
&#8594; Les contrôleurs basiques faisant appel à des données créés.
&#8594; Les données doivent être envoyé par des classes de type factory, les données sont en dur.
&#8594; La documentation doit être commencée.
&#8594; Date limite : le 20/12/2021
### Problèmes rencontrés
- 	Pour le jalon nous n'avons pas vraiment rencontré de problèmes techniques particuliers.
- 	L'une des difficultés a été la mise en place et le respect du design pour les développeurs.
- 	Il y a juste eu un petit temps d'adaptation pour certains pour les Factory et la compréhension des Areas.
- 	Nous n'avons pas eu de retard particulier pour ce projet, juste quelques petits détails n'ont pas été mis en place comme vu ci-dessus (cf. : #Jalons/Jalon1).
- 	Pour les réseaux la mise en place du reverse proxy a été un peu du car les tutoriels qu'ils trouvaient sur le sujet se faisaient avec un DNS, mais nous n'en avons pas dans notre projet. Ils ont donc dû faire une redirection des ports.
- 	Le réseau ayant aussi été validé tardivement tout l'adressage IP a dû être modifier ce qui a créé des conflits sur Zabbix qui ont dû être fixés. Cela s'en est résulté d'un léger retard.
- 	Certains membres du groupe ont aussi trouvé que le temps accordé pour le projet était un peu court pour tout ce que l'on avait à faire (nouvelles informations, les cours, les rendus, …).
### Conclusion
Pour le rendu du jalon nous avons été à l'heure. Juste quelques petits détails n'étaient pas faits :
- 	La documentation n'avait pas été commencé,
- 	Les styles dans les titres de la page d'accueil n'étaient pas affichés,
- 	Du css inline, responsive pas mis partout, format de données, code non commenté...
## Jalon 2 :
### Travail à réaliser
Le rendu attendu pour le jalon 2 :

&#8594; Il doit être possible d’utiliser les données fictives « local » ou bien celles de la base de données au travers les repositories.

&#8594; Il est possible de seeder la base de données avec les données fictives « local ».

&#8594; Les données sont persistées en base de données et sont accessibles au travers de repositories.

&#8594; Les vues HTML sont remplacées par du code dynamique. Toutes les opérations de lecture en base de données sont réalisées, également les opérations de suppression (exemple : supprimer un titre).

&#8594; Les contrôleurs font usage des repositories (au lieu des « simplesfactories » du jalon 1).

&#8594; La documentation doit être poursuivie.

&#8594; Date limite : le 08/01/2022.

### Problèmes rencontrés
- 	Pour ce jalon la difficulté a été la mise en place de la base de données et des repositories au sein du projet.
- 	Il y eu la création de l'image de l'application par docker et son déploiement. Lors du déploiement, nous avons remarqués que tous les styles (css, bootstrap) liés à notre partie administration ne s'affichaient plus.

- 	Ce problème venait du lien du script dans le layout de notre administration, il a été réglé le lendemain et est maintenant fonctionnel.
- 	Les Ops n'ont pas eu de réel problème sur ce jalon, juste une différence entre les jalons du cahier des charges et celui des clauses techniques sur le traitement du firewalling qui pourrait les retarder.
- 	Ils ont aussi soulevé un manque de cours sur certaines notions qui les ralenties sur certains points, pour cela ils se sont beaucoup entraidés entre Ops et fait beaucoup de recherches documentaires.
- 	Les machines non rattachées directement au réseau Zabbix (192.168.10.0) ne pouvaient être supervisées. il a fallu renseigner la passerelle la plus proche des machines dans le fichier de configuration zabbix_agent pour permettre la supervision.
- 	Jalon 2 les Ops était dans les temps
- 	Comme lors du jalon précédent au niveau timing qui semble un peu court par rapport à la demande.
### Conclusion
Pour le rendu du jalon 2 nous avons été à l'heure. Il y a eu un peu de reste à faire et des questions au client à poser sur certains points :
- 	Responsive image, style page d'accueil

- 	Revoir jaquette des derniers titres synchro
- 	Faire pagination (changer l'icône par un chevron)
- 	Lien du titre et lien artiste non-fonctionnel
- 	Affichage des commentaires page titre (include commentaire)
- 	Page d'un artiste date de naissance et site web à ajouter
- 	Ajouter l'artiste aux titres dans la recherche et dans style
- 	Styles par ordre alphabétique et mettre le tous en premier
- 	Biographie obligatoire pour l'artiste
- 	Artiste limite de caractères dans le nom à enlever
- 	Création et modification de titre voir pour cocher le tous dans les styles et le bloquer pas de style tous
- 	Espace entre le bouton supprimer et le lien de retour
- 	Dimension input text dans les styles
- 	Pour le commentaire couper le commentaire ou le mettre en entier
- 	Ajouter l'artiste à côté du titre dans commentaires
- 	Modifier texte dans supprimer commentaire
- 	modelState
- 	Choix du seeder
- 	Choix du repository
- 	Les logs
- 	Favicon imposer ou lui en proposer 3 (demander au client )
- 	Demander s’il n'y a que la sidebar dans les viewcomponent
- 	Requêtes linq fonctionnelles sur Sqlite, SqlServer
- 	Revoir la documentation
## Jalon 3 :
### Travail à réaliser
Le rendu attendu pour le jalon 2 :

&#8594; Est attendu le projet final complet. Les dernières fonctionnalités manquantes sont réalisées.

&#8594; Les fonctionnalités « incrémenter le nombre de likes », « incrémenter le nombre de lectures » sont réalisées. 

&#8594; Toutes les opérations d’écriture (ajout, édition) en base de données sont réalisées.

&#8594; Les routes attendues sont respectées. L’application est testée et fonctionne dans des environnements différents (dev ou prod), avec SQLite, avec SQLServer ou PostgreSQL, avec les logs applicatifs adéquats,

&#8594; L’équipe termine la documentation complète du projet.

### Problèmes rencontrés
- 	Pour le CI/CD le CI a fonctionné mais le CD a eu des erreurs que nous n'avons pas pu résoudre. Nous avons demandé à Mr Hyacinthe Briand mais il n'a pas trouvé de problème apparent et nous a conseillé d'essayer notre application en local en récupérant l'image générer dans votre registre.

- 	Pour le seeder de l'api deezer nous avons eu des problèmes sur les clés étrangères non respectées. On a mis du temps à le faire (à pratiqument une journée).
- 	Sur ce jalon comme sur les derniers le temps nous a manqué pour approfondir certains points
- 	Pour chef de projet répartition du travail a été compliqué pour les dernières tâches à faire et se faire entendre pour que chacun fasse la tâche qui lui était demandé a été un peu dur à la fin
- 	Le distanciel n'a pas été un frein
- 	Pour les Ops le manque de ressources (Ram) a été un vrai frein et il n'a pas été possible d'y remédier
- 	ELK rame ce qui nous a obliger à forcer les agents filebeat mais cela n'a fonctionné qu'une journée. Pour l'instant on a éteint les machines et rallumé mais cela bug encore.
- 	La migration est un échec à cause d'un abonnement limité (le quota n'était pas assez important), cela n'a pas été fait,
- 	Pour la création des metrics zabbix, les cours n’étaient pas suffisants, des essais ont été fait certains ont fonctionné, mais vue le nombre de metrics à paramétrer seulement certaines ont pu être réalisées. Donc on a pris les deux ports de transports UDP/TCP après avoir reparamétré le firewall en mettant en place le firewalling il y a eu des problèmes avec le serveur zabbix.
- 	Pas de difficulté sur le PRA choix des scénarios évident créé efficacement

### Conclusion 
Le rendu du jalon 3 sera remis dans les temps. Il reste tout de même certains points qui n'ont pas été réalisés :

- Le CI/CD comme vu ci-dessus ne pourra pas être livré, le CD ne marche pas.

- Certaines metrics zabbix n'ont pas été faites,
- La migration n'a pas été faite
- ELK ne pourra pas non plus être rendu complètement 

## Annexes
