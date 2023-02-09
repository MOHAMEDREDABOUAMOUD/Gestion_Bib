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
    internal class ModifierEp : Form
    {
        Dictionary<int, List<Emprunt>> emprunts = Program.gemprunt.DictEmprunt;
        protected MetroLabel label1, label2, label3, label4;
        protected Label labelErr;
        protected MetroComboBox comboBox1, comboBox2;
        protected DateTimePicker dateTimePicker1, dateTimePicker2;
        protected MetroButton button1, button2;
        protected DataGridView DataGridView1;
        protected TableLayoutPanel TableLayoutPanel1;
        protected FlowLayoutPanel FlowLayoutPanel1;
        public ModifierEp()
        {
            BackColor = Color.White;
            label1= new MetroLabel { Text="Code Etudiant", Width=100};
            label2= new MetroLabel { Text="Code Oeuvre", Width=100 };
            label3= new MetroLabel { Text="Nouvelle date d' emprunt", Width=170 };
            label4= new MetroLabel { Text="Nouvelle date de retour", Width=170 };
            labelErr = new Label { Text = "", ForeColor = System.Drawing.Color.Red, Width = 400 };
            comboBox1 = new MetroComboBox { Width=200};
            comboBox2= new MetroComboBox { Width=200};
            foreach (var item in emprunts.Keys)
            {
                comboBox1.Items.Add(item);
            }
            
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2= new DateTimePicker();
            TableLayoutPanel1 = new TableLayoutPanel { AutoSize= true, RowCount=4, ColumnCount=2, Anchor= AnchorStyles.Left, Padding = new Padding(150, 0, 0, 0) };
            TableLayoutPanel1.Controls.Add(label1);
            TableLayoutPanel1.Controls.Add(comboBox1);
            TableLayoutPanel1.Controls.Add(label2);
            TableLayoutPanel1.Controls.Add(comboBox2);
            TableLayoutPanel1.Controls.Add(label3);
            TableLayoutPanel1.Controls.Add(dateTimePicker1);
            TableLayoutPanel1.Controls.Add(label4);
            TableLayoutPanel1.Controls.Add(dateTimePicker2);

            this.Controls.Add(TableLayoutPanel1);
            
            button1= new MetroButton { Text="Fermer"};
            button2= new MetroButton { Text="Modifier"};
            FlowLayoutPanel1= new FlowLayoutPanel { AutoSize=true, FlowDirection=FlowDirection.RightToLeft, Dock=DockStyle.Bottom};
            FlowLayoutPanel1.Controls.Add(button1);
            FlowLayoutPanel1.Controls.Add(button2);
            FlowLayoutPanel1.Controls.Add(labelErr);

            this.Controls.Add(FlowLayoutPanel1);

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void ComboBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            foreach (var ep in emprunts[int.Parse(comboBox1.SelectedItem.ToString())])
            {
                comboBox2.Items.Add(ep.CodeOuvr);
            }
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                Program.gemprunt.modifierEmprunt(
                    int.Parse(comboBox1.SelectedItem.ToString()),
                    int.Parse(comboBox2.SelectedItem.ToString()),
                    DateOnly.FromDateTime(dateTimePicker1.Value),
                    DateOnly.FromDateTime(dateTimePicker2.Value)
                    );
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
            else labelErr.Text = "*Veuiller remplir tous les champs";
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            Menu.label1.Text = "MENU";
            this.Close();
        }
    }
}
