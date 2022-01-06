using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webzine.Entity.Factory
{
    public static class ArtisteFactory
    {
        public static IEnumerable<Artiste> CreateArtiste()
        {
            return new List<Artiste>()
            {
                new Artiste{IdArtiste = 1, Nom = "747", Biographie = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer felis justo, viverra ut luctus eget, sagittis in enim. Etiam sodales sem leo, ut ultricies ex cursus id. Nunc quis tincidunt augue, eget porta lorem. Nam rutrum est in eros suscipit, vitae malesuada elit fermentum. Aliquam fringilla, dolor non convallis pharetra, quam purus laoreet neque, ut rhoncus ligula tellus ac enim. Praesent viverra dictum nulla, eget pulvinar massa feugiat at. Suspendisse tempor purus dolor, sit amet aliquam velit varius nec. Aenean vel dui tempor, dapibus magna sed, dapibus erat. Vestibulum pharetra finibus tortor. Nunc quis accumsan odio. Integer tempus leo nibh, eu tempor tellus tempor ut. Aenean ullamcorper mattis neque, id laoreet massa dignissim vel. Sed neque odio, tempus in feugiat sed, faucibus eget justo. Suspendisse ante orci, mattis eu eros quis, condimentum interdum ipsum. Donec auctor, magna sit amet blandit iaculis, nisi ipsum venenatis leo, vitae consectetur odio lacus sed arcu. Sed eu ipsum vestibulum, aliquet velit ut, porttitor ipsum."},
                new Artiste{IdArtiste = 2, Nom = "Röyksopp", Biographie = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer felis justo, viverra ut luctus eget, sagittis in enim. Etiam sodales sem leo, ut ultricies ex cursus id. Nunc quis tincidunt augue, eget porta lorem. Nam rutrum est in eros suscipit, vitae malesuada elit fermentum. Aliquam fringilla, dolor non convallis pharetra, quam purus laoreet neque, ut rhoncus ligula tellus ac enim. Praesent viverra dictum nulla, eget pulvinar massa feugiat at. Suspendisse tempor purus dolor, sit amet aliquam velit varius nec. Aenean vel dui tempor, dapibus magna sed, dapibus erat. Vestibulum pharetra finibus tortor. Nunc quis accumsan odio. Integer tempus leo nibh, eu tempor tellus tempor ut. Aenean ullamcorper mattis neque, id laoreet massa dignissim vel. Sed neque odio, tempus in feugiat sed, faucibus eget justo. Suspendisse ante orci, mattis eu eros quis, condimentum interdum ipsum. Donec auctor, magna sit amet blandit iaculis, nisi ipsum venenatis leo, vitae consectetur odio lacus sed arcu. Sed eu ipsum vestibulum, aliquet velit ut, porttitor ipsum."},
                new Artiste{IdArtiste = 3, Nom = "Jean-Michel Jarre", Biographie = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer felis justo, viverra ut luctus eget, sagittis in enim. Etiam sodales sem leo, ut ultricies ex cursus id. Nunc quis tincidunt augue, eget porta lorem. Nam rutrum est in eros suscipit, vitae malesuada elit fermentum. Aliquam fringilla, dolor non convallis pharetra, quam purus laoreet neque, ut rhoncus ligula tellus ac enim. Praesent viverra dictum nulla, eget pulvinar massa feugiat at. Suspendisse tempor purus dolor, sit amet aliquam velit varius nec. Aenean vel dui tempor, dapibus magna sed, dapibus erat. Vestibulum pharetra finibus tortor. Nunc quis accumsan odio. Integer tempus leo nibh, eu tempor tellus tempor ut. Aenean ullamcorper mattis neque, id laoreet massa dignissim vel. Sed neque odio, tempus in feugiat sed, faucibus eget justo. Suspendisse ante orci, mattis eu eros quis, condimentum interdum ipsum. Donec auctor, magna sit amet blandit iaculis, nisi ipsum venenatis leo, vitae consectetur odio lacus sed arcu. Sed eu ipsum vestibulum, aliquet velit ut, porttitor ipsum."},
            };
        }

    
    }
}
