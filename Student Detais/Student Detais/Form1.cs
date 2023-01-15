using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_Detais
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string connectionString = "server=localhost;database=std;uid=root;pwd=''";
        MySqlConnection con = new MySqlConnection(connectionString);

        public void LoadData()
        {
            string query = "select * from detalis";
            MySqlDataAdapter adp = new MySqlDataAdapter(query, con);
            con.Open();
            DataTable tb = new DataTable();
            adp.Fill(tb);
            dataGridView1.DataSource = tb;
        }
        
        public void enterDetails ()
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            try
            {
                string query = "insert into detalis values('" + txt1.Text + "','" + txt2.Text + "','" + txt3.Text + "'," + txt4.Text + ",'" + txt5.Text + "')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                DataTable tb = new DataTable();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted..!");
                txt1.Clear();
                txt2.Clear();
                txt3.Clear();
                txt4.Clear();
                txt5.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("There is a problem. Please contact the SW engineer");
            }
            con.Close();
        }

        public void updateDetails()
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            try
            {
                string query = " update detalis set FirstName = '" + txt8.Text + "', LastName = '" + txt9.Text + "', Age = " + txt10.Text + ", Town = '" + txt11.Text + "' where IndexNo = '" + txt7.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                DataTable tb = new DataTable();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated..!");
                txt7.Clear();
                txt8.Clear();
                txt9.Clear();
                txt10.Clear();
                txt11.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("There is a problem. Please contact the SW engineer");
            }
            con.Close();
        }

        public void deleteDetails()
        {
            if (con.State == ConnectionState.Open)
                con.Close();


            try
            {
                string query = "delete from detalis where indexno ='" + txt6.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted .....");
                txt6.Clear();
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("There is a problem. Please contact the SW engineer");
            }
            con.Close();
        }

        public void showDetails ()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            try
            {
                string query = "select * from detalis";
                MySqlDataAdapter adp = new MySqlDataAdapter(query, con);
                con.Open();
                DataTable tb = new DataTable();
                adp.Fill(tb);
                dataGridView1.DataSource = tb;
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("There is a problem. Please contact the SW engineer");
            }
            con.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            enterDetails();
        }

        private void btn5_Click_1(object sender, EventArgs e)
        {
            showDetails();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            deleteDetails();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            updateDetails();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
