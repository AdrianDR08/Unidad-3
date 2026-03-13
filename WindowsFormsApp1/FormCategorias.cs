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
    public partial class FormCategorias : Form
    {
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            CategoriaDAO dao = new CategoriaDAO();

            dataGridCategorias.DataSource = dao.MostrarCategorias();

            MessageBox.Show("Categorias mostradas correctamente.");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            CategoriaDAO dao = new CategoriaDAO();

            dao.InsertarCategoria(
                int.Parse(txtIDCategoria.Text),
                txtNombreCategoria.Text,
                txtDescripcion.Text
            );

            dataGridCategorias.DataSource = dao.MostrarCategorias();

            MessageBox.Show("Categoria insertada correctamente.");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CategoriaDAO dao = new CategoriaDAO();

            dao.ActualizarCategoria(
                int.Parse(txtIDCategoria.Text),
                txtNombreCategoria.Text,
                txtDescripcion.Text
            );

            dataGridCategorias.DataSource = dao.MostrarCategorias();

            MessageBox.Show("Categoria actualizada correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CategoriaDAO dao = new CategoriaDAO();

            dao.EliminarCategoria(int.Parse(txtIDCategoria.Text));

            dataGridCategorias.DataSource = dao.MostrarCategorias();

            MessageBox.Show("Categoria eliminada correctamente.");
        }

        }
    }

