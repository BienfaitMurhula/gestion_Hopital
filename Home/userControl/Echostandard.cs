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
    public partial class Echostandard : UserControl
    {
        public Echostandard()
        {
            InitializeComponent();
        }

        private void Echostandard_Load(object sender, EventArgs e)
        {
            traitement.getinstance().chargementdatagrid(dataGridView1, "select * from v_echostandard");
            traitement.getinstance().chargementcb1(patient, "nom", "postnom", "prenom", "patient");
        }
    }
}
