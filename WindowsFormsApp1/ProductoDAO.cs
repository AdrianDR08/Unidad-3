using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class ProductoDAO
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-5HV8ES8;Initial Catalog=ProyectoBD;Integrated Security=True");

        public DataTable MostrarProductos()
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Productos", con);

            DataTable tabla = new DataTable();

            da.Fill(tabla);

            con.Close();

            return tabla;
        }

        public void InsertarProducto(int id, string nombre, string descripcion, decimal precio, int stock, int categoria)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Productos (ProductoID,NombreProducto,Descripcion,Precio,Stock,CategoriaID) VALUES (@id,@nombre,@descripcion,@precio,@stock,@categoria)", con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.Parameters.AddWithValue("@categoria", categoria);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void ActualizarProducto(int id, string nombre, string descripcion, decimal precio, int stock, int categoria)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Productos SET NombreProducto=@nombre,Descripcion=@descripcion,Precio=@precio,Stock=@stock,CategoriaID=@categoria WHERE ProductoID=@id", con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.Parameters.AddWithValue("@categoria", categoria);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EliminarProducto(int id)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Productos WHERE ProductoID=@id", con);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
