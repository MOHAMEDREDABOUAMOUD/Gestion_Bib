using ConsoleApp1.Models;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WinBib.OuvrageForms;

namespace WinBib.Views.OuvrageForms
{
    internal class RechercherO2 : ListerO
    {
        MetroButton buttonR;
        FlowLayoutPanel flowLayout;
        public RechercherO2()
        {
            index = 0;
            textBox0.Clear();
            textBox1.Clear();
            textBox2.Clear();
            listBox1.Items.Clear();
            textBox1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            buttonR= new MetroButton { Text = "Rechercher", Width=80,Height=24};
            base.Controls.Remove(FlowLayoutPanel1);
            FlowLayoutPanel1.Controls.Remove(labelErr);
            FlowLayoutPanel1.Controls.Add(buttonR);
            FlowLayoutPanel1.Controls.Add(labelErr);
            base.Controls.Add(FlowLayoutPanel1);
            //flowLayout = new FlowLayoutPanel { AutoSize = true, Dock = DockStyle.Right };
            //flowLayout.Controls.Add(buttonR);
            //TableLayoutPanel1.Controls.Add(flowLayout);
            buttonR.Click += ButtonR_Click;
            textBox0.KeyPress += TextBox0_KeyPress;
            
        }

        private void TextBox0_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.KeyChar = '\0';
            }
        }

        private void ButtonR_Click(object? sender, EventArgs e)
        {
            labelErr.Text = "";
            if (textBox1.Text != "")
            {
                ouvrages = Program.gouvrages.rechercherOuvrageT(textBox1.Text);
                if (ouvrages != null)
                {
                    button2.Enabled = true;
                    button3.Enabled = true;
                    foreach (var item in ouvrages)
                    {
                        textBox0.Text = item.Code.ToString();
                        textBox2.Text = item.Editdate + "";
                        listBox1.Items.Clear();
                        foreach (var a in item.Auteurs)
                        {
                            listBox1.Items.Add(a + "");
                        }
                    }

                }
                else
                {
                    button2.Enabled = false;
                    button3.Enabled = false;
                    labelErr.Text = "*Oeuvre introuvable!";
                    textBox0.Clear();
                    textBox2.Clear();
                    listBox1.Items.Clear();
                }
            }
            else labelErr.Text = "*Veuillez saisir le titre de l'Oeuvre";
        }
    }

}

                