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
    public partial class frmAgregarMarca : Form
    {
        private Marca marca = null;
        public frmAgregarMarca()
        {
            InitializeComponent();
            Text = "Agregar Marca";
        }
        public frmAgregarMarca(Marca marca) : this()
        {
            this.marca = marca;
            Text = "Modificar Marca";
        }

        private void btnAceptarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();

            try
            {

                string input = (txtDescripcionMarca.Text ?? string.Empty).Trim();
                input = Regex.Replace(input, @"\s{2,}", " ");


                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("La marca de la marca es obligatoria.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescripcionMarca.Focus();
                    return;
                }

                if (input.Length < 2)
                {
                    MessageBox.Show("La marca debe tener al menos 2 caracteres.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescripcionMarca.Focus();
                    return;
                }

                if (marca == null)
                    marca = new Marca();


                marca.Descripcion = input;

                if (marca.Id != 0)
                {
                    negocio.modificar(marca);
                    MessageBox.Show("Marca modificada correctamente", "OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    negocio.agregar(marca);
                    MessageBox.Show("Marca agregada correctamente", "OK",
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

        private void btnCancelarMarca_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAgregarMarca_Load(object sender, EventArgs e)
        {
            if (marca != null)
                txtDescripcionMarca.Text = marca.Descripcion;
        }
    }
    
}
