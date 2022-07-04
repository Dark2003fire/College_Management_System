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
    public partial class UserForm : Form
    {

 
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UseridTb.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
            UsernameTb.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
            PasswordTb.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        
        public UserForm()
        {

            InitializeComponent();

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hjha0\OneDrive\Pictures\Documents\Collegedb.mdf;Integrated Security=True;Connect Timeout=30");
      
        private void UserForm_Load(object sender, EventArgs e)
        {
            Populate();

        }

        private void Populate()
        {
            Con.Open();
            string query = "select * from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query  ,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];
            Con.Close();
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (UseridTb.Text == "" || UsernameTb.Text == "" || PasswordTb.Text == "")
                {
                    MessageBox.Show("Missing Information");

                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTbl values('" + UseridTb.Text + "' , ' " + UsernameTb.Text + "' ,'" + PasswordTb.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Added Successfully");
                    Con.Close();
                    Populate();

                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");

            }






          



        }

        private void UIdTb_TextChanged(object sender, EventArgs e)
        {

            


        }

        private void UpassTb_TextChanged(object sender, EventArgs e)
        {
          


        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (UseridTb.Text == "")
                {
                    MessageBox.Show("Enter the User Id");

                }
                else
                {
                    Con.Open();
                    string query = "delete from UserTbl where Userid = " + UseridTb.Text + "; ";
                    SqlCommand cmd = new SqlCommand(query , Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted Successfully");
                    Con.Close();
                    Populate();

                }


            }
            catch
            {

                MessageBox.Show("Oops....User not deleted");



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(UseridTb.Text == "" || UsernameTb.Text == "" || PasswordTb.Text == "")
                {

                    MessageBox.Show("Missing Information");

                }
                else
                {
                    Con.Open();
                    string query = "update UserTbl set Username = '" + UsernameTb.Text + "',Password = '"+PasswordTb.Text+"'where Userid = "+UseridTb.Text+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Update Succesfully");
                    Con.Close();
                    Populate();





                }




            }
            catch
            {
                MessageBox.Show("User not deleted");


            }
        }
    }
}
