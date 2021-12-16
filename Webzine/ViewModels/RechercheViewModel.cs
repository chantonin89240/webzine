
using Microsoft.AspNetCore.Mvc;

namespace Webzine.ViewModels
{
    //using Webzine.Entity;

    public class RechercheViewModel : Controller
    {
        private string searchedItem;
        public string SearchedItem { get { return searchedItem; } set { searchedItem = value; } }



        // List<Artiste>
        // List<Titre>



        //GetArtistes
        //GetTitres



        public RechercheViewModel()
        {
            searchedItem = "";
        }


        //public RechercheViewModel(String SearchedItem)?

    }
}