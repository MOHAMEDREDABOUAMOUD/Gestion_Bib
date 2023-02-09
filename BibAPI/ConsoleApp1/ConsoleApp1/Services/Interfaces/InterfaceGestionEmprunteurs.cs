using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services.Interfaces
{
    public interface InterfaceGestionEmprunteurs
    {
        public List<Emprunteur> Emprunteurs { get; set; }
        public void ajouterEmprunteur(string nom, string prenom);
        public Emprunteur rechercherEmprunteur(int code);
        public Emprunteur rechercherEmprunteur(string nom, string prenom);
        public bool suprimerEmprunteur(int code);
        public bool modifierEmprunteur(int code, string nom, string prenom);
    }
}
