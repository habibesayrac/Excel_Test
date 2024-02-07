using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Configuration;

namespace Excel_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\habib\OneDrive\Desktop\1.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES;'");

        void listele()
        {
            connection.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from [Sheet1$]", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }



        private void BtnListele_Click(object sender, EventArgs e)
        {

            listele();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand("insert into [Sheet1$] (Saat,Ders) values (@p1,@p2)", connection);
            command.Parameters.AddWithValue("@p1", TxtSaat.Text);
            command.Parameters.AddWithValue("@p2", TxtDersAdi.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme başarılı!");
            connection.Close();
            listele();

        }

    }
}
