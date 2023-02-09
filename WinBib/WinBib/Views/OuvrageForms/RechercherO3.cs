using ConsoleApp1.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Label = System.Windows.Forms.Label;

namespace WinBib.Views.OuvrageForms
{
    internal class RechercherO3 : Form
    {
        protected MetroLabel label1, label2;
        protected TextBox TextBox1;
        protected Label labelErr;
        protected DataGridView DataGridView1;
        protected TableLayoutPanel TableLayoutPanel1;
        protected FlowLayoutPanel FlowLayoutPanel1;
        protected MetroButton button1, button2;

        public RechercherO3()
        {
            BackColor= Color.White;
            label1 = new MetroLabel { Text = "Auteur"};
            label2 = new MetroLabel { Text = "Oeuvres"};
            labelErr = new Label { Text = "", ForeColor = System.Drawing.Color.Red, Width = 400 };
            TextBox1 = new TextBox { Width = 200 };
            DataGridView1 = new DataGridView
            {
                RowHeadersVisible = false,
                //AutoSize = true,
                Width = 530,
                Height = 100,
                ColumnCount = 3,
                BorderStyle = BorderStyle.None,
                GridColor = Color.DarkCyan,
                BackgroundColor = Color.White,
                //Enabled = false
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true
            };

            DataGridView1.Columns[0].Name = "Code Oeuvre";
            DataGridView1.Columns[1].Name = "Titre";
            DataGridView1.Columns[2].Name = "Date d'édition";
            
            TableLayoutPanel1 = new TableLayoutPanel { AutoSize = true, RowCount = 2, ColumnCount = 2 , Padding = new Padding(150, 0, 0, 0) };
            TableLayoutPanel1.Anchor = AnchorStyles.Left;
            TableLayoutPanel1.Controls.Add(label1);
            TableLayoutPanel1.Controls.Add(TextBox1);
            TableLayoutPanel1.Controls.Add(label2);
            TableLayoutPanel1.Controls.Add(DataGridView1);
            button1 = new MetroButton { Text = "Fermer" };
            button2 = new MetroButton { Text = "Rechercher" };
            FlowLayoutPanel1 = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Bottom };
            FlowLayoutPanel1.Controls.Add(button1);
            FlowLayoutPanel1.Controls.Add(button2);
            FlowLayoutPanel1.Controls.Add(labelErr);

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            TextBox1.KeyPress += TextBox1_KeyPress;
            this.Controls.Add(TableLayoutPanel1);
            this.Controls.Add(FlowLayoutPanel1);
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            Menu.label1.Text = "MENU";
            this.Close();
        }

        private void TextBox1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'a' || e.KeyChar > 'z') && (e.KeyChar < 'A' || e.KeyChar > 'Z') && e.KeyChar != '\b')
            {
                e.KeyChar = '\0';
            }
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            DataGridView1.Rows.Clear();
            if (TextBox1.Text != "")
            {
                List<Ouvrage> o = Program.gouvrages.rechercherOuvrageA(TextBox1.Text);
                if (o != null)
                {
                    labelErr.Text = "";
                    foreach (var item in o)
                    {
                        DataGridView1.Rows.Add(item.Code, item.Titre, item.Editdate);
                    }
                }
                else
                {
                    labelErr.Text = "*Oeuvre introuvable!";
                    DataGridView1.Rows.Clear();
                }
            }
            else
            { 
                DataGridView1.Rows.Clear();
                labelErr.Text = "*Veuillez saisir le nom de l'auteur";
            }
        }

    }
}
