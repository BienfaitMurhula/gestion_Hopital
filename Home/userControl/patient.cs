using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Home.dialogues;
using Home.Classes;

namespace Home.userControl
{
    public partial class patient : UserControl
    {
        public patient()
        {
            InitializeComponent();
            gunaButton2.Enabled = false;
            gunaButton3.Enabled = false;
        }
        Addpatient p = new Addpatient();
        private void gunaButton1_Click(object sender, EventArgs e)
        {
            p.ShowDialog();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            traitement.getinstance().id = int.Parse(row.Cells[0].Value.ToString());
            p.charger(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString(), row.Cells[11].Value.ToString(), row.Cells[12].Value.ToString(), row.Cells[13].Value.ToString(), row.Cells[14].Value.ToString(), row.Cells[15].Value.ToString(), row.Cells[16].Value.ToString(), row.Cells[17].Value.ToString(), row.Cells[18].Value.ToString(), int.Parse(row.Cells[0].Value.ToString()), (byte[])row.Cells[19].Value) ;
            p.ShowDialog();
        }

        private void patient_Load(object sender, EventArgs e)
        {
            traitement.getinstance().chargementdatagrid(dataGridView1,"select * from patient");
        }
        DataGridViewRow row;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                gunaButton2.Enabled = true;
                gunaButton3.Enabled = true;
               row = this.dataGridView1.Rows[e.RowIndex];
                
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            traitement.getinstance().id = int.Parse(row.Cells[0].Value.ToString());
            traitement.getinstance().supprimer( "patient", "Id", dataGridView1, "select * from v_patient");
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
            traitement.getinstance().rechercher("select * from v_patient where nom like '%" + gunaTextBox1.Text + "%'", dataGridView1);
        }
    }
}
