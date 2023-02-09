using ConsoleApp1.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinBib.EmpruntForms
{
    internal class RechercherEp : Form
    {
        protected Dictionary<int, List<Emprunt>> emprunts = Program.gemprunt.DictEmprunt;
        protected MetroLabel label1, label2;
        protected Label labelErr;
        protected MetroComboBox comboBox1;
        protected MetroButton button1, button2;
        protected DataGridView DataGridView1;
        protected TableLayoutPanel TableLayoutPanel1;
        protected FlowLayoutPanel FlowLayoutPanel1;
        int index = 0;
        public RechercherEp()
        {
            BackColor = Color.White;
            label1 = new MetroLabel { Text = "Code Etudiant", Width = 100 };
            label2 = new MetroLabel { Text = "Emprunts", Width = 100 };
            labelErr = new Label { Text = "", ForeColor = System.Drawing.Color.Red, Width = 200, Dock=DockStyle.Bottom };
            comboBox1 = new MetroComboBox { Width = 200 };
            foreach (var item in emprunts.Keys)
            {
                comboBox1.Items.Add(item);
            }

            DataGridView1 = new DataGridView
            {
                //AutoSize = true,
                Width = 530,
                Height = 100,
                RowHeadersVisible = false,
                BorderStyle = BorderStyle.None,
                GridColor = Color.DarkCyan,
                BackgroundColor = Color.White,
                //Enabled = false
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true
            };

            DataGridView1.ColumnCount = 3;
            DataGridView1.Columns[0].Name= "Code Oeuvre";
            DataGridView1.Columns[1].Name= "Date d'emprunt";
            DataGridView1.Columns[2].Name= "Date de retour";

            TableLayoutPanel1 = new TableLayoutPanel { AutoSize = true, RowCount = 2, ColumnCount = 2, Padding = new Padding(50, 0, 0, 0) };
            TableLayoutPanel1.Anchor = AnchorStyles.Left;
            TableLayoutPanel1.Controls.Add(label1);
            TableLayoutPanel1.Controls.Add(comboBox1);
            TableLayoutPanel1.Controls.Add(label2);
            TableLayoutPanel1.Controls.Add(DataGridView1);
            this.Controls.Add(TableLayoutPanel1);
            this.Controls.Add(labelErr);

            FlowLayoutPanel1 = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.RightToLeft };
            FlowLayoutPanel1.Dock = DockStyle.Bottom;

            button1 = new MetroButton { Text = "Fermer" };
            button2 = new MetroButton { Text = "Rechercher" };
            //FlowLayoutPanel1.Controls.Add(labelErr);

            FlowLayoutPanel1.Controls.Add(button1);
            FlowLayoutPanel1.Controls.Add(button2);
            this.Controls.Add(FlowLayoutPanel1);

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;

        }

        public void Button2_Click(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if (comboBox1.SelectedIndex != -1)
            {
                List<Emprunt> ep = Program.gemprunt.rechercherEmpruntE(Int32.Parse(comboBox1.SelectedItem.ToString()));
                if (ep != null)
                {
                    foreach (var item in ep)
                    {
                        DataGridView1.Rows.Add(item.CodeOuvr, item.EmpruntDate, item.RetourDate);
                    }
                }
            }
            else labelErr.Text = "*Veuillez selectionner un emprunt";
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            Menu.label1.Text = "MENU";
            this.Close();
        }
    }
}
