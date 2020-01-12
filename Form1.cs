using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Login
{
    public partial class Form1 : Form
    {   //objeto de conexion

        private NpgsqlConnection conexion1 = new NpgsqlConnection();
        
        public Form1()
        {
            InitializeComponent();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            String cadena = "SELECT * FROM User VALUES WHERE username='" + textBox1.Text + "'AND password = '" + textBox2.Text + "';";
            conexion1.ConnectionString = "User ID=postgres; Password=jypam.1995; Host=localhost; Port=5432; Database=Login; commandtimeout=900";
            conexion1.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(cadena, conexion1);
            NpgsqlDataReader reader;
            reader = cmd.ExecuteReader();

            string user;

            if (reader.Read())
            {
                user = reader.GetString(0);

                MessageBox.Show("Bienvenido '" + user + "'");


            }else
            {
                MessageBox.Show("No se encontro usuario");
            }

            conexion1.Close();

        }
    }
}
