namespace Webzine.Entity.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Webzine.Entity;

    /// <summary>
    /// Tests de l'entité <see cref="Titre"/>.
    /// Vérifie que les contraintes imposées (nom du champ, longueur max du champ,
    /// champ obligatoire, libellé du champ, clé primaire...) sont bien respectées.
    /// </summary>
    [TestClass]
    public class TitreTests
    {
        [TestMethod]
        public void TitrehasidTitre()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.IdTitre));
        }

        [TestMethod]
        public void Titrehasidartiste()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.IdArtiste));
        }

        [TestMethod]
        public void Titrehasartiste()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.Artiste));
        }

        [TestMethod]
        public void Titrehaslibelle()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.Libelle));
        }

        [TestMethod]
        public void Titrehaslibelledisplayvalid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.Libelle), "Titre");
        }

        [TestMethod]
        public void Titrehaslibellerequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.Libelle));
        }

        [TestMethod]
        public void Titrehaslibelletaillemin1()
        {
            Common.AttributLongueurMin(typeof(Titre), nameof(Titre.Libelle), 1);
        }

        [TestMethod]
        public void Titrehaslibelletaillemax200()
        {
            Common.AttributLongueurMax(typeof(Titre), nameof(Titre.Libelle), 200);
        }

        [TestMethod]
        public void Titrehaschronique()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.Chronique));
        }

        [TestMethod]
        public void Titrehaschroniquerequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.Chronique));
        }

        [TestMethod]
        public void Titrehaschroniquetaillemin10()
        {
            Common.AttributLongueurMin(typeof(Titre), nameof(Titre.Chronique), 10);
        }

        [TestMethod]
        public void Titrehaschroniquetaillemax4000()
        {
            Common.AttributLongueurMax(typeof(Titre), nameof(Titre.Chronique), 4000);
        }

        [TestMethod]
        public void Titrehasdatecreation()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.DateCreation));
        }

        [TestMethod]
        public void Titrehasdatecreationrequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.DateCreation));
        }

        [TestMethod]
        public void Titrehasdatecreationdisplayvalid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.DateCreation), "date de création");
        }

        [TestMethod]
        public void Titrehasduree()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.Duree));
        }

        [TestMethod]
        public void Titrehasdureedisplayvalid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.Duree), "durée en secondes");
        }

        [TestMethod]
        public void Titrehasdatesortie()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.DateSortie));
        }

        [TestMethod]
        public void Titrehasdatesortierequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.DateSortie));
        }

        [TestMethod]
        public void Titrehasdatesortiedisplayvalid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.DateSortie), "date de sortie");
        }

        [TestMethod]
        public void Titrehasurljaquette()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.UrlJaquette));
        }

        [TestMethod]
        public void Titrehasurljaquetterequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.UrlJaquette));
        }

        [TestMethod]
        public void Titrehasurljaquettedisplayvalid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.UrlJaquette), "jaquette de l'album");
        }

        [TestMethod]
        public void Titrehasurljaquettetaillemax250()
        {
            Common.AttributLongueurMax(typeof(Titre), nameof(Titre.UrlJaquette), 250);
        }

        [TestMethod]
        public void Titrehasurlecoute()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.UrlEcoute));
        }

        [TestMethod]
        public void Titrehasurlecoutedisplayvalid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.UrlEcoute), "url d'écoute");
        }

        [TestMethod]
        public void Titrehasurlecoutetaillemin13()
        {
            Common.AttributLongueurMin(typeof(Titre), nameof(Titre.UrlEcoute), 13);
        }

        [TestMethod]
        public void Titrehasurlecoutetaillemax250()
        {
            Common.AttributLongueurMax(typeof(Titre), nameof(Titre.UrlEcoute), 250);
        }

        [TestMethod]
        public void Titrehasnblectures()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.NbLectures));
        }

        [TestMethod]
        public void Titrehasnblecturesdisplayvalid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.NbLectures), "nombre de lectures");
        }

        [TestMethod]
        public void Titrehasnblecturesrequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.NbLectures));
        }

        [TestMethod]
        public void Titrehasnblikes()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.NbLikes));
        }

        [TestMethod]
        public void Titrehasnblikesdisplayvalid()
        {
            Common.AttributDisplay(typeof(Titre), nameof(Titre.NbLikes), "nombre de likes");
        }

        [TestMethod]
        public void Titrehasnblikesrequis()
        {
            Common.AttributRequis(typeof(Titre), nameof(Titre.NbLikes));
        }

        //[TestMethod]
        //public void Titrehasalbum()
        //{
        //    Common.HasProperty(typeof(Titre), nameof(Titre.album));
        //}

        //[TestMethod]
        //public void Titrehasalbumrequis()
        //{
        //    Common.AttributRequis(typeof(Titre), nameof(Titre.album));
        //}

        [TestMethod]
        public void TitrehasTitresstyles()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.TitresStyles));
        }

        [TestMethod]
        public void Titrehascommentaires()
        {
            Common.HasProperty(typeof(Titre), nameof(Titre.Commentaires));
        }

        [TestMethod]
        public void Titreurljaquetteeisnotmandatory()
        {
            Common.AttributHasNotUrlValidation(typeof(Titre), nameof(Titre.UrlJaquette));
        }
    }
}
