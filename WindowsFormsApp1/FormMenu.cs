using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();

            // Conectar los botones a sus eventos
            btnClientes.Click += btnClientes_Click;
            btnCategorias.Click += btnCategorias_Click;
            btnProveedores.Click += btnProveedores_Click;
            btnProductos.Click += btnProductos_Click;
        }

        // Abrir formulario Clientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            Form1 clientes = new Form1();
            clientes.Show();
        }

        // Abrir formulario Categorías
        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FormCategorias categorias = new FormCategorias();
            categorias.Show();
        }

        // Abrir formulario Proveedores
        private void btnProveedores_Click(object sender, EventArgs e)
        {
            FormProveedores proveedores = new FormProveedores();
            proveedores.Show();
        }

        // Abrir formulario Productos
        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormProductos productos = new FormProductos();
            productos.Show();
        }
    }
}