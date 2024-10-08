using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Home.Classes;

namespace Home.userControl
{
    public partial class aptitude : UserControl
    {
        public aptitude()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void aptitude_Load(object sender, EventArgs e)
        {
            traitement.getinstance().chargementdatagrid(dataGridView1, "select * from v_aptitude");
            traitement.getinstance().chargementcb1(patient, "nom", "postnom", "prenom", "patient");
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            traitement.getinstance().aptitudeP(taille,poids,pt,etat,conc,val,patient, "select * from v_aptitude", dataGridView1,"Reussi","Echec ");
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
