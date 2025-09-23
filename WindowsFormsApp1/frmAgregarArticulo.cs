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
    public partial class frmAgregarArticulo : Form
    {
        private Articulo articulo = null;
        public frmAgregarArticulo()
        {
            InitializeComponent();
        }
        public frmAgregarArticulo(Articulo existente) : this()
        {
            articulo = existente;
            Text = "Modificar Artículo";
        }

        private void btnCancelarArticulo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptarArticulo_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            // VALIDACIONES
            
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El código es obligatorio.");
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción es obligatoria.");
                return;
            }
            if (cboMarcas.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una marca.");
                return;
            }
            if (cboCategorias.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una categoría.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPrecio.Text) || !decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número positivo.");
                return;
            }
            
            string url = txtUrlImagen.Text.Trim();
            if (!string.IsNullOrEmpty(url) && !(url.StartsWith("http://") || url.StartsWith("https://")))
            {
                MessageBox.Show("La URL de la imagen debe comenzar con http:// o https://");
                return;
            }

            try
            {
                
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = precio;
                
                articulo.Marca = (Marca)cboMarcas.SelectedItem;
                articulo.Categoria = (Categoria)cboCategorias.SelectedItem;

                
                if (!string.IsNullOrEmpty(url))
                {
                    if (articulo.Imagenes == null)
                        articulo.Imagenes = new List<string>();
                    if (!articulo.Imagenes.Contains(url))
                        articulo.Imagenes.Add(url);
                }

                
                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    //negocio.guardarImagenes(articulo.Id, articulo.Imagenes);
                    MessageBox.Show("Modificado exitosamente");
                }
                
                else
                {
                    negocio.agregar(articulo);
                    //negocio.guardarImagenes(nuevoId, articulo.Imagenes);
                    MessageBox.Show("Agregado exitosamente");
                }
                                
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();
            }
        }


        private void frmAgregarArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                
                List<Marca> listaMarcas = marcaNegocio.listar();                
                List<Marca> marcasUnicas = new List<Marca>();
                
                foreach (Marca marca in listaMarcas)
                {
                    
                    if (!marcasUnicas.Any(m => m.Id == marca.Id))
                    {
                        marcasUnicas.Add(marca);
                    }
                }
                
                cboMarcas.DataSource = marcasUnicas;
                cboMarcas.ValueMember = "Id";
                cboMarcas.DisplayMember = "Descripcion";


                
                List<Categoria> listaCategorias = categoriaNegocio.listar();
                List<Categoria> categoriasUnicas = new List<Categoria>();
                foreach (Categoria categoria in listaCategorias)
                {
                    if (!categoriasUnicas.Any(c => c.Id == categoria.Id))
                    {
                        categoriasUnicas.Add(categoria);
                    }
                }
                cboCategorias.DataSource = categoriasUnicas;
                cboCategorias.ValueMember = "Id";
                cboCategorias.DisplayMember = "Descripcion";

                
                if (articulo != null && articulo.Id != 0)
                {
                    
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    
                    if (articulo.Marca != null)
                        cboMarcas.SelectedValue = articulo.Marca.Id;
                    if (articulo.Categoria != null)
                        cboCategorias.SelectedValue = articulo.Categoria.Id;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }

            //articuloActual = articulo;
            //indiceImagenActual = 0;
            //MostrarImagenActual();
        }
                
    }
}
