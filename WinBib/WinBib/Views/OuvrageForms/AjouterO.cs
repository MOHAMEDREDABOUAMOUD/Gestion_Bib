using ConsoleApp1.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinBib.EmprunteurForms;

namespace WinBib.OuvrageForms
{
    internal class AjouterO : Form
    {
        protected MetroLabel label1, label2, label3;
        protected Label labelErr;
        protected TextBox textBox1, textBox2;
        protected DateTimePicker dateTimePicker1;
        protected ListBox listBox1;
        protected MetroButton button1, button2, button3, button11, button12, button21, button22;
        protected TableLayoutPanel TableLayoutPanel1, TableLayoutPanel2;
        protected FlowLayoutPanel FlowLayoutPanel1;
        public AjouterO() 
        {
            this.BackColor = Color.White;
            label1 = new MetroLabel { Text = "Titre"};
            label2 = new MetroLabel { Text = "Date d'édition", Width =100 };
            label3 = new MetroLabel { Text = "Auteurs" };
            labelErr = new Label { Text="",ForeColor= System.Drawing.Color.Red,Width=400};
            textBox1 = new TextBox { Width = 250 };
            textBox2 = new TextBox { Width = 200 };
            dateTimePicker1 = new DateTimePicker { Width=250};
            listBox1 = new ListBox { Width=200};
            button11 = new MetroButton { Text = "+", Width = 50 };
            button12 = new MetroButton { Text = "-", Width = 50 };

            TableLayoutPanel1 = new TableLayoutPanel { AutoSize=true, RowCount = 3, ColumnCount =2, Padding = new Padding(150, 0, 0, 0) };
            TableLayoutPanel1.Anchor = AnchorStyles.Left;
            TableLayoutPanel1.Controls.Add (label1);
            TableLayoutPanel1.Controls.Add (textBox1);
            TableLayoutPanel1.Controls.Add (label2);
            TableLayoutPanel1.Controls.Add (dateTimePicker1);
            TableLayoutPanel1.Controls.Add (label3);

            TableLayoutPanel2 = new TableLayoutPanel { AutoSize = true, RowCount =2 , ColumnCount = 2 };
            //TableLayoutPanel2.Anchor = AnchorStyles.None;
            TableLayoutPanel2.Controls.Add(textBox2);
            TableLayoutPanel2.Controls.Add(button11);
            TableLayoutPanel2.Controls.Add(listBox1);
            TableLayoutPanel2.Controls.Add(button12);

            TableLayoutPanel1.Controls.Add(TableLayoutPanel2);

            this.Controls.Add(TableLayoutPanel1);

            button21 = new MetroButton { Text = "Fermer"};
            button22 = new MetroButton { Text = "Ajouter" };
            FlowLayoutPanel1= new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.RightToLeft};
            FlowLayoutPanel1.Dock = DockStyle.Bottom;
            FlowLayoutPanel1.Controls.Add (button21);
            FlowLayoutPanel1.Controls.Add (button22);
            FlowLayoutPanel1.Controls.Add (labelErr);
            this.Controls.Add (FlowLayoutPanel1);

            button21.Click += Button21_Click;
            button22.Click += Button22_Click;

            button11.Click += Button11_Click;
            button12.Click += Button12_Click;
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

        private void Button12_Click(object? sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void Button11_Click(object? sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text);
        }

        private void Button22_Click(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if (textBox1.Text != "")
            {
                if (listBox1.Items.Count > 0)
                {
                    List<string> auteurs = new List<string>();
                    foreach (var item in listBox1.Items)
                    {
                        auteurs.Add(item + "");
                    }
                    Program.gouvrages.ajouterOuvrage(textBox1.Text, DateOnly.FromDateTime(dateTimePicker1.Value), auteurs);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    listBox1.Items.Clear();
                }
                else labelErr.Text = "Une Oeuvre doit avoir un auteur";
            }
            else labelErr.Text = "*Veuillez saisir le titre de l'oeuvre";
        }

        private void Button21_Click(object? sender, EventArgs e)
        {
            Menu.label1.Text = "MENU";
            this.Close();
        }
    }
}
