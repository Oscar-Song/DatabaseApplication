using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void connBtn_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            int id = Int32.Parse(txtID.Text);

            string connectionString;
            SqlConnection cnn;
            connectionString = @"Server=DESKTOP-8ULP6FI\SQLEXPRESS;Database=Demodb;Trusted_Connection=true";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql= "";

            sql = "Insert into demotb (TutorialID, TutorialName) values("+id+",'"+name+"')";

            command = new SqlCommand(sql, cnn);
            adapter.DeleteCommand = new SqlCommand(sql, cnn);
            adapter.DeleteCommand.ExecuteNonQuery();

            MessageBox.Show("Done!");
            command.Dispose();
            cnn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'demodbDataSet.demotb' table. You can move, or remove it, as needed.
            this.demotbTableAdapter.Fill(this.demodbDataSet.demotb);

        }
    }
}
