using ConsoleApp1.Services;
using ConsoleApp1.Services.Interfaces;
using System.Reflection.Metadata;

namespace WinBib
{
    internal static class Program
    {
        public static InterfaceGestionEmprunteurs gemprunteurs;
        public static InterfaceGestionEmprunt gemprunt;
        public static InterfaceGestionOuvrages gouvrages;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            gemprunteurs = new GestionEmprunteurs();
            gemprunt = new GestionEmprunt();
            gouvrages = new GestionOuvrages();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Menu());
        }
    }
}