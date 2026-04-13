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

namespace InventarioEquiposTI
{
    public partial class FormAgregarEquipo : Form
    {

    string connectionString = "Server=.\\SQLEXPRESS;Database=InventarioTI;Trusted_Connection=True";
       
        public FormAgregarEquipo()
        {
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Equipos (Tipo, Marca, Modelo, Estado) VALUES (@Tipo, @Marca, @Modelo, @Estado)";
                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Tipo", txtTipo.Text);
                comando.Parameters.AddWithValue("@Marca", txtMarca.Text);
                comando.Parameters.AddWithValue("@Modelo", txtModelo.Text);
                comando.Parameters.AddWithValue("@Estado", txtEstado.Text);

                conexion.Open();
                comando.ExecuteNonQuery();
            }

            MessageBox.Show("Equipo agregado correctamente");
            this.Close();
        }
        private void FormAgregarEquipo_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (txtTipo.Text == "" || txtMarca.Text == "" || txtModelo.Text == "" || txtEstado.Text == "")
            {
                MessageBox.Show("Por favor llena todos los campos");
                return;
            }

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Equipos 
                         (Tipo, Marca, Modelo, Estado) 
                         VALUES 
                         (@Tipo, @Marca, @Modelo, @Estado)";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Tipo", txtTipo.Text);
                comando.Parameters.AddWithValue("@Marca", txtMarca.Text);
                comando.Parameters.AddWithValue("@Modelo", txtModelo.Text);
                comando.Parameters.AddWithValue("@Estado", txtEstado.Text);

                conexion.Open();
                comando.ExecuteNonQuery();
            }

            MessageBox.Show("Equipo agregado correctamente");
            this.Close();

        }
    }
}
