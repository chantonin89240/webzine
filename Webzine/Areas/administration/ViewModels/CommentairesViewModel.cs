namespace Webzine.ViewModels
{
    using Webzine.Entity;
    using Webzine.Entity.Factory;
    using Webzine.Repository;

    public class CommentairesViewModel
    {

        private LocalCommentaireRepository _commentaireRepository;

        /// <summary>
        /// Renvoie ou modifie la base de commentaires utilisée
        /// </summary>
        public List<Commentaire> commentaires { get; set; }

        /// <summary>
        /// Renvoie ou modifie la base de titres utilisée
        /// </summary>
        public List<Titre> titres { get; set; }

        /// <summary>
        /// Remplit toute la base du viewModel avec les données des Factory correspondant.
        /// Mettre à jour dés que la BDD est en place!!!
        /// </summary>
        public void Generate()
        {
            _commentaireRepository = new LocalCommentaireRepository();

            commentaires = _commentaireRepository.FindAll().ToList();
            titres = TitreFactory.CreateTitre().ToList();

        }

        /// <summary>
        /// Récupère ou modifie le commentaire de la vue
        /// </summary>
        public Commentaire contextCommentaire { get; set; }

        /// <summary>
        /// Récupère ou modifie le titre associé au commentaire
        /// </summary>
        public Titre contextTitre { get; set; }

        /// <summary>
        /// Récupère un commentaire et son titre correspondant
        /// </summary>
        /// <param name="id"> ID du commentaire </param>
        public void Acquire(int id)
        {
            _commentaireRepository = new LocalCommentaireRepository();

            titres = TitreFactory.CreateTitre().ToList();

            contextCommentaire = _commentaireRepository.Find(id);

            // ContextTitre = titreRepository.Find(ContextCommentaire.IdTitre);
            contextTitre = titres.FirstOrDefault(title => title.IdTitre == contextCommentaire.IdTitre);

        }
    }
}
