using ConsoleApp1.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBib.OuvrageForms
{
    internal class ModifierO : Form
    {
        protected List<Ouvrage> ouvrages = Program.gouvrages.Ouvrages();
        protected MetroComboBox comboBox1;
        protected MetroLabel label0,label1, label2, label3;
        protected Label labelErr;
        protected TextBox textBox1, textBox2;
        protected DateTimePicker dateTimePicker1;
        protected ListBox listBox1;
        protected TableLayoutPanel TableLayoutPanel1, TableLayoutPanel2;
        protected FlowLayoutPanel FlowLayoutPanel1;
        protected MetroButton button1, button2, button3, button4; 
        public ModifierO()
        {
            BackColor= Color.White;
            label0= new MetroLabel { Text="Oeuvre"};
            label1= new MetroLabel { Text="Nouveau titre"};
            label2= new MetroLabel { Text="Nouvelle date d'edition", Width=150};
            label3= new MetroLabel { Text="Auteurs"};
            labelErr = new Label { Text = "", ForeColor = System.Drawing.Color.Red, Width = 400 };
            comboBox1 = new MetroComboBox { Width =250};
            foreach (var item in ouvrages)
            {
                comboBox1.Items.Add(item);
            }
            textBox1= new TextBox { Width=250};
            textBox2= new TextBox { Width=200};
            listBox1 = new ListBox { Width=200};
            comboBox1.SelectedValueChanged += ComboBox1_SelectedValueChanged;
            dateTimePicker1= new DateTimePicker { Width=250};

            TableLayoutPanel1= new TableLayoutPanel { AutoSize=true, RowCount=4 , ColumnCount=2, Padding = new Padding(150, 0, 0, 0) };
            TableLayoutPanel1.Anchor= AnchorStyles.Left;
            TableLayoutPanel1.Controls.Add(label0);
            TableLayoutPanel1.Controls.Add(comboBox1);
            TableLayoutPanel1.Controls.Add(label1);
            TableLayoutPanel1.Controls.Add(textBox1);
            TableLayoutPanel1.Controls.Add(label2);
            TableLayoutPanel1.Controls.Add(dateTimePicker1);
            TableLayoutPanel1.Controls.Add(label3);
            TableLayoutPanel2= new TableLayoutPanel { AutoSize = true, RowCount = 2, ColumnCount = 2 };
            button3 = new MetroButton { Text = "+", Width=50 };
            button4 = new MetroButton { Text = "-", Width = 50 };
            TableLayoutPanel2.Controls.Add(textBox2);
            TableLayoutPanel2.Controls.Add(button3);
            TableLayoutPanel2.Controls.Add(listBox1);
            TableLayoutPanel2.Controls.Add(button4);
            TableLayoutPanel1.Controls.Add(TableLayoutPanel2);

            this.Controls.Add(TableLayoutPanel1);
            button1= new MetroButton { Text="Modifier"};
            button2 = new MetroButton { Text = "Fermer" };

            FlowLayoutPanel1= new FlowLayoutPanel { AutoSize=true, FlowDirection=FlowDirection.RightToLeft };
            FlowLayoutPanel1.Dock= DockStyle.Bottom;
            FlowLayoutPanel1.Controls.Add(button2); 
            FlowLayoutPanel1.Controls.Add(button1);
            FlowLayoutPanel1.Controls.Add(labelErr);

            this.Controls.Add(FlowLayoutPanel1);

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;
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

        private void Button4_Click(object? sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void Button3_Click(object? sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text);
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            Menu.label1.Text = "MENU";
            this.Close();
        }

        public void Button1_Click(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if (comboBox1.SelectedIndex != -1)
            {
                if(textBox1.Text != "")
                {   
                    if(listBox1.Items.Count > 0)
                    {
                        Ouvrage o = (Ouvrage)comboBox1.SelectedItem;
                        List<string> list = new List<string>();
                        foreach (var item in listBox1.Items)
                        {
                            list.Add(item + "");
                        }
                        Program.gouvrages.modifierOuvrage(o.Code,textBox1.Text,DateOnly.FromDateTime(dateTimePicker1.Value),list);
                    }
                    else labelErr.Text = "*Une Oeuvre doit avoir un auteur";
                }
                else labelErr.Text = "*Veuillez saisir un titre";
            }
            else labelErr.Text = "*Veuillez selectionner le code de l'Oeuvre";
        }

        private void ComboBox1_SelectedValueChanged(object? sender, EventArgs e)
        {
            Ouvrage o = (Ouvrage)comboBox1.SelectedItem;
            listBox1.Items.Clear();
            foreach (var item in o.Auteurs)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
