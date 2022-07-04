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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            Student_Info();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hjha0\OneDrive\Pictures\Documents\Collegedb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Student_Info()
        {
            Con.Open();
            string query = "select * from StudentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StdDGV.DataSource = ds.Tables[0];
            Con.Close();



        }
        private void noduelist()
        {
            Con.Open();
            string query = "select * from StudentTbl where StdFees > "+0+"";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StdDGV.DataSource = ds.Tables[0];
            Con.Close();



        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(StdId.Text ==""||StdName.Text == "" || StdPhone.Text ==""||StdFees.Text=="")
                {
                    MessageBox.Show("Missing Information");


                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into StudentTbl values('" + StdId.Text + "' , '" + StdName.Text + "' , '" + StdGender.Text + "' ,'" + StdDOB.Text + "' ,'" + StdPhone.Text + "' , '" + StdDep.Text + "' , '" + StdFees.Text + "' )", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Successfully Added");
                    Con.Close();
                    Student_Info();



                }

            }
            catch
            {

                MessageBox.Show("Something Went Wrong");

            }

            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void StdDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
                StdId.Text = StdDGV.SelectedRows[0].Cells[0].Value.ToString();
                StdName.Text = StdDGV.SelectedRows[0].Cells[1].Value.ToString();
                StdGender.Text = StdDGV.SelectedRows[0].Cells[2].Value.ToString();
                StdDOB.Text = StdDGV.SelectedRows[0].Cells[3].Value.ToString();
                StdPhone.Text = StdDGV.SelectedRows[0].Cells[4].Value.ToString();
                StdDep.Text = StdDGV.SelectedRows[0].Cells[5].Value.ToString();
                StdFees.Text = StdDGV.SelectedRows[0].Cells[6].Value.ToString();
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (StdId.Text == "")
                {
                    MessageBox.Show("Missing Information");

                }
                else
                {
                    Con.Open();
                    string query = "delete from StudentTbl where StdId= '"+StdId.Text+"';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Deleted Successfully");
                    Con.Close();
                    Student_Info();


                }

            }
            catch
            {

                MessageBox.Show("Oops....User Not deleted");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (StdId.Text == "" || StdName.Text == "" || StdGender.Text == "" || StdPhone.Text == "" || StdFees.Text == "" )
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update StudentTbl set StdName = '" + StdName.Text + "' , StdGender = '" + StdGender.Text + "' , StdDOB = '" + StdDOB.Text + "' , StdPhone = '" + StdPhone.Text + "' , StdDep = '" + StdDep.Text + "' , StdFees = '" + StdFees.Text + "' , where StdId = '"+StdId.Text+"';";
                    SqlCommand cmd = new SqlCommand(query , Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Updated Successfully");
                    Con.Close();
                    Student_Info();

                }
            }
            catch
            {



                MessageBox.Show("Oops...Student not updated ");


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm home = new MainForm();
            home.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Student_Info();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            noduelist(); 
        }
    }
}
