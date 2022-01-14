namespace Webzine.Services
{

    // using Webzine.Repository.Contracts;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;

    public class Moderator
    {
        private ITitreRepository _titreRepository;
        public Moderator(ITitreRepository titreRepository)
        {
            this._titreRepository = titreRepository;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="titreRepository"></param>
        /// <param name="listIdStyle"></param>
        /// <returns></returns>
        public bool ModerationText(Titre titre, List<string> listIdStyle)
        {
            List<string> ExcludeWord = new List<string>() { "pute", "batard", "enculé", "salop" };
            // Il manque la normalisation du texte accent par exemple

            var text = titre.Chronique;
            var wordListOfText = text.Split(" ");

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
    }
}