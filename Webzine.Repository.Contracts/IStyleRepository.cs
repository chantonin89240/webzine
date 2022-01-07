using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    public interface IStyleRepository
    {
        /// <summary>
        /// Ajout d'un style
        /// </summary>
        /// <param name="style"></param>
        void Add(Style style);

        /// <summary>
        /// Suppression d'un style
        /// </summary>
        /// <param name="style"></param>
        void Delete(Style style);

        /// <summary>
        /// Récupération d'un style
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Style Find(int id);

        /// <summary>
        /// Récupération de tous les style
        /// </summary>
        /// <returns></returns>
        IEnumerable<Style> FindAll();

        /// <summary>
        /// Modification d'un style
        /// </summary>
        /// <param name="style"></param>
        void Update(Style style);
    }
}
