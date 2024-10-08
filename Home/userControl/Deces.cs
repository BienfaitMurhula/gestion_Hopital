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
    public partial class Deces : UserControl
    {
        public Deces()
        {
            InitializeComponent();
        }

        private void Deces_Load(object sender, EventArgs e)
        {
            traitement.getinstance().chargementdatagrid(dataGridView1, "select * from v_deces");
            traitement.getinstance().chargementcb1(patient, "nom", "postnom", "prenom", "patient");
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            traitement.getinstance().certifimagerie(date, lieu, cause, antecedent, antecedent1, patient, " call p_deces ","select * from v_deces", dataGridView1, "Enregistrer avec succès", "Echec d'enregistrement");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            traitement.getinstance().depinsert(traitement.getinstance().id, e, dataGridView1, date, lieu, cause, antecedent, antecedent1, patient);
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            traitement.getinstance().certifimagerie(date, lieu, cause, antecedent, antecedent1, patient, " call p_deces ", "select * from v_deces", dataGridView1, "Modification avec succès", "Echec d'enregistrement");

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            traitement.getinstance().supprimer("certificat_deces", "Id", dataGridView1, "select * from v_deces");
        }
    }
}
