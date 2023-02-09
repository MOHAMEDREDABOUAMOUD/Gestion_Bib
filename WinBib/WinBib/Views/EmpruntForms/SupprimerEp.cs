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
    internal class SupprimerEp : Form
    {
        Dictionary<int, List<Emprunt>> emprunts = Program.gemprunt.DictEmprunt;
        protected MetroLabel label1, label2;
        protected Label labelErr;
        protected MetroComboBox comboBox1;
        protected MetroButton button1, button2, button3;
        protected DataGridView DataGridView1;
        protected TableLayoutPanel TableLayoutPanel1, TableLayoutPanel2;
        protected FlowLayoutPanel FlowLayoutPanel1;
        protected int codeo;
        public SupprimerEp()
        {
            BackColor = Color.White;
            label1= new MetroLabel { Text="Code Etudiant"};
            label2= new MetroLabel { Text="Emprunts"};
            labelErr = new Label { Text = "", ForeColor = System.Drawing.Color.Red, Width = 400 };

            comboBox1 = new MetroComboBox { Width = 200 };
            foreach (var item in emprunts.Keys)
            {
                comboBox1.Items.Add(item);
            }
            DataGridView1 = new DataGridView
            {
                AutoSize = true,
                BorderStyle = BorderStyle.None,
                GridColor = Color.DarkCyan,
                BackgroundColor = Color.White,
                RowHeadersVisible = false
            };
            DataGridView1.ColumnCount = 3;
            DataGridView1.Columns[0].Name = "Code Oeuvre";
            DataGridView1.Columns[1].Name = "Date d'emprunt";
            DataGridView1.Columns[2].Name = "Date de retour";

            TableLayoutPanel1 = new TableLayoutPanel { AutoSize= true, RowCount=2, ColumnCount=2, Anchor = AnchorStyles.Left,Padding=new Padding(50,0,0,0) };
            TableLayoutPanel1.Controls.Add(label1);
            TableLayoutPanel1.Controls.Add(comboBox1);
            TableLayoutPanel1.Controls.Add(label2);

            button3 = new MetroButton { Text = "-", Width=30};
            TableLayoutPanel2 = new TableLayoutPanel { AutoSize = true, RowCount = 1, ColumnCount=2};
            TableLayoutPanel2.Controls.Add(DataGridView1);
            TableLayoutPanel2.Controls.Add(button3);

            TableLayoutPanel1.Controls.Add(TableLayoutPanel2);

            this.Controls.Add(TableLayoutPanel1);

            button1 = new MetroButton { Text = "Fermer" };
            button2 = new MetroButton { Text = "Supprimer Tout", Width=100 };

            FlowLayoutPanel1= new FlowLayoutPanel { AutoSize=true, FlowDirection=FlowDirection.RightToLeft, Dock=DockStyle.Bottom};
            FlowLayoutPanel1.Controls.Add(button1);
            FlowLayoutPanel1.Controls.Add(button2);
            FlowLayoutPanel1.Controls.Add(labelErr);
            this.Controls.Add(FlowLayoutPanel1);

            comboBox1.SelectedValueChanged += ComboBox1_SelectedValueChanged;
            button3.Click += Button3_Click;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            DataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            codeo=int.Parse(DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            MessageBox.Show(codeo.ToString());
        }

        private void ComboBox1_SelectedValueChanged(object? sender, EventArgs e)
        {
            DataGridView1.Rows.Clear();
            foreach (var item in emprunts[int.Parse(comboBox1.SelectedItem.ToString())])
            {
                DataGridView1.Rows.Add(item.CodeOuvr, item.EmpruntDate, item.RetourDate);
            }
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if (comboBox1.SelectedIndex != -1)
            {
                Program.gemprunt.suprimerEmprunt(int.Parse(comboBox1.SelectedItem.ToString()));
            }
            else labelErr.Text = "*Veuillez selectionner un etudiant";
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            Menu.label1.Text = "MENU";
            this.Close();
        }

        private void Button3_Click(object? sender, EventArgs e)
        {
            DataGridView1.Rows.Clear();
            if(emprunts.Count >0)
            {
                if(comboBox1.SelectedIndex!= -1)
                {
                    if (DataGridView1.SelectedCells != null)
                    {
                        Program.gemprunt.suprimerEmprunt(int.Parse(comboBox1.SelectedItem.ToString()), codeo);
                    }
                    else labelErr.Text = "*Veuillez selectionner un emprunt a supprimer";
                }else labelErr.Text = "*Veuillez selectionner un etudiant";

                DataGridView1.Rows.Clear();
                foreach (var item in emprunts[int.Parse(comboBox1.SelectedItem.ToString())])
                {
                    DataGridView1.Rows.Add(item.CodeOuvr, item.EmpruntDate, item.RetourDate);
                }
            }
        }
    }
}
