using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBib.OuvrageForms
{
    internal class SupprimerO : ModifierO
    {
        TextBox textBox;
        public SupprimerO() 
        {
            textBox1.Enabled = false;
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Enabled = false;
            textBox2.BackColor = Color.White;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            BackColor= Color.White; 
            label1.Text = "Titre";
            label2.Text = "Date d'edition";
            label2.Width = 100;
            button1.Text = "Supprimer";
            textBox= new TextBox { Width=200};
            TableLayoutPanel1.Controls.Remove(dateTimePicker1);
            TableLayoutPanel1.Controls.Remove(label3);
            TableLayoutPanel2.Controls.Remove(listBox1);
            TableLayoutPanel2.Controls.Add(textBox);
            TableLayoutPanel1.Controls.Add(label3);
            TableLayoutPanel1.Controls.Add(listBox1);
            

            TableLayoutPanel2.Controls.Remove(button3);
            TableLayoutPanel2.Controls.Remove(button4);
            TableLayoutPanel2.Controls.Remove(textBox2);

            comboBox1.SelectedValueChanged += ComboBox1_SelectedValueChanged;
            button1.Click -= Button1_Click;
            button1.Click += Button1_Click1;
        }

        private void Button1_Click1(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if (comboBox1.SelectedIndex != -1)
            {
                Ouvrage o = (Ouvrage)comboBox1.SelectedItem;
                Program.gouvrages.suprimerOuvrage(o.Code);
            }
            else labelErr.Text = "*Veuillez selectionner un code";
        }

        private void ComboBox1_SelectedValueChanged(object? sender, EventArgs e)
        {
            Ouvrage o = (Ouvrage)comboBox1.SelectedItem;
            textBox.Text = o.Editdate+"";
            textBox1.Text = o.Titre;
            textBox2.Text = o.Editdate+"";
        }
    }
}
