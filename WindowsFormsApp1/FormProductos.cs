using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
            CargarCategorias();
        }

        void CargarCategorias()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5HV8ES8;Initial Catalog=ProyectoBD;Integrated Security=True");

            SqlDataAdapter da = new SqlDataAdapter("SELECT CategoriaID, NombreCategoria FROM Categorias", con);

            DataTable tabla = new DataTable();

            da.Fill(tabla);

            comboCategorias.DataSource = tabla;
            comboCategorias.DisplayMember = "NombreCategoria";
            comboCategorias.ValueMember = "CategoriaID";
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            ProductoDAO dao = new ProductoDAO();

            dataGridProductos.DataSource = dao.MostrarProductos();

            MessageBox.Show("Productos mostrados correctamente.");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            ProductoDAO dao = new ProductoDAO();

            dao.InsertarProducto(
                int.Parse(txtIDProducto.Text),
                txtNombreProducto.Text,
                txtDescripcion.Text,
                decimal.Parse(txtPrecio.Text),
                int.Parse(txtStock.Text),
                (int)comboCategorias.SelectedValue
            );

            dataGridProductos.DataSource = dao.MostrarProductos();

            MessageBox.Show("Producto insertado correctamente.");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ProductoDAO dao = new ProductoDAO();

            dao.ActualizarProducto(
                int.Parse(txtIDProducto.Text),
                txtNombreProducto.Text,
                txtDescripcion.Text,
                decimal.Parse(txtPrecio.Text),
                int.Parse(txtStock.Text),
                (int)comboCategorias.SelectedValue
            );

            dataGridProductos.DataSource = dao.MostrarProductos();

            MessageBox.Show("Producto actualizado correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ProductoDAO dao = new ProductoDAO();

            dao.EliminarProducto(int.Parse(txtIDProducto.Text));

            dataGridProductos.DataSource = dao.MostrarProductos();

            MessageBox.Show("Producto eliminado correctamente.");
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
