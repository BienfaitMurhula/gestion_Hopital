using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home.dialogues
{
    public partial class echo : Form
    {
        public echo()
        {
            InitializeComponent();
        }
        public void charger(string aa, string bb, string cc, string dd, string ee, string ff, string gg, string hh, string ii, string jj, string kk, string ll, string mm, string nn, string oo, string pp, string qq, string rr, string ss, string tt, string uu, string vv, string xx, string yy,int idi)
        {
            a.Text = aa;
            b.Text = bb;
            c.Text = cc;
            d.Text = dd;
            e.Text = ee;
            f.Text = ff;
            g.Text = gg;
            h.Text = hh;
            i.Text = ii;
            j.Text = jj;
            k.Text = kk;
            l.Text = ll;
            m.Text = mm;
            n.Text = nn;
            o.Text = oo;
            p.Text = pp;
            q.Text = qq;
            r.Text = rr;
            s.Text = ss;
            t.Text = tt;
            u.Text = uu;
            v.Text = vv;
            x.Text = xx;
            y.Text = yy;
            ID = idi;

        }
        int ID;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
