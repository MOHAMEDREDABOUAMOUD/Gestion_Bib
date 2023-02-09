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
    internal class AjouterEp : Form
    {
        DateTimePicker DateTimePicker1, DateTimePicker2;
        MetroLabel label1, label2, label3, label4;
        protected Label labelErr;
        MetroButton button1, button2;
        ComboBox comboBox1, comboBox2;
        TableLayoutPanel TableLayoutPanel1;
        FlowLayoutPanel FlowLayoutPanel1;
        List<Ouvrage> ouvrages = Program.gouvrages.Ouvrages();
        List<Emprunteur> emprunteurs = Program.gemprunteurs.Emprunteurs;

        public AjouterEp()
        {
            BackColor = Color.White;
            label1 = new MetroLabel { Text="Etudiant"};
            label2 = new MetroLabel { Text="Oeuvre"};
            label3 = new MetroLabel { Text = "Date d'emprunt", Width=120 };
            label4 = new MetroLabel { Text = "Date de retour", Width = 120 };
            labelErr = new Label { Text = "", ForeColor = System.Drawing.Color.Red, Width = 200 };

            comboBox1 = new ComboBox { Width =200};
            foreach (var item in emprunteurs)
            {
                comboBox1.Items.Add(item.Code);
            }
            comboBox2 = new ComboBox { Width =200};
            foreach (var item in ouvrages)
            {
                comboBox2.Items.Add(item.Code);
            }

            DateTimePicker1 = new DateTimePicker();
            DateTimePicker2 = new DateTimePicker();

            TableLayoutPanel1 = new TableLayoutPanel { AutoSize= true, RowCount=4, ColumnCount=2 , Padding = new Padding(150, 0, 0, 0) };
            TableLayoutPanel1.Anchor = AnchorStyles.Left;
            TableLayoutPanel1.Controls.Add(label1);
            TableLayoutPanel1.Controls.Add(comboBox1);
            TableLayoutPanel1.Controls.Add(label2);
            TableLayoutPanel1.Controls.Add(comboBox2);
            TableLayoutPanel1.Controls.Add(label3);
            TableLayoutPanel1.Controls.Add(DateTimePicker1);
            TableLayoutPanel1.Controls.Add(label4);
            TableLayoutPanel1.Controls.Add(DateTimePicker2);

            this.Controls.Add(TableLayoutPanel1);

            FlowLayoutPanel1 = new FlowLayoutPanel { AutoSize=true  , FlowDirection=FlowDirection.RightToLeft};
            FlowLayoutPanel1.Dock = DockStyle.Bottom;
            button1 = new MetroButton { Text = "Fermer" };
            button2 = new MetroButton { Text = "Ajouter" };
            FlowLayoutPanel1.Controls.Add(button1); 
            FlowLayoutPanel1.Controls.Add(button2);
            FlowLayoutPanel1.Controls.Add(labelErr);

            this.Controls.Add(FlowLayoutPanel1);

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                if (Program.gemprunt.rechercherEmpruntEO(int.Parse(comboBox1.SelectedItem.ToString()), int.Parse(comboBox2.SelectedItem.ToString())) == null)
                {
                    Program.gemprunt.ajouterEmprunt(
                        int.Parse(comboBox1.SelectedItem.ToString()),
                        int.Parse(comboBox2.SelectedItem.ToString()),
                        DateOnly.FromDateTime(DateTimePicker1.Value),
                        DateOnly.FromDateTime(DateTimePicker2.Value)
                        );
                }
                else labelErr.Text = "*Cet emprunt existe deja";
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
            else labelErr.Text = "*Veuillez remplir tous les champs";
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            Menu.label1.Text = "MENU";
            this.Close();
        }
    }
}
