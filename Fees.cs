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
    public partial class Fees : Form
    {
 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Fees()
 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hjha0\OneDrive\Pictures\Documents\Collegedb.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (FeesNum.Text == "" || StdNameTb.Text == "" || Amount.Text == ""||Period.Text==""||StdIdTb.Text=="")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                   // string period = Period.Value.Year.ToString();
                    Con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select count(*) from FeesTbl where StdId= " + StdIdTb.Text + " and Period = '" + Period.Text + "'", Con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("No Dues for the selected Periods");
                        Con.Close();

                    }
                    else
                    {
                        //Con.Open();
                        SqlCommand cmd = new SqlCommand("insert into FeesTbl values (" + StdIdTb.Text + " , " + FeesNum.Text + " , " + Period.Text + " , " + Amount.Text + " , " + StdNameTb.Text + ")", Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Fees Added Successfully");
                        Con.Close();
                        Fees_Info();

                        updatestd();
                    }

                }
            }
            catch
            {
                MessageBox.Show("Oops....Something Wromg");

            }
        }

       
       // private readonly EventHandler dt;

       // public bool V { get; private set; }
        /*
        private void fillDepartment()
        {
            fillDepartment(StdId.DataSourceChanged, V, GetDt(), GetDt());
        }
        */
        /*
        private EventHandler GetDt()
        {
            return dt;
        }

        private DataTable GetDt()
        {
            return dataTable;
        }
*/
        /*
        private void fillDepartment(EventHandler dataSourceChanged, bool v, EventHandler dt, DataTable dt)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select StdName  from StudentTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            object value = dt.Columns.Add("StdName", typeof(int));
            dt.Load(rdr);
            const string V = "StdId";
            StdId.CausesValidation = v;
            //dataSourceChanged = dt;

            Con.Close();


        }
        */
        private void Fees_Info()
        {
            Con.Open();
            string query = "select * from FeesTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            FeesDGV.DataSource = ds.Tables[0];
            Con.Close();


        }
        private void updatestd()
        {
            Con.Open();
            string query = "update StudentTbl set StdFees = '" + Amount.Text + "' , where StdId = '" + StdIdTb.Text + "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();

            Con.Close();

        }
        private void Fees_Load(object sender, EventArgs e)
        {
            Fees_Info();


        }

        private TextBox GetStdName()
        {
            return StdNameTb;
        }

        private void StdId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            Con.Open();
            string query = "select * form StudentTbl where StdId = '" + StdIdTb.Text + "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                StdNameTb.Text = dr["StdName"].ToString();
            }

            Con.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm home = new MainForm();
            home.Show();
            this.Hide();

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            e.Graphics.DrawString("FEES RECEIPT", new Font("Century", 25, FontStyle.Bold), Brushes.Red, new Point(230));
            e.Graphics.DrawString("Receipt Number :", new Font("Century", 20, FontStyle.Bold), Brushes.Black, new Point(40,50));
            e.Graphics.DrawString(FeesDGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century ", 20, FontStyle.Bold), Brushes.Blue, new Point(300, 50));
            e.Graphics.DrawString("Student User :", new Font("Century", 20, FontStyle.Bold), Brushes.Blue, new Point(40, 80));
            e.Graphics.DrawString(FeesDGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century",20,FontStyle.Bold),Brushes.Blue  , new Point(300, 80));
            e.Graphics.DrawString("Student Name:", new Font("Century", 20, FontStyle.Bold), Brushes.Blue, new Point(40, 110));
            e.Graphics.DrawString(FeesDGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century", 20, FontStyle.Bold), Brushes.Blue, new Point(300, 110));
            e.Graphics.DrawString("Student Period :", new Font("Century", 20, FontStyle.Bold), Brushes.Blue, new Point(40, 140));
            e.Graphics.DrawString(FeesDGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Century", 20, FontStyle.Bold), Brushes.Blue, new Point(300, 140));
            e.Graphics.DrawString("Amount :", new Font("Century", 20, FontStyle.Bold), Brushes.Blue, new Point(40, 170));
            e.Graphics.DrawString(FeesDGV.SelectedRows[0].Cells[4].Value.ToString(), new Font("Century"  20, FontStyle.Bold), Brushes.Blue, new Point(300, 170));

#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        private void FeesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(printPreviewDialog1.ShowDialog()== DialogResult.OK)
            {
                printDocument1.Print();

            }
        }
    }
}
