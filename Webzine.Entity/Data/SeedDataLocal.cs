namespace Webzine.Entity.Data
{
    using Newtonsoft.Json;

    /// <summary>
    /// Service d'importation des données de Factory dans la BDD.
    /// </summary>
    internal class SeedDataLocal
    {
        const string DatasFile = "Data/ArtistRock.json";

        /// <summary>
        /// Méthode de désérialisation.
        /// </summary>
        /// <typeparam name="T">Type d'objets à préciser à l'appel de la méthode</typeparam>
        /// <param name="dataFile">Chemin du fichier sous forme de string.</param>
        /// <returns>Liste d'objets.</returns>
        /// <exception cref="Exception">Si la liste est vide.</exception>
        public static IEnumerable<T> LoadDatas<T>(string dataFile)
        {
            string json = File.ReadAllText(dataFile);
            return JsonConvert.DeserializeObject<List<T>>(json)
                ?? throw new Exception("La liste ne doit pas être vide.");
        }
    }
}
