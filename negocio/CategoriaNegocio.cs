using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            var lista = new List<Categoria>();
            var datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var aux = new Categoria
                    {
                        Id = (int)datos.Lector["Id"],
                        Descripcion = (string)datos.Lector["Descripcion"]
                    };
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error listando categorías.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void agregar(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into CATEGORIAS (Descripcion)values(@Descripcion)");
                datos.setearParametro("@Descripcion", nueva.Descripcion);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {                
                datos.setearConsulta("update CATEGORIAS set Descripcion = @Descripcion Where Id = @id");
                datos.setearParametro("@Descripcion", nueva.Descripcion);
                datos.setearParametro("@id", nueva.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
               
                if (!ExisteCategoria(id))
                {
                    MessageBox.Show("La categoría no existe o ya fue eliminada.");
                    return;
                }                  
                
                if (TieneArticulosAsociados(id))
                {
                    MessageBox.Show("No se puede eliminar la Categoría: tiene artículos asociados.");
                    return;
                }                    

                datos.setearConsulta("DELETE FROM CATEGORIAS WHERE id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private bool TieneArticulosAsociados(int idCategoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(
                    "SELECT TOP 1 1 FROM ARTICULOS WHERE IdCategoria = @IdCategoria"
                );
                datos.setearParametro("@IdCategoria", idCategoria);
                datos.ejecutarLectura();
                return datos.Lector.Read();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private bool ExisteCategoria(int id)
        {
            var datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT TOP 1 1 FROM CATEGORIAS WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();
                return datos.Lector.Read();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
                
        

    }
}
