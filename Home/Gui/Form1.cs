using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Home.Classes;
using Home.userControl;
namespace Home
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            Menuok();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            
        }
        public void Menuok()
        {
            Menupatient.Visible = false;
           logistique.Visible = false;
            rendezvous.Visible = false;
           finance.Visible = false;
            panel4.Visible = false;
            parametre.Visible = false;
            Exa.Visible = false;
        }
        public void CacherMenu()
        {
            if (Menupatient.Visible == true)
                Menupatient.Visible = false;
            if (panel4.Visible == true)
                panel4.Visible = false;
            if (logistique.Visible == true)
                logistique.Visible = false;
            if (rendezvous.Visible == true)
                rendezvous.Visible = false;
            if (finance.Visible == true)
                finance.Visible = false;
            if (parametre.Visible == true)
                parametre.Visible = false;
            if (Exa.Visible == true)
                Exa.Visible = false;
        }
        public void afficheMenu(Panel panel)
        {
            if (panel.Visible == false)
            {
                CacherMenu();
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //afficheMenu(Menupatient);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new patient());
        }

        private void button4_Click(object sender, EventArgs e)
        {                                                                                
            traitement.getinstance().Appel(pan, new consulta());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new laboratoire());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new aptitude());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new Deces());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //traitement.getinstance().Appel(pan, new ());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //afficheMenu(panel4);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //afficheMenu(panel6);
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            afficheMenu(Menupatient);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            afficheMenu(panel4);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            afficheMenu(rendezvous);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            afficheMenu(finance);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            afficheMenu(logistique);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            afficheMenu(parametre);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new patient());
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new Medicament());
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new prescription());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new aptitude());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new attestation());
        }

        private void button18_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new naissance());
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new Note());
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new Ordonnance());
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            afficheMenu(finance);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            afficheMenu(rendezvous);
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            afficheMenu(logistique);
        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            afficheMenu(parametre);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            afficheMenu(Exa);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new Deces());
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new reference());
        }

        private void button37_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new Ecographie());
        }

        private void button39_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new Imagerie());
        }

        private void button23_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new consulta());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new laboratoire());
        }

        private void button40_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new reference());
        }

        private void button32_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new Examenprenuptiaux());
        }

        private void button38_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new Echostandard());
        }

        private void button22_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new Hospitalisation());
        }

        private void button41_Click(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new Service());
        }

        private void button40_Click_1(object sender, EventArgs e)
        {
            traitement.getinstance().Appel(pan, new Suivie());
        }
    }
}
