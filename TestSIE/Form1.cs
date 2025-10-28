using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TestSIE.Classes;

namespace TestSIE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarPersonas();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            string nombre = txtPersonName.Text.Trim();
            string apellido = txtLastNamePerson.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show("Debe ingresar nombre y apellido.");
                return;
            }

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();

                // Valida persona unica
                string checkQuery = "SELECT COUNT(*) FROM Persona WHERE nombre=@nombre AND apellido=@apellido";
                using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@nombre", nombre);
                    cmdCheck.Parameters.AddWithValue("@apellido", apellido);

                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        txtPersonName.Text = string.Empty;
                        txtLastNamePerson.Text = string.Empty;
                        MessageBox.Show("Ya existe una persona con ese nombre y apellido.");
                        return;
                    }
                }


                string insertQuery = "INSERT INTO Persona (nombre, apellido) VALUES (@nombre, @apellido)";
                using (SqlCommand cmdInsert = new SqlCommand(insertQuery, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@nombre", nombre);
                    cmdInsert.Parameters.AddWithValue("@apellido", apellido);
                    cmdInsert.ExecuteNonQuery();
                }

                MessageBox.Show("Persona agregada correctamente.");

            }

            txtPersonName.Text = string.Empty;
            txtLastNamePerson.Text = string.Empty;
            CargarPersonas();
        }

        private void CargarPersonas()
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT id, nombre, apellido FROM Persona";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    gcPersons.DataSource = dt;
                }
            }
        }

        private void btnCreateCar_Click(object sender, EventArgs e)
        {
            string marca = txtBrand.Text.Trim();
            string modelo = txtModel.Text.Trim();
            string vin = txtVIN.Text.Trim();

            if (string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(modelo) || string.IsNullOrEmpty(vin))
            {
                MessageBox.Show("Debe ingresar marca, modelo y VIN.");
                return;
            }

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();

                // Valida VIN único
                string checkQuery = "SELECT COUNT(*) FROM Coche WHERE VIN=@vin";
                using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@vin", vin);
                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Ya existe un coche con ese VIN.");
                        return;
                    }
                }

                string insertQuery = "INSERT INTO Coche (marca, modelo, VIN) VALUES (@marca, @modelo, @vin)";
                using (SqlCommand cmdInsert = new SqlCommand(insertQuery, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@marca", marca);
                    cmdInsert.Parameters.AddWithValue("@modelo", modelo);
                    cmdInsert.Parameters.AddWithValue("@vin", vin);
                    cmdInsert.ExecuteNonQuery();
                }

                MessageBox.Show("Coche agregado correctamente.");
            }

            CargarCoches();
        }

        private void CargarCoches()
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT id, marca, modelo, VIN FROM Coche";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    gcCars.DataSource = dt;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAssingCar_Click(object sender, EventArgs e)
        {

        }
    }
}