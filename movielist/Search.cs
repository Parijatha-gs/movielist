using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
namespace movielist
{
    public partial class Search : Form
    {
        public string constring = "Data Source=DESKTOP-VUE203J;Initial Catalog=moviemulesoft;Integrated Security=True";
        
        public Search()
        {
            InitializeComponent();
        }

       
       
        private void search_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search s = new Search();
            s.Show();
        }

        

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        

        private void searchbutton_Click(object sender, EventArgs e)
        {
            
            
                SqlConnection con = new SqlConnection(constring);
           // string sqlquery = "select *from [moviemulesoft].[dbo].[movielist]";
                string sqlquery = "select *from [moviemulesoft].[dbo].[movielist] where [movie_name]='" + searchbar.Text + "'";
                con.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, con);
                SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                searchgridview.DataSource = dt;               
                con.Close();
            

        }
        private void searchgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            searchgridview.EnableHeadersVisualStyles = false;
            this.searchgridview.DefaultCellStyle.BackColor = Color.White;
            this.searchgridview.DefaultCellStyle.ForeColor = Color.Black;
            
        }

        

        private void searchbar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dataGridView1.Show();
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(" select *from movielist", con);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                con.Close();
            }
            else
            {
               dataGridView1.Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void INSERT_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into movielist([s.no],movie_name,lead_hero,lead_heroine,director,release_year)values('" + Convert.ToInt32(textBox2.Text) + "','" + textBox3.Text + "','" + textBox4.Text+"','"+textBox7.Text+"','"+textBox6.Text+"','" + Convert.ToInt32(textBox5.Text) + "');"; 
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Added Successfully.");
            }
            catch (Exception )
            {
                MessageBox.Show("Sorry!Couldn't insert data.");
                
            }
           
            // movielist.Rows.Add(textBox2.Text, textBox3.Text, textBox4.Text, textBox7.Text, textBox6.Text, textBox5.Text);
        }
    }
}
