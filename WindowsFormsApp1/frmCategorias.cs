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
    public partial class frmCategorias : Form
    {
        private List<Categoria> lista;
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void cargar()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                lista = negocio.listar();
                dgvCategorias.DataSource = lista;
                dgvCategorias.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            frmAgregarCategoria categoria = new frmAgregarCategoria();
            categoria.ShowDialog();
            cargar();
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null) return;

            Categoria seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
            frmAgregarCategoria categoria = new frmAgregarCategoria(seleccionada);
            categoria.ShowDialog();
            cargar();
        }
        
        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategorias.CurrentRow == null)
                    return;

                Categoria seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

                var resp = MessageBox.Show(
                    "¿Eliminar físicamente la categoría seleccionada?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resp == DialogResult.Yes)
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
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
