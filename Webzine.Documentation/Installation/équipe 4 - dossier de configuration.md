# Dossier de configuration




## Table des matières
1. [Introduction](#introduction)
2. [Présentation du fichier de configuration](#paragraph1)
    1. [Fichier appsettings.json](#subparagraph1)
3. [Liste des paramètres](#subparagraph2)
    1. [Partie Configuration](#config)
       1. [DataRepository](#DataRepository)
       2. [SGBD](#SGBD)
       3. [HomePageDisplay](#HomePageDisplay)
       4. [ResetDb](#ResetDb)
       5. [ResetDb](#ResetDb)
       6. [KeywordSearchApiDeezer](#KeywordSearchApiDeezer)
       7. [ModerationWordList](#ModerationWordList)
     1. [Partie ConnectionStrings](#connectDB)
     2. [Partie Logging](#log)


## <span style="color:purple">1. Introduction <a name="introduction"></a>

Ce dossier est dédié à la configuration de l'application par l'utilisation du fichier appsettings.json. Vous pouvez y retrouver la liste des paramètres de configuration ainsi que leurs différentes valeurs possibles. Pour chaque paramètre, un paragraphe est dédié afin que vous preniez connaissance du comportement de l'application en fonction de la configuration que vous aurez choisie.

## <span style="color:purple">2. Présentation du fichier de configuration <a name="paragraph1"></a>

### <span style="color:purple"> 2.1 Fichier appsettings.json <a name="subparagraph1"></a>

Veuillez trouver le fichier de configuration nommé appsettings.json dans le répertoire Webzine.WebApplicaton 

[Ouvrir le fichier appsettings.json](../../Webzine.WebApplication/appsettings.json)

## <span style="color:purple">3. Liste des paramètres <a name="subparagraph2"></a>

Le fichier est composé de 4 sections :
* [Configuration](#config)
* [ConnectionStrings](#connectDB)
* [Logging](#journalisation)

### <span style="color:purple"> 3.1 Section Configuration <a name="config"></a>
Dans cette section vous trouverez les paramètres dédiés à l'affichage des titres chroniqués sur la page d'accueil, une liste de mot pour modérer les chronique, ainsi que les paramètres de configuration de la base de données.

> Paramètre DataRepository <a name="DataRepository"></a>

Valeur acceptée : 
* "Local" -> L'application fonctionnera sans base de données avec un jeu de fausses données généré automatiquement. Ce mode peut aider à comprendre le comportement de l'application en cas de mauvais fonctionnement
* LocalWithDatabase" -> L'application générera une base de données et le jeu de fausses données sera insérer dans la base. Ce mode permet de tester le fonctionnement de l'application avec la base de données.
* "Database" -> L'application générera une base de données et fonctionnera avec cette base de données.
  
<u>Tout autre valeur pour ce paramètre entrainera une erreur au démarrage de l'application.</u>

> Paramètre SGBD <a name="SGBD"></a>

 Ce paramètre correspond au système de gestion de base de données lorsque une base de données est utilisée.
Valeur acceptée : 
* "SQLite" 
* "PostgreSql"
* "SqlServer"

<u>Tout autre valeur pour ce paramètre entrainera une erreur au démarrage de l'application si l'application doit fonctionner avec une base de données.</u>

> Paramètre HomePageDisplay <a name="HomePageDisplay"></a>

 Ce paramètre correspond au nombre de titres à afficher sur la page d'accueuil, dans la partie "Derniers titres chroniqués".
 
 Valeur minimum : 3

> Paramètre ResetDb <a name="ResetDb"></a>

Ce paramètre permet de réinitialiser la base de données au démarrage de l'application. Ce paramètre a été conçu comme un interupteur, si ça valeur est "on" la base de données est réinitialiser, si c'est "off" ou tout autre valeur l'application fonctionnera avec la base données existante au paravant.

<u>Atention si aucune base de données n'a été créé auparavant, et que le paramètre est sur "off", l'application ne fonctionnera pas correctement dans les modes de fonctionnement avec base de données.</u>

> Paramètre KeywordSearchApiDeezer <a name="KeywordSearchApiDeezer"></a>

 Ce paramètre est une liste de mot clés que l'application utilisera pour alimenter la base de données avec la configuration :

 * "DataRepository": "Database"
  
et

 * "ResetDb": "on"

Pour chaque mot clé l'application téléchargera, à partir de l'API de Deezer, un jeu de données correspondant.

> Paramètre ModerationWordList <a name="ModerationWordList"></a>

 Ce paramètre est une liste de mot clés que l'application utilisera pour modérer les chroniques. Si un ou plusieurs mot de la liste est contenu dans une chronique, le titre ne sera pas enregistrer, et l'utilisateur sera rediriger vers la page de création ou d'édition de titre. Un message "Votre chronique ne respecte pas la charte du site" sera alors affiché


### <span style="color:purple">3.2 Section ConnectionStrings <a name="connectDB"></a>

Dans cette section il y a trois paramètre correspondant au différentes chaînes de connexion au base de données.
*  WebzineDbSqlite 
  >Par défault : "Data Source=Webzine.db"
*  WebzineDbSQLServer 
  >Par défault : "Server=.;Database=WebzineDb;Trusted_Connection=True;MultipleActiveResultSets=true"
*  WebzineDbPostgreSql
  >Par défault : "Host=localhost;User ID=username;Database=Webzine;Pooling=true;password=password;"

Concernant PostgreSql un serveur de base de données PostgreSql doit être accessible, et un role doit être défini par User ID et password.

<u>Tout autre valeur pour ces paramètres entrainera une erreur au démarrage de l'application.</u>

### <span style="color:purple">3.3 Section Logging <a name="log"></a>

Cet section est dédié aux paramètres de journalisation, qui permettent d'enregistrer un historique des événements affectant le fonctionnement de l'application.

<u>Tout autre valeur pour ces paramètres entrainera un fonctionnement inattendu de l'enregistrement de l'historique de journalisation. Si un dépannage venait à être nécessaire cela pourrait entraîner un surcoût.</u>