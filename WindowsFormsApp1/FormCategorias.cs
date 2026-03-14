using System;
using System.Linq;
using System.Windows.Forms;
using unidad4.MIGRA;

namespace WindowsFormsApp1
{
    public partial class FormCategorias : Form
    {
        public FormCategorias()
        {
            InitializeComponent();
        }

        // Botón Mostrar
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1())
            {
                dataGridCategorias.DataSource = db.Categorias
                    .Select(c => new
                    {
                        c.CategoriaID,
                        c.NombreCategoria,
                        c.Descripcion
                    })
                    .ToList();
            }

            MessageBox.Show("Categorías mostradas correctamente.");
        }

        // Botón Insertar
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1())
            {
                unidad4.MIGRA.Categorias c = new unidad4.MIGRA.Categorias
                {
                    CategoriaID = int.Parse(txtIDCategoria.Text),
                    NombreCategoria = txtNombreCategoria.Text,
                    Descripcion = txtDescripcion.Text
                };

                db.Categorias.Add(c);
                db.SaveChanges();
            }

            btnMostrar_Click(sender, e); // refrescar DataGrid
            MessageBox.Show("Categoría insertada correctamente.");
        }

        // Botón Actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1())
            {
                int id = int.Parse(txtIDCategoria.Text);
                var c = db.Categorias.Find(id);
                if (c != null)
                {
                    c.NombreCategoria = txtNombreCategoria.Text;
                    c.Descripcion = txtDescripcion.Text;

                    db.SaveChanges();
                }
            }

            btnMostrar_Click(sender, e); // refrescar DataGrid
            MessageBox.Show("Categoría actualizada correctamente.");
        }

        // Botón Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1())
            {
                int id = int.Parse(txtIDCategoria.Text);
                var c = db.Categorias.Find(id);
                if (c != null)
                {
                    db.Categorias.Remove(c);
                    db.SaveChanges();
                }
            }

            btnMostrar_Click(sender, e); // refrescar DataGrid
            MessageBox.Show("Categoría eliminada correctamente.");
        }

        // Evento vacío para el Designer
        private void txtIDCategoria_TextChanged(object sender, EventArgs e) { }
    }
}