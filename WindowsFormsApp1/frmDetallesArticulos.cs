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
        public frmDetallesArticulos(Articulo articulo)
        {
            InitializeComponent();
            _articulo = articulo;
        }

        private void frmDetallesArticulos_Load(object sender, EventArgs e)
        {
            lblCodigoValor.Text = _articulo.Codigo;
            lblNombreValor.Text = _articulo.Nombre;
            lblDescripcionValor.Text = _articulo.Descripcion;
            lblMarcaValor.Text = _articulo.Marca != null ? _articulo.Marca.Descripcion : "-";
            lblCategoriaValor.Text = _articulo.Categoria != null ? _articulo.Categoria.Descripcion : "-";
            lblPrecioValor.Text = _articulo.Precio.ToString("C2");

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
