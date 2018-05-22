using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ElAmigo
{
    public class clsProducto
    {
        private int _IdProducto;
        private string _DescripcionProd;

        //constructor para insertar producto
        public clsProducto(string parDescripcionProd)
        {
            DescripcionProd = parDescripcionProd;
        }

        public clsProducto(int parIdProducto, string parDescripcionProd)
        {
            IdProducto = parIdProducto;
            DescripcionProd = parDescripcionProd;
        }

        public int IdProducto
        {
            get { return _IdProducto; }
            set { _IdProducto = value; }
        }

        public string DescripcionProd
        {
            get { return _DescripcionProd; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El nombre del Producto no debe quedar vacío.");
                }
                else if (value.Length > 200)
                {
                    throw new Exception("El nombre del Producto no puede exceder mas de  30 caracteres");
                }
                else
                {
                    _DescripcionProd = value.ToUpper();
                }
            }
        }


        public void InsertarProducto()
        {
            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand comando1;
            comando1 = new SqlCommand("usp_Producto_Insertar", conexion);
            comando1.CommandType = System.Data.CommandType.StoredProcedure;
            comando1.Parameters.AddWithValue("@parDescripcion_Prod", DescripcionProd);
            conexion.Open();
            comando1.ExecuteNonQuery();
            conexion.Close();
        }

        public static List<clsProducto> ListarProductoTodos()
        {
            List<clsProducto> x = new List<clsProducto>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Producto_Listar_Todos", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();

            while (contenedor.Read() == true)
            {

                clsProducto MiObjeto;
                MiObjeto = new clsProducto(Convert.ToInt32(contenedor["IdProducto"]), contenedor["Descripcion_Prod"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsProducto> ListarProductoPorDescripcion(string parametroDescripcion)
        {
            List<clsProducto> x = new List<clsProducto>();

            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand comando;
            comando = new SqlCommand("usp_Producto_ListarPorDescripcion", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@parDescripcion_Prod", parametroDescripcion);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = comando.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsProducto MiObjeto;
                MiObjeto = new clsProducto(Convert.ToInt32(contenedor["IdProducto"]), contenedor["Descripcion_Prod"].ToString());
                x.Add(MiObjeto);
            }
            conexion.Close();

            return x;
        }

        public static List<clsProducto> ListarProductoPorId(int parametroId)
        {
            List<clsProducto> x = new List<clsProducto>();

            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand comando;
            comando = new SqlCommand("usp_Producto_ListarPorId", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@parIdProducto", parametroId);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = comando.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsProducto MiObjeto;
                MiObjeto = new clsProducto(Convert.ToInt32(contenedor["IdProducto"]), contenedor["Descripcion_Prod"].ToString());
                x.Add(MiObjeto);
            }
            conexion.Close();

            return x;
        }

        public void Actualizar(clsProducto NuevosDatos)
        {
            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand comando;
            comando = new SqlCommand("usp_Producto_Actualizar", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@parIdProducto",IdProducto);
            comando.Parameters.AddWithValue("@parNUEVO_Descripcion_Prod", NuevosDatos.DescripcionProd);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

    }
}
