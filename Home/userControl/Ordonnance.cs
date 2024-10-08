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
    public partial class Ordonnance : UserControl
    {
        public Ordonnance()
        {
            InitializeComponent();
        }

        private void Ordonnance_Load(object sender, EventArgs e)
        {
            traitement.getinstance().chargementdatagrid(dataGridView1, "select * from v_ordonnance");
            traitement.getinstance().chargementcb1(patient, "nom", "postnom", "prenom", "patient");
        }
    }
}
