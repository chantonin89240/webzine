namespace Webzine.Services
{

    using Webzine.Repository.Contracts;
    
    
    public class Moderator
    {
        private ITitreRepository _titreRepository;
        public List<string> ExcludeWord = new List<string>(){"pute","batard", "enculé", "salop"};
        
        public Moderator(ITitreRepository titreRepository)
        {
            this._titreRepository = titreRepository;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="titreRepository"></param>
        // public void ModerationText(TitreViewModel model, ITitreRepository titreRepository)
        // {
        //     // Il manque la nomalisation du texte accent par exemple

        //     var text = model.Titre.Chronique;
        //     string[] wordListOfText = text.Split(" ");

        //     if(ExcludeWord.Intersect(wordListOfText).Count == 0)
        //     {
        //         var listIdStyle = this.Request.Form["ListeStyles"].ToList();
        //         this._titreRepository.Add(model.Titre);
        //         this._titreRepository.AddStyles(model.Titre, listIdStyle);  

        //         return this.RedirectToAction(nameof(Index));
        //     }
        //     else
        //     {
        //         return this.View(model.Titre);
        //     }
        // }
    }
}