using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinBib.EmpruntForms;

namespace WinBib.Views.EmpruntForms
{
    internal class RechercherEP2 : RechercherEp
    {

        public RechercherEP2()
        {
            label1.Text = "Code Oeuvre";
            comboBox1.Items.Clear();
            foreach (var item in emprunts.Values)
            {
                foreach (var ep in item)
                {
                    comboBox1.Items.Add(ep.CodeOuvr);
                }
            }
            DataGridView1.Columns[0].Name = "Code Etudiant";
            button2.Click -= Button2_Click;
            button2.Click += Button2_Click1;

        }

        private void Button2_Click1(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if (comboBox1.SelectedIndex != -1)
            {
                List<Emprunt> ep = Program.gemprunt.rechercherEmpruntO(Int32.Parse(comboBox1.SelectedItem.ToString()));
                if (ep != null)
                {
                    foreach (var item in ep)
                    {
                        DataGridView1.Rows.Add(item.CodeEtud, item.EmpruntDate, item.RetourDate);
                    }
                }
            }
            else labelErr.Text = "*Veuillez selectionner un emprunt";
        }
    }
}
