using System;
using System.Linq;
using System.Windows.Forms;
using unidad4.MIGRA;

namespace WindowsFormsApp1
{
    public partial class FormProveedores : Form
    {
        public FormProveedores()
        {
            InitializeComponent();
        }

       
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1())
            {
                dataGridProveedores.DataSource = db.Proveedores
                    .Select(p => new
                    {
                        p.ProveedorID,
                        p.NombreProveedor,
                        p.Telefono,
                        p.Direccion
                    })
                    .ToList();
            }

            MessageBox.Show("Proveedores mostrados correctamente.");
        }

        
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1())
            {
                unidad4.MIGRA.Proveedores p = new unidad4.MIGRA.Proveedores
                {
                    ProveedorID = int.Parse(txtIDProveedor.Text),
                    NombreProveedor = txtNombreProveedor.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                };

                db.Proveedores.Add(p);
                db.SaveChanges();
            }

            btnMostrar_Click(sender, e);
            MessageBox.Show("Proveedor insertado correctamente.");
        }

        
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1())
            {
                int id = int.Parse(txtIDProveedor.Text);
                var p = db.Proveedores.Find(id);
                if (p != null)
                {
                    p.NombreProveedor = txtNombreProveedor.Text;
                    p.Telefono = txtTelefono.Text;
                    p.Direccion = txtDireccion.Text;

                    db.SaveChanges();
                }
            }

            btnMostrar_Click(sender, e);
            MessageBox.Show("Proveedor actualizado correctamente.");
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1())
            {
                int id = int.Parse(txtIDProveedor.Text);
                var p = db.Proveedores.Find(id);
                if (p != null)
                {
                    db.Proveedores.Remove(p);
                    db.SaveChanges();
                }
            }

            btnMostrar_Click(sender, e);
            MessageBox.Show("Proveedor eliminado correctamente.");
        }

        
        private void txtIDProveedor_TextChanged(object sender, EventArgs e) { }

        private void dataGridProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}