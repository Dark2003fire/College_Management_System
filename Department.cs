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
    public partial class Department : Form
    {
        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        public Department()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hjha0\OneDrive\Pictures\Documents\Collegedb.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void TotalInfo()
        {
            Con.Open();
            string query = "select * from DepartmentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query , Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DepDGV.DataSource = ds.Tables[0];
            Con.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "" || DepDescTb.Text == "" || DepDurationTb.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into DepartmentTbl values ('"+DepNameTb.Text+"'  , '" +DepDescTb.Text +"', '"+DepDurationTb.Text+"')" , Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department  Added Successfully");
                    Con.Close();
                    TotalInfo();

                }
                    

               

            }
            catch
            {
                MessageBox.Show("Something went Wrong");


            }

        }

        private void Department_Load(object sender, EventArgs e)
        {
            TotalInfo();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(DepNameTb.Text == "")
                {
                    MessageBox.Show("Enter the Department Name");
                }
                else
                {
                    Con.Open();
                    string query = "delete from DepartmentTbl where DepName = ' " + DepNameTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Deleted Successfully");
                    Con.Close();
                    TotalInfo();


                }
                

            }
            catch
            {

                MessageBox.Show("Oops...Department not Deleted ");

            }
        }

        private void DepDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DepNameTb.Text = DepDGV.SelectedRows[0].Cells[0].Value.ToString();
            DepDescTb.Text = DepDGV.SelectedRows[0].Cells[1].Value.ToString();
            DepDurationTb.Text = DepDGV.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(DepNameTb.Text == "" || DepDescTb.Text==""|| DepDurationTb.Text == "")
                {
                    MessageBox.Show("Missing Data");

                }
                else
                {
                    Con.Open();
                    string query = "update  DepartmentTbl set DepDesc='" + DepDescTb.Text + "' ,  DepDuration = '" + DepDurationTb.Text + "' , where DepName = '" + DepNameTb.Text + "' ;";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Updated Successfully");
                    Con.Close();
                    TotalInfo();


                }
            }
            catch
            {

                MessageBox.Show("Oops...Department Not Updated");


            }
        }
    }
}
