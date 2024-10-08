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
    public partial class reference : UserControl
    {
        public reference()
        {
            InitializeComponent();
        }
        
        private void reference_Load(object sender, EventArgs e)
        {
            Classes.traitement.getinstance().chargementdatagrid(dataGridView1, "select * from v_reference");
            Classes.traitement.getinstance().chargementcb1(patient, "nom", "postnom", "prenom", "patient");
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            Classes.traitement.getinstance().reference(arrive,symptomes,diagnostics,traitement,motif, transfert, patient, "select * from v_reference",dataGridView1,"Enregistrer avec succès","Echec d'enregistrement");
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Classes.traitement.getinstance().reference(arrive, symptomes, diagnostics, traitement, motif, transfert,patient, "select * from v_reference", dataGridView1, "Modifié avec succès", "Echec d'enregistrement");

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            Classes.traitement.getinstance().supprimer("reference", "Id", dataGridView1, "select * from v_reference");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Classes.traitement.getinstance().deplacerRef(Classes.traitement.getinstance().id, e, dataGridView1, arrive, symptomes, diagnostics, traitement, motif, transfert, patient);
        }
    }
}
