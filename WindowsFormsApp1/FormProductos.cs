using System;
using System.Linq;
using System.Windows.Forms;
using unidad4.MIGRA;

namespace WindowsFormsApp1
{
    public partial class FormProductos : Form

    {
        public FormProductos()
        {
            InitializeComponent();
            CargarCategorias(); // Carga ComboBox al iniciar
            MostrarProductos();  // Muestra productos al iniciar
        }

        // Método para llenar ComboBox con Categorías
        private void CargarCategorias()
        {
            using (var db = new MIGRAMODE1())
            {
                comboCategorias.DataSource = db.Categorias.ToList();
                comboCategorias.DisplayMember = "NombreCategoria"; // Cambia según tu modelo
                comboCategorias.ValueMember = "CategoriaID";
            }
        }

        // Mostrar todos los productos en DataGridView
        private void MostrarProductos()
        {
            using (var db = new MIGRAMODE1())
            {
                dataGridProductos.DataSource = db.Productos
                    .Select(p => new
                    {
                        p.ProductoID,
                        p.NombreProducto,
                        p.Descripcion,
                        p.Precio,
                        p.Stock,
                        Categoria = p.Categorias.NombreCategoria
                    })
                    .ToList();
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarProductos();
            MessageBox.Show("Productos mostrados correctamente.");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1())
            {
                Productos p = new Productos
                {
                    // ProductoID generalmente se autogenera, no es necesario asignarlo
                    NombreProducto = txtNombreProducto.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    Stock = int.Parse(txtStock.Text),
                    CategoriaID = (int)comboCategorias.SelectedValue
                };
                db.Productos.Add(p);
                db.SaveChanges();
            }

            MostrarProductos();
            MessageBox.Show("Producto insertado correctamente.");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1())
            {
                int id = int.Parse(txtIDProducto.Text);
                var producto = db.Productos.Find(id);
                if (producto != null)
                {
                    producto.NombreProducto = txtNombreProducto.Text;
                    producto.Descripcion = txtDescripcion.Text;
                    producto.Precio = decimal.Parse(txtPrecio.Text);
                    producto.Stock = int.Parse(txtStock.Text);
                    producto.CategoriaID = (int)comboCategorias.SelectedValue;

                    db.SaveChanges();
                }
            }

            MostrarProductos();
            MessageBox.Show("Producto actualizado correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1())
            {
                int id = int.Parse(txtIDProducto.Text);
                var producto = db.Productos.Find(id);
                if (producto != null)
                {
                    db.Productos.Remove(producto);
                    db.SaveChanges();
                }
            }

            MostrarProductos();
            MessageBox.Show("Producto eliminado correctamente.");
        }
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void comboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Puedes dejarlo vacío si no necesitas lógica
        }
        private void dataGridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Opcional: dejar vacío si no necesitas lógica
        }
        private void dataGridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridProductos.Rows[e.RowIndex];
                txtIDProducto.Text = row.Cells["ProductoID"].Value.ToString();
                txtNombreProducto.Text = row.Cells["NombreProducto"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtStock.Text = row.Cells["Stock"].Value.ToString();

                string catNombre = row.Cells["Categoria"].Value.ToString();
                comboCategorias.SelectedIndex = comboCategorias.FindString(catNombre);
            }
        }
    }
}