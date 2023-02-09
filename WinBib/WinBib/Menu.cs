using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms.Design;
using WinBib.EmprunteurForms;
using WinBib.EmpruntForms;
using WinBib.OuvrageForms;
using WinBib.Views.EmpruntForms;
using WinBib.Views.OuvrageForms;

namespace WinBib
{
    public class Menu : Form
    {
        Button btn1 = new Button { Text = "Emprunteur", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn2 = new Button { Text = "Ouvrage", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn3 = new Button { Text = "Emprunt", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn4 = new Button { Text = "Quitter", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        public static Label label1 = new Label { Width = 700, Height = 100 };
        Panel panel1 = new Panel { Width = 700, Height = 400 };
        GroupBox gbemprunteur = new GroupBox { Width = 100, Height = 250 };
        Button btn11 = new Button { Text = "Ajouter", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn5 = new Button { Text = "Lister", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn12 = new Button { Text = "Rechercher", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn13 = new Button { Text = "Modifier", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn14 = new Button { Text = "Supprimer", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        GroupBox gbouvrage = new GroupBox { Width = 100, Height = 250 };
        Button btn21 = new Button { Text = "Ajouter", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn22 = new Button { Text = "Lister", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn23 = new Button { Text = "Rechercher", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn24 = new Button { Text = "Modifier", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn25 = new Button { Text = "Supprimer", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        GroupBox gbemprunt = new GroupBox { Width = 100, Height = 250 };
        Button btn31 = new Button { Text = "Ajouter", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn30 = new Button { Text = "Lister", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn32 = new Button { Text = "Rechercher", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn33 = new Button { Text = "Modifier", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn34 = new Button { Text = "Supprimer", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        GroupBox gbouvrageR = new GroupBox { Width = 100, Height = 150 };
        Button btn231 = new Button { Text = "Par Code", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn232 = new Button { Text = "Par Titre", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn233 = new Button { Text = "Par Auteur", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        GroupBox gbempruntR = new GroupBox { Width = 100, Height = 100 };
        Button btn331 = new Button { Text = "Code Etudiant", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };
        Button btn332 = new Button { Text = "Code Oeuvre", Width = 100, Height = 50, ForeColor = Color.DarkCyan, Font = new Font("Century Gothic", 8, style: FontStyle.Bold) };

        Form lastf = null;
        public Menu()
        {
            //Size = new Size(818, 546);
            Size = new Size(900, 600);
            //BackColor = Color.FromArgb(41, 44, 51);
            BackColor = Color.White;

            this.StartPosition = FormStartPosition.CenterScreen;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("C:\\Users\\msii\\Desktop\\3eme annee\\c#\\projet Bib\\ProjetChecked\\ProjetChecked\\ProjetBib\\WinBib\\images.png");
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Height = 100;
            Controls.Add(pictureBox);

            #region 
            btn1.Location = new Point(0, 100);
            btn1.FlatStyle = FlatStyle.Flat;
            btn2.Location = new Point(btn1.Left, btn1.Bottom);
            btn2.FlatStyle = FlatStyle.Flat;
            btn3.Location = new Point(btn2.Left, btn2.Bottom);
            btn3.FlatStyle = FlatStyle.Flat;
            btn4.Location = new Point(btn3.Left, btn3.Bottom);
            btn4.FlatStyle = FlatStyle.Flat;
            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);
            Controls.Add(btn4);
            label1.Location = new Point(100, 0);
            label1.Text = "MENU";
            label1.Font = new Font("Century Gothic", 24, style: FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(label1);

            gbemprunteur.Location = new Point(btn1.Right, btn1.Top);
            btn11.FlatStyle = FlatStyle.Flat;
            btn5.FlatStyle = FlatStyle.Flat;
            btn5.Location = new Point(btn11.Left, btn11.Bottom);
            btn12.Location = new Point(btn5.Left, btn5.Bottom);
            btn12.FlatStyle = FlatStyle.Flat;
            btn13.Location = new Point(btn12.Left, btn12.Bottom);
            btn13.FlatStyle = FlatStyle.Flat;
            btn14.Location = new Point(btn13.Left, btn13.Bottom);
            btn14.FlatStyle = FlatStyle.Flat;
            gbemprunteur.Controls.Add(btn11);
            gbemprunteur.Controls.Add(btn5);
            gbemprunteur.Controls.Add(btn12);
            gbemprunteur.Controls.Add(btn13);
            gbemprunteur.Controls.Add(btn14);
            Controls.Add(gbemprunteur);

            gbouvrage.Location = new Point(btn2.Right, btn2.Top);
            btn21.FlatStyle = FlatStyle.Flat;
            btn22.Location = new Point(btn21.Left, btn21.Bottom);
            btn22.FlatStyle = FlatStyle.Flat;
            btn23.Location = new Point(btn22.Left, btn22.Bottom);
            btn23.FlatStyle = FlatStyle.Flat;
            btn24.Location = new Point(btn23.Left, btn23.Bottom);
            btn24.FlatStyle = FlatStyle.Flat;
            btn25.Location = new Point(btn24.Left, btn24.Bottom);
            btn25.FlatStyle = FlatStyle.Flat;
            gbouvrage.Controls.Add(btn21);
            gbouvrage.Controls.Add(btn22);
            gbouvrage.Controls.Add(btn23);
            gbouvrage.Controls.Add(btn24);
            gbouvrage.Controls.Add(btn25);
            Controls.Add(gbouvrage);

            gbouvrageR.Location = new Point(btn2.Right+100,btn2.Top+100);
            btn231.FlatStyle = FlatStyle.Flat;
            btn232.Location = new Point(btn231.Left, btn231.Bottom);
            btn232.FlatStyle = FlatStyle.Flat;
            btn233.Location = new Point(btn232.Left, btn232.Bottom);
            btn233.FlatStyle = FlatStyle.Flat;
            gbouvrageR.Controls.Add(btn231);
            gbouvrageR.Controls.Add(btn232);
            gbouvrageR.Controls.Add(btn233);
            Controls.Add(gbouvrageR);

            gbemprunt.Location = new Point(btn3.Right, btn3.Top);
            btn31.FlatStyle = FlatStyle.Flat;
            btn30.Location = new Point(btn31.Left,btn31.Bottom);
            btn30.FlatStyle = FlatStyle.Flat;
            btn32.Location = new Point(btn30.Left, btn30.Bottom);
            btn32.FlatStyle = FlatStyle.Flat;
            btn33.Location = new Point(btn32.Left, btn32.Bottom);
            btn33.FlatStyle = FlatStyle.Flat;
            btn34.Location = new Point(btn33.Left, btn33.Bottom);
            btn34.FlatStyle = FlatStyle.Flat;
            gbemprunt.Controls.Add(btn31);
            gbemprunt.Controls.Add(btn30);
            gbemprunt.Controls.Add(btn32);
            gbemprunt.Controls.Add(btn33);
            gbemprunt.Controls.Add(btn34);
            Controls.Add(gbemprunt);

            gbempruntR.Location= new Point(btn3.Right+100, btn3.Top+100);
            btn331.FlatStyle = FlatStyle.Flat;
            btn332.Location = new Point(btn331.Left, btn331.Bottom);
            btn332.FlatStyle = FlatStyle.Flat;
            gbempruntR.Controls.Add(btn331);
            gbempruntR.Controls.Add(btn332);
            Controls.Add(gbempruntR);

            panel1.Location = new Point(100, 100);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            PictureBox pictureBox2 = new PictureBox();
            pictureBox2.Image = Image.FromFile("C:\\Users\\msii\\Desktop\\3eme annee\\c#\\projet Bib\\ProjetChecked\\ProjetChecked\\ProjetBib\\WinBib\\bibl.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Height = panel1.Height;
            pictureBox2.Width = panel1.Width;
            panel1.Controls.Add(pictureBox2);
            Controls.Add(panel1);

            gbemprunteur.Visible = false;
            gbouvrage.Visible = false;
            gbouvrageR.Visible = false;
            gbemprunt.Visible = false;
            gbempruntR.Visible = false;
            #endregion


            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
            btn11.Click += Btn11_Click;
            btn5.Click += Btn5_Click;
            btn12.Click += Btn12_Click;
            btn13.Click += Btn13_Click;
            btn4.Click += Btn4_Click;
            btn14.Click += Btn14_Click;
            btn21.Click += Btn21_Click;
            btn22.Click += Btn22_Click;
            btn23.Click += Btn23_Click;
            btn24.Click += Btn24_Click;
            btn25.Click += Btn25_Click;
            btn31.Click += Btn31_Click;
            btn30.Click += Btn30_Click;
            btn32.Click += Btn32_Click;
            btn33.Click += Btn33_Click;
            btn34.Click += Btn34_Click;
            btn231.Click += Btn231_Click;
            btn232.Click += Btn232_Click;
            btn233.Click += Btn233_Click;
            btn331.Click += Btn331_Click;
            btn332.Click += Btn332_Click;
        }

        private void Btn332_Click(object? sender, EventArgs e)
        {
            gbemprunt.Visible = false;
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            RechercherEP2 f = new RechercherEP2();
            OpenChildForm(f, "Rechercher Emprunt par code Oeuvre");
        }

        private void Btn331_Click(object? sender, EventArgs e)
        {
            gbemprunt.Visible = false;
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            RechercherEp f = new RechercherEp();
            OpenChildForm(f, "Rechercher Emprunt par code Etudiant");
        }

        private void Btn233_Click(object? sender, EventArgs e)
        {
            gbouvrage.Visible = false;
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            RechercherO3 f = new RechercherO3();
            OpenChildForm(f, "Rechercher Oeuvre par Auteur");
        }

        private void Btn232_Click(object? sender, EventArgs e)
        {
            gbouvrage.Visible = false;
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            RechercherO2 f = new RechercherO2();
            OpenChildForm(f, "Rechercher Oeuvre par titre");
        }

        private void Btn231_Click(object? sender, EventArgs e)
        {
            gbouvrage.Visible = false;
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            RechercherO f = new RechercherO();
            OpenChildForm(f, "Rechercher Oeuvre par code");
        }

        private void Btn34_Click(object? sender, EventArgs e)
        {
            gbemprunt.Visible = false; 
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            SupprimerEp f = new SupprimerEp();
            OpenChildForm(f, "Supprimer Emprunt");
        }

        private void Btn33_Click(object? sender, EventArgs e)
        {
            gbemprunt.Visible = false; 
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            ModifierEp f = new ModifierEp();
            OpenChildForm(f, "Modifier Emprunt");
        }

        private void Btn32_Click(object? sender, EventArgs e)
        {
            if(gbempruntR.Visible==false) gbempruntR.Visible = true;
            else gbempruntR.Visible = false;
        }

        private void Btn30_Click(object? sender, EventArgs e)
        {
            gbemprunt.Visible = false;
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            ListerEp f = new ListerEp();
            OpenChildForm(f, "Lister Emprunt");
        }

        private void Btn31_Click(object? sender, EventArgs e)
        {
            gbemprunt.Visible = false; 
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            AjouterEp f = new AjouterEp();
            OpenChildForm(f, "Ajouter Emprunt");
        }

        private void Btn25_Click(object? sender, EventArgs e)
        {
            gbouvrage.Visible = false;
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            SupprimerO f = new SupprimerO();
            OpenChildForm(f, "Supprimer Oeuvre");
        }

        private void Btn24_Click(object? sender, EventArgs e)
        {
            gbouvrage.Visible = false; gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            ModifierO f = new ModifierO();
            OpenChildForm(f, "Modifier Oeuvre");
        }

        private void Btn23_Click(object? sender, EventArgs e)
        {
            if(gbouvrageR.Visible==false) gbouvrageR.Visible = true;
            else gbouvrageR.Visible = false;
        }

        private void Btn22_Click(object? sender, EventArgs e)
        {
            gbouvrage.Visible = false; 
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            ListerO f = new ListerO();
            OpenChildForm(f, "Lister Oeuvre");
        }

        private void Btn21_Click(object? sender, EventArgs e)
        {
            gbouvrage.Visible = false; 
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            AjouterO f = new AjouterO();
            OpenChildForm(f, "Ajouter Oeuvre");
        }

        private void Btn14_Click(object? sender, EventArgs e)
        {
            gbemprunteur.Visible = false; 
            gbouvrageR.Visible = false;
            Supprimer f = new Supprimer();
            OpenChildForm(f, "Supprimer Etudiant");
        }

        private void Btn13_Click(object? sender, EventArgs e)
        {
            gbemprunteur.Visible = false; 
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            ModifierE f = new ModifierE();
            OpenChildForm(f, "Modifier Etudiant");
        }

        private void Btn5_Click(object? sender, EventArgs e)
        {
            gbemprunteur.Visible = false; 
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            Lister f = new Lister();
            OpenChildForm(f, "Lister Etudiant");
        }

        private void Btn12_Click(object? sender, EventArgs e)
        {
            gbemprunteur.Visible = false; 
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            RechercherE f = new RechercherE();
            OpenChildForm(f, "Chercher Etudiant");
        }

        private void Btn4_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn11_Click(object? sender, EventArgs e)
        {
            gbemprunteur.Visible = false;
            gbouvrageR.Visible = false;
            gbempruntR.Visible = false;
            AjouterE f = new AjouterE();
            OpenChildForm(f, "Ajouter Etudiant");
        }

        private void Btn3_Click(object? sender, EventArgs e)
        {
            if (gbemprunt.Visible == false)
            {
                gbemprunteur.Visible = false; 
                gbouvrageR.Visible = false;
                gbempruntR.Visible = false;
                gbouvrage.Visible = false;
                gbemprunt.Visible = true;
            }
            else
            {
                gbemprunt.Visible = false;
            }
        }

        private void Btn2_Click(object? sender, EventArgs e)
        {
            if (gbouvrage.Visible == false)
            {
                gbemprunt.Visible = false; 
                gbouvrageR.Visible = false;
                gbempruntR.Visible = false;
                gbemprunteur.Visible = false;
                gbouvrage.Visible = true;
            }
            else
            {
                gbouvrage.Visible = false;
            }
        }

        private void Btn1_Click(object? sender, EventArgs e)
        {
            if (gbemprunteur.Visible == false)
            {
                gbouvrage.Visible = false; 
                gbouvrageR.Visible = false;
                gbempruntR.Visible = false;
                gbemprunt.Visible = false;
                gbemprunteur.Visible = true;
            }
            else
            {
                gbemprunteur.Visible = false;
            }
        }

        public void OpenChildForm(Form childForm, string title)
        {
            if(lastf!=null) lastf.Close();
            lastf = childForm;
            label1.Text = title;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
