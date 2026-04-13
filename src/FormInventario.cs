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
using InventarioEquiposTI.Models;


namespace InventarioEquiposTI
{
    public partial class FormInventario : Form
    {
        string connectionString = "Server=.\\SQLEXPRESS;Database=InventarioTI;Trusted_Connection=True;";
        public FormInventario()
        {
            InitializeComponent();
        }
        private List<Equipo> ObtenerEquipos()
        {
            List<Equipo> lista = new List<Equipo>();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Equipos";
                SqlCommand comando = new SqlCommand(query, conexion);

                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Equipo equipo = new Equipo()
                    {
                        IdEquipo = Convert.ToInt32(reader["IdEquipo"]),
                        Tipo = reader["Tipo"].ToString(),
                        Marca = reader["Marca"].ToString(),
                        Modelo = reader["Modelo"].ToString(),
                        Estado = reader["Estado"].ToString()
                    };

                    lista.Add(equipo);
                }
            }

            return lista;
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            dgvEquipos.DataSource = ObtenerEquipos();
        }

        private void dgvEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAgregarEquipo form = new FormAgregarEquipo();
            form.ShowDialog();
            dgvEquipos.DataSource = ObtenerEquipos();
        }
    }
}
