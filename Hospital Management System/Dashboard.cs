using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            /*to have fresh home, disabled all panels*/
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

        }

        private void NewRecordBtn_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void AddressTxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ContactTxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void AgeTxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BloodTxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void PaitionIdTxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String name = NameTxt.Text; /*storing text from textbox into variable to designated datatypes*/
                String address = AddressTxt.Text;
                Int64 contact = Convert.ToInt64(ContactTxt.Text);
                int age = Convert.ToInt32(AgeTxt.Text);
                String gender = comboGender.Text;
                String blood = BloodTxt.Text;
                String any = PreProblemTxt.Text;
                int pid = Convert.ToInt32(PaitionIdTxt.Text);

                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
                con.ConnectionString = "data source = DESKTOP-G7R371A\\SQLEXPRESS; database = Hospital; integrated security = True";
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.Connection = con; /*connecting database*/

                cmd.CommandText = "insert into AddPatient values ('" + name + "', '" + address + "'," + contact + "," + age + ",'" + gender + "','" + blood + "','" + any + "'," + pid + ")";

                System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet DS = new DataSet(); /*Data set to fill boxes*/
                DA.Fill(DS);
                MessageBox.Show("Data Saved!");
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill up all boxes");
            }

            /*Clearing all boxes*/

            NameTxt.Clear();
            AddressTxt.Clear();
            ContactTxt.Clear();
            AgeTxt.Clear();
            BloodTxt.Clear();
            PreProblemTxt.Clear();
            PaitionIdTxt.Clear();
            comboGender.ResetText();


        }

       
        

        private void AllinfoBtn_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.Visible = false;
            panel4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            panel2.Visible = true;
            panel3.Visible = false;
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int pid = Convert.ToInt32(textBox1.Text);

                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
                con.ConnectionString = "data source = DESKTOP-G7R371A\\SQLEXPRESS; database = Hospital; integrated security = True";
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from Addpatient where Patient_ID = " + pid + ""; /*checking the values from the AddPatient table*/

                System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int pid = Convert.ToInt32(textBox1.Text);
                String symptom = SymptomTxt.Text; 
                String diagnosis = DiagoTxt.Text;
                String medicine = MedTxt.Text;
                String ward = comboWard.Text;
                String type = comboTOWard.Text;


                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
                con.ConnectionString = "data source = DESKTOP-G7R371A\\SQLEXPRESS; database = Hospital; integrated security = True";
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "insert into MedicalReport values (" + pid + ", '" + symptom + "','" + diagnosis + "','" + medicine + "','" + ward + "','" + type + "')";

                System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                MessageBox.Show("Data Saved!");
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill up all boxes");
            }


            SymptomTxt.Clear();
            DiagoTxt.Clear();
            MedTxt.Clear();
            comboWard.ResetText();
            comboTOWard.ResetText();
        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {

        }

        private void HistoryPatTxt_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void ShowAllBtn_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "data source = DESKTOP-G7R371A\\SQLEXPRESS; database = Hospital; integrated security = True";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Connection = con;


            cmd.CommandText = "select * from AddPatient join MedicalReport on AddPatient.Patient_ID = MedicalReport.Patient_ID";

            System.Data.SqlClient.SqlDataAdapter DA1 = new System.Data.SqlClient.SqlDataAdapter(cmd);
            DataSet DS1 = new DataSet();
            DA1.Fill(DS1);

            dataGridView2.DataSource = DS1.Tables[0];
        }

        private void HinfoBtn_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel3.Visible = false;
            panel2.Visible = false;
        }
    }
}
