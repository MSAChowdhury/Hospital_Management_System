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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            String username = usertxt.Text;
            String password = passtxt.Text;
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(); 
            con.ConnectionString = "data source = DESKTOP-G7R371A\\SQLEXPRESS; database = Hospital; integrated security = True"; /*linking database*/
            /*checking two values from the Login table*/
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select UserName, Password from Login where UserName = '" + usertxt.Text + "'and Password = '" + passtxt.Text + "'");
            /*connecting the databse*/
            cmd.Connection = con; 

            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); /*Data tables to get confirmed by some values if the name & pass is stored*/
            da.Fill(dt);
            if (dt.Rows.Count > 0) 
            {
                MessageBox.Show("Welcome " + usertxt.Text + ""); 

                this.Hide();
                Dashboard ds = new Dashboard(); /*creating object for 2nd form named 'dashboard'*/
                ds.Show();

            }
            else /*If enetered wrong name or pass*/
            {
                MessageBox.Show("INVALID! username or password");
            }
        }
    }
}
