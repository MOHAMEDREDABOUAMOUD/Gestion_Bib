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
    internal class ModifierE : Form
    {
        protected List<Emprunteur> emprunteurs = Program.gemprunteurs.Emprunteurs;
        protected MetroComboBox comboBox1;
        protected TableLayoutPanel TableLayoutPanel1;
        protected FlowLayoutPanel flowLayoutPanel1;
        protected MetroLabel label0, label1, label2, label3;
        protected Label labelErr;
        protected TextBox textBox1, textBox2;
        protected MetroButton button1, button2;
        public ModifierE()
        {
            Size = new Size(450, 270);
            BackColor = Color.White;
            Text = "Modifier Etudiant";
            TableLayoutPanel1 = new TableLayoutPanel { AutoSize = true, ColumnCount = 2, RowCount = 2, Padding = new Padding(200, 0, 0, 0) };
            TableLayoutPanel1.Anchor = AnchorStyles.Left;
            label1 = new MetroLabel { Text = " Etudiant" };
            comboBox1 = new MetroComboBox { Width = 200};
            foreach (var item in emprunteurs)
            {
                comboBox1.Items.Add(item);
            }
            textBox1 = new TextBox { Width = 200 };
            label2 = new MetroLabel { Text = " Nouveau Nom ", Width = 150 };
            textBox2 = new TextBox { Width = 200 };
            label3 = new MetroLabel { Text = " Nouveau Prenom ", Width = 150 };
            labelErr = new Label { Text = "", ForeColor = System.Drawing.Color.Red, Width = 400 };
            TableLayoutPanel1.Controls.Add(label1);
            TableLayoutPanel1.Controls.Add(comboBox1);
            TableLayoutPanel1.Controls.Add(label2);
            TableLayoutPanel1.Controls.Add(textBox1);
            TableLayoutPanel1.Controls.Add(label3);
            TableLayoutPanel1.Controls.Add(textBox2);


            button1 = new MetroButton { Text = "Modifier" };
            button2 = new MetroButton { Text = "Fermer" };
            flowLayoutPanel1 = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.RightToLeft };
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Controls.Add(labelErr);
            flowLayoutPanel1.Dock = DockStyle.Bottom;

            Controls.Add(TableLayoutPanel1);
            Controls.Add(flowLayoutPanel1);
            button2.Click += Button2_Click;
            button1.Click += Button1_Click;
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
            if ((e.KeyChar < 'a' || e.KeyChar > 'z') && (e.KeyChar < 'A' || e.KeyChar > 'Z') && e.KeyChar != '\b')
            {
                e.KeyChar = '\0';
            }
        }

        public void Button1_Click(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if (comboBox1.SelectedIndex != -1 && textBox1.Text != "" && textBox2.Text != "")
            {
                Emprunteur em = (Emprunteur)comboBox1.SelectedItem;
                Program.gemprunteurs.modifierEmprunteur(em.Code, textBox1.Text, textBox2.Text);
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }
            else labelErr.Text = "Veuillez remplir tous les champs!";
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            Menu.label1.Text = "MENU";
            Close();
        }
    }
}

