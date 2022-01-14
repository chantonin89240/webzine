namespace Webzine.Services
{
    using Webzine.Entity;

    /// <summary>
    /// Volontairement l'interface n'est pas dans une bibliothèque de classe
    /// </summary>
    public interface IModeratorServices
    {
        bool ModerationCreateChronique(Titre titre, List<string> listIdStyle);

        bool ModerationEditChronique(Titre titre, List<string> newIdStyle, List<string> oldIdStyle);
    }
}