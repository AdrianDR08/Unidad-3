using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class ClienteDAO
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-5HV8ES8;Initial Catalog=ProyectoBD;Integrated Security=True");

        public DataTable MostrarClientes()
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Clientes", con);

            DataTable tabla = new DataTable();

            da.Fill(tabla);

            con.Close();

            return tabla;
        }
    }
}