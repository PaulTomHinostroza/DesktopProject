using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ElAmigo
{
    public class clsAlmacen
    {
        private int _IdAlmacen;
        private string _DireccionAlm;
        private string _TelefonoAlm;
        private string _DescripcionAlm;
        private string _TipoAlm;

        //constructor para listar
        public clsAlmacen(int parIdAlmacen, string parDireccionAlm, string parTelefonoAlm, string parDescripcionAlm, string parTipoAlm) 
        {
            IdAlmacen = parIdAlmacen;
            DireccionAlm = parDireccionAlm;
            TelefonoAlm = parTelefonoAlm;
            DescripcionAlm = parDescripcionAlm;
            TipoAlm = parTipoAlm;
            
        }

        //constructor para insertar
        public clsAlmacen(string parDireccionAlm, string parTelefonoAlm, string parTipoAlm)
        {
            DireccionAlm = parDireccionAlm;
            TelefonoAlm = parTelefonoAlm;
            TipoAlm = parTipoAlm;

        }

        public int IdAlmacen
        {
            get { return _IdAlmacen; }
            set { _IdAlmacen = value; }
        }

        public string DireccionAlm
        {
            get { return _DireccionAlm; }
            set 
            { 
                _DireccionAlm = value.ToUpper(); 
            }
        }

        public string TelefonoAlm
        {
            get { return _TelefonoAlm; }
            set { _TelefonoAlm = value; }
        }

        public string DescripcionAlm
        {
            get { return _DescripcionAlm; }
            set 
            { 
                _DescripcionAlm = value.ToUpper(); 
            }
        }

        public string TipoAlm
        {
            get { return _TipoAlm; }
            set 
            { 
                _TipoAlm = value.ToUpper(); 
            }
        }

        public void InsertarAlmacen()
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Almacen_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parDireccion_Alm", DireccionAlm);
            cmd.Parameters.AddWithValue("@parTelefono_Alm", TelefonoAlm);
            cmd.Parameters.AddWithValue("@parTipo_Alm", TipoAlm);


            if (string.IsNullOrEmpty(DescripcionAlm))
            {
                cmd.Parameters.AddWithValue("@parDescripcion_Alm", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parDescripcion_Alm", DescripcionAlm);
            }

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public static List<clsAlmacen> ListarAlmacenTodos()
        {
            List<clsAlmacen> x = new List<clsAlmacen>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Almacen_Listar_Todos", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();

            while (contenedor.Read() == true)
            {

                clsAlmacen MiObjeto;
                MiObjeto = new clsAlmacen(Convert.ToInt32(contenedor["IdAlmacen"]), contenedor["Direccion_Alm"].ToString(),
                                        contenedor["Telefono_Alm"].ToString(), contenedor["Descripcion_Alm"].ToString(), contenedor["Tipo_Alm"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsAlmacen> ListarAlmacenPorDireccion(string parametroDireccion)
        {
            List<clsAlmacen> x = new List<clsAlmacen>();

            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand cmd = new SqlCommand("usp_Almacen_ListarPorDireccion", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parDireccion_Alm", parametroDireccion);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsAlmacen MiObjeto;
                MiObjeto = new clsAlmacen(Convert.ToInt32(contenedor["IdAlmacen"]), contenedor["Direccion_Alm"].ToString(),
                                        contenedor["Telefono_Alm"].ToString(), contenedor["Descripcion_Alm"].ToString(), contenedor["Tipo_Alm"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();

            return x;
        }

        public static List<clsAlmacen> ListarAlmacenPorId(int parametroId)
        {
            List<clsAlmacen> x = new List<clsAlmacen>();

            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand cmd = new SqlCommand("usp_Almacen_ListarPorId", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdAlmacen", parametroId);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsAlmacen MiObjeto;
                MiObjeto = new clsAlmacen(Convert.ToInt32(contenedor["IdAlmacen"]), contenedor["Direccion_Alm"].ToString(),
                                        contenedor["Telefono_Alm"].ToString(), contenedor["Descripcion_Alm"].ToString(), contenedor["Tipo_Alm"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();

            return x;
        }

        public void Actualizar(clsAlmacen NuevosDatos)
        {
            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand cmd = new SqlCommand("usp_Almacen_Actualizar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdAlmacen", IdAlmacen);

            cmd.Parameters.AddWithValue("@parNUEVO_Direccion_Alm", NuevosDatos.DireccionAlm);
            cmd.Parameters.AddWithValue("@parNUEVO_Telefono_Alm", NuevosDatos.TelefonoAlm);
            cmd.Parameters.AddWithValue("@parNUEVO_Tipo_Alm", NuevosDatos.TipoAlm);

            if (string.IsNullOrEmpty(NuevosDatos.DescripcionAlm))
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Descripcion_Alm", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Descripcion_Alm", NuevosDatos.DescripcionAlm);
            }
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
