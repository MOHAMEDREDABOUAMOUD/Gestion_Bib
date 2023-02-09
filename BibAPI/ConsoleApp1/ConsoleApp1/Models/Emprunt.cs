using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Emprunt
    {
        int codeEtud;
        int codeOuvr;
        DateOnly empruntDate;
        DateOnly retourDate;

        public Emprunt()
        {
            codeEtud = 1;
            codeOuvr = 1;
            empruntDate = new DateOnly();
            retourDate = new DateOnly();
        }

        public Emprunt(int codeEtud, int codeOuvr, DateOnly empruntDate, DateOnly retourDate)
        {
            this.codeEtud = codeEtud;
            this.codeOuvr = codeOuvr;
            this.empruntDate = empruntDate;
            this.retourDate = retourDate;
        }

        public int CodeEtud { get => codeEtud; set => codeEtud = value; }
        public int CodeOuvr { get => codeOuvr; set => codeOuvr = value; }
        public DateOnly EmpruntDate { get => empruntDate; set => empruntDate = value; }
        public DateOnly RetourDate { get => retourDate; set => retourDate = value; }

        public override string ToString()
        {
            return "Code etudiant : " + codeEtud + " Code Ouvrage : " + codeOuvr + " date d'emprunt : " + empruntDate + " date de retour : " + retourDate;
        }
        public override bool Equals(object? obj)
        {
            Emprunt other = obj as Emprunt;
            return other.codeEtud == codeEtud && other.codeOuvr == codeOuvr && other.empruntDate == empruntDate && other.retourDate == retourDate;
        }

    }
}
