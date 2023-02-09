using ConsoleApp1;
using ConsoleApp1.Models;
using ConsoleApp1.Services;
using ConsoleApp1.Services.Interfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ConsoleBib
{
    internal class Program
    {
        static int menu1()
        {
            Console.WriteLine("MENU Principale");
            Console.WriteLine("1-Menu Emprunteurs");
            Console.WriteLine("2-Menu Ouvrages");
            Console.WriteLine("3-Menu Emprunts");
            Console.WriteLine("4-Exit");
            Console.WriteLine("Votre choix : ");
            string input = Console.ReadLine();
            int number=-1;
            Int32.TryParse(input, out number);
            return number;
        }
        static int menu11()
        {
            Console.WriteLine("MENU Emprunteurs");
            Console.WriteLine("1-Ajouter");
            Console.WriteLine("2-Rechercher");
            Console.WriteLine("3-Modifier");
            Console.WriteLine("4-Suprimer");
            Console.WriteLine("5-Afficher");
            Console.WriteLine("6-Retour");
            Console.WriteLine("Votre choix : ");
            string input = Console.ReadLine();
            int number=-1;
            Int32.TryParse(input, out number);
            return number;
        }
        static int menu12()
        {
            Console.WriteLine("MENU Ouvrages");
            Console.WriteLine("1-Ajouter");
            Console.WriteLine("2-Rechercher");
            Console.WriteLine("3-Modifier");
            Console.WriteLine("4-Suprimer");
            Console.WriteLine("5-Afficher");
            Console.WriteLine("6-Gestion auteurs");
            Console.WriteLine("7-Retour");
            Console.WriteLine("Votre choix : ");
            string input = Console.ReadLine();
            int number = -1;
            Int32.TryParse(input, out number);
            return number;
        }
        static int menu121()
        {
            Console.WriteLine("MENU Auteur");
            Console.WriteLine("1-Ajouter");
            Console.WriteLine("2-Rechercher");
            Console.WriteLine("3-Modifier");
            Console.WriteLine("4-Suprimer");
            Console.WriteLine("5-Afficher");
            Console.WriteLine("6-Retour");
            Console.WriteLine("Votre choix : ");
            string input = Console.ReadLine();
            int number = -1;
            Int32.TryParse(input, out number);
            return number;
        }
        static int menu122()
        {
            Console.WriteLine("MENU Recherche Ouvrage");
            Console.WriteLine("1-Par code");
            Console.WriteLine("2-Par titre");
            Console.WriteLine("3-Par auteur");
            Console.WriteLine("4-Retour");
            Console.WriteLine("Votre choix : ");
            string input = Console.ReadLine();
            int number = -1;
            Int32.TryParse(input, out number);
            return number;
        }
        static int menu13()
        {
            Console.WriteLine("MENU Emprunts");
            Console.WriteLine("1-Ajouter");
            Console.WriteLine("2-Rechercher");
            Console.WriteLine("3-Modifier");
            Console.WriteLine("4-Suprimer");
            Console.WriteLine("5-Afficher");
            Console.WriteLine("6-Retour");
            Console.WriteLine("Votre choix : ");
            string input = Console.ReadLine();
            int number = -1;
            Int32.TryParse(input, out number);
            return number;
        }
        static int menu131()
        {
            Console.WriteLine("MENU Supprimer emprunt");
            Console.WriteLine("1-Tous les emprunts");
            Console.WriteLine("2-une seule emprunt");
            Console.WriteLine("3-Retour");
            Console.WriteLine("Votre choix : ");
            string input = Console.ReadLine();
            int number = -1;
            Int32.TryParse(input, out number);
            return number;
        }
        static int menu132()
        {
            Console.WriteLine("MENU Rechercher emprunt");
            Console.WriteLine("1-Par etudiant");
            Console.WriteLine("2-Par Ouvre");
            Console.WriteLine("3-Retour");
            Console.WriteLine("Votre choix : ");
            string input = Console.ReadLine();
            int number = -1;
            Int32.TryParse(input, out number);
            return number;
        }
        static void Main(string[] args)
        {
            InterfaceGestionEmprunteurs gemprunteurs=new GestionEmprunteurs();
            InterfaceGestionOuvrages gouvrages=new GestionOuvrages();
            InterfaceGestionEmprunt gemprunt=new GestionEmprunt();
            int code,code1,code2;
            int a,b,day,month,year;
            string input,input1;
            string nom,nom1, prenom,titre;
            Ouvrage ouvr;
            DateOnly dateo,dateo1,dateo2;
            do
            {
                do
                {
                    Console.Clear();
                    a = menu1();
                } while (a < 1 || a > 4);
                switch (a)
                {
                    case 1:
                        do
                        {
                            do
                            {
                                Console.Clear();
                                a = menu11();
                            } while (a < 1 || a > 6);
                            switch (a)
                            {
                                case 1:
                                    Console.WriteLine("Nom : ");
                                    nom=Console.ReadLine();
                                    Console.WriteLine("Prenom : ");
                                    prenom=Console.ReadLine();
                                    gemprunteurs.ajouterEmprunteur(nom,prenom);
                                    break;
                                case 2:
                                    Console.WriteLine("Code : ");
                                    input = Console.ReadLine();
                                    if(Int32.TryParse(input, out code))
                                    {
                                        Emprunteur e = gemprunteurs.rechercherEmprunteur(code);
                                        if (e != null) Console.WriteLine(e);
                                        else Console.WriteLine("emprunteur introuvable");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("invalid code");
                                        Console.Read();
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("Code : ");
                                    input = Console.ReadLine();
                                    if (Int32.TryParse(input, out code))
                                    {
                                        if (gemprunteurs.rechercherEmprunteur(code)!=null)
                                        {
                                            Console.WriteLine("Nom : ");
                                            nom = Console.ReadLine();
                                            Console.WriteLine("Prenom : ");
                                            prenom = Console.ReadLine();
                                            gemprunteurs.modifierEmprunteur(code, nom, prenom);
                                        }
                                        else
                                        {
                                            Console.WriteLine("emprunteur introuvable");
                                            Console.Read();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("invalid code");
                                        Console.Read();
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("Code : ");
                                    input = Console.ReadLine();
                                    if(Int32.TryParse(input, out code))
                                    {
                                        if(gemprunteurs.rechercherEmprunteur(code) != null) gemprunteurs.suprimerEmprunteur(code);
                                        else
                                        {
                                            Console.WriteLine("emprunteur introuvable");
                                            Console.Read();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("invalid code");
                                        Console.Read();
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine(gemprunteurs);
                                    Console.ReadLine();
                                    break;
                            }
                        } while (a!=6);
                        
                        break;
                    case 2:
                        do
                        {
                            do
                            {
                                Console.Clear();
                                a = menu12();
                            } while (a < 1 || a > 7);
                            switch (a)
                            {
                                case 1:
                                    Console.WriteLine("Titre : ");
                                    titre = Console.ReadLine();
                                    Console.WriteLine("Date d'edition : ");
                                    do
                                    {
                                        Console.Write("Jour : ");
                                        input = Console.ReadLine();
                                        Int32.TryParse(input, out day);
                                    } while (day<1 || day>31);
                                    do 
                                    {
                                        Console.Write("Mois : ");
                                        input = Console.ReadLine();
                                        Int32.TryParse(input, out month);
                                    } while (month<1 || month>12);
                                    do
                                    {
                                        Console.Write("Annee : ");
                                        input = Console.ReadLine();
                                        Int32.TryParse(input, out year);
                                    } while (year<1 || year>DateTime.Now.Year);
                                    dateo = new DateOnly(year, month, day);
                                    gouvrages.ajouterOuvrage(titre, dateo,new List<string>());
                                    break;
                                case 2:

                                    do
                                    {
                                        do
                                        {
                                            Console.Clear();
                                            b = menu122();
                                        }while (b < 0 || b > 4);
                                        List<Ouvrage> ouvrages;
                                        switch (b)
                                        {
                                            case 1:
                                                Console.WriteLine("Code : ");
                                                input = Console.ReadLine();
                                                if(Int32.TryParse(input, out code))
                                                {
                                                    Ouvrage o = gouvrages.rechercherOuvrage(code);
                                                    if (o != null) Console.WriteLine(o);
                                                    else Console.WriteLine("Oeuvre introuvable");
                                                    Console.ReadLine();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("invalid code");
                                                    Console.Read();
                                                }
                                                break;
                                            case 2:
                                                Console.WriteLine("Titre : ");
                                                input = Console.ReadLine();
                                                ouvrages = gouvrages.rechercherOuvrageT(input);
                                                if (ouvrages != null)
                                                {
                                                    foreach (Ouvrage ouvrage in ouvrages)
                                                    {
                                                        Console.WriteLine(ouvrage);
                                                    }
                                                }
                                                else Console.WriteLine("Oeuvre introuvable");
                                                break;
                                            case 3:
                                                Console.WriteLine("Auteur : ");
                                                input = Console.ReadLine();
                                                ouvrages = gouvrages.rechercherOuvrageA(input);
                                                if (ouvrages != null)
                                                {
                                                    foreach (Ouvrage ouvrage in ouvrages)
                                                    {
                                                        Console.WriteLine(ouvrage);
                                                    }
                                                }
                                                else Console.WriteLine("Oeuvre introuvable");
                                                break;
                                            case 4:
                                                break;
                                        }
                                        Console.ReadLine();
                                    } while (b!=4);

                                    break;
                                case 3:
                                    Console.WriteLine("Code : ");
                                    input = Console.ReadLine();
                                    if(Int32.TryParse(input, out code))
                                    {
                                        if(gouvrages.rechercherOuvrage(code) != null)
                                        {
                                            Console.WriteLine("Titre : ");
                                            titre = Console.ReadLine();
                                            Console.WriteLine("Date d'edition : ");
                                            do
                                            {
                                                Console.Write("Jour : ");
                                                input = Console.ReadLine();
                                                Int32.TryParse(input, out day);
                                            } while (day < 1 || day > 31);
                                            do
                                            {
                                                Console.Write("Mois : ");
                                                input = Console.ReadLine();
                                                Int32.TryParse(input, out month);
                                            } while (month < 1 || month > 12);
                                            do
                                            {
                                                Console.Write("Annee : ");
                                                input = Console.ReadLine();
                                                Int32.TryParse(input, out year);
                                            } while (year < 1 || year > DateTime.Now.Year);
                                            dateo = new DateOnly(year, month, day);

                                            gouvrages.modifierOuvrage(code, titre, dateo, gouvrages.rechercherOuvrage(code).Auteurs);
                                        }
                                        else
                                        {
                                            Console.WriteLine("oeuvre introuvable");
                                            Console.Read();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("invalid code");
                                        Console.Read();
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("Code : ");
                                    input = Console.ReadLine();
                                    if(Int32.TryParse(input, out code))
                                    {
                                        if(gouvrages.rechercherOuvrage(code) != null) gouvrages.suprimerOuvrage(code);
                                        else
                                        {
                                            Console.WriteLine("oeuvre introuvable");
                                            Console.Read();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("invalid code");
                                        Console.Read();
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine(gouvrages);
                                    Console.ReadLine();
                                    break;
                                case 6:
                                    Console.WriteLine("Code : ");
                                    input = Console.ReadLine();
                                    if(Int32.TryParse(input, out code))
                                    {
                                        if(gouvrages.rechercherOuvrage(code) != null)
                                        {
                                            do
                                            {
                                                do
                                                {
                                                    Console.Clear();
                                                    b = menu121();
                                                } while (b < 0 || b > 6);
                                                switch (b)
                                                {
                                                    case 1:
                                                        Console.WriteLine("Nom : ");
                                                        nom = Console.ReadLine();
                                                        ouvr = gouvrages.rechercherOuvrage(code);
                                                        ouvr.Auteurs.Add(nom);
                                                        break;
                                                    case 2:
                                                        Console.WriteLine("Nom : ");
                                                        nom = Console.ReadLine();
                                                        ouvr = gouvrages.rechercherOuvrage(code);
                                                        if (ouvr != null)
                                                        {
                                                            string noma = ouvr.rechercherAuteur(nom);
                                                            if (noma != "") Console.WriteLine(noma);
                                                            else Console.WriteLine("auteur introuvable");
                                                            Console.ReadLine();
                                                        }
                                                        break;
                                                    case 3:
                                                        Console.WriteLine("Nom d'auteur: ");
                                                        nom = Console.ReadLine();
                                                        Console.WriteLine("Nouveau nom d'auteur: ");
                                                        nom1 = Console.ReadLine();
                                                        ouvr = gouvrages.rechercherOuvrage(code);
                                                        ouvr.modifierAuteur(nom, nom1);
                                                        break;
                                                    case 4:
                                                        Console.WriteLine("Nom : ");
                                                        nom = Console.ReadLine();
                                                        ouvr = gouvrages.rechercherOuvrage(code);
                                                        ouvr.suprimerAuteur(nom);
                                                        break;
                                                    case 5:
                                                        Console.WriteLine(gouvrages.rechercherOuvrage(code));
                                                        Console.ReadLine();
                                                        break;
                                                }
                                            } while (b != 6);
                                        }
                                        else
                                        {
                                            Console.WriteLine("oeuvre introuvable");
                                            Console.Read();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("invalid code");
                                        Console.Read();
                                    }
                                    break;
                            }
                        } while (a != 7);
                        
                        break;
                    case 3:
                        if (gemprunteurs.Emprunteurs.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("veuillez ajouter au moins un emprunteur");
                            Console.Read();
                        }
                        else if (gouvrages.Ouvrages().Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("veuillez ajouter au moins une oeuvre");
                            Console.Read();
                        }
                        else
                        {
                            do
                            {
                                do
                                {
                                    Console.Clear();
                                    a = menu13();
                                } while (a < 1 || a > 6);
                                switch (a)
                                {
                                    case 1:
                                        do
                                        {
                                            Console.WriteLine("Code d'emprunteur: ");
                                            input = Console.ReadLine();
                                            Int32.TryParse(input, out code1);
                                        } while (gemprunteurs.rechercherEmprunteur(code1) == null);
                                        do
                                        {
                                            Console.WriteLine("Code d'ouvrage: ");
                                            input = Console.ReadLine();
                                            Int32.TryParse(input, out code2);
                                        } while (gouvrages.rechercherOuvrage(code2) == null);
                                        Console.WriteLine("Date d'emprunt : ");
                                        do
                                        {
                                            Console.Write("Jour : ");
                                            input = Console.ReadLine();
                                            Int32.TryParse(input, out day);
                                        } while (day < 1 || day > 31);
                                        do
                                        {
                                            Console.Write("Mois : ");
                                            input = Console.ReadLine();
                                            Int32.TryParse(input, out month);
                                        } while (month < 1 || month > 12);
                                        do
                                        {
                                            Console.Write("Annee : ");
                                            input = Console.ReadLine();
                                            Int32.TryParse(input, out year);
                                        } while (year < 1 || year > DateTime.Now.Year);
                                        dateo1 = new DateOnly(year, month, day);
                                        Console.WriteLine("Date de retour : ");
                                        do
                                        {
                                            Console.Write("Jour : ");
                                            input = Console.ReadLine();
                                            Int32.TryParse(input, out day);
                                        } while (day < 1 || day > 31);
                                        do
                                        {
                                            Console.Write("Mois : ");
                                            input = Console.ReadLine();
                                            Int32.TryParse(input, out month);
                                        } while (month < 1 || month > 12);
                                        do
                                        {
                                            Console.Write("Annee : ");
                                            input = Console.ReadLine();
                                            Int32.TryParse(input, out year);
                                        } while (year < 1 || year > DateTime.Now.Year);
                                        dateo2 = new DateOnly(year, month, day);
                                        gemprunt.ajouterEmprunt(code1, code2, dateo1, dateo2);
                                        break;
                                    case 2:

                                        do
                                        {
                                            do
                                            {
                                                Console.Clear();
                                                b = menu132();
                                            } while (b < 0 || b > 3);
                                            List<Emprunt> le;
                                            switch (b)
                                            {
                                                case 1:
                                                    Console.WriteLine("Code d'emprunteur: ");
                                                    input = Console.ReadLine();
                                                    if(Int32.TryParse(input, out code))
                                                    {
                                                        le = gemprunt.rechercherEmpruntE(code);
                                                        if (le != null)
                                                        {
                                                            Console.WriteLine(code.ToString() + " :");
                                                            foreach (Emprunt item in le)
                                                            {
                                                                Console.Write(item + " | ");
                                                            }
                                                            Console.ReadLine();
                                                        }
                                                        else Console.WriteLine("emprunteur introuvable");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("invalid code");
                                                        Console.Read();
                                                    }
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Code d'ouvrage: ");
                                                    input = Console.ReadLine();
                                                    if(Int32.TryParse(input, out code))
                                                    {
                                                        le = gemprunt.rechercherEmpruntO(code);
                                                        if (le != null)
                                                        {
                                                            Console.WriteLine(code.ToString() + " :");
                                                            foreach (Emprunt item in le)
                                                            {
                                                                Console.Write(item + " | ");
                                                            }
                                                            Console.ReadLine();
                                                        }
                                                        else Console.WriteLine("oeuvre introuvable");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("invalid code");
                                                        Console.Read();
                                                    }
                                                    break;
                                                case 3:
                                                    break;
                                            }
                                        } while (b != 3);

                                        break;
                                    case 3:
                                        Console.WriteLine("Code d'emprunteur: ");
                                        input = Console.ReadLine();
                                        if(Int32.TryParse(input, out code1))
                                        {
                                            if(gemprunt.rechercherEmpruntE(code1) != null)
                                            {
                                                Console.WriteLine("Code d'ouvrage: ");
                                                input = Console.ReadLine();
                                                if (Int32.TryParse(input, out code2))
                                                {
                                                    if(gemprunt.rechercherEmpruntO(code2) != null)
                                                    {
                                                        Console.WriteLine("Nouvelle date d'emprunt : ");
                                                        do
                                                        {
                                                            Console.Write("Jour : ");
                                                            input = Console.ReadLine();
                                                            Int32.TryParse(input, out day);
                                                        } while (day < 1 || day > 31);
                                                        do
                                                        {
                                                            Console.Write("Mois : ");
                                                            input = Console.ReadLine();
                                                            Int32.TryParse(input, out month);
                                                        } while (month < 1 || month > 12);
                                                        do
                                                        {
                                                            Console.Write("Annee : ");
                                                            input = Console.ReadLine();
                                                            Int32.TryParse(input, out year);
                                                        } while (year < 1 || year > DateTime.Now.Year);
                                                        dateo1 = new DateOnly(year, month, day);
                                                        Console.WriteLine("Nouvelle date de retour : ");
                                                        do
                                                        {
                                                            Console.Write("Jour : ");
                                                            input = Console.ReadLine();
                                                            Int32.TryParse(input, out day);
                                                        } while (day < 1 || day > 31);
                                                        do
                                                        {
                                                            Console.Write("Mois : ");
                                                            input = Console.ReadLine();
                                                            Int32.TryParse(input, out month);
                                                        } while (month < 1 || month > 12);
                                                        do
                                                        {
                                                            Console.Write("Annee : ");
                                                            input = Console.ReadLine();
                                                            Int32.TryParse(input, out year);
                                                        } while (year < 1 || year > DateTime.Now.Year);
                                                        dateo2 = new DateOnly(year, month, day);
                                                        gemprunt.modifierEmprunt(code1, code2, dateo1, dateo2);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("oeuvre introuvable");
                                                        Console.Read();
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("invalid code");
                                                    Console.Read();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Emprunteur introuvable");
                                                Console.Read();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("invalid code");
                                            Console.Read();
                                        }
                                        break;
                                    case 4:
                                        do
                                        {
                                            do
                                            {
                                                Console.Clear();
                                                b = menu131();
                                            } while (b < 0 && b > 3);
                                            switch (b)
                                            {
                                                case 1:
                                                    Console.WriteLine("Code d'emprunteur: ");
                                                    input = Console.ReadLine();
                                                    if(Int32.TryParse(input, out code1))
                                                    {
                                                        if(gemprunt.rechercherEmpruntE(code1) != null) gemprunt.suprimerEmprunt(code1);
                                                        else
                                                        {
                                                            Console.WriteLine("emprunteur introuvable");
                                                            Console.Read();
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Code d'emprunteur: ");
                                                    input = Console.ReadLine();
                                                    if(Int32.TryParse(input, out code1)) 
                                                    {
                                                        if(gemprunt.rechercherEmpruntE(code1) != null)
                                                        {
                                                            Console.WriteLine("Code d'oeuvre: ");
                                                            input = Console.ReadLine();
                                                            if (Int32.TryParse(input, out code2))
                                                            {
                                                                if (gemprunt.rechercherEmpruntO(code2) != null) gemprunt.suprimerEmprunt(code1, code2);
                                                                else
                                                                {
                                                                    Console.WriteLine("oeuvre introuvable");
                                                                    Console.Read();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("invalid code");
                                                                Console.Read();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("emprunteur introuvable");
                                                            Console.Read();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("invalid code");
                                                        Console.Read();
                                                    }
                                                    break;
                                                case 3:
                                                    break;
                                            }
                                        } while (b != 3);
                                        break;
                                    case 5:
                                        Console.WriteLine(gemprunt);
                                        Console.ReadLine();
                                        break;
                                }
                            } while (a != 6);
                        }
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            } while (a!=4);
            
        }
    }
}