using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Prueba_CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9ME3U4J\\SQLEXPRESS2008;Initial Catalog=CRUD;Integrated Security=True;");
            con.Open();
            SqlCommand command = new SqlCommand("insert into products values ('"+nameProduct.Text + "','" + designName.Text + "','" + selectColor.Text + "', getdate())", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Exito");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9ME3U4J\\SQLEXPRESS2008;Initial Catalog=CRUD;Integrated Security=True;");
            con.Open();
            int valor;
            if(int.TryParse(buscar.Text,out valor))
            {
                SqlCommand command = new SqlCommand("select * from products where product_id=@valor", con);
                command.Parameters.AddWithValue("@valor", valor);
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Example of accessing data by column name:
                            int productId = reader.GetInt32(reader.GetOrdinal("product_id"));
                            string productName = reader.GetString(reader.GetOrdinal("product_name"));
                            string design = reader.GetString(reader.GetOrdinal("design"));
                            string color = reader.GetString(reader.GetOrdinal("color"));
                            DateTime fecha = reader.GetDateTime(reader.GetOrdinal("product_date"));

                            
                            resultado.Text=String.Format
                            ("ID: {0}, Name: {1}, Design: {2}, Color: {3}, Date: {4}"
                            ,productId,productName,design,color,fecha);
                        }
                    }
                }
                con.Close();
            }
        }
    }
}
