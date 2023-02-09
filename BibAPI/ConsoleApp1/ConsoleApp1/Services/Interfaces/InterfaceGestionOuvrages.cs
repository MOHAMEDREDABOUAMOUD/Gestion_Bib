using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services.Interfaces
{
    public interface InterfaceGestionOuvrages
    {
        public List<Ouvrage> Ouvrages();
        public void ajouterOuvrage(string titre, DateOnly dateo, List<string> auteurs);
        public Ouvrage rechercherOuvrage(int code);
        public List<Ouvrage> rechercherOuvrageT(string titre);
        public List<Ouvrage> rechercherOuvrageA(string auteur);
        public bool suprimerOuvrage(int code);
        public void modifierOuvrage(int code, string titre, DateOnly dateo, List<string> auteurs);

    }
}
