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
    public partial class Ecographie : UserControl
    {
        public Ecographie()
        {
            InitializeComponent();
            gunaButton2.Enabled = false;
            gunaButton3.Enabled = false;
        }
        echo t = new echo();
        private void gunaButton1_Click(object sender, EventArgs e)
        {
            t.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                gunaButton2.Enabled = true;
                gunaButton3.Enabled = true;
                row = this.dataGridView1.Rows[e.RowIndex];

            }
            }
        DataGridViewRow row;
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            t.charger(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString(), row.Cells[11].Value.ToString(), row.Cells[12].Value.ToString(), row.Cells[13].Value.ToString(), row.Cells[14].Value.ToString(), row.Cells[15].Value.ToString(), row.Cells[16].Value.ToString(), row.Cells[17].Value.ToString(), row.Cells[18].Value.ToString(), row.Cells[19].Value.ToString(), row.Cells[20].Value.ToString(), row.Cells[21].Value.ToString(), row.Cells[22].Value.ToString(), row.Cells[23].Value.ToString(), row.Cells[24].Value.ToString(), int.Parse(row.Cells[0].Value.ToString()));
            t.ShowDialog();
        }

        private void Ecographie_Load(object sender, EventArgs e)
        {
            traitement.getinstance().chargementdatagrid(dataGridView1, "select * from echo_obs");
        }
    }
}
