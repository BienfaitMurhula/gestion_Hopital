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
    public partial class prescription : UserControl
    {
        public prescription()
        {
            InitializeComponent();
        }

        private void prescription_Load(object sender, EventArgs e)
        {
            traitement.getinstance().chargementdatagrid(dataGridView1, "select * from v_precrit");
            traitement.getinstance().chargementcb1(gunaComboBox1, "nom", "postnom","prenom","patient");

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            traitement.getinstance().insertion(gunaComboBox2, gunaTextBox3, gunaComboBox1, " call p_prescription ", "select * from v_precrit", dataGridView1, "Enregistrer avec succes", "echec d'enregistrement");
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            traitement.getinstance().insertion(gunaComboBox2, gunaTextBox3, gunaComboBox1, " call p_prescription ", "select * from v_precrit", dataGridView1, "Enregistrer avec succes", "echec d'enregistrement");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            traitement.getinstance().depinsertion(traitement.getinstance().id, e, dataGridView1, gunaComboBox2, gunaTextBox3, gunaComboBox1);
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            traitement.getinstance().supprimer("prescriprion", "Id", dataGridView1, "select * from v_precrit");

        }
    }
}
