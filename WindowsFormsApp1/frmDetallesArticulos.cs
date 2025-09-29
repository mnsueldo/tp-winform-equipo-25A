using dominio;
using negocio;
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
    public partial class frmDetallesArticulos : Form
    {
        private readonly Articulo _articulo;
        private readonly List<Imagen> listaImagenes; 
        private int indiceImagenActual = 0;
        public frmDetallesArticulos(Articulo articulo, List<Imagen> listaImagenes)
        {
            InitializeComponent();
            _articulo = articulo;
            this.listaImagenes = listaImagenes;

        }

        private void frmDetallesArticulos_Load(object sender, EventArgs e)
        {
            lblCodigoValor.Text = _articulo.Codigo;
            lblNombreValor.Text = _articulo.Nombre;
            lblDescripcionValor.Text = _articulo.Descripcion;
            lblMarcaValor.Text = _articulo.Marca != null ? _articulo.Marca.Descripcion : "-";
            lblCategoriaValor.Text = _articulo.Categoria != null ? _articulo.Categoria.Descripcion : "-";
            lblPrecioValor.Text = _articulo.Precio.ToString("C2");

            mostrarImagenActual();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mostrarImagenActual()
        {
            if (listaImagenes != null && listaImagenes.Count > 0)
            {
                try
                {
                    pbxDetalles.Load(listaImagenes[indiceImagenActual].ImagenUrl);
                }

                catch (Exception ex)
                {
                    pbxDetalles.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
                }
            }
            else
            {
                pbxDetalles.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }


        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (listaImagenes != null && indiceImagenActual < listaImagenes.Count - 1)
            {
                indiceImagenActual++;
                mostrarImagenActual();
            }
            else if (listaImagenes != null && indiceImagenActual == listaImagenes.Count - 1)
            {
                indiceImagenActual = 0;
                mostrarImagenActual();
            }
        }

        private void btnAtras_Click_1(object sender, EventArgs e)
        {
            if (listaImagenes != null && indiceImagenActual > 0)
            {
                indiceImagenActual--;
                mostrarImagenActual();
            }
            else if (listaImagenes != null && indiceImagenActual == 0)
            {
                indiceImagenActual = listaImagenes.Count - 1;
                mostrarImagenActual();
            }
        }
    }
}
