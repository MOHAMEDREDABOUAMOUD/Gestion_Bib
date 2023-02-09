using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using ConsoleApp1.Services.Interfaces;

namespace ConsoleApp1.Services
{
    public class GestionEmprunteurs : InterfaceGestionEmprunteurs
    {
        List<Emprunteur> emprunteurs;

        public GestionEmprunteurs()
        {
            emprunteurs = new List<Emprunteur>();
        }

        public List<Emprunteur> Emprunteurs { get => emprunteurs; set => emprunteurs = value; }

        bool uniq(string nom,string prenom)
        {
            foreach (Emprunteur emprunteur in emprunteurs)
            {
                if (emprunteur.Nom == nom && emprunteur.Prenom == prenom) return false;
            }
            return true;
        }

        public void ajouterEmprunteur(string nom, string prenom)
        {   
            emprunteurs.Add(new Emprunteur(nom, prenom));
            //if (uniq(nom, prenom))
            //{
                
            //    return true;
            //}
            //else return false;
        }
        public Emprunteur rechercherEmprunteur(int code)
        {
            foreach (Emprunteur emprunteur in emprunteurs)
            {
                if (emprunteur.Code == code) return emprunteur;
            }
            return null;
        }
        public Emprunteur rechercherEmprunteur(string nom,string prenom)
        {
            foreach (Emprunteur emprunteur in emprunteurs)
            {
                if (emprunteur.Nom == nom && emprunteur.Prenom==prenom) return emprunteur;
            }
            return null;
        }
        public bool suprimerEmprunteur(int code)
        {
            foreach (Emprunteur emprunteur in emprunteurs)
            {
                if (emprunteur.Code == code)
                {
                    emprunteurs.Remove(emprunteur);
                    return true;
                }
            }
            return false;
        }
        public bool modifierEmprunteur(int code, string nom, string prenom)
        {
            foreach (Emprunteur emprunteur in emprunteurs)
            {
                if (emprunteur.Code == code)
                {
                    emprunteur.Prenom = prenom;
                    emprunteur.Nom = nom;
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            string s = "";
            foreach (Emprunteur item in emprunteurs)
            {
                s += item + "\n";
            }
            return s;
        }
    }
}
