using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using Guna.UI.WinForms;
using System.IO;
using System.Drawing;

namespace Home.Classes
{
    class traitement
    {
        public static traitement instance = null;
        public static MySqlConnection con;
        public static MySqlCommand cmd;
        MySqlDataReader dr = null;
        MySqlDataAdapter da = null;
        DataSet ds = null;
        public int id;

        public static traitement getinstance()
        {
            if (instance == null)

                instance = new traitement();
            return instance;

        }
        public void connect()
        {
            string server = "localhost";
            string database = "hopital";
            string user = "root";
            string password = "";
            //string port = "3306";
            //string sslM = "none";

            string connString = String.Format("server={0};user id={1}; database={2}; password={3}", server, user, database, password);


            try
            {
                con = new MySqlConnection(connString);
                con.Open();

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Connection failed", e.Message);


            }
            finally
            {
                con.Close();
            }

        }
        public void insertion(string n, string post, string pr, string se, string et, Control da, string li, string ad, string tel, string gr, string pro, string rel, string me, Control re, string ty, string em, string na, string vi, GunaPictureBox photo)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand("call p_patient (@id, @a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o,@p,@q,@r,@s)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@a", n);
                cmd.Parameters.AddWithValue("@b", post);
                cmd.Parameters.AddWithValue("@c", pr);
                cmd.Parameters.AddWithValue("@d", et);
                cmd.Parameters.AddWithValue("@e", se);
                cmd.Parameters.AddWithValue("@f", DateTime.Parse(da.Text));
                cmd.Parameters.AddWithValue("@g", li);
                cmd.Parameters.AddWithValue("@h", ad);
                cmd.Parameters.AddWithValue("@i", tel);
                cmd.Parameters.AddWithValue("@j", gr);
                cmd.Parameters.AddWithValue("@k", pro);
                cmd.Parameters.AddWithValue("@l", rel);
                cmd.Parameters.AddWithValue("@m", me);
                cmd.Parameters.AddWithValue("@n", DateTime.Parse(re.Text));
                cmd.Parameters.AddWithValue("@o", ty);
                cmd.Parameters.AddWithValue("@p", em);
                cmd.Parameters.AddWithValue("@q", na);
                cmd.Parameters.AddWithValue("@r", vi);
                cmd.Parameters.AddWithValue("@s", convertImageTobyte(photo));

                cmd.ExecuteNonQuery();
                MessageBox.Show("ok");

