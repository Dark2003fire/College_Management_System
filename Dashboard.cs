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
namespace CollegeManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hjha0\OneDrive\Pictures\Documents\Collegedb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Dashboard_Load(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from StudentTbl", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            Stdlbl.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from FeesTbl", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            Feeslbl.Text = "Rs"+Convert.ToInt32(dt2.Rows[0][0].ToString())*25000;
            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from TeacherTbl", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            Teacherlbl.Text = dt3.Rows[0][0].ToString();
            SqlDataAdapter sda4 = new SqlDataAdapter("select count(*) from DepartmentTbl" ,Con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            Deplbl.Text = dt4.Rows[0][0].ToString();


            Con.Close();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
