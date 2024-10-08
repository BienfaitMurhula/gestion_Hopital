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
    public partial class consulta : UserControl
    {
        public consulta()
        {
            InitializeComponent();
        }

        private void consulta_Load(object sender, EventArgs e)
        {
            traitement.getinstance().chargementcb1(patient, "nom", "postnom", "prenom", "patient");

            traitement.getinstance().chargementdatagrid(dataGridView1, "select * from v_consultation");
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if (traitement.getinstance().id <= 0)
            {
                traitement.getinstance().insertion(examen, prix, patient, "CALL p_consultation", "select * from v_consultation", dataGridView1, "Enregistré avec succes", "Erreur d'enregistrement");
            }
            else
            {
                traitement.getinstance().insertion(examen, prix, patient, "CALL p_consultation ", "select * from v_consultation", dataGridView1, "Modifié avec succes", "Erreur de modification");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            traitement.getinstance().depinsertion(traitement.getinstance().id, e, dataGridView1, examen, prix, patient);


            //MessageBox.Show(""+traitement.getinstance().id);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            traitement.getinstance().depinsertion(traitement.getinstance().id, e, dataGridView1, examen, prix, patient);
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            traitement.getinstance().insertion(examen, prix, patient, "CALL p_consultation ", "select * from v_consultation", dataGridView1, "Modifié avec succes", "Erreur de modification");

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            traitement.getinstance().supprimer("consultation", "Id", dataGridView1, "select * from v_consultation");
        }
    }
}
