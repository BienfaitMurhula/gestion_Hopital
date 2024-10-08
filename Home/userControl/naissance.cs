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
    public partial class naissance : UserControl
    {
        public naissance()
        {
            InitializeComponent();
        }

        private void naissance_Load(object sender, EventArgs e)
        {
            traitement.getinstance().chargementdatagrid(dataGridView1, "select * from certificat_naiss");
            traitement.getinstance().chargementcb1(patient, "nom", "postnom", "prenom", "patient");
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            traitement.getinstance().certificatNaiss(date,nombre,sexe,poids,taille,groupe,mode,apgar,Nom,Dossier,temps,patient,registre, "select * from certificat_naiss", dataGridView1,"Enregistré","Echec");
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            traitement.getinstance().certificatNaiss(date, nombre, sexe, poids, taille, groupe, mode, apgar, Nom, Dossier, temps, patient, registre, "select * from certificat_naiss", dataGridView1, "Modifié", "Echec");

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            traitement.getinstance().supprimer("attest_med", "Id", dataGridView1, "select * from certificat_naiss");

        }
    }
}
