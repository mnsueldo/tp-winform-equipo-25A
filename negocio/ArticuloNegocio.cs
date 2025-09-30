using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class ArticuloNegocio {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion,A.Precio, A.IdCategoria, A.IdMarca, C.Descripcion AS Categoria, M.Descripcion AS Marca FROM ARTICULOS AS A INNER JOIN CATEGORIAS AS C ON A.IdCategoria = C.Id INNER JOIN MARCAS AS M ON A.IdMarca = M.Id;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];


                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Precio"))))
                        aux.Precio = (decimal)datos.Lector["Precio"];


                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];


                    
                    aux.Imagenes = ObtenerImagenesPorId(aux.Id);
                    aux.UrlImagen = (aux.Imagenes != null && aux.Imagenes.Count > 0) ? aux.Imagenes[0] : null;

                    lista.Add(aux);
                }

                return lista;
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

        public List<Imagen> getImagenes(int idArticulo) // funcion para las imganes de la lista
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta($"select id,idArticulo, ImagenUrl from IMAGENES where IdArticulo={idArticulo}");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = (int)datos.Lector["id"];
                    aux.IdArticulo = (int)datos.Lector["idArticulo"];   
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];


                    lista.Add(aux);
                }

                return lista;
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
        
        public List<string> ObtenerImagenesPorId(int idArticulo)
        {
            var imagenes = new List<string>();
            var datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ImagenUrl FROM IMAGENES WHERE IdArticulo = @idArticulo");
                datos.setearParametro("@idArticulo", idArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var u = (datos.Lector["ImagenUrl"] as string)?.Trim();
                    if (!string.IsNullOrWhiteSpace(u))
                        imagenes.Add(u);
                }

                return imagenes;
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error de base al listar imágenes del artículo.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error inesperado al listar imágenes del artículo.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int agregar(Articulo nuevo)
        {
            var datos = new AccesoDatos();
            int idGenerado = 0;

            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) OUTPUT INSERTED.Id VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@Precio", nuevo.Precio);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                    idGenerado = Convert.ToInt32(datos.Lector[0]);

                return idGenerado;
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error de base al agregar el artículo.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error inesperado al agregar el artículo.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
        public void modificar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdCategoria = @idCategoria, IdMarca = @idMarca, Precio = @precio Where Id = @id");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);                
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@id", nuevo.Id);

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



        public void eliminarFisico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta(
                    "DELETE FROM IMAGENES WHERE IdArticulo = @id; " + "DELETE FROM ARTICULOS WHERE Id = @id;"
                );
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

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            var lista = new List<Articulo>();
            var datos = new AccesoDatos();

            try
            {
                string consulta = @"SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, C.Descripcion AS Categoria, M.Descripcion AS Marca, A.IdCategoria, A.IdMarca FROM ARTICULOS AS A INNER JOIN CATEGORIAS AS C ON C.Id = A.IdCategoriaINNER JOIN MARCAS AS M ON M.Id = A.IdMarca LEFT JOIN  IMAGENES   AS I ON A.Id = I.IdArticulo WHERE 1=1 ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "AND A.Precio > @filtroPrecio ";
                            datos.setearParametro("@filtroPrecio", Convert.ToDecimal(filtro));
                            break;
                        case "Menor a":
                            consulta += "AND A.Precio < @filtroPrecio ";
                            datos.setearParametro("@filtroPrecio", Convert.ToDecimal(filtro));
                            break;
                        default:
                            consulta += "AND A.Precio = @filtroPrecio ";
                            datos.setearParametro("@filtroPrecio", Convert.ToDecimal(filtro));
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    consulta += "AND A.Nombre LIKE @filtro ";
                    datos.setearParametro("@filtro", criterio == "Comienza con" ? (filtro + "%")
                                               : criterio == "Termina con" ? ("%" + filtro)
                                                                             : ("%" + filtro + "%"));
                }
                else if (campo == "Descripcion" || campo == "Descripción")
                {
                    consulta += "AND A.Descripcion LIKE @filtro ";
                    datos.setearParametro("@filtro", criterio == "Comienza con" ? (filtro + "%")
                                               : criterio == "Termina con" ? ("%" + filtro)
                                                                             : ("%" + filtro + "%"));
                }
                else if (campo == "Marca")
                {
                    consulta += "AND M.Descripcion LIKE @filtro ";
                    datos.setearParametro("@filtro", criterio == "Comienza con" ? (filtro + "%")
                                               : criterio == "Termina con" ? ("%" + filtro)
                                                                             : ("%" + filtro + "%"));
                }
                else if (campo == "Categoria" || campo == "Categoría")
                {
                    consulta += "AND C.Descripcion LIKE @filtro ";
                    datos.setearParametro("@filtro", criterio == "Comienza con" ? (filtro + "%")
                                               : criterio == "Termina con" ? ("%" + filtro)
                                                                             : ("%" + filtro + "%"));
                }
                else if (campo == "Codigo" || campo == "Código")
                {
                    consulta += "AND A.Codigo LIKE @filtro ";
                    datos.setearParametro("@filtro", criterio == "Comienza con" ? (filtro + "%")
                                               : criterio == "Termina con" ? ("%" + filtro)
                                                                             : ("%" + filtro + "%"));
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var aux = new Articulo
                    {
                        Id = (int)datos.Lector["Id"],
                        Codigo = (string)datos.Lector["Codigo"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Marca = new Marca
                        {
                            Id = (int)datos.Lector["IdMarca"],
                            Descripcion = (string)datos.Lector["Marca"]
                        },
                        Categoria = new Categoria
                        {
                            Id = (int)datos.Lector["IdCategoria"],
                            Descripcion = (string)datos.Lector["Categoria"]
                        }
                    };

                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Precio")))
                        aux.Precio = (decimal)datos.Lector["Precio"];
                                        

                    lista.Add(aux);
                }

                return lista;
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error de base al filtrar artículos.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error inesperado al filtrar artículos.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public void guardarImagenes(int idArticulo, List<string> imagenes)
        {
            if (imagenes == null)
                return;
            
            using (SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true"))
            {
                conexion.Open();
                                
                var comandoDelete = new SqlCommand("DELETE FROM IMAGENES WHERE IdArticulo = @idArticulo", conexion);
                comandoDelete.Parameters.AddWithValue("@idArticulo", idArticulo);
                comandoDelete.ExecuteNonQuery();

               
                foreach (var url in imagenes)
                {
                    var comandoInsert = new SqlCommand("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idArticulo, @url)", conexion);
                    comandoInsert.Parameters.AddWithValue("@idArticulo", idArticulo);
                    comandoInsert.Parameters.AddWithValue("@url", url);
                    comandoInsert.ExecuteNonQuery();
                }
            }
        }


    }
}
