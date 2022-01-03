using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.Factory
{
    public static class TitreFactory
    {
        public static IEnumerable<Titre> CreateTitre()
        {
            return new List<Titre>()
            {
                new Titre(){
                    IdTitre = 1,
                    IdArtiste = 1,
                    Artiste = new Artiste() {IdArtiste = 1, Biographie = "lorem", Nom = "747", Titres = new List<Titre>() },
                    Libelle = "Aurora Centralis",
                    Chronique = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                    UrlJaquette = "https://img.discogs.com/B6iuYM2bOHOt4oFHSVAZT2n5_fM=/fit-in/300x300/filters:strip_icc():format(webp):mode_rgb():quality(40)/discogs-images/R-12114833-1529064355-3135.jpeg.jpg",
                    UrlEcoute = "https://www.youtube.com/embed/ow00U-slPYk",
                    Lien = "",
                    DateCreation = new DateTime(2021, 07, 22),
                    DateSortie =  new DateTime(2021, 07, 22),
                    Duree = 180,
                    NbLectures = 20,
                    NbLikes = 8,
                    Commentaires = new List<Commentaire>()
					{
                        new Commentaire()
                        {
                            IdCommentaire = 1,
                            Auteur = "michelle",
                            Contenu = "lorem ipsum",
                            DateCreation = new DateTime(2021, 12, 11),
                            IdTitre = 1,
                            Titre = new Titre(),
                        },
                    },
                    TitresStyles = new List<TitreStyle>()
                    {
                        new TitreStyle()
                        {
                            IdStyle = 1,
                            IdTitre = 1,
                        },
                        new TitreStyle()
                        {
                            IdStyle = 2,
                            IdTitre = 1,
                        },
                        new TitreStyle()
                        {
                            IdStyle = 3,
                            IdTitre = 1,
                        },
                    },
                },
                new Titre()
                {
                    IdTitre = 2,
                    IdArtiste = 2,
                    Artiste = new Artiste(){IdArtiste = 2, Biographie="lorem", Nom="Röyksopp", Titres = new List<Titre>()},
                    Libelle = "Sordid Affai - Maceo Plex Remix",
                    Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    UrlJaquette = "https://img.discogs.com/Lt0SDzF84Mi_dDAnT_kb2fN7I-A=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-6190573-1413305948-2894.jpeg.jpg",
                    UrlEcoute = "",
                    Lien = "",
                    DateCreation = new DateTime(2021, 12, 10),
                    DateSortie = new DateTime(2021, 12, 11),
                    Duree = 180,
                    NbLectures = 10,
                    NbLikes = 4,
                    Commentaires = new List<Commentaire>(),
                    TitresStyles = new List<TitreStyle>()
                    {
                        new TitreStyle()
                        {
                            IdStyle = 1,
                            IdTitre = 2,
                        },
                        new TitreStyle()
                        {
                            IdStyle = 2,
                            IdTitre = 2,
                        },
                        new TitreStyle()
                        {
                            IdStyle = 3,
                            IdTitre = 2,
                        },
                    },
                },
                new Titre()
                {
                    IdTitre = 3,
                    IdArtiste = 3,
                    Artiste = new Artiste(){IdArtiste = 3, Biographie="lorem", Nom="Jean-Michel Jarre", Titres = new List<Titre>()},
                    Libelle = "Oxygene, Pt1",
                    Chronique = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    UrlJaquette = "https://www.guettapen.com/wp-content/uploads/2016/12/Oxygene-3.jpg",
                    UrlEcoute = "",
                    Lien = "",
                    DateCreation = new DateTime(2021, 12, 10),
                    DateSortie = new DateTime(2021, 12, 11),
                    Duree = 180,
                    NbLectures = 345,
                    NbLikes = 243,
                    Commentaires = new List<Commentaire>(),
                    TitresStyles = new List<TitreStyle>()
                    {
                        new TitreStyle()
                        {
                            IdStyle = 1,
                            IdTitre = 3,
                        },
                        new TitreStyle()
                        {
                            IdStyle = 2,
                            IdTitre = 3,
                        },
                        new TitreStyle()
                        {
                            IdStyle = 3,
                            IdTitre = 3,
                        },
                    },
                },
            };
        }

        public static IEnumerable<Titre> CreateTitre2()
        {
            return new List<Titre>()
            {
                new Titre(){
                    IdTitre = 1,
                    IdArtiste = 1,
                    Artiste = new Artiste(),
                    Libelle = "So Flute",
                    Chronique = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                    UrlJaquette = "https://images-na.ssl-images-amazon.com/images/I/51z6pNALiiL._SY355_.jpg",
                    UrlEcoute = "",
                    Lien = "",
                    DateCreation = new DateTime(2021, 12, 10),
                    DateSortie =  new DateTime(2021, 12, 11),
                    Duree = 180,
                    NbLectures = 20,
                    NbLikes = 7,
                    Commentaires = new List<Commentaire>(),
                    TitresStyles = new List<TitreStyle>()
                    {
                        new TitreStyle()
                        {
                            IdStyle = 1,
                            IdTitre = 1,
                        },
                        new TitreStyle()
                        {
                            IdStyle = 2,
                            IdTitre = 1,
                        },
                        new TitreStyle()
                        {
                            IdStyle = 3,
                            IdTitre = 1,
                        },
                    },
                },
                new Titre()
                {
                    IdTitre = 2,
                    IdArtiste = 2,
                    Artiste = new Artiste(),
                    Libelle = "Take Five",
                    Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    UrlJaquette = "https://img.discogs.com/OQJ30JshYpPG0E7eFpKJgEKF1zs=/fit-in/300x300/filters:strip_icc():format(jpeg):mode_rgb():quality(40)/discogs-images/R-7283481-1437975825-6839.jpeg.jpg",
                    UrlEcoute = "",
                    Lien = "",
                    DateCreation = new DateTime(2021, 12, 10),
                    DateSortie = new DateTime(2021, 12, 11),
                    Duree = 180,
                    NbLectures = 20,
                    NbLikes = 7,
                    Commentaires = new List<Commentaire>(),
                    TitresStyles = new List<TitreStyle>()
                    {
                        new TitreStyle()
                        {
                            IdStyle = 1,
                            IdTitre = 2,
                        },
                        new TitreStyle()
                        {
                            IdStyle = 2,
                            IdTitre = 2,
                        },
                        new TitreStyle()
                        {
                            IdStyle = 3,
                            IdTitre = 2,
                        },
                    },
                },
                new Titre()
                {
                    IdTitre = 3,
                    IdArtiste = 3,
                    Artiste = new Artiste(),
                    Libelle = "Blade runner end titles",
                    Chronique = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    UrlJaquette = "https://i1.sndcdn.com/artworks-000014228197-duydcr-t500x500.jpg",
                    UrlEcoute = "",
                    Lien = "",
                    DateCreation = new DateTime(2021, 12, 10),
                    DateSortie = new DateTime(2021, 12, 11),
                    Duree = 180,
                    NbLectures = 20,
                    NbLikes = 7,
                    Commentaires = new List<Commentaire>(),
                    TitresStyles = new List<TitreStyle>()
                    {
                        new TitreStyle()
                        {
                            IdStyle = 1,
                            IdTitre = 3,
                        },
                        new TitreStyle()
                        {
                            IdStyle = 2,
                            IdTitre = 3,
                        },
                        new TitreStyle()
                        {
                            IdStyle = 3,
                            IdTitre = 3,
                        },
                    },
                },
            };
        }
    }
}
