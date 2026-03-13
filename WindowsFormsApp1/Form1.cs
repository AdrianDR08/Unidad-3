using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ClienteDAO clienteDAO = new ClienteDAO();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();

            dataGridClientes.DataSource = dao.MostrarClientes();

            MessageBox.Show("Clientes mostrados correctamente.");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();

            dao.InsertarCliente(
                int.Parse(txtID.Text),
                txtNombre.Text,
                txtCorreo.Text,
                txtTelefono.Text,
                txtDireccion.Text
            );

            dataGridClientes.DataSource = dao.MostrarClientes();

            MessageBox.Show("Cliente insertado correctamente.");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();

            dao.ActualizarCliente(
                int.Parse(txtID.Text),
                txtNombre.Text,
                txtCorreo.Text,
                txtTelefono.Text,
                txtDireccion.Text
            );

            dataGridClientes.DataSource = dao.MostrarClientes();

            MessageBox.Show("Cliente actualizado correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();

            dao.EliminarCliente(int.Parse(txtID.Text));

            dataGridClientes.DataSource = dao.MostrarClientes();

            MessageBox.Show("Cliente eliminado correctamente.");
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

