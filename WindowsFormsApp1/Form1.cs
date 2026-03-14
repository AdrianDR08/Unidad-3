using System;
using System.Linq;
using System.Windows.Forms;
using unidad4.MIGRA;
using WindowsFormsApp1; 

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1()) 
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

       
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            using (var db = new MIGRAMODE1()) 
            {
                
                unidad4.MIGRA.Clientes c = new unidad4.MIGRA.Clientes
                {
                    ClienteID = int.Parse(txtID.Text),
                    NombreCompleto = txtNombre.Text,      
                    CorreoElectronico = txtCorreo.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                };

                db.Clientes.Add(c);  
                db.SaveChanges();    
            }

            
            btnMostrar_Click(sender, e);

            MessageBox.Show("Cliente insertado correctamente.");
        }

        
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

            btnMostrar_Click(sender, e);
            MessageBox.Show("Cliente actualizado correctamente.");
        }

       
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

            btnMostrar_Click(sender, e); 
            MessageBox.Show("Cliente eliminado correctamente.");
        }

        
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        
        private void txtID_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

        private void dataGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}