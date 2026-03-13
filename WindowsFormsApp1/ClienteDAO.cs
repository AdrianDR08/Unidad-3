using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
public class ClienteDAO
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-5HV8ES8;Initial Catalog=ProyectoBD;Integrated Security=True");

    //mostar
    public DataTable MostrarClientes()
    {
        con.Open();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Clientes", con);

        DataTable tabla = new DataTable();

        da.Fill(tabla);

        con.Close();

        return tabla;
    }

    // Insertar cliente
    public void InsertarCliente(int id, string nombre, string correo, string telefono, string direccion)
    {
        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Clientes VALUES (@id,@nombre,@correo,@telefono,@direccion)", con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@direccion", direccion);

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
    // Actualizar cliente
    public void ActualizarCliente(int id, string nombre, string correo, string telefono, string direccion)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand(
            "UPDATE Clientes SET NombreCompleto=@nombre, CorreoElectronico=@correo, Telefono=@telefono, Direccion=@direccion WHERE ClienteID=@id",
            con
        );
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@correo", correo);
        cmd.Parameters.AddWithValue("@telefono", telefono);
        cmd.Parameters.AddWithValue("@direccion", direccion);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    // Eliminar cliente
    public void EliminarCliente(int id)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM Clientes WHERE ClienteID=@id", con);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}