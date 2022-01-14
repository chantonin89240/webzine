namespace Webzine.Services
{
    using Webzine.Entity;
    using Webzine.Repository.Contracts;

    public class ModeratorServices : IModeratorServices
    {
        private readonly List<string> ExcludeWord = new List<string>() { "pute", "batard", "enculé", "salope" };
        private ITitreRepository _titreRepository;
        public ModeratorServices(ITitreRepository titreRepository)
        {
            this._titreRepository = titreRepository;
        }

        /// <summary>
        /// Moderation du contenu lors d'une création de chronique.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="titreRepository"></param>
        /// <param name="listIdStyle"></param>
        /// <returns></returns>
        public bool ModerationCreateChronique(Titre titre, List<string> listIdStyle)
        {
            // Il manque la normalisation du texte accent par exemple
            // Traitement du texte en fonction du niveau d'exigence de perfomance

            var text = titre.Chronique;
            var wordListOfText = text.ToLower().Split(" ");

            if (ExcludeWord.Intersect(wordListOfText).Count() == 0)
            {
                try
                {
                    _titreRepository.Add(titre);
                    _titreRepository.AddStyles(titre, listIdStyle);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }            
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Moderation du contenu lors d'une modification de chronique.
        /// </summary>
        /// <param name="titre"></param>
        /// <param name="newIdStyle"></param>
        /// <param name="oldIdStyle"></param>
        /// <returns></returns>
        public bool ModerationEditChronique(Titre titre, List<string> newIdStyle, List<string> oldIdStyle)
        {
            // Il manque la normalisation du texte accent par exemple
            // Traitement du texte en fonction du niveau d'exigence de perfomance
            var text = titre.Chronique;
            var wordListOfText = text.ToLower().Split(" ");

            if (ExcludeWord.Intersect(wordListOfText).Count() == 0)
            {
                try
                {
                    if(newIdStyle != oldIdStyle)
                    {
                        var listRemove = oldIdStyle.Except(newIdStyle).ToList();
                        var listAdd = newIdStyle.Except(oldIdStyle).ToList();
                        this._titreRepository.UpdateStyles(titre.IdTitre, listRemove, listAdd);
                    }
                    this._titreRepository.Update(titre);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }            
            }
            else
            {
                return false;
            }
        }
    }
}