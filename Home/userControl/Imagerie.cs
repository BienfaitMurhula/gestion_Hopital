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
    public partial class Imagerie : UserControl
    {
        public Imagerie()
        {
            InitializeComponent();
        }

        private void Imagerie_Load(object sender, EventArgs e)
        {
            traitement.getinstance().chargementdatagrid(dataGridView1, "select * from v_imagerie");
            traitement.getinstance().chargementcb1(patient, "nom", "postnom", "prenom", "patient");

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            traitement.getinstance().certifimagerie(lieu, cause, antecedent, antecedent1, note,patient, " call p_image ", "select * from v_imagerie", dataGridView1, "Enregistrer avec succès", "Echec d'enregistrement");

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            traitement.getinstance().certifimagerie(lieu, cause, antecedent, antecedent1, note, patient, " call p_image ", "select * from v_imagerie", dataGridView1, "Modification avec succès", "Echec d'enregistrement");

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            traitement.getinstance().supprimer("imagerie", "Id", dataGridView1, "select * from v_imagerie");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            traitement.getinstance().depinsert(traitement.getinstance().id, e, dataGridView1, lieu, cause, antecedent, antecedent1,note, patient);

        }
    }
}
