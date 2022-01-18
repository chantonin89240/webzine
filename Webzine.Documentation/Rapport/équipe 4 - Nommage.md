# Webzine: Noms des Tables et leurs variables


## Titres:
|variable       |description|
|--------       |-----------|
|IdTitre        |Num&eacute;ro Identifiant du Titre|
|IdArtiste      |Num&eacute;ro identifiant de l'Artiste ayant cr&eacute;&eacute; le Titre
|Chronique      |Chronique Magazine attach&eacute;e au Titre
|Libelle        | Nom du Titre
|Duree          | Duration du Titre en secondes
|DateSortie     | Date de sortie du Titre
|DateCreation   | Date de cr&eacute;ation de la chronique du titre
|NbLectures     |Nombre de vues accumul&eacute;es par la page web du titre
|NbLikes        | Nombre de Likes accumul&eacute;es par la page Web du titre
|UrlJaquette    |Lien sur une image de la jaquette de l'album du Titre
|UrlEcoute      |Lien sur un m&eacute;dia video permettant d'&eacute;couter le Titre
|Artiste        |(__C#__) Entit&eacute; Artiste Attach&eacute;e au Titre
|Commentaires   | (__C#__) Entit&eacute;s Commentaire rattach&eacute;s au Titre
---
## Styles:
|variable   |description|
|--------   |-----------|
|IdStyle    |Num&eacute;ro identifiant du style.
|Libelle    |Libell&eacute; du style (ex: Rock).
|TitresStyle| (__C#__) Liste des liens entre les Titres et les Styles
---
## TitreStyles:
Correspond &agrave; un lien entre un Titre et un Style dans la base de donn&eacute;es.
|variable   |description|
|--------   |-----------|
|IdStyle    |Num&eacute;ro identifiant du Style de la relation
|IdTitre    |Num&eacute;ro identifiant du Titre de la relation
|Style      |(__C#__) Style de la relation
|Titre      |(__C#__) Titre de la relation
---
## Artistes:
|variable   |description|
|--------   |-----------|
|IdArtiste  |Num&eacute;ro identifiant de l'Artiste.
|Nom        |Nom de l'Artiste.
|Biographie |Biographie de l'Artiste.
|Titres     |(__C#__) Liste des Titres de l'artiste.
---
## Commentaires:
|variable       |description
|--------       |-----------
|IdCommentaire  | Identifiant du commmentaire
|Auteur         | Nom de l'utilisateur ayant cr&eacute;&eacute; le commentaire
|Contenu        | Contenu du commentaire
|IdTitre        | Identifiant du Titre auquel le commentaire est li&eacute;
|Titre          | (__C#__) Titre li&eacute; au commentaire
