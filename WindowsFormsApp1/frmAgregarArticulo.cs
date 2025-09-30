using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmAgregarArticulo : Form
    {
        private Articulo articulo = null;
        private int indiceImagenActual = 0; // Para saber qué foto estamos viendo ahora
        private Articulo articuloActual = null; // Variable para manejar el artículo actual en la gestión de imágenes
        public frmAgregarArticulo()
        {
            InitializeComponent();
            articulo = new Articulo();
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
                if (articulo == null) articulo = new Articulo();

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
                    negocio.guardarImagenes(articulo.Id, articulo.Imagenes);
                    MessageBox.Show("Modificado exitosamente");
                }
                
                else
                {
                    int nuevoId = negocio.agregar(articulo);
                    negocio.guardarImagenes(nuevoId, articulo.Imagenes);
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

            articuloActual = articulo;
            indiceImagenActual = 0;
            MostrarImagenActual();          
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }
        private void MostrarImagenActual()
        {
            
            if (articulo == null || articulo.Imagenes == null || articulo.Imagenes.Count == 0)
            {
                pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
                return;
            }

            try
            {
                
                pbxArticulo.Load(articulo.Imagenes[indiceImagenActual]);
            }
            catch
            {                
                pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }
        private void cargarImagen(string url)
        {
            try
            {                
                pbxArticulo.Load(url);
            }
            catch (Exception)
            {

                pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            
            if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
            {
                
                articulo.Imagenes.RemoveAt(indiceImagenActual);

                
                if (indiceImagenActual >= articulo.Imagenes.Count)
                    indiceImagenActual = articulo.Imagenes.Count - 1;

                
                MostrarImagenActual();
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            string url = txtUrlImagen.Text.Trim();
            if (!string.IsNullOrEmpty(url))
            {
                
                if (!(url.StartsWith("http://") || url.StartsWith("https://")))
                {
                    MessageBox.Show("La URL de la imagen debe comenzar con http:// o https://");
                    return;
                }
                if (articulo.Imagenes == null)
                    articulo.Imagenes = new List<string>();
                
                if (articulo.Imagenes.Contains(url))
                {
                    MessageBox.Show("La imagen ya fue agregada.");
                    return;
                }
                
                articulo.Imagenes.Add(url);
                
                indiceImagenActual = articulo.Imagenes.Count - 1;
                MostrarImagenActual();                
                txtUrlImagen.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese una URL de imagen válida.");
            }
        }
    }
}
