using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Globalization;
using Web.DataController;
using Web.Models;
using Web.Pages.Helper;

namespace test.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Personne> Personnes { get; set; }

        //public ActionResult<string> Create( string pet);

        private readonly Context Ctx;
        public IndexModel(Context ctx)
        {
            Ctx = ctx;
        }

        public void OnGet()
        {
            var query = from b in Ctx.Personne
                        
                        select b;
            Personnes = new List<Personne>();
            Personnes = query.OrderByDescending(x=>x.Nom).ToList();
            Personnes = Helper.CalculAgeCourrant(Personnes);           
        }
    }
}
