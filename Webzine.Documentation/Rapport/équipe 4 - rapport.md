# Webzine
    

## Introduction


Le projet est la création d'un site Webzine. 
Le projet est la création d'un site Webzine. 

Le site webzine est magazine web entièrement dédié à la musique. Les visiteurs pourront lire des chroniques de leurs titres  préférés.  
Ce  webzine  est  également  interactif;  les  visiteurs  pourront  donner  leur  avis  sur chaque titre.
Il y a aussi une partie administration avec la possibilité d'ajouter des titres, 
des artistes, des styles, et de les éditer ou de les supprimer.
Une page contact est aussi présente pour avoir les informations nécessaires pour nous contacter en cas de besoins.

Ce projet est à réaliser en 4 semaines et est divisé en 3 jalons à remettre à une date précise.



## Organisation

Nous sommes le groupe 4, une équipe de 6 : 
- 4 développeurs : Vincent Simonin, Antonin Chataigner, Lucas Alves et Jean-Christophe Pouzin
- 2 réseaux : Teddy Vitard et Axel Maucolot.

Les développeurs devront s'occuper de toute la partie wep application et les réseaux de l'infrastructure réseau qui accueillera l'application.


## Jalons

Jalon 1 : 

			Le rendu attendu pour le jalon 1 :

			- Est le squelette du webzine entièrement conçu.

			- Les entités sont pleinement développées. 

			- L’IHM doit être terminé.

			- Les contrôleurs basiques faisant appel à des données créés. 

			- Les données doivent être envoyé par des classes de type factory, les données sont en dur.
		
			- La documentation doit être commencée.

			- Date limite: le 20/12/2021

			Pour le rendu du jalon nous avons été à l'heure. Juste quel que petit détails n'étaient pas faits :

			- la documentation n'avait pas été commencé,

			- les styles dans les titres de la page d'accueil n'étaient pas affichés,

			- du css inline, responsive pas mis partout, format de données, code non commenté...

Jalon 2 : 

			Le rendu attendu pour le jalon 2 :
				
				- Il doit être possible d’utiliser les données fictives «local» ou bien celles de la base de données au travers les repositories.

				- Il est possible de seeder la base de données avec les données fictives «local». 
				
				- Les données sont persistées en base de données et sont accessibles au travers de repositories.
				
				- Les vues HTML sont remplacées par du code dynamique.Toutes les opérations de lecture en base de données sont réalisées, 
				  également les opérations de suppression (exemple: supprimer un titre).
				  
				- Les contrôleurs font usage des repositories (au lieu des«simplesfactories»du jalon 1).
				
				- La documentation doit être poursuivie.
				
				- Date limite: le 08/01/2022.

## Problèmes rencontrés

Jalon 1 : 
			
			Pour le jalon nous n'avons pas vraiment rencontré de problèmes techniques particuliés.
			L'une des difficultés a été la mise en place et le respect du design pour les développeurs.
			Il y a juste eu un petit temps d'adaptation pour certains pour les Factory et la compréhension des Areas.
			Nous n'avons pas eu de retard particulier pour ce projet, juste quelques petits détails n'ont pas été mis en place comme vu ci-dessus(cf : #Jalons/Jalon1).

Jalon 2 :

			Pour ce jalon la difficulté a été la mise en place de la base de données et des repositories au sein du projet.
			Il y eu la création de l'image de l'application par docker et sont déploiement. lors du déploiement, 
			nous avons remarqués que tous les styles (css, bootstrap) liés à notre partie administration ne s'affichaient plus.   

## Conclusion 

## Annexes 