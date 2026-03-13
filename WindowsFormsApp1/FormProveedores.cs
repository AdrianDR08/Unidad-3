using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormProveedores : Form
    {
        public FormProveedores()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                ProveedorDAO dao = new ProveedorDAO();

                dao.EliminarProveedor(int.Parse(txtIDProveedor.Text));

                dataGridProveedores.DataSource = dao.MostrarProveedores();

                MessageBox.Show("Proveedor eliminado correctamente.");
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            {
                ProveedorDAO dao = new ProveedorDAO();

                dataGridProveedores.DataSource = dao.MostrarProveedores();

                MessageBox.Show("Proveedores mostrados correctamente.");
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            {
                ProveedorDAO dao = new ProveedorDAO();

                dao.InsertarProveedor(
                    int.Parse(txtIDProveedor.Text),
                    txtNombreProveedor.Text,
                    txtTelefono.Text,
                    txtDireccion.Text
                );

                dataGridProveedores.DataSource = dao.MostrarProveedores();

                MessageBox.Show("Proveedor insertado correctamente.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            {
                ProveedorDAO dao = new ProveedorDAO();

                dao.ActualizarProveedor(
                    int.Parse(txtIDProveedor.Text),
                    txtNombreProveedor.Text,
                    txtTelefono.Text,
                    txtDireccion.Text
                );

                dataGridProveedores.DataSource = dao.MostrarProveedores();

                MessageBox.Show("Proveedor actualizado correctamente.");
            }
        }
    }
}
