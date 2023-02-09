using ConsoleApp1.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBib.EmprunteurForms
{
    internal class RechercherE : Form
    {
        protected MetroLabel label1, label2, label3;
        protected Label labelErr;
        protected TextBox TextBox1, textBox2, textBox3;
        protected MetroButton button1, button2;
        protected TableLayoutPanel TableLayoutPanel1;
        protected FlowLayoutPanel FlowLayoutPanel1;

        public RechercherE()
        {
            BackColor = Color.White;
            label1 = new MetroLabel { Text = " Code " };
            label2 = new MetroLabel { Text = " Nom " };
            label3 = new MetroLabel { Text = " Prenom " };
            labelErr = new Label { Text = "", ForeColor = System.Drawing.Color.Red, Width = 200, Dock = DockStyle.Bottom };
            TextBox1 = new TextBox { Width = 200 };
            textBox2 = new TextBox { Width = 200, Enabled = false, BorderStyle = BorderStyle.FixedSingle, BackColor = Color.White };
            textBox3 = new TextBox { Width = 200, Enabled = false, BorderStyle = BorderStyle.FixedSingle, BackColor = Color.White };
            TableLayoutPanel1 = new TableLayoutPanel { AutoSize = true, ColumnCount = 2, RowCount =1, Padding = new Padding(200, 0, 0, 0) };
            //TableLayoutPanel1.Dock = DockStyle.Fill ;
            TableLayoutPanel1.Anchor = AnchorStyles.Left;
            TableLayoutPanel1.Controls.Add(label1);
            TableLayoutPanel1.Controls.Add(TextBox1);
            TableLayoutPanel1.Controls.Add(label2);
            TableLayoutPanel1.Controls.Add(textBox2);
            TableLayoutPanel1.Controls.Add(label3);
            TableLayoutPanel1.Controls.Add(textBox3);

            this.Controls.Add(TableLayoutPanel1);
            this.Controls.Add(labelErr);

            button1 = new MetroButton { Text = "Fermer" };
            button2 = new MetroButton { Text = "Chercher" };
            FlowLayoutPanel1 = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.RightToLeft };
            FlowLayoutPanel1.Dock = DockStyle.Bottom;
            FlowLayoutPanel1.Controls.Add(button1);
            FlowLayoutPanel1.Controls.Add(button2);
            //FlowLayoutPanel1.Controls.Add(labelErr);
            this.Controls.Add(FlowLayoutPanel1);

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            TextBox1.KeyPress += TextBox1_KeyPress;

        }

        private void TextBox1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.KeyChar = '\0';
            }
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if (TextBox1.Text != "")
            {
                Emprunteur em = Program.gemprunteurs.rechercherEmprunteur(Int32.Parse(TextBox1.Text));
                if (em != null)
                {
                    textBox2.Text = em.Nom;
                    textBox3.Text = em.Prenom;
                }
                else
                {
                    labelErr.Text = "Etudiant introuvable";
                    TextBox1.Text = string.Empty;
                }
            }
            else labelErr.Text = "*Veuillez saisir le code de l'etudiant que vous chercher";
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            Menu.label1.Text = "MENU";
            this.Close();
        }
    }
}
