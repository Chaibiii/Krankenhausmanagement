using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EFF2010v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"data source =.\sqlexpress ;initial catalog=EFF2010v1;integrated security=SSPI");
        SqlDataReader dr;
        SqlCommand cmd = new SqlCommand();
        BindingSource bs = new BindingSource();
        BindingSource bs1 = new BindingSource();
        BindingSource bs2 = new BindingSource();
        BindingSource bs3 = new BindingSource();
        BindingSource bs4 = new BindingSource();

        private void Form1_Load(object sender, EventArgs e)
        {
       


            chargerDG1();
            chargerDG2();
            chargerDG3();
            chargerCB("Specialite", comboBox1);
            chargerCB("Service", comboBox2);
            chargerDG4();
            chargerDG5();
            chargerCB("Service", comboBox3);
            chargerCB("Patient", comboBox4);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            
            chargerCB("Médecin", comboBox5);
            chargerCB("Patient", comboBox6);
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            chargerCB("hopital", comboBox7);


            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "Select s.Idspecialite ,   s.NBLits , m.Idmedecin  from Specialite s , Hopital h,Médecin m where m.Idspecialite=s.Idspecialite";
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            CrystalReport2 cr2 = new CrystalReport2();
            cr2.SetDataSource(dt);

            crystalReportViewer2.ReportSource = cr2;
        }
        //charger datagridview hopital
        void chargerDG1()
        {
           try {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                cmd.Connection = cn;
                cmd.CommandText = "select * from Hopital";
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                bs.DataSource = dt;
                textBox1.DataBindings.Add("text", bs, "IdHopital");
                textBox2.DataBindings.Add("text", bs, "Nom");
                textBox3.DataBindings.Add("text", bs, "Adresse");
                textBox4.DataBindings.Add("text", bs, "Ville");
                dr.Close();
                cn.Close();
            }
            catch ( Exception Ex) {}
        }

        //charger datagridview medecin
        void chargerDG2()
        {
            try
            {
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                cmd.Connection = cn;
                cmd.CommandText = "select * from Médecin";
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                bs1.DataSource = dt;
                textBox5.DataBindings.Add("text", bs1, "Idmedecin");
                textBox6.DataBindings.Add("text", bs1, "Nom");
                textBox7.DataBindings.Add("text", bs1, "Prenom");
                textBox8.DataBindings.Add("text", bs1, "DbN");
                textBox9.DataBindings.Add("text", bs1, "Sexe");
                dr.Close();
                cn.Close();
            }
            catch (Exception Ex) { }
        }


        //charger datagridview Patient
        void chargerDG3()
        {
            
                if (cn.State == ConnectionState.Closed) { cn.Open(); }
                cmd.Connection = cn;
                cmd.CommandText = "select * from Patient";
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView3.DataSource = dt;
                bs2.DataSource = dt;
                textBox10.DataBindings.Add("text", bs2, "Idpatient");
                textBox11.DataBindings.Add("text", bs2, "Nom");
                textBox12.DataBindings.Add("text", bs2, "Prenom");
                textBox13.DataBindings.Add("text", bs1, "DbN");
                textBox14.DataBindings.Add("text", bs1, "Sexe");
                textBox15.DataBindings.Add("text", bs2, "Adresse");
                dr.Close();
                cn.Close();
           
        }
        //charger datagridview Séjourne
        void chargerDG4()
        {

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select * from Séjourne";
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView4.DataSource = dt;
            bs3.DataSource = dt;
            textBox16.DataBindings.Add("text", bs3, "Idsejour");
            textBox17.DataBindings.Add("text", bs3, "DateEntree");
            textBox18.DataBindings.Add("text", bs3, "Datesortie");
          
            dr.Close();
            cn.Close();

        }

        //charger datagridview Soigne
        void chargerDG5()
        {

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select * from Soigne";
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView5.DataSource = dt;
            bs4.DataSource = dt;
            textBox19.DataBindings.Add("text", bs4, "IdSoin");
            textBox20.DataBindings.Add("text", bs4, "Nommaladie");
            textBox21.DataBindings.Add("text", bs4, "commentaire");
            textBox22.DataBindings.Add("text", bs4, "Date_soigne");

            dr.Close();
            cn.Close();

        }


        //charger combobox

        void chargerCB(string t, ComboBox bx)
        {
            if (cn.State == ConnectionState.Closed)
            { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "select * from " + t;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                bx.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*Ajouter Hopital*/
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*Modifier Hopital*/
            if (cn.State == ConnectionState.Closed)
            { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "update Hopital set  Nom='" + textBox2.Text + "',Adresse='" + textBox3.Text + "',Ville='" + textBox4.Text + "'where IdHopital='" + textBox1.Text+"',";

            int x = cmd.ExecuteNonQuery();
            if (x == 0)
            {
                label5.Text = "la modification à échoué";
                label5.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label5.Text = "la modification a réussi";
                label5.ForeColor = System.Drawing.Color.Green;
                chargerDG1();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*supprimes Hopital*/
            if (cn.State == ConnectionState.Closed)
            { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "delete from Hopital where IdHopital=" + textBox1.Text;

            int x = cmd.ExecuteNonQuery();
            if (x == 0)
            {
                label5.Text = "la Suppression à échoué";
                label5.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label5.Text = "la Suppression a réussi";
                label5.ForeColor = System.Drawing.Color.Green;
                chargerDG1();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*premier Hopital*/
            bs.MoveFirst();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*dernier Hopital*/
            bs.MoveLast();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            /*precedent Hopital*/
            if (bs.Position == 0) { MessageBox.Show("vous etes sur le premier"); }
            else { bs.MovePrevious(); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*suivant Hopital*/
            if (bs.Position == bs.Count - 1) { MessageBox.Show("vous étes sur le dernier "); }
            else
            { bs.MoveNext(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*Enregistrer Hopital*/
            if (cn.State == ConnectionState.Closed) { cn.Open(); }

            cmd.Connection = cn;
            cmd.CommandText = " insert into Hopital values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            int x = cmd.ExecuteNonQuery();
            chargerDG1();
            cn.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        { /*premier Médecin*/
            bs1.MoveFirst();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            /*dernier Médecin*/
            bs1.MoveLast();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            /*precedent Médecin*/
            if (bs1.Position == 0) { MessageBox.Show("vous etes sur le premier"); }
            else { bs1.MovePrevious(); }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            /*suivant Médecin*/
            if (bs1.Position == bs1.Count - 1) { MessageBox.Show("vous étes sur le dernier "); }
            else
            { bs1.MoveNext(); }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            /*Ajouter Médecin*/
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox1.SelectedIndex = -1;

            comboBox2.SelectedIndex = -1;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            /*Modifier Médecin*/
            if (cn.State == ConnectionState.Closed)
            { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "update Médecin set  Nom='" + textBox6.Text + "',Prenom='" + textBox7.Text + "',DbN='" + textBox8.Text + "'where Idmedecin='" + textBox5.Text + "',";

            int x = cmd.ExecuteNonQuery();
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            /*supprimes Médecin*/
            if (cn.State == ConnectionState.Closed)
            { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "delete from Médecin   where Idmedecin=" + textBox5.Text;

            int x = cmd.ExecuteNonQuery();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            /*Enregistrer Médecin*/
            if (cn.State == ConnectionState.Closed) { cn.Open(); }

            cmd.Connection = cn;
            cmd.CommandText = " insert into Médecin values(" + textBox5.Text + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','"+textBox9.Text+"',"+comboBox1.Text+","+comboBox2.Text+")";
            int x = cmd.ExecuteNonQuery();
            chargerDG2();
            cn.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            /*Ajouter Patient*/
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            /*precedent Patient*/
            if (bs2.Position == 0) { MessageBox.Show("vous etes sur le premier"); }
            else { bs2.MovePrevious(); }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            /*premier Patient*/
            bs2.MoveFirst();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            /*dernier Patient*/
            bs2.MoveLast();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            /*suivant Patient*/
            if (bs2.Position == bs2.Count - 1) { MessageBox.Show("vous étes sur le dernier "); }
            else
            { bs2.MoveNext(); }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            /*precedent Séjourne*/
            if (bs3.Position == 0) { MessageBox.Show("vous etes sur le premier"); }
            else { bs3.MovePrevious(); }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            /*premier Séjourne*/
            bs3.MoveFirst();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            /*dernier Séjourne*/
            bs3.MoveLast();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            /*suivant Séjourne*/
            if (bs3.Position == bs3.Count - 1) { MessageBox.Show("vous étes sur le dernier "); }
            else
            { bs3.MoveNext(); }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            /*Ajouter Séjourne*/
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

        }

        private void button22_Click(object sender, EventArgs e)
        {
            /*Modifier Patient*/
            if (cn.State == ConnectionState.Closed)
            { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "update Patient set  Nom='" + textBox11.Text + "',Prenom='" + textBox12.Text + "',DdN='" + textBox13.Text + "',Sexe='" + textBox14.Text + "',Adresse='" + textBox15.Text + "'where Idpatient='" + textBox10.Text + "',";

            int x = cmd.ExecuteNonQuery();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            /*Enregistrer Patient*/
            if (cn.State == ConnectionState.Closed) { cn.Open(); }

            cmd.Connection = cn;
            cmd.CommandText = " insert into Patient values(" + textBox10.Text + ",'" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "')";
            int x = cmd.ExecuteNonQuery();
            chargerDG3();
            cn.Close();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            /*Modifier Séjourne*/
            if (cn.State == ConnectionState.Closed)
            { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "update Séjourne set Idservice=" + comboBox3.Text + " , Idpatient=" + comboBox4.Text + " , DateEntree='" + textBox17.Text + "',Datesortie='" + textBox18.Text + "'where Idsejour='" + textBox16.Text + "',";

            int x = cmd.ExecuteNonQuery();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            /*Enregistrer Séjourne*/
            if (cn.State == ConnectionState.Closed) { cn.Open(); }

            cmd.Connection = cn;
            cmd.CommandText = " insert into Séjourne values(" + textBox16.Text + "," + comboBox3.Text + "," + comboBox4.Text + ",'" + textBox17.Text + "','" + textBox18.Text + "')";
            int x = cmd.ExecuteNonQuery();
            chargerDG4();
            cn.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            /*supprimes Patient*/
            if (cn.State == ConnectionState.Closed)
            { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "delete from Patient   where Idpatient=" + textBox10.Text;

            int x = cmd.ExecuteNonQuery();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            /*Ajouter Soigne*/
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            /*Modifier Soigne*/
            if (cn.State == ConnectionState.Closed)
            { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "update Soigne set Idmedecin=" + comboBox5.Text + " , Idpatient=" + comboBox6.Text + " , Nommaladie='" + textBox20.Text + "',commentaire='" + textBox21.Text + "',Date_soigne='" + textBox22.Text + "'where IdSoin='" + textBox19.Text + "',";

            int x = cmd.ExecuteNonQuery();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            /*Enregistrer Soigne*/
            if (cn.State == ConnectionState.Closed) { cn.Open(); }

            cmd.Connection = cn;
            cmd.CommandText = " insert into Soigne values(" + textBox19.Text + "," + comboBox5.Text + "," + comboBox6.Text + ",'" + textBox20.Text + "','" + textBox21.Text + "','" + textBox22.Text + "')";
            int x = cmd.ExecuteNonQuery();
            chargerDG5();
            cn.Close();
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (cn.State == ConnectionState.Closed) { cn.Open(); }
            cmd.Connection = cn;
            cmd.CommandText = "Select s.Idservice ,   s.NBLits , m.Idmedecin  from Service s , Hopital h,Médecin m where m.Idservice=s.Idservice and h.IdHopital =" + comboBox7.Text;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            CrystalReport1 cr1 = new CrystalReport1();
            cr1.SetDataSource(dt);

            crystalReportViewer1.ReportSource = cr1;
        }


    }
}
