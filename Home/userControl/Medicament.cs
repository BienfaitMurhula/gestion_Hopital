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
    public partial class Medicament : UserControl
    {
        public Medicament()
        {
            InitializeComponent();
        }

        private void Medicament_Load(object sender, EventArgs e)
        {
            traitement.getinstance().chargementdatagrid(dataGridView1, "select * from medicamenta");
            traitement.getinstance().chargementcb1(patient, "nom", "postnom", "prenom", "patient");
        }
    }
}
