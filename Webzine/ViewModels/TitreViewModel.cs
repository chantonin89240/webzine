﻿using Webzine.Entity;
using Webzine.Entity.Factory;

namespace Webzine.WebApplication.ViewModels
{
    public class TitreViewModel
    {
        public List<Titre> Titres { get; set; }
        public string LibelleStyle { get; set; }

        public IEnumerable<Titre> GetTitres(int idStyle)
        {
            this.Titres = TitreFactory.CreateTitre2().ToList().FindAll(titre => titre.TitresStyles.Exists(ts => ts.IdStyle == idStyle));
            return Titres;
        }

        public string GetLibelle(int idStyle)
        {
            this.LibelleStyle = StyleFactory.CreateStyle().First(el => el.IdStyle == idStyle).Libelle;
            return this.LibelleStyle;
        }
    }
}
