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
    internal class AjouterE : Form
    {
        //protected static List<Emprunteur> etudiants= new List<Emprunteur>();
        protected TableLayoutPanel TableLayoutPanel1;
        protected FlowLayoutPanel flowLayoutPanel1;
        protected MetroLabel label1, label2, label0;
        protected Label labelErr;
        protected TextBox textBox1, textBox2;

        protected MetroButton button1, button2;
        public AjouterE()
        {
            Size = new Size(400, 200);
            BackColor = Color.White;


            TableLayoutPanel1 =  new TableLayoutPanel { AutoSize = true, ColumnCount = 2, RowCount = 3, Padding = new Padding(200, 0, 0, 0) };
            //TableLayoutPanel1.Dock = DockStyle.Fill;
            TableLayoutPanel1.Anchor = AnchorStyles.Left;
            label1 = new MetroLabel { Text = " Nom " };
            textBox1 = new TextBox { Width = 200 };
            textBox2 = new TextBox { Width = 200 };
            label2 = new MetroLabel { Text = " Prenom " };
            labelErr = new Label { Text = "", ForeColor = Color.Red, Width = 200, Anchor=AnchorStyles.Bottom};
            TableLayoutPanel1.Controls.Add(label1);
            TableLayoutPanel1.Controls.Add(textBox1);
            TableLayoutPanel1.Controls.Add(label2);
            TableLayoutPanel1.Controls.Add(textBox2);
            //TableLayoutPanel1.Controls.Add(labelErr);

            button1 = new MetroButton { Text = "Ajouter" };
            button2 = new MetroButton { Text = "Fermer" };
            flowLayoutPanel1 = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.RightToLeft };
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            //flowLayoutPanel1.Anchor = AnchorStyles.Bottom;
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(button1);
            //flowLayoutPanel1.Controls.Add(labelErr);

            Controls.Add(TableLayoutPanel1);
            Controls.Add(labelErr);
            Controls.Add(flowLayoutPanel1);

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;

            textBox1.KeyPress += TextBox1_KeyPress;
            textBox2.KeyPress += TextBox2_KeyPress;
        }

        private void TextBox2_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'a' || e.KeyChar > 'z') && (e.KeyChar < 'A' || e.KeyChar > 'Z') && e.KeyChar != '\b')
            {
                e.KeyChar = '\0';
            }
        }

        private void TextBox1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if((e.KeyChar < 'a' || e.KeyChar > 'z') && (e.KeyChar < 'A' || e.KeyChar > 'Z') && e.KeyChar!='\b' )
            {
                e.KeyChar = '\0';
            }
        }

        public void Button2_Click(object? sender, EventArgs e)
        {
            Menu.label1.Text = "MENU";
            Close();
        }

        public void Button1_Click(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Program.gemprunteurs.ajouterEmprunteur(textBox1.Text, textBox2.Text);
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else labelErr.Text = "*Veuillez remplir tous les champs!";
        }
    }
}
