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
        }
    }
}
