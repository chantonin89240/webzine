// <copyright file="CommentaireController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Webzine.Entity;
    using Webzine.Repository;
    using Webzine.Repository.Contracts;

    public class CommentaireController : Controller
    {
        private ICommentaireRepository commentaireRepository;
        private ITitreRepository titreRepository;

        CommentaireController(ICommentaireRepository commentaireRepository, ITitreRepository titreRepository)
        {
            this.commentaireRepository = commentaireRepository;
            this.titreRepository = titreRepository;
        }

        [HttpPost]
        public ActionResult Index(Commentaire model)
        {
            if (this.ModelState.IsValid)
            {
                // Send to Model to save into DB.
                // WARN: IT WON'T HAVE IT'S CommentaireId SET!
                model.DateCreation = DateTime.Now;
                model.Titre = this.titreRepository.Find(model.IdTitre);
                this.commentaireRepository.Add(model);
            }

            return this.Redirect("Titre/Titre?idTitre=" + model.IdTitre);
        }
    }
}
