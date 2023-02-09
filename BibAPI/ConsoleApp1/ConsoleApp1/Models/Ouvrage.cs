using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Ouvrage
    {
        int code;
        string titre;
        DateOnly editdate;
        List<string> auteurs;
        static int lastcode;

        public Ouvrage()
        {
            //code = lastcode;
            //lastcode++;
            titre = "?????";
            editdate = new DateOnly();
            auteurs = new List<string>();
            code = Interlocked.Increment(ref lastcode);
        }

        public Ouvrage(string titre, DateOnly editdate)
            :this()
        {
            //code = lastcode;
            //lastcode++;
            this.titre = titre;
            this.editdate = editdate;
            //auteurs = new List<string>();
        }

        public int Code { get => code; }
        public string Titre { get => titre; set => titre = value; }
        public DateOnly Editdate { get => editdate; set => editdate = value; }
        public List<string> Auteurs { get => auteurs; set => auteurs = value; }

        public void ajouterAuteur(string nom)
        {
            auteurs.Add(nom);
        }
        public string rechercherAuteur(string nom)
        {
            if (auteurs.IndexOf(nom) != -1) return nom;
            else return "";
        }
        public void suprimerAuteur(string nom)
        {
            if (auteurs.IndexOf(nom) != -1)
            {
                auteurs.Remove(nom);
            }
        }
        public void modifierAuteur(string oldname, string newname)
        {
            if (auteurs.IndexOf(oldname) != -1) auteurs[auteurs.IndexOf(oldname)] = newname;
        }
        public override string ToString()
        {
            string s = code.ToString() + " " + titre + " " + editdate.ToString() + " Auteurs : ";
            foreach (string nom in auteurs)
            {
                s += "-" + nom;
            }
            return s;
        }
        public override bool Equals(object? obj)
        {
            Ouvrage other = obj as Ouvrage;
            return other.Code == code;
        }
    }
}
