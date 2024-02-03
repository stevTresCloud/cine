using cine_acceso_datos.Entidades;
using cine_logica_negocio;
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
    public partial class FrmPelicula : Form
    {
        private Pelicula pelicula;
        private PeliculaLogica peliculaLogica;
        private int idValor;
        private int swNuevo = 1;
        public FrmPelicula()
        {
            InitializeComponent();
            pelicula = new Pelicula();
            peliculaLogica = new PeliculaLogica();
        }

        private void insertarPelicula()
        {
            pelicula.TITULO = txtTitulo.Text;
            pelicula.CATEGORIA = txtCategoria.Text;
            pelicula.RESTRICCION = txtRestriccion.Text;
            pelicula.SINOPSIS = txtSinopsis.Text;
            pelicula.TRAILER_URL= txtTrailer.Text;
            pelicula.CALIFICACION = int.Parse(txtCalificacion.Text);
            pelicula.CANTIDAD_PELICULA = int.Parse(txtCantidad.Text);
            //pelicula.ID_LINEAS_PEDIDO= txtLineaPedido.Text;
            //pelicula.REPARTO = txtReparto.Text;
            pelicula.ACTIVO_PELICULA = true;

            int id_pelicula = peliculaLogica.InsertarPelicula(
                titulo: pelicula.TITULO,
                categoria: pelicula.CATEGORIA,
                restriccion: pelicula.RESTRICCION,
                sinopsis: pelicula.SINOPSIS,
                trailerUrl: pelicula.TRAILER_URL,
                cantidadPelicula: pelicula.CANTIDAD_PELICULA,
                calificacion: int.Parse(txtCalificacion.Text)
                );

            if (id_pelicula != 0)
            {
                MessageBox.Show("Error: Al crear Pelicula");
            }
            else
            {
                MessageBox.Show("Pelicula creada correctamente");
                listarPeliculas();
            }
            txtTitulo.Text = "";
            txtCategoria.Text = "";
            txtRestriccion.Text = "";
            txtSinopsis.Text = "";
            txtTrailer.Text = "";
            txtCalificacion.Text = "";
            txtCantidad.Text = "";

        }

        private void actualizarPelicula()
        {
            //pelicula.ID_PELICULA = int.Parse(txtIdPelicula.Text);
            //pelicula.TITULO = txtTitulo.Text;
            //pelicula.CATEGORIA = txtCategoria.Text;
            //pelicula.RESTRICCION = txtRestriccion.Text;
            //pelicula.SINOPSIS = txtSinopsis.Text;
            //pelicula.TRAILER_URL = txtTrailer.Text;
            //pelicula.CALIFICACION = int.Parse(txtCalificacion.Text);
            //pelicula.CANTIDAD_PELICULA = int.Parse(txtCantidad.Text);
            ////pelicula.ID_LINEAS_PEDIDO= txtLineaPedido.Text;
            //pelicula.ACTIVO_PELICULA = true;
            //if (peliculaLogica.ActualizaPelicula(pelicula))
            //{
            //    MessageBox.Show("Pelicula actualizada correctamente");
            //    listarPeliculas();

            //}
            //else
            //{
            //    MessageBox.Show("Error: Al actualizar Pelicula");
            //}
            //txtTitulo.Text = "";
            //txtCategoria.Text = "";
            //txtRestriccion.Text = "";
            //txtSinopsis.Text = "";
            //txtTrailer.Text = "";
            //txtCalificacion.Text = "";
            //txtCantidad.Text = "";
            //txtReparto.Text = "";
        }

        private void listarPeliculas()
        {
            dgvPeliculas.DataSource = null;
            dgvPeliculas.Rows.Clear();
            dgvPeliculas.Columns.Clear();
            dgvPeliculas.DataSource = peliculaLogica.SeleccionarPeliculas();
        }

        private void FrmPelicula_Load(object sender, EventArgs e)
        {
            listarPeliculas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (swNuevo == 1)
            {
                insertarPelicula();
            }
            else
            {
                actualizarPelicula();
            }
            listarPeliculas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            idValor = (int)dgvPeliculas.CurrentRow.Cells[0].Value;

            if (idValor == 0)
            {
                MessageBox.Show("Error: Seleccione una Pelicula");
                return;
            }

            peliculaLogica.EliminarPelicula(idValor);
            listarPeliculas();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtIdPelicula.Text = dgvPeliculas.CurrentRow.Cells[0].Value.ToString();
            txtTitulo.Text = dgvPeliculas.CurrentRow.Cells[1].Value.ToString();
            txtCategoria.Text = dgvPeliculas.CurrentRow.Cells[2].Value.ToString();
            txtRestriccion.Text = dgvPeliculas.CurrentRow.Cells[3].Value.ToString();
            txtSinopsis.Text = dgvPeliculas.CurrentRow.Cells[4].Value.ToString();
            txtTrailer.Text = dgvPeliculas.CurrentRow.Cells[5].Value.ToString();
            txtCalificacion.Text = dgvPeliculas.CurrentRow.Cells[6].Value.ToString();
            txtCantidad.Text = dgvPeliculas.CurrentRow.Cells[9].Value.ToString();
            txtReparto.Text = dgvPeliculas.CurrentRow.Cells[11].Value.ToString();
            swNuevo = 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
