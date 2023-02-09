using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBib.OuvrageForms
{
    internal class RechercherO : ListerO
    {
        public RechercherO()
        {
            textBox0.Enabled= true;
            textBox1.Enabled= false;
            FlowLayoutPanel1.Controls.Remove(button3);
            button2.Text = "Rechercher";
            button2.Click -= Button2_Click;
            button2.Click += Button2_Click1;

            textBox0.Clear();
            textBox1.Clear();
            textBox2.Clear();
            listBox1.Items.Clear();
            textBox0.KeyPress += TextBox0_KeyPress;
        }

        private void TextBox0_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.KeyChar = '\0';
            }
        }

        private void Button2_Click1(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if ( textBox0.Text!= "")
            {
                Ouvrage o = Program.gouvrages.rechercherOuvrage(Int32.Parse(textBox0.Text));
                if (o != null)
                {
                    textBox1.Text = o.Titre;
                    textBox2.Text = o.Editdate + "";
                    listBox1.Items.Clear();
                    foreach (var item in o.Auteurs)
                    {
                        listBox1.Items.Add(item + "");
                    }
                }
                else labelErr.Text = "*Oeuvre introuvable!";
            }
            else labelErr.Text = "*Veuillez saisir le code de l'Oeuvre";
        }
    }
}
