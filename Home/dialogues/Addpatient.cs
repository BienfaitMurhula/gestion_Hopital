using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Home.Classes;

namespace Home.dialogues
{
    public partial class Addpatient : Form
    {
        public Addpatient()
        {
            InitializeComponent();
            //gunaTextBox1.Text = n;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void Addpatient_Load(object sender, EventArgs e)
        {

        }
        int ID;
        public void charger(string n, string post, string pr, string et, string se, string da, string li, string ad, string tel, string em, string gr, string pro, string rel, string me, string re, string ty, string na, string vi,  int idi, byte []  photo)
        {
            Nom.Text = n;
            Postnom.Text = post;
            Prenom.Text = pr;
            sexe.Text = se;
            Etat.Text = et;
            date.Text = da;
            Lieu.Text = li;
            Adresse.Text = ad;
            groupe.Text = gr;
            Telephone.Text = tel;
            Hopital.Text = pro;
            Religion.Text = rel;
            Medecin.Text = me;
            dater.Text = re;
            type.Text = ty;
            Email.Text = em;
            Nationalite.Text = na;
            Residence.Text = vi;
            ID = idi;

            MemoryStream ms = new MemoryStream();
            byte [] picture = photo;
            ms.Write(picture, 0, picture.Length);
            gunaPictureBox1.Image = new System.Drawing.Bitmap(ms);
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dl = new OpenFileDialog();
                dl.InitialDirectory = "C:\\";
                dl.FilterIndex = 2;
                dl.Filter = "JPEG | *.jpg";
                dl.RestoreDirectory = true;
                if (dl.ShowDialog() == DialogResult.OK)
                {
                    gunaPictureBox1.Image = Image.FromFile(dl.FileName);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("echec de charger la photo " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            traitement.getinstance().insertion(Nom.Text, Postnom.Text, Prenom.Text, sexe.Text, Etat.Text, date, Lieu.Text, Adresse.Text, Telephone.Text, groupe.Text, Hopital.Text, Religion.Text, Medecin.Text, dater, type.Text, Email.Text, Nationalite.Text, Residence.Text,gunaPictureBox1);
        }
    }
}
