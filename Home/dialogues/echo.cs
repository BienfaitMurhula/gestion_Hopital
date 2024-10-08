using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Home.Classes;
using Home.userControl;
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
            nombre.Text = aa;
            present.Text = bb;
            morph.Text = cc;
            bcf.Text = dd;
            mfa.Text = ee;
            mrf.Text = ff;
            gs.Text = gg;
            lec.Text = hh;
            bip.Text = ii;
            hc.Text = jj;
            fl.Text = kk;
            agesta.Text = ll;
            dpa.Text = mm;
            poids.Text = nn;
            placent.Text = oo;
            sexe.Text = pp;
            la.Text = qq;
            cordon.Text = rr;
            type.Text = ss;
            autres.Text = tt;
            estimat.Text = uu;
            v.Text = vv;
            rendez.Text = xx;
            patient.Text = yy;
            ID = idi;

        }
        int ID;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            //Home f = new Home();
            //traitement.getinstance().Appel(f.pan, new echo());
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            traitement.getinstance().echo_obs(nombre,present,morph,bcf,mfa,mrf,gs,lec,bip,hc,fl,agesta,dpa,poids,placent,sexe,la,cordon,type,autres,estimat,rendez,patient,"Enregistré","Echec");
        }

        private void echo_Load(object sender, EventArgs e)
        {
            traitement.getinstance().chargementcb1(patient, "nom", "postnom", "prenom", "patient");
        }
    }
}
