using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class CategoriaDAO
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-5HV8ES8;Initial Catalog=ProyectoBD;Integrated Security=True");

        public DataTable MostrarCategorias()
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Categorias", con);

            DataTable tabla = new DataTable();

            da.Fill(tabla);

            con.Close();

            return tabla;
        }

        public void InsertarCategoria(int id, string nombre, string descripcion)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Categorias VALUES (@id,@nombre,@descripcion)", con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void ActualizarCategoria(int id, string nombre, string descripcion)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Categorias SET NombreCategoria=@nombre,Descripcion=@descripcion WHERE CategoriaID=@id", con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EliminarCategoria(int id)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Categorias WHERE CategoriaID=@id", con);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}