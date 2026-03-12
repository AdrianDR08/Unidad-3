using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class clientes
    {
        public static SqlConnection ClientesConecction()
        { 
            SqlConnection Conexion = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=master;Data Source=DESKTOP-5HV8ES8");
            Conexion.Open();

            return Conexion;
        }




}
}
