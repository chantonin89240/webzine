using Webzine.Entity;
using Webzine.Entity.Factory;

namespace Webzine.WebApplication.ViewModels
{
    public static class LayoutViewModel
    {
        public static List<Style> Styles = StyleFactory.CreateStyle().ToList();
    }
}
