namespace Webzine.Services
{
    using Microsoft.Extensions.Configuration;
    using System.Globalization;
    using System.Text;
    using Webzine.Entity;
    using Webzine.Repository.Contracts;
    using Webzine.Services.Contracts;

    public class ModeratorServices : IModeratorServices
    {
        private readonly IConfiguration _configuration;
        private readonly List<string> ExcludeWord;
        private ITitreRepository _titreRepository;
        public ModeratorServices(ITitreRepository titreRepository, IConfiguration config)
        {
            this._titreRepository = titreRepository;
            this._configuration = config;
            this.ExcludeWord = config.GetSection("Configuration").GetSection("ModerationWordList").Get<List<string>>();
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

            var wordListOfText = NormalizationTextToWordArray(titre.Chronique);

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
            // Normalisation du texte accent par exemple
            // Traitement du texte en fonction du niveau d'exigence de perfomance
            var wordListOfText = NormalizationTextToWordArray(titre.Chronique);

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

        /// <summary>
        /// Normalisation du texte : suppression des accents et des caractères de ponctuation
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns>Tableau des mots composants "inputText" sans accent, sans caractère de ponctuation et en minuscule</returns>
        public string[] NormalizationTextToWordArray(string inputText)
        {
            string textNormalized;
            string[] wordArray;
            StringBuilder stringBuilder = new StringBuilder();
            // Remplacement des saut à la ligne par des espaces et suppression
            // Normalisation à l’aide de la décomposition canonique complète de la chaîne Unicode.
            string normalizedString = inputText
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Normalize(NormalizationForm.FormD);

            foreach(var car in normalizedString)
            {
                // Si le caractère n'est pas de type accent ou ponctuation on l'ajoute (A voir : Caractères monétaires)
                if (CharUnicodeInfo.GetUnicodeCategory(car) != UnicodeCategory.NonSpacingMark && 
                    CharUnicodeInfo.GetUnicodeCategory(car) != UnicodeCategory.OtherPunctuation) //&& 
                    //CharUnicodeInfo.GetUnicodeCategory(car) != UnicodeCategory.CurrencySymbol)
                {
                    stringBuilder.Append(car);
                }     
            }
            textNormalized = stringBuilder.ToString().ToLower();
            wordArray = textNormalized.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return wordArray;
        }
    }
}