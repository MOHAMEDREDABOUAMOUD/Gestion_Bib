using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using ConsoleApp1.Services.Interfaces;

namespace ConsoleApp1.Services
{
    public class GestionEmprunt : InterfaceGestionEmprunt
    {
        Dictionary<int, List<Emprunt>> dictEmprunt;

        public Dictionary<int, List<Emprunt>> DictEmprunt { get => dictEmprunt; set => dictEmprunt = value; }

        public GestionEmprunt()
        {
            DictEmprunt = new Dictionary<int, List<Emprunt>>();
        }


        public void ajouterEmprunt(int codeEtud, int codeOuvr, DateOnly datoE, DateOnly dateoR)
        {
            if (DictEmprunt.Keys.Contains(codeEtud))
            {
                DictEmprunt[codeEtud].Add(new Emprunt(codeEtud, codeOuvr, datoE, dateoR));
            }
            else
            {
                DictEmprunt.Add(codeEtud, new List<Emprunt>());
                DictEmprunt[codeEtud].Add(new Emprunt(codeEtud, codeOuvr, datoE, dateoR));
            }
        }
        public List<Emprunt> rechercherEmpruntE(int codeEtud)
        {
            if (DictEmprunt.Keys.Contains(codeEtud)) return DictEmprunt[codeEtud];
            else return null;
        }
        public List<Emprunt> rechercherEmpruntO(int codeO)
        {
            List<Emprunt> list = new List<Emprunt>();
            foreach(List<Emprunt> emprunt in dictEmprunt.Values)
            {
                foreach (Emprunt emp in emprunt)
                {
                    if(emp.CodeOuvr==codeO) list.Add(emp);
                }
            }
            if (list.Count > 0) return list;
            else return null;
        }
        public Emprunt rechercherEmpruntEO(int codeEtud, int codeO)
        {
            if (DictEmprunt.Keys.Contains(codeEtud))
            {
                foreach (Emprunt emp in dictEmprunt[codeEtud])
                {
                    if (emp.CodeOuvr == codeO) return emp;
                }
                return null;
            }
            else return null;
        }
        public bool suprimerEmprunt(int codeEtud)
        {
            if (DictEmprunt.Keys.Contains(codeEtud))
            {
                DictEmprunt.Remove(codeEtud);
                return true;
            }
            else return false;
        }

        public bool suprimerEmprunt(int codeEtud, int codeO)
        {
            if (DictEmprunt.Keys.Contains(codeEtud))
            {
                List<Emprunt> l = rechercherEmpruntE(codeEtud);
                foreach (Emprunt emprunt in l)
                {
                    if (emprunt.CodeOuvr == codeO)
                    {
                        l.Remove(emprunt);
                        return true;
                    }
                }
                return false;
            }
            else return false;
        }
        public bool modifierEmprunt(int codeEtud, int codeOuvr, DateOnly dateoE, DateOnly dateoR)
        {
            if (DictEmprunt.Keys.Contains(codeEtud))
            {
                List<Emprunt> l = rechercherEmpruntE(codeEtud);
                foreach (Emprunt emprunt in l)
                {
                    if (emprunt.CodeOuvr == codeOuvr)
                    {
                        emprunt.EmpruntDate = dateoE;
                        emprunt.RetourDate = dateoR;
                        return true;
                    }
                }
                return false;
            }
            else return false;
        }
        public override string ToString()
        {
            string s = "", s2 = "";
            foreach (KeyValuePair<int, List<Emprunt>> item in DictEmprunt)
            {
                foreach (var item2 in item.Value)
                {
                    s2 += item + "|";
                }
                s += item.Key + s2 + "\n";
                s2 = "";
            }
            return s;
        }
    }
}
