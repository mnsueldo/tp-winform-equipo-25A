using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmAgregarCategoria : Form
    {
        private Categoria categoria = null;
        public frmAgregarCategoria()
        {
            InitializeComponent();
            Text = "Agregar Categoría";
        }
        public frmAgregarCategoria(Categoria categoria) : this()
        {
            this.categoria = categoria;
            Text = "Modificar Categoria";
        }
        private void frmAgregarCategoria_Load(object sender, EventArgs e)
        {
            if (categoria != null)
                txtDescripcionCategoria.Text = categoria.Descripcion;
        }

        private void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {

                string input = (txtDescripcionCategoria.Text ?? string.Empty).Trim();
                input = Regex.Replace(input, @"\s{2,}", " ");

                
                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("La descripción de la marca es obligatoria.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescripcionCategoria.Focus();
                    return;
                }

                if (input.Length < 2)
                {
                    MessageBox.Show("La descripción debe tener al menos 2 caracteres.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescripcionCategoria.Focus();
                    return;
                }

                if (categoria == null)
                    categoria = new Categoria();                              

                
                categoria.Descripcion = input;

                if (categoria.Id != 0)
                {
                    negocio.modificar(categoria);
                    MessageBox.Show("Categoria modificada correctamente", "OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    negocio.agregar(categoria);
                    MessageBox.Show("Categoria agregada correctamente", "OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Close();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