                id = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("echeeeeeeeeeee" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public byte[] convertImageTobyte(GunaPictureBox pic)
        {
            MemoryStream ms = new MemoryStream();
            pic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bytImage = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(bytImage, 0, bytImage.Length);
            return bytImage;
        }
        public void chargementdatagrid(DataGridView dt, string sql)
        {
            try
            {
                connect();
                con.Open();
                da = new MySqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "table");
                dt.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de chargement !!! " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void chargementcb(GunaComboBox cb, string nomChamp, string nomTable)
        {
            connect();
            if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();
            using (IDbCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = @"select " + nomChamp + " from " + nomTable + "";
                IDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string de = rd[nomChamp].ToString();
                    cb.Items.Add(de);
                }
                rd.Close();
                rd.Dispose();
                cmd.Dispose();
            }
        }
        public void chargementcb1(GunaComboBox cb, string nomChamp, string nomChamp1, string nomChamp2, string nomTable)
        {
            connect();
            if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();
            using (IDbCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = @"select " + nomChamp + " ," + nomChamp1 + " ," + nomChamp2 + " from " + nomTable + "";
                IDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string de = rd[nomChamp].ToString() + " " + rd[nomChamp1].ToString() + " " + rd[nomChamp2].ToString();
                    cb.Items.Add(de);
                }
                rd.Close();
                rd.Dispose();
                cmd.Dispose();
            }
        }
        //effacer le formulaire
        public void effacer(params Control[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i].ResetText();
            }
        }
        // suppresion des donnés
        public void supprimer(String table, string col, DataGridView d, string sql)
        {
            try
            {

                if (id > 0)
                {
                    DialogResult res = MessageBox.Show("Voulez-vous supprimer ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        connect();
                        con.Open();
                        cmd = new MySqlCommand("delete from " + table + " where " + col + "= @id", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        chargementdatagrid(d, sql);
                        MessageBox.Show("Suppression reussie ");
                        id = 0;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur de suppression " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        // Rechercher les données
        public void rechercher(string sql, DataGridView dat)
        {
            try
            {
                connect();
                con.Open();
                DataTable tab = new DataTable();
                da = new MySqlDataAdapter(sql, con);
                da.Fill(tab);
                dat.DataSource = tab;
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("erreur de recherche +e message  " + e);
            }
            finally
            {
                con.Close();
            }
        }
        // insertion cetificat de des et imagerie
        public void certifimagerie(Control date, Control lieu, Control cause, Control ant1, Control ant2, Control patient, string req, string sql, DataGridView d, String mess, String messE)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand(req + " (@id,@lieu,@cause,@ant1,@ant2,@date,@patient)", con);
                cmd.Parameters.AddWithValue("id", id);
                //cmd.Parameters.AddWithValue("date", DateTime.Parse(date.Text));
                cmd.Parameters.AddWithValue("lieu", lieu.Text);
                cmd.Parameters.AddWithValue("cause", cause.Text);
                cmd.Parameters.AddWithValue("ant1", ant1.Text);
                cmd.Parameters.AddWithValue("ant2", ant2.Text);
                cmd.Parameters.AddWithValue("date", date.Text);
                cmd.Parameters.AddWithValue("patient", patientId(patient.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(mess);
                effacer(date, lieu, cause, ant2, ant1, patient);
                chargementdatagrid(d, sql);
                id = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(messE + " " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void depinsert(int code, DataGridViewCellEventArgs e, DataGridView dt, Control date, Control lieu, Control cause, Control ant1, Control ant2, Control patient)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ro = dt.Rows[e.RowIndex];
                id = Convert.ToInt16(ro.Cells[0].Value.ToString());
                patient.Text = ro.Cells[1].Value.ToString();
                date.Text = ro.Cells[2].Value.ToString();
                lieu.Text = ro.Cells[3].Value.ToString();
                cause.Text = ro.Cells[4].Value.ToString();
                ant1.Text = ro.Cells[5].Value.ToString();
                ant2.Text = ro.Cells[6].Value.ToString();
            }
        }
        //insertion notes, prescription, consultation
        public void insertion(Control note, Control raison, Control patient, string req, string sql, DataGridView d, String mess, String messE)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand(req + " (@id,@a,@b,@c)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@a", note.Text);
                cmd.Parameters.AddWithValue("@b", raison.Text);
                cmd.Parameters.AddWithValue("@c", patientId(patient.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(mess);
                effacer(note, raison, patient);
                chargementdatagrid(d, sql);
            }
            catch (Exception e)
            {
                MessageBox.Show(messE + " " + e.Message);
            }
            finally
            {
                con.Close();
            }
            id = 0;
        }
        public void depinsertion(int code, DataGridViewCellEventArgs e, DataGridView dt, Control note, Control rais, Control pat)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ro = dt.Rows[e.RowIndex];
                id = Convert.ToInt16(ro.Cells[0].Value.ToString());
                pat.Text = ro.Cells[1].Value.ToString();
                note.Text = ro.Cells[2].Value.ToString();
                rais.Text = ro.Cells[3].Value.ToString();
            }
        }
        // deplacement des données
        public void deplaptitude(int code, DataGridViewCellEventArgs e, DataGridView dt, Control des, DateTimePicker date, Control type, Control officier)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ro = dt.Rows[e.RowIndex];
                id = Convert.ToInt16(ro.Cells[0].Value.ToString());
                des.Text = ro.Cells[1].Value.ToString();
                date.Text = ro.Cells[2].Value.ToString();
                type.Text = ro.Cells[3].Value.ToString();
                officier.Text = ro.Cells[4].Value.ToString();
            }
        }
        // insertion aptitude physique
        public void aptitudeP(Control taille, Control poids, Control pt, Control etat, Control conclusion, Control valid, Control patient, string sql, DataGridView d, String mess, String messE)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand("call p_aptitude (@id,@taile,@poids,@pt,@etat,@concl,@val,@patient)", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("taille", taille.Text);
                cmd.Parameters.AddWithValue("poids", poids.Text);
                cmd.Parameters.AddWithValue("pt", pt.Text);
                cmd.Parameters.AddWithValue("etat", etat.Text);
                cmd.Parameters.AddWithValue("concl", conclusion.Text);
                cmd.Parameters.AddWithValue("val", DateTime.Parse(valid.Text));
                cmd.Parameters.AddWithValue("patient", patientId(patient.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(mess);
                effacer(taille, poids, pt, etat, conclusion, valid, patient);
                chargementdatagrid(d, sql);
                id = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(messE + " " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void echo_obs(Control nbr, Control present, Control morphologie, Control bcf, Control mfa, Control mrf, Control gs, Control lcc, Control bip, Control hc, Control fl, Control age, Control dpa, Control poids, Control placenta, Control sexe, Control la, Control cordon, Control type, Control autre, Control estimation, Control rendevous, Control patient, String mess, String messE)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand("call p_echo_obs (@id,@nbr,@pres,@morph,@bcf,@mfa,@mrf,@gs,@lcc,@bip,@hc,@fl,@age,@dpa,@poids,@place,@sexe,@la,@cordon,@type,@autre,@estimation,@rend,@patient)", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("nbr", Convert.ToUInt16(nbr.Text));
                cmd.Parameters.AddWithValue("pres", present.Text);
                cmd.Parameters.AddWithValue("morph", morphologie.Text);
                cmd.Parameters.AddWithValue("bcf", bcf.Text);
                cmd.Parameters.AddWithValue("mfa", mfa.Text);
                cmd.Parameters.AddWithValue("mrf", mrf.Text);
                cmd.Parameters.AddWithValue("gs", gs.Text);
                cmd.Parameters.AddWithValue("lcc", lcc.Text);
                cmd.Parameters.AddWithValue("bip", bip.Text);
                cmd.Parameters.AddWithValue("hc", hc.Text);
                cmd.Parameters.AddWithValue("fl", fl.Text);
                cmd.Parameters.AddWithValue("age", int.Parse(age.Text));
                cmd.Parameters.AddWithValue("dpa", dpa.Text);
                cmd.Parameters.AddWithValue("poids", poids.Text);
                cmd.Parameters.AddWithValue("place", placenta.Text);
                cmd.Parameters.AddWithValue("sexe", sexe.Text);
                cmd.Parameters.AddWithValue("la", la.Text);
                cmd.Parameters.AddWithValue("cordon", cordon.Text);
                cmd.Parameters.AddWithValue("type", type.Text);
                cmd.Parameters.AddWithValue("autre", autre.Text);
                cmd.Parameters.AddWithValue("estimation", estimation.Text);
                cmd.Parameters.AddWithValue("rend", rendevous.Text);
                cmd.Parameters.AddWithValue("patient", patientId(patient.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(mess);
                effacer(nbr, present, morphologie, bcf, mfa, mrf, gs, la, lcc, bip, hc, fl, age, dpa, placenta, sexe, cordon, type, autre, estimation, rendevous, poids, patient);

                id = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(messE + " " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // insertion certificatNaiss
        public void certificatNaiss(Control date_accoch, Control nombre, Control sexe, Control poids, Control taille, Control group, Control mode, Control apgar, Control nom, Control doss, Control temps, Control patient, Control reg, string sql, DataGridView d, String mess, String messE)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand(" call p_certifNaiss (@id,@no,@sexe,@poids,@taille,@group,@apgar,@nom,@doss,@reg,@mode,@date,@patient,@temp)", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("date", DateTime.Parse(date_accoch.Text));
                cmd.Parameters.AddWithValue("sexe", sexe.Text);
                cmd.Parameters.AddWithValue("poids", int.Parse(poids.Text));
                cmd.Parameters.AddWithValue("taille", int.Parse(taille.Text));
                cmd.Parameters.AddWithValue("group", group.Text);
                cmd.Parameters.AddWithValue("apgar", apgar.Text);
                cmd.Parameters.AddWithValue("nom", nom.Text);
                cmd.Parameters.AddWithValue("mode", mode.Text);
                cmd.Parameters.AddWithValue("no", int.Parse(nombre.Text));
                cmd.Parameters.AddWithValue("temp", temps.Text);
                cmd.Parameters.AddWithValue("doss", doss.Text);
                cmd.Parameters.AddWithValue("reg", reg.Text);
                cmd.Parameters.AddWithValue("patient", patientId(patient.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(mess);
                effacer(taille, poids, sexe, group, apgar, nom, date_accoch, patient);
                chargementdatagrid(d, sql);
                id = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(messE + " " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        // insertion certificat deces
        public void labo(Control type, Control result, Control borne, Control note, Control patient, string sql, DataGridView d, String mess, String messE)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand("labo @id,@type,@resultat,@borne,@note,@patient", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("type", type.Text);
                cmd.Parameters.AddWithValue("resultat", result.Text);
                cmd.Parameters.AddWithValue("borne", borne.Text);
                cmd.Parameters.AddWithValue("note", note.Text);
                cmd.Parameters.AddWithValue("patient", patient.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(mess);
                effacer(type, borne, result, note, patient);
                chargementdatagrid(d, sql);
                id = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(messE + " " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void reference(Control arrive, Control symptome, Control diagnostique, Control ttt, Control motif, Control motiff, Control patient, string sql, DataGridView d, String mess, String messE)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand("call p_reference ( @id,@type,@resultat,@borne,@note,@motif,@ref,@patient)", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("type", DateTime.Parse(arrive.Text));
                cmd.Parameters.AddWithValue("resultat", symptome.Text);
                cmd.Parameters.AddWithValue("borne", diagnostique.Text);
                cmd.Parameters.AddWithValue("note", ttt.Text);
                cmd.Parameters.AddWithValue("motif", motif.Text);
                cmd.Parameters.AddWithValue("ref", DateTime.Parse(motiff.Text));
                cmd.Parameters.AddWithValue("patient", patientId(patient.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(mess);
                effacer(arrive, symptome, diagnostique, ttt, motif, patient);
                chargementdatagrid(d, sql);
                id = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(messE + " " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void deplacerRef(int code, DataGridViewCellEventArgs e, DataGridView dt, Control arrive, Control symptome, Control diagnostique, Control ttt, Control motif, Control motiff, Control patient)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ro = dt.Rows[e.RowIndex];
                id = Convert.ToInt16(ro.Cells[0].Value.ToString());
                patient.Text = ro.Cells[1].Value.ToString();
                arrive.Text = ro.Cells[2].Value.ToString();
                symptome.Text = ro.Cells[3].Value.ToString();
                diagnostique.Text = ro.Cells[4].Value.ToString();
                ttt.Text = ro.Cells[5].Value.ToString();
                motif.Text = ro.Cells[6].Value.ToString();
                motiff.Text = ro.Cells[7].Value.ToString();
            }
        }
        public void attestationMed(Control debut, Control fin, Control remarque, Control patient, string sql, DataGridView d, String mess, String messE)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand("call p_attestationMed (@id,@type,@resultat,@borne,@patient)", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("type", DateTime.Parse(debut.Text));
                cmd.Parameters.AddWithValue("resultat", DateTime.Parse(fin.Text));
                cmd.Parameters.AddWithValue("borne", remarque.Text);
                cmd.Parameters.AddWithValue("patient", patientId(patient.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(mess);
                effacer(debut, fin, remarque, patient);
                chargementdatagrid(d, sql);
                id = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(messE + " " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void deplacerMed(int code, DataGridViewCellEventArgs e, DataGridView dt, Control debut, Control fin, Control remarque, Control patientr)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ro = dt.Rows[e.RowIndex];
                id = Convert.ToInt16(ro.Cells[0].Value.ToString());
                patientr.Text = ro.Cells[1].Value.ToString();
                debut.Text = ro.Cells[2].Value.ToString();
                fin.Text = ro.Cells[3].Value.ToString();
                remarque.Text = ro.Cells[4].Value.ToString();
            }
        }
        public int patientId(string valeur1)
        {
            int idp = 0;
            connect();
            con.Open();
            if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT id from patient where concat(nom, ' ',postnom,' ',prenom) like '" + valeur1 + "'";

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                        idp = int.Parse(dr.GetFieldValue<object>(0).ToString());
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return idp;
        }

        public string GetID(String champ, String table, String champcondition1, String valeur1)
        {
            string _id = string.Empty;

            connect();
            con.Open();
            if (!con.State.ToString().Trim().ToLower().Equals("open")) con.Open();
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT DISTINCT " + champ + " FROM " + table + " WHERE " + champcondition1 + " = @valeur1";
                cmd.Parameters.Add(new MySqlParameter("@valeur1", SqlDbType.NVarChar)).Value = valeur1;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                        _id = dr.GetFieldValue<object>(0).ToString();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return _id.ToString();
        }
        public void Appel(Panel s, Control c)
        {
            try
            {
                s.Controls.Clear();
                s.Controls.Add(c);
                s.Show();

            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur de fermeture");
            }
        }

        //======================================================================================================
        public void medicament(Control med, Control type, Control qte, Control patient, string sql, DataGridView d, String mess, String messE)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand("call p_medicament (@id,@med,@type,@qte,@patient)", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("med", med.Text);
                cmd.Parameters.AddWithValue("type", type.Text);
                cmd.Parameters.AddWithValue("qte", Convert.ToInt16(qte.Text));
                cmd.Parameters.AddWithValue("patient", patientId(patient.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(mess);
                effacer(med,type,qte, patient);
                chargementdatagrid(d, sql);
                id = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(messE + " " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void deplacerMedicament(int code, DataGridViewCellEventArgs e, DataGridView dt, Control med, Control type, Control qte, Control patient)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ro = dt.Rows[e.RowIndex];
                id = Convert.ToInt16(ro.Cells[0].Value.ToString());
                patient.Text = ro.Cells[1].Value.ToString();
                med.Text = ro.Cells[2].Value.ToString();
                type.Text = ro.Cells[3].Value.ToString();
                qte.Text = ro.Cells[4].Value.ToString();
            }
        }

        //hospitalisation
        public void hospitralisation(Control date, Control chambre, Control lit, Control sortie, Control patient, string sql, DataGridView d, String mess, String messE)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand("call p_hospitalisation (@id,@date,@chambre,@lit,@sortie,@patient)", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("date", DateTime.Parse(date.Text));
                cmd.Parameters.AddWithValue("chambre", chambre.Text);
                cmd.Parameters.AddWithValue("lit", lit.Text);
                cmd.Parameters.AddWithValue("sortie", sortie.Text);
                cmd.Parameters.AddWithValue("patient", patientId(patient.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(mess);
                effacer(date, chambre, lit, sortie, patient);
                chargementdatagrid(d, sql);
                id = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(messE + " " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void deplacerhospitalisation(int code, DataGridViewCellEventArgs e, DataGridView dt, Control date, Control chambre, Control lit, Control sortie, Control patientr)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ro = dt.Rows[e.RowIndex];
                id = Convert.ToInt16(ro.Cells[0].Value.ToString());
                patientr.Text = ro.Cells[1].Value.ToString();
                date.Text = ro.Cells[2].Value.ToString();
                chambre.Text = ro.Cells[3].Value.ToString();
                lit.Text = ro.Cells[4].Value.ToString();
                sortie.Text = ro.Cells[5].Value.ToString();
            }
        }
        //echo standard
        public void echostd(Control clinique, Control medecin, Control resultat, Control patient, string sql, DataGridView d, String mess, String messE)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand("call p_echoStand (@id,@clc,@resultat,@patient,@med)", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("clc", clinique.Text);
                cmd.Parameters.AddWithValue("resultat", resultat.Text);
                cmd.Parameters.AddWithValue("patient", patientId(patient.Text));
                cmd.Parameters.AddWithValue("med", patientId(medecin.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(mess);
                effacer(clinique, resultat, patient, medecin);
                chargementdatagrid(d, sql);
                id = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(messE + " " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void deplacerechostd(int code, DataGridViewCellEventArgs e, DataGridView dt, Control clc, Control patient, Control med, Control result)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ro = dt.Rows[e.RowIndex];
                id = Convert.ToInt16(ro.Cells[0].Value.ToString());
                patient.Text = ro.Cells[1].Value.ToString();
                clc.Text = ro.Cells[2].Value.ToString();
                med.Text = ro.Cells[3].Value.ToString();
                result.Text = ro.Cells[4].Value.ToString();
            }
        }

        //Service

        public void service(Control des, string sql, DataGridView d, String mess, String messE)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand("call p_service (@id,@des)", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("des", des.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(mess);
                effacer(des);
                chargementdatagrid(d, sql);
                id = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(messE + " " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void deplacerechostd(int code, DataGridViewCellEventArgs e, DataGridView dt, Control des)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ro = dt.Rows[e.RowIndex];
                id = Convert.ToInt16(ro.Cells[0].Value.ToString());
                des.Text = ro.Cells[1].Value.ToString();
            }
        }

        // Examen prenuption

        public void examenPren(Control nom, Control post, Control fx, Control cr, Control rh,Control si, Control frottis, Control sed, Control sperm, Control med, string sql, DataGridView d, String mess, String messE)
        {
            try
            {
                connect();
                con.Open();
                cmd = new MySqlCommand("call p_examPrenuption (@id,@nom,@post,@fx,@cr,rh,si,frottis,sed,sperm,med )", con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("nom", nom.Text);
                cmd.Parameters.AddWithValue("post", post.Text);
                cmd.Parameters.AddWithValue("fx", fx.Text);
                cmd.Parameters.AddWithValue("cr", cr.Text);
                cmd.Parameters.AddWithValue("hr", rh.Text);
                cmd.Parameters.AddWithValue("si", si.Text);
                cmd.Parameters.AddWithValue("frottis", frottis.Text);
                cmd.Parameters.AddWithValue("sed", sed.Text);
                cmd.Parameters.AddWithValue("sperm", sperm.Text);
                cmd.Parameters.AddWithValue("med", patientId(med.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(mess);
                effacer(nom,post,fx,cr, si,rh,frottis,med,sperm, sed);
                chargementdatagrid(d, sql);
                id = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(messE + " " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void deplacerexamen(int code, DataGridViewCellEventArgs e, DataGridView dt, Control nom, Control post, Control fx, Control cr, Control rh, Control si, Control frottis, Control sed, Control sperm, Control med)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ro = dt.Rows[e.RowIndex];
                id = Convert.ToInt16(ro.Cells[0].Value.ToString());
                nom.Text = ro.Cells[1].Value.ToString();
                post.Text = ro.Cells[2].Value.ToString();
                fx.Text = ro.Cells[3].Value.ToString();
                cr.Text = ro.Cells[4].Value.ToString();
                rh.Text = ro.Cells[5].Value.ToString();
                si.Text = ro.Cells[6].Value.ToString();
                frottis.Text = ro.Cells[7].Value.ToString();
                sed.Text = ro.Cells[8].Value.ToString();
                sperm.Text = ro.Cells[9].Value.ToString();
                med.Text = ro.Cells[10].Value.ToString();
            }
        }
    }
}