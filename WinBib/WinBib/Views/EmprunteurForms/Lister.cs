using ConsoleApp1.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinBib.EmprunteurForms
{
    internal class Lister : Form
    {
        List<Emprunteur> emprunteurs = Program.gemprunteurs.Emprunteurs;
        protected MetroLabel Label1;
        protected DataGridView DataGridView1;
        protected MetroButton button1;
        TableLayoutPanel TableLayoutPanel1;
        FlowLayoutPanel FlowLayoutPanel1;
        public Lister()
        {
            BackColor = Color.White;
            Text = "Lister Etudiants";
            button1 = new MetroButton { Text = "Fermer"};
            TableLayoutPanel1 = new TableLayoutPanel { AutoSize= true, AutoScroll= true , Anchor=AnchorStyles.Left, Padding = new Padding(200, 0, 0, 0) };
            DataGridView1 = new DataGridView
            {
                RowHeadersVisible = false,
                //AutoSize = true,
                Width = 530,
                Height = 100,
                BorderStyle = BorderStyle.None,
                GridColor = Color.DarkCyan,
                BackgroundColor = Color.White,
                ScrollBars=ScrollBars.Vertical,
                //Anchor = AnchorStyles.None,

                //nabled = false
                ReadOnly = true,
            };
            DataGridView1.ColumnCount = 3;
            DataGridView1.Columns[0].Name = "Code Etudiant";
            DataGridView1.Columns[1].Name = "Nom";
            DataGridView1.Columns[2].Name = "Prenom";
            DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1;
            if (emprunteurs.Count > 0)
            {
                foreach (var item in emprunteurs)
                {
                    DataGridView1.Rows.Add(item.Code, item.Nom, item.Prenom);
                }
            }
            TableLayoutPanel1.Controls.Add(DataGridView1);
            this.Controls.Add(TableLayoutPanel1);
            FlowLayoutPanel1 = new FlowLayoutPanel { AutoSize= true, FlowDirection = FlowDirection.RightToLeft, Dock=DockStyle.Bottom }; 
            FlowLayoutPanel1.Controls.Add(button1);
            this.Controls.Add(FlowLayoutPanel1);

            button1.Click += Button1_Click;
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            Menu.label1.Text = "MENU";
            this.Close();
        }
    }
}
