using System;
using System.Linq;
using System.Windows.Forms;
using unidad4.MIGRA;
using WindowsFormsApp1; // Ajusta solo si tu EDMX está en otro namespace

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Botón Mostrar
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1()) // <- tu contenedor real
            {
                dataGridClientes.DataSource = db.Clientes
                    .Select(c => new
                    {
                        c.ClienteID,
                        c.NombreCompleto,
                        c.CorreoElectronico,
                        c.Telefono,
                        c.Direccion
                    })
                    .ToList();
            }

            MessageBox.Show("Clientes mostrados correctamente.");
        }

        // Botón Insertar
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1()) // tu contexto EF
            {
                // Crear un objeto de la clase EF, no tu clase Cliente manual
                unidad4.MIGRA.Clientes c = new unidad4.MIGRA.Clientes
                {
                    ClienteID = int.Parse(txtID.Text),
                    NombreCompleto = txtNombre.Text,      // nombres exactos del EDMX
                    CorreoElectronico = txtCorreo.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                };

                db.Clientes.Add(c);  // EF agrega el registro
                db.SaveChanges();    // EF guarda cambios
            }

            // Refrescar DataGrid para mostrar el nuevo cliente
            btnMostrar_Click(sender, e);

            MessageBox.Show("Cliente insertado correctamente.");
        }

        // Botón Actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1())
            {
                int id = int.Parse(txtID.Text);
                var c = db.Clientes.Find(id);
                if (c != null)
                {
                    c.NombreCompleto = txtNombre.Text;
                    c.CorreoElectronico = txtCorreo.Text;
                    c.Telefono = txtTelefono.Text;
                    c.Direccion = txtDireccion.Text;

                    db.SaveChanges();
                }
            }

            btnMostrar_Click(sender, e); // refrescar DataGrid
            MessageBox.Show("Cliente actualizado correctamente.");
        }

        // Botón Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1())
            {
                int id = int.Parse(txtID.Text);
                var c = db.Clientes.Find(id);
                if (c != null)
                {
                    db.Clientes.Remove(c);
                    db.SaveChanges();
                }
            }

            btnMostrar_Click(sender, e); // refrescar DataGrid
            MessageBox.Show("Cliente eliminado correctamente.");
        }

        // Validar que solo se ingresen números en ID
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        // Eventos vacíos para el Designer
        private void txtID_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}