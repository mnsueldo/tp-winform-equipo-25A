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
    public partial class frmMarcas : Form
    {
        private List<Marca> listaMarca;
        public frmMarcas()
        {
            InitializeComponent();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void cargar()
        {
            try
            {
                var negocio = new MarcaNegocio();
                listaMarca = negocio.listar();
                dgvMarcas.DataSource = listaMarca;
                if (dgvMarcas.Columns["Id"] != null)
                    dgvMarcas.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregarMarcas_Click(object sender, EventArgs e)
        {
            frmAgregarMarca agregar = new frmAgregarMarca();
            agregar.ShowDialog();
            cargar();
        }

        private void btnModificarMarcas_Click(object sender, EventArgs e)
        {
            Marca seleccionado = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
            frmAgregarMarca modificar = new frmAgregarMarca(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminarMarcas_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMarcas.CurrentRow == null)
                    return;

                Marca seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;

                var resp = MessageBox.Show(
                    "¿Eliminar físicamente la Marca seleccionada?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resp == DialogResult.Yes)
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    negocio.eliminar(seleccionada.Id);
                    cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error");
            }

        }
    }
}
