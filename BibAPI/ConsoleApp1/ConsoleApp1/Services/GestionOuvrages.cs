using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using ConsoleApp1.Services.Interfaces;

namespace ConsoleApp1.Services
{
    public class GestionOuvrages : InterfaceGestionOuvrages
    {
        List<Ouvrage> ouvrages;

        public GestionOuvrages()
        {
            ouvrages = new List<Ouvrage>();
        }

        public List<Ouvrage> Ouvrages() {
            return ouvrages; 
        }

        bool uniq(string titre)
        {
            foreach (Ouvrage ouvrage in ouvrages)
            {
                if (ouvrage.Titre == titre) return false;
            }
            return true;
        }

        public void ajouterOuvrage(string titre, DateOnly dateo, List<string> auteurs)
        {
            //if (uniq(titre))
            //{
            Ouvrage o = new Ouvrage(titre, dateo);
            ouvrages.Add(o);
            foreach (var item in auteurs)
            {
                o.ajouterAuteur(item);
            }
            //}
            //else return false;
        }
        public Ouvrage rechercherOuvrage(int code)
        {
            foreach (Ouvrage ouvrage in ouvrages)
            {
                if (ouvrage.Code == code) return ouvrage;
            }
            return null;
        }

        public List<Ouvrage> rechercherOuvrageT(string titre)
        {
            List<Ouvrage> l=new List<Ouvrage>();
            foreach (Ouvrage ouvrage in ouvrages)
            {
                if (ouvrage.Titre == titre) l.Add(ouvrage);
            }
            if (l.Count > 0) return l;
            else return null;
        }
        public List<Ouvrage> rechercherOuvrageA(string auteur)
        {
            List<Ouvrage> l=new List<Ouvrage>();
            foreach (Ouvrage ouvrage in ouvrages)
            {
                foreach(string a in ouvrage.Auteurs)
                {
                    if (a == auteur) l.Add(ouvrage);
                }
            }
            if (l.Count > 0) return l;
            else return null;
        }
        public bool suprimerOuvrage(int code)
        {
            foreach (Ouvrage ouvrage in ouvrages)
            {
                if (ouvrage.Code == code)
                {
                    ouvrages.Remove(ouvrage);
                    return true;
                }
            }
            return false;
        }
        public void modifierOuvrage(int code, string titre, DateOnly dateo, List<string> auteurs)
        {
            foreach (Ouvrage ouvrage in ouvrages)
            {
                if (ouvrage.Code == code)
                {
                    ouvrage.Titre = titre;
                    ouvrage.Editdate = dateo;
                    ouvrage.Auteurs = auteurs;
                }
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (Ouvrage item in ouvrages)
            {
                s += item + "\n";
            }
            return s;
        }
    }
}
