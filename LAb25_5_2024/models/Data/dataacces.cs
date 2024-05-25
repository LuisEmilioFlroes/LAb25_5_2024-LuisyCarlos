using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LAb25_5_2024.models


using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace LAb25_5_2024.models.Data
{
    internal class dataacces
    {
        string connectionString = "server=localhost;database=db_universidad:user=root;=LuisFlores";
        MySqlConnection connection;
       
        public dataacces(string connectionstring)
        {
            
             connection = new MySqlConnection(connectionstring);

            
           


        }
        public void insertar(model juegos)
        {
            string query = "INSERT INTO catalogo_consolas (nombre_consola, compania, anio_lanzamiento, generacion)" +
                "VALUES(@nombre_consola, @compania, @anio_lanzamiento, @generacion)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre_consola", juegos._Nombre_consola);
            cmd.Parameters.AddWithValue("@compania", juegos._compania);
            cmd.Parameters.AddWithValue("@anio_lanzamiento",juegos.anio_lanzamiento );
            cmd.Parameters.AddWithValue("@generacion", juegos.generacion);
            
            connection.Open();
            cmd.ExecuteNonQuery();
        }
        public void Actualizar(model juegos)
        {
            try
            {
                string query = "UPDATE catalogo_consolas SET nombre_consola = @nombre_consola, compania = @compania," +
                    " anio_lanzamiento = @anio_lanzamiento, generacion = @generacion WHERE id_consola = @id_consola";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre_consola", juegos._Nombre_consola);
                cmd.Parameters.AddWithValue("@id_consola", juegos.id_consola);
                cmd.Parameters.AddWithValue("@compania", juegos._compania);
                cmd.Parameters.AddWithValue("@anio_lanzamiento", juegos.anio_lanzamiento);
                cmd.Parameters.AddWithValue("@generacion", juegos.generacion);
               

                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


    }
}
