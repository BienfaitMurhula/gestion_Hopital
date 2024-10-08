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
    public partial class attestation : UserControl
    {
        public attestation()
        {
            InitializeComponent();
        }

        private void attestation_Load(object sender, EventArgs e)
        {
            traitement.getinstance().chargementdatagrid(dataGridView1, "select * from v_attestmedicale");
            traitement.getinstance().chargementcb1(patient, "nom", "postnom", "prenom", "patient");
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            traitement.getinstance().attestationMed(debut, fin, remarque, patient, "select * from v_attestmedicale", dataGridView1, "Enregistrer avec succès", "Echec d'enregistrement");
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            traitement.getinstance().attestationMed(debut, fin, remarque, patient, "select * from v_attestmedicale", dataGridView1, "Enregistrer avec succès", "Echec d'enregistrement");

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            traitement.getinstance().supprimer("attest_med", "Id", dataGridView1, "select * from v_attestmedicale");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            traitement.getinstance().deplacerMed(traitement.getinstance().id, e, dataGridView1, debut, fin, remarque, patient);
        }
    }
}
