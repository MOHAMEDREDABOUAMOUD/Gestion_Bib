using ConsoleApp1.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBib.EmpruntForms
{
    internal class ListerEp : Form
    {
        Dictionary<int, List<Emprunt>> emprunts = Program.gemprunt.DictEmprunt;
        protected MetroLabel label1, label2;
        protected TextBox TextBox1;
        protected MetroButton button1;
        protected DataGridView DataGridView1;
        protected TableLayoutPanel TableLayoutPanel1;
        protected FlowLayoutPanel FlowLayoutPanel1;
        public ListerEp() 
        {
            BackColor=Color.White;
            label1= new MetroLabel { Text= "Code Etudiant", Width=100};
            label2= new MetroLabel { Text= "Emprunts", Width=100};
            TextBox1= new TextBox { Width=200};

            DataGridView1 = new DataGridView {
                RowHeadersVisible = false,
                //AutoSize = true,
                Width = 530,
                Height = 100,
                BorderStyle = BorderStyle.None,
                GridColor = Color.DarkCyan,
                BackgroundColor = Color.White,
                //Enabled = false,
                ScrollBars=ScrollBars.Vertical,
                ReadOnly=true
            };
            DataGridView1.ColumnCount = 4;
            DataGridView1.Columns[0].Name = "Code Etudiant";
            DataGridView1.Columns[1].Name = "Code Oeuvre";
            DataGridView1.Columns[2].Name = "Date d'emprunt";
            DataGridView1.Columns[3].Name = "Date de retour";

            //VScrollBar s = new VScrollBar();
            //DataGridView1.Controls.Add(s);
            //s.Dock = DockStyle.Right;
            //s.Width = 20;
            //s.Height = 100;


            //DataGridViewTextBoxColumn ce = new DataGridViewTextBoxColumn();
            //ce.HeaderText = "Code Etudiant";
            //DataGridViewTextBoxColumn co = new DataGridViewTextBoxColumn();
            //co.HeaderText = "Code Oeuvre";
            //DataGridViewTextBoxColumn de = new DataGridViewTextBoxColumn();
            //de.HeaderText = "Date d'emprunt";
            //DataGridViewTextBoxColumn dr = new DataGridViewTextBoxColumn();
            //dr.HeaderText = "Date de retour";
            //DataGridView1.Columns.AddRange(ce,co, de, dr);
            if(emprunts.Count> 0 )
            {
                foreach (var item in emprunts)
                {
                    //DataGridView1.Rows.Add(item.Key);
                    foreach (var e in emprunts[item.Key])
                    {
                        DataGridView1.Rows.Add(item.Key, e.CodeOuvr, e.EmpruntDate, e.RetourDate);
                    }
                }

            }
            TableLayoutPanel1 = new TableLayoutPanel { AutoSize = true, RowCount = 1, ColumnCount = 1 ,Padding=new Padding(100,0,0,0)};
            TableLayoutPanel1.Anchor = AnchorStyles.Left;
            //TableLayoutPanel1.Controls.Add(label1);
            //TableLayoutPanel1.Controls.Add(TextBox1);
            //TableLayoutPanel1.Controls.Add(label2);
            TableLayoutPanel1.Controls.Add(DataGridView1);
            this.Controls.Add(TableLayoutPanel1);

            FlowLayoutPanel1= new FlowLayoutPanel { AutoSize=true, FlowDirection= FlowDirection.RightToLeft };
            FlowLayoutPanel1.Dock= DockStyle.Bottom;
            button1 = new MetroButton { Text = "Fermer" };
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
