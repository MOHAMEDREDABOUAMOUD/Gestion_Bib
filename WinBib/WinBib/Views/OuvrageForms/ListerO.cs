using ConsoleApp1.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WinBib.OuvrageForms
{
    internal class ListerO : Form
    {
        protected List<Ouvrage> ouvrages = Program.gouvrages.Ouvrages();

        protected MetroLabel label0, label1, label2, label3;
        protected Label labelErr;
        protected TextBox textBox0, textBox1, textBox2;
        protected ListBox listBox1;
        protected TableLayoutPanel TableLayoutPanel1;
        protected FlowLayoutPanel FlowLayoutPanel1;
        protected MetroButton button1, button2, button3;
        protected int index = 0;
        public ListerO()
        {
            BackColor = Color.White;
            label0 = new MetroLabel { Text = "Code" };
            textBox0 = new TextBox { Width = 200, Enabled=false,BackColor=Color.White, BorderStyle= BorderStyle.FixedSingle };
            label1 = new MetroLabel { Text = "Titre" };
            label2 = new MetroLabel { Text = "Date d'édition", Width = 100 };
            label3 = new MetroLabel { Text = "Auteur" };
            labelErr = new Label { Text = "", ForeColor = System.Drawing.Color.Red, Width = 400 };
            textBox1 = new TextBox { Width = 200, Enabled = false, BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
            textBox2 = new TextBox { Width = 200, Enabled = false, BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
            listBox1 = new ListBox { Width = 200, Enabled = false, BorderStyle = BorderStyle.FixedSingle };
            TableLayoutPanel1 = new TableLayoutPanel { AutoSize = true, RowCount = 4, ColumnCount = 2 , Padding = new Padding(150, 0, 0, 0) };
            TableLayoutPanel1.Anchor = AnchorStyles.Left;
            TableLayoutPanel1.Controls.Add(label0);
            TableLayoutPanel1.Controls.Add(textBox0);
            TableLayoutPanel1.Controls.Add(label1);
            TableLayoutPanel1.Controls.Add(textBox1);
            TableLayoutPanel1.Controls.Add(label2);
            TableLayoutPanel1.Controls.Add(textBox2);
            TableLayoutPanel1.Controls.Add(label3);
            TableLayoutPanel1.Controls.Add(listBox1);

            this.Controls.Add(TableLayoutPanel1);

            button1 = new MetroButton { Text = "Fermer" };
            button2 = new MetroButton { Text = ">>" };
            button3 = new MetroButton { Text = "<<" };

            FlowLayoutPanel1 = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.RightToLeft };
            FlowLayoutPanel1.Dock = DockStyle.Bottom;
            FlowLayoutPanel1.Controls.Add(button1);
            FlowLayoutPanel1.Controls.Add(button2);
            FlowLayoutPanel1.Controls.Add(button3);
            FlowLayoutPanel1.Controls.Add(labelErr);

            this.Controls.Add(FlowLayoutPanel1);
            if (ouvrages.Count > 0)
            {
                update();
            }

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
        }

        public void Button2_Click(object? sender, EventArgs e)
        {
            index++;
            if (index > ouvrages.Count - 1)
                index = 0;
            if (ouvrages.Count > 0)
                update();
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            Menu.label1.Text = "MENU";
            this.Close();
        }

        public void Button3_Click(object? sender, EventArgs e)
        {
            index--;
            if (index < 0)
                index = ouvrages.Count - 1;
            if (ouvrages.Count > 0)
                update();
        }
        void update()
        {
            Ouvrage o = ouvrages[index];
            textBox0.Text = o.Code + "";
            textBox1.Text = o.Titre;
            textBox2.Text = o.Editdate + "";
            listBox1.Items.Clear();
            foreach (var item in o.Auteurs)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}

//using ConsoleApp1.Models;
//using MetroFramework.Controls;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace WinBib.OuvrageForms
//{
//    internal class ListerO : Form
//    {
//        List<Ouvrage> ouvrages = Program.gouvrages.Ouvrages;

//        protected DataGridView DataGridView1;
//        protected TableLayoutPanel TableLayoutPanel1;
//        protected FlowLayoutPanel FlowLayoutPanel1;
//        protected MetroButton button1;
//        protected DataGridViewColumn auteurs;
//        public ListerO()
//        {
//            BackColor = Color.White;
//            Text = "Lister Oeuvres";
//            button1 = new MetroButton { Text = "Fermer" };
//            TableLayoutPanel1 = new TableLayoutPanel { AutoSize = true, AutoScroll = true, Anchor = AnchorStyles.None };
//            DataGridView1 = new DataGridView
//            {
//                RowHeadersVisible = false,
//                AutoSize = true,
//                BorderStyle = BorderStyle.None,
//                GridColor = Color.DarkCyan,
//                BackgroundColor = Color.White,
//                ScrollBars = ScrollBars.Vertical,
//                //Anchor = AnchorStyles.None,

//            };
//            DataGridViewTextBoxColumn co = new DataGridViewTextBoxColumn();
//            co.HeaderText = "Code Oeuvre";
//            co.Name = "Code Oeuvre";
//            DataGridViewTextBoxColumn titre = new DataGridViewTextBoxColumn();
//            titre.HeaderText = "Titre";
//            DataGridViewTextBoxColumn date = new DataGridViewTextBoxColumn();
//            date.HeaderText = "Date d'edition";
//            auteurs = new DataGridViewComboBoxColumn();
//            auteurs.HeaderText = "Auteurs";
//            auteurs.Name = "Auteurs";
//            DataGridView1.Columns.AddRange(co, titre, date, auteurs);

//            //auteurs.FlatStyle= FlatStyle.Flat;
//            if (ouvrages.Count > 0)
//            {
//                foreach (var item in ouvrages)
//                {
//                    DataGridView1.Rows.Add(item.Code, item.Titre, item.Editdate);
//                }
//                foreach (DataGridViewRow row in DataGridView1.Rows)
//                {
//                    DataGridViewComboBoxCell cb = new DataGridViewComboBoxCell();

//                    foreach (var item in ouvrages)
//                    {
//                        List<string> l = new List<string>();
//                        l = item.Auteurs;
//                        cb.DataSource = l;
//                    }
//                    row.Cells["Auteurs"].Value = cb;

//                }
//                //foreach (DataGridViewRow row in DataGridView1.Rows)
//                //{
//                //    DataGridViewComboBoxCell comboCell = row.Cells["Auteurs"] as DataGridViewComboBoxCell;
//                //    foreach (var item in ouvrages)
//                //    {
//                //        List<string> l = new List<string>();
//                //        l = item.Auteurs;
//                //        comboCell.DataSource = l;
//                //    }
//                //}
//            }

//            DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1;

//            TableLayoutPanel1.Controls.Add(DataGridView1);
//            this.Controls.Add(TableLayoutPanel1);
//            FlowLayoutPanel1 = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Bottom };
//            FlowLayoutPanel1.Controls.Add(button1);
//            this.Controls.Add(FlowLayoutPanel1);

//            FlowLayoutPanel1 = new FlowLayoutPanel { AutoSize= true, FlowDirection=FlowDirection.RightToLeft};
//            FlowLayoutPanel1.Dock = DockStyle.Bottom;
//            FlowLayoutPanel1.Controls.Add(button1);


//            button1.Click += Button1_Click;
//            //DataGridView1.CellStateChanged += DataGridView1_CellStateChanged;
//        }

//        //private void DataGridView1_CellStateChanged(object? sender, DataGridViewCellStateChangedEventArgs e)
//        //{
//        //    int cov;
//        //    Ouvrage o;
//        //    for (int i = 0; i < DataGridView1.Rows.Count - 1; i++)
//        //    {
//        //        cov = Convert.ToInt32(DataGridView1.Rows[i].Cells[0].Value);
//        //        o = Program.gouvrages.rechercherOuvrage(cov);
//        //        foreach (var item in o.Auteurs)
//        //        {
//        //            auteurs.Items.Add(item);
//        //        }
//        //        auteurs.Items.Clear();

//        //    }
//        //}

//        private void Button1_Click(object? sender, EventArgs e)
//        {
//            this.Close();
//        }

//    }
//}
