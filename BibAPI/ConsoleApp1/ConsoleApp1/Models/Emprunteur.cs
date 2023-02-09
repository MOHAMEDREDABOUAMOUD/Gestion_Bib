using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Emprunteur
    {
        int code;
        string nom;
        string prenom;
        static int lastcode;

        public int Code { get => code; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public Emprunteur()
        {
            //code = lastcode;
            //lastcode++;
            nom = "?????";
            prenom = "?????";
            code = Interlocked.Increment(ref lastcode);

        }

        public Emprunteur(string nom, string prenom)
            :this()
        {
            //code = lastcode;
            //lastcode++;
            this.nom = nom;
            this.prenom = prenom;
        }
        public override string ToString()
        {
            return code.ToString() + " " + nom + " " + prenom;
        }
        public override bool Equals(object? obj)
        {
            Emprunteur other = obj as Emprunteur;
            return other.code == code;
        }
    }
}
