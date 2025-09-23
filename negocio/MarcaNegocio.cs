using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion FROM MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        public void agregar(Marca nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into MARCAS (Descripcion)values(@Descripcion)");
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

        public void modificar(Marca nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update MARCAS set Descripcion = @Descripcion Where Id = @id");
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
                if (!ExisteMarca(id))
                {
                    MessageBox.Show("La Marca no existe o ya fue eliminada.");
                    return;
                }

                if (TieneArticulosAsociados(id))
                {
                    MessageBox.Show("No se puede eliminar la Marca: tiene artículos asociados.");
                    return;
                }

                datos.setearConsulta("DELETE FROM MARCAS WHERE id = @id");
                datos.setearParametro("@id", id);
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

        private bool TieneArticulosAsociados(int idMarca)
        {
            var datos = new AccesoDatos();
            try
            {                
                datos.setearConsulta("SELECT TOP 1 1 FROM ARTICULOS WHERE IdMarca = @IdMarca");
                datos.setearParametro("@IdMarca", idMarca);
                datos.ejecutarLectura();
                return datos.Lector.Read();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private bool ExisteMarca(int id)
        {
            var datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT TOP 1 1 FROM MARCAS WHERE Id = @Id");
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
