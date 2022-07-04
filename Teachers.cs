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
    public partial class Teachers : Form
    {
        public Teachers()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               if(TeacheridTb.Text ==""||TeacherNameTb.Text==""||
                  TeacherPhoneTb.Text==""||TeacherAddTb.Text == "" || TeacherDepTb.Text==""|| TeacherDOBTb.Text==""||TeacherGenderTb.Text=="")
                {
                    MessageBox.Show("Missing Information");

                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into TeacherTbl values" +
                        " ('" + TeacheridTb.Text + "' , " +
                        "'" + TeacherNameTb.Text + "' , " +
                        "'" + TeacherPhoneTb.Text + "' , " +
                        "'" + TeacherAddTb.Text + "'  , " +
                        "'" + TeacherGenderTb.Text + "' , " +
                        "'" + TeacherDOBTb.Text + "' ," +
                        "'" + TeacherDepTb.Text + "' )", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Teacher Added Successfully ");
                    Con.Close();
                    Teacher_info();

                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");


            }
        }

       
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hjha0\OneDrive\Pictures\Documents\Collegedb.mdf;Integrated Security=True;Connect Timeout=30");
      /*  private  void fillDepartment()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select DepName  from DepartmentTbl" , Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DepName", typeof(string));
            dt.Load(rdr);
            TeacherDepTb.CausesValidation = "DepName"
            TeacherDepTb.Datasource = dt;
            
            Con.Close();


        }
    */
        private void Teacher_info()
        {

            Con.Open();
            string query = "select * from TeacherTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TeacherDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void Teachers_Load(object sender, EventArgs e)
        {
           // fillDepartment();
            Teacher_info();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void TeacherDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TeacheridTb.Text = TeacherDGV.SelectedRows[0].Cells[0].Value.ToString();
            TeacherNameTb.Text = TeacherDGV.SelectedRows[0].Cells[1].Value.ToString();
            TeacherGenderTb.Text = TeacherDGV.SelectedRows[0].Cells[2].Value.ToString();
            TeacherPhoneTb.Text = TeacherDGV.SelectedRows[0].Cells[4].Value.ToString();
            TeacherAddTb.Text = TeacherDGV.SelectedRows[0].Cells[6].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(TeacheridTb.Text == "")
                {
                    MessageBox.Show("Missing Information");

                }
                else
                {
                    Con.Open();
                    string query = "delete from TeacherTbl where Teacherid = '"+TeacheridTb.Text+"';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Teacher Deleted Successfully");
                    Con.Close();
                    Teacher_info();

                }
            }
            catch
            {
                MessageBox.Show("Ooops....Teacher Info Not deleted ");


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (TeacheridTb.Text == "" || TeacherNameTb.Text == "" || TeacherAddTb.Text == "" || TeacherPhoneTb.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    Con.Open();
                    string query = "update TeacherTbl set TeacherName = '" + TeacherNameTb.Text + "' , TeacherGender = '" + TeacherGenderTb.Text + "' , TeacherDOB = '" + TeacherDOBTb.Text + "', TeacherPhone = '" + TeacherPhoneTb.Text + "', TeacherDep = '" + TeacherDepTb.Text + "' , TeacherAdd = '" + TeacherAddTb.Text + "' ,  where Teacherid = '" + TeacheridTb.Text +"' ; ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Teacher updated Successfully");
                    Con.Close();
                    Teacher_info();



                }
            }
            catch
            {
                MessageBox.Show("Oops...Teacher info not updated");

            }
        }
    }
}
