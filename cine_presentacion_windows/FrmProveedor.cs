using cine_acceso_datos.Entidades;
using cine_logica_negocio;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cine_presentacion_windows
{

    public partial class FrmProveedor : Form
    {
        private ProveedorLogica proveedorLogica;

        public FrmProveedor()
        {
            InitializeComponent();
            proveedorLogica = new ProveedorLogica();
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            inicializarDatosProveedores();
        }

        private void inicializarDatosProveedores()
        {
            // Inicializamos el DataGridView
            List<Proveedor> listaProveedores = proveedorLogica.ObtenerTodosProveedores();
            dgvProveedores.Rows.Clear();
            dgvProveedores.Columns.Clear();

            //Añadir columnas al DataGridView
            dgvProveedores.Columns.Add("id", "ID");
            dgvProveedores.Columns.Add("nombre", "Nombre");
            dgvProveedores.Columns.Add("apellido", "Apellido");
            dgvProveedores.Columns.Add("identificacion", "Identificación");
            dgvProveedores.Columns.Add("direccion", "Dirección");
            dgvProveedores.Columns.Add("telefono", "Teléfono");
            dgvProveedores.Columns.Add("correo", "Correo");

            foreach (Proveedor proveedor in listaProveedores)
            {
                dgvProveedores.Rows.Add(
                    proveedor.ID_PROVEEDOR,
                    proveedor.NOMBRE_PROVEEDOR,
                    proveedor.APELLIDO_PROVEEDOR,
                    proveedor.IDENTIFICACION_PROVEEDOR,
                    proveedor.DIRECCION_PROVEEDOR,
                    proveedor.TELEFONO_PROVEEDOR,
                    proveedor.CORREO_PROVEEDOR);
            }
            dgvProveedores.ClearSelection();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvProveedores.Rows[e.RowIndex];
                txtNombre.Text = row.Cells["nombre"].Value.ToString() ?? string.Empty;
                txtApellido.Text = row.Cells["apellido"].Value.ToString() ?? string.Empty;
                txtIdentificacion.Text = row.Cells["identificacion"].Value.ToString() ?? string.Empty;
                txtDireccion.Text = row.Cells["direccion"].Value?.ToString() ?? string.Empty;
                txtTelefono.Text = row.Cells["telefono"].Value.ToString() ?? string.Empty;
                txtCorreo.Text = row.Cells["correo"].Value == null ? "" : row.Cells["correo"].Value.ToString();
                txtIdProveedor.Text = row.Cells["id"].Value.ToString();
            }
            else
            {
                limpiarCampos();
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            bool validaciones;
            validaciones = validacionesCampos();
            if (!validaciones)
            {
                return;
            }
            Proveedor proveedor = new Proveedor();
            proveedor.NOMBRE_PROVEEDOR = txtNombre.Text;
            proveedor.APELLIDO_PROVEEDOR = txtApellido.Text;
            proveedor.IDENTIFICACION_PROVEEDOR = txtIdentificacion.Text;
            proveedor.DIRECCION_PROVEEDOR = String.IsNullOrEmpty(txtDireccion.Text) ? "" : txtDireccion.Text;
            proveedor.TELEFONO_PROVEEDOR = txtTelefono.Text;
            proveedor.CORREO_PROVEEDOR = txtCorreo.Text;
            int proveedorCreado = proveedorLogica.InsertarProveedor(
                nombre: proveedor.NOMBRE_PROVEEDOR,
                apellido: proveedor.APELLIDO_PROVEEDOR,
                identificacion: proveedor.IDENTIFICACION_PROVEEDOR,
                direccion: proveedor.DIRECCION_PROVEEDOR,
                telefono: proveedor.TELEFONO_PROVEEDOR,
                correo: proveedor.CORREO_PROVEEDOR
                );
            MessageBox.Show("Proveedor creado con ID: " + proveedorCreado);
            limpiarCampos();
            inicializarDatosProveedores();
        }

        public bool validacionesCampos()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El nombre del proveedor no puede estar vacío");
                return false;
            }
            if (txtApellido.Text == "")
            {
                MessageBox.Show("El apellido del proveedor no puede estar vacío");
                return false;
            }
            if (txtIdentificacion.Text == "")
            {
                MessageBox.Show("La identificación del proveedor no puede estar vacía");
                return false;
            }
            if (txtTelefono.Text == "")
            {
                MessageBox.Show("El teléfono del proveedor no puede estar vacío");
                return false;
            }
            if (txtCorreo.Text == "")
            {
                MessageBox.Show("El correo del proveedor no puede estar vacío");
                return false;
            }
            return true;
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtIdentificacion.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Editamos un proveedor a partir de las cajas de texto
            if (txtIdProveedor.Text != "")
            {
                bool validaciones;
                validaciones = validacionesCampos();
                if (!validaciones)
                {
                    return;
                }
                int idProveedor = Convert.ToInt32(txtIdProveedor.Text);
                proveedorLogica.ActualizarProveedor(
                   idProveedor: idProveedor,
                   nombre: txtNombre.Text,
                   apellido: txtApellido.Text,
                   identificacion: txtIdentificacion.Text,
                   direccion: txtDireccion.Text,
                   telefono: txtTelefono.Text,
                   correo: txtCorreo.Text
                   );
                MessageBox.Show("Proveedor actualizado con ID: " + idProveedor);
                limpiarCampos();
                inicializarDatosProveedores();
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Eliminamos un proveedor seleccionado de la caja de texto txtIdProveedor
            if (txtIdProveedor.Text != "")
            {
                int idProveedor = Convert.ToInt32(txtIdProveedor.Text);
                proveedorLogica.EliminarProveedor(idProveedor);
                MessageBox.Show("Proveedor eliminado con ID: " + idProveedor);
                limpiarCampos();
                inicializarDatosProveedores();
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para eliminar");
            }
        }
    }
}
