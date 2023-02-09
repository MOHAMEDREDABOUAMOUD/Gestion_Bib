using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services.Interfaces
{
    public interface InterfaceGestionEmprunt
    {
        public Dictionary<int,List<Emprunt>> DictEmprunt { get; set; }
        public void ajouterEmprunt(int codeEtud, int codeOuvr, DateOnly datoE, DateOnly dateoR);
        public List<Emprunt> rechercherEmpruntE(int codeEtud);
        public List<Emprunt> rechercherEmpruntO(int codeO);
        public Emprunt rechercherEmpruntEO(int codeEtud,int codeO);
        public bool suprimerEmprunt(int codeEtud);
        public bool suprimerEmprunt(int codeEtud, int codeO);
        public bool modifierEmprunt(int codeEtud, int codeOuvr, DateOnly dateoE, DateOnly dateoR);
    }
}
