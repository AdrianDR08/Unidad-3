using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class ProveedorDAO
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-5HV8ES8;Initial Catalog=ProyectoBD;Integrated Security=True");

        public DataTable MostrarProveedores()
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Proveedores", con);

            DataTable tabla = new DataTable();

            da.Fill(tabla);

            con.Close();

            return tabla;
        }

        public void InsertarProveedor(int id, string nombre, string telefono, string direccion)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Proveedores (ProveedorID, NombreProveedor, Telefono, Direccion) VALUES (@id,@nombre,@telefono,@direccion)", con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@direccion", direccion);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void ActualizarProveedor(int id, string nombre, string telefono, string direccion)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Proveedores SET NombreProveedor=@nombre, Telefono=@telefono, Direccion=@direccion WHERE ProveedorID=@id", con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@direccion", direccion);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EliminarProveedor(int id)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM Proveedores WHERE ProveedorID=@id", con);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}