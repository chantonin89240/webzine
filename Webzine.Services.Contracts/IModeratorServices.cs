namespace Webzine.Services.Contracts
{
    using Webzine.Entity;

    public interface IModeratorServices
    {
        bool ModerationCreateChronique(Titre titre, List<string> listIdStyle);

        bool ModerationEditChronique(Titre titre, List<string> newIdStyle, List<string> oldIdStyle);

        string[] NormalizationTextToWordArray(string inputText);
    }
}