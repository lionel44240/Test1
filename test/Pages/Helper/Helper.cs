using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Pages.Helper
{
    public class Helper
    {

        // calculer l'age de la personne
        public static List<Personne> CalculAgeCourrant(List<Personne> personnes)
        {
            List<Personne> listPersonneToReturn = new List<Personne>();

            foreach (Personne item in personnes)
            {
                //ajouter l'age actuelle de la personne suivant son mois de naissance.
                item.AgeActuel = DateTime.Now.Year - item.DateNaissance.Year -
                        (DateTime.Now.Month < item.DateNaissance.Month ? 1 :
                        (DateTime.Now.Month == item.DateNaissance.Month && DateTime.Now.Day < item.DateNaissance.Day) ? 1 : 0);
                listPersonneToReturn.Add(item);
            }
            return listPersonneToReturn;
        }
        
        public static Personne CalculAgeCourrant(Personne personne)
        {
            //ajouter l'age actuelle de la personne suivant son mois de naissance.
            personne.AgeActuel = DateTime.Now.Year - personne.DateNaissance.Year -
                        (DateTime.Now.Month < personne.DateNaissance.Month ? 1 :
                        (DateTime.Now.Month == personne.DateNaissance.Month && DateTime.Now.Day < personne.DateNaissance.Day) ? 1 : 0);
           
            return personne;
        }
    }
}
