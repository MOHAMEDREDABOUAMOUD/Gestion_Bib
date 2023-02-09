using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBib.EmprunteurForms
{
    internal class Supprimer : ModifierE
    {
        public Supprimer() 
        {
            this.Size = new Size(450, 270);
            this.BackColor = Color.White;
            this.Text = "Supprimer Etudiant";
            button1.Text = "Supprimer";
            TableLayoutPanel1.Controls.Remove(label3);
            TableLayoutPanel1.Controls.Remove(label2);
            TableLayoutPanel1.Controls.Remove(textBox1);
            TableLayoutPanel1.Controls.Remove(textBox2);

            button1.Click -= Button1_Click;
            button1.Click += Button1_Click1;

        }

        private void Button1_Click1(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if (comboBox1.SelectedIndex != -1)
            {
                Emprunteur em = (Emprunteur)comboBox1.SelectedItem;
                Program.gemprunteurs.suprimerEmprunteur(em.Code);
            }
            else labelErr.Text = "*Veuillez selectionner un etudiant";
        }
    }
}
