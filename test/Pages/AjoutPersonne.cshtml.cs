using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.DataController;
using Web.Models;

namespace Web.Pages
{
    public class AjoutPersonneModel : PageModel
    {
        [BindProperty]
        public Personne Personne { get; set; }

        private readonly Context Ctx;

        public AjoutPersonneModel(Context ctx)
        {
            Ctx = ctx;
        }

        public void OnGet()
        {
        }

        public async void OnPostAsync()
        {
           await Insert();
        }


        // TODO verification des Donnes avec une regex pour echapper les carracteres autres que l'alphabet.
        public async Task<RedirectToActionResult> Insert()
        {
            if (Helper.Helper.CalculAgeCourrant(Personne).AgeActuel > 150)
            {
               // TODO retourner une alert Age trop eleve
            }
            Personne personne = new Personne()
            {
                DateNaissance = Personne.DateNaissance != null ? Personne.DateNaissance : default,
                Nom = Personne.Nom != null ? Personne.Nom : default,
                Prenom = Personne.Prenom != null ? Personne.Prenom : default
            };

            if (personne.DateNaissance != default && personne.Nom != default && personne.Prenom != default)
            {
                try
                {
                    await Ctx.Personne.AddAsync(personne);
                    Ctx.SaveChanges();
                }
                catch (Exception)
                {
                    // TODO retourner une alert erreur d'insertion, pouvane etre un nom deja existant
                }
            }
            else
            {
                // TODO retourner une alert Un champs n'a pas ete rempli correctement
            }
            return RedirectToAction(actionName: "OnGetAsync", controllerName: "Index");
        }
    }
}
