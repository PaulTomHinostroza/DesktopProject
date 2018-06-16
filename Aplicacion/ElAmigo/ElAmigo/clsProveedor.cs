using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ElAmigo
{
    public class clsProveedor
    {

        private int _IdProveedor;
        private string _NombreRazonProv;
        private string _NombreContactoProv;
        private string _CelularContactoProv;
        private string _DireccionProv;
        private string _TelefonoProv;
        private string _EmailProv;
        private string _NroCuentaProv;

        //constructor para insertar proveedor
        public clsProveedor(string parNombreRazon,string parNombreContacto,string parCelularContacto, string parTelefonoProv)
        {
            NombreRazonProv = parNombreRazon;
            NombreContactoProv = parNombreContacto;
            CelularContactoProv = parCelularContacto;
            TelefonoProv = parTelefonoProv;
        }

        //constructor para listar todos
        public clsProveedor(int parIdProveedor, string parNombreRazon,string parNombreContactoProv,string parCelularContactoProv, string parDireccionProv, string parTelefonoProv,
                            string parEmailProv, string parNroCuentaProv) 
        {
            IdProveedor = parIdProveedor;
            NombreRazonProv = parNombreRazon;
            NombreContactoProv = parNombreContactoProv;
            CelularContactoProv = parCelularContactoProv;
            DireccionProv = parDireccionProv;
            TelefonoProv = parTelefonoProv;
            EmailProv = parEmailProv;
            NroCuentaProv = parNroCuentaProv;
        }



        public int IdProveedor
        {
            get { return _IdProveedor; }
            set { _IdProveedor = value; }
        }

        public string NombreRazonProv
        {
            get { return _NombreRazonProv; }
            set 
            { 
                _NombreRazonProv = value.ToUpper(); 
            }
        }

        public string NombreContactoProv
        {
            get { return _NombreContactoProv; }
            set 
            { 
                _NombreContactoProv = value.ToUpper(); 
            }
        }

        public string CelularContactoProv
        {
            get { return _CelularContactoProv; }
            set { _CelularContactoProv = value; }
        }

        public string DireccionProv
        {
            get { return _DireccionProv; }
            set 
            { 
                _DireccionProv = value.ToUpper(); 
            }
        }

        public string TelefonoProv
        {
            get { return _TelefonoProv; }
            set { _TelefonoProv = value; }
        }

        public string EmailProv
        {
            get { return _EmailProv; }
            set 
            { 
                _EmailProv = value.ToUpper(); 
            }
        }

        public string NroCuentaProv
        {
            get { return _NroCuentaProv; }
            set { _NroCuentaProv = value; }
        }

        public void InsertarProveedor() 
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Proveedor_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parNombre_Prov", NombreRazonProv);
            cmd.Parameters.AddWithValue("@parNombre_Contacto_Prov", NombreContactoProv);
            cmd.Parameters.AddWithValue("@parCelular_Contacto_Prov", CelularContactoProv);
            cmd.Parameters.AddWithValue("@parTelefono_Prov", TelefonoProv);

            if (string.IsNullOrEmpty(DireccionProv))
            {
                cmd.Parameters.AddWithValue("@parDireccion_Prov", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parDireccion_Prov", DireccionProv);
            }

            if (string.IsNullOrEmpty(EmailProv))
            {
                cmd.Parameters.AddWithValue("@parEmail_Prov", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parEmail_Prov", EmailProv);
            }

            if (string.IsNullOrEmpty(NroCuentaProv))
            {
                cmd.Parameters.AddWithValue("@parNroCuenta_Prov", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parNroCuenta_Prov", NroCuentaProv);
            }

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public static List<clsProveedor> ListarProveedorTodos()
        {
            List<clsProveedor> x = new List<clsProveedor>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Proveedor_Listar_Todos", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();

            while (contenedor.Read() == true)
            {

                clsProveedor MiObjeto;
                MiObjeto = new clsProveedor(Convert.ToInt32(contenedor["IdProveedor"]), contenedor["Nombre_Prov"].ToString(), contenedor["Nombre_Contacto_Prov"].ToString(),
                                            contenedor["Celular_Contacto_Prov"].ToString(), contenedor["Direccion_Prov"].ToString(), contenedor["Telefono_Prov"].ToString(),
                                            contenedor["Email_Prov"].ToString(), contenedor["NroCuenta_Prov"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsProveedor> ListarProveedorPorNombre(string parametroNombre)
        {
            List<clsProveedor> x = new List<clsProveedor>();

            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand cmd = new SqlCommand("usp_Proveedor_ListarPorNombre", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parNombre_Prov", parametroNombre);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsProveedor MiObjeto;
                MiObjeto = new clsProveedor(Convert.ToInt32(contenedor["IdProveedor"]), contenedor["Nombre_Prov"].ToString(), contenedor["Nombre_Contacto_Prov"].ToString(),
                                            contenedor["Celular_Contacto_Prov"].ToString(), contenedor["Direccion_Prov"].ToString(), contenedor["Telefono_Prov"].ToString(),
                                            contenedor["Email_Prov"].ToString(), contenedor["NroCuenta_Prov"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();

            return x;
        }

        public static List<clsProveedor> ListarProveedorPorId(int parametroId)
        {
            List<clsProveedor> x = new List<clsProveedor>();

            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand cmd = new SqlCommand("usp_Proveedor_ListarPorId", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdProveedor", parametroId);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsProveedor MiObjeto;
                MiObjeto = new clsProveedor(Convert.ToInt32(contenedor["IdProveedor"]), contenedor["Nombre_Prov"].ToString(), contenedor["Nombre_Contacto_Prov"].ToString(),
                                            contenedor["Celular_Contacto_Prov"].ToString(), contenedor["Direccion_Prov"].ToString(), contenedor["Telefono_Prov"].ToString(),
                                            contenedor["Email_Prov"].ToString(), contenedor["NroCuenta_Prov"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();

            return x;
        }

        public void Actualizar(clsProveedor NuevosDatos)
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand cmd = new SqlCommand("usp_Proveedor_Actualizar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdProveedor", IdProveedor);
            cmd.Parameters.AddWithValue("@parNUEVO_Nombre_Prov", NuevosDatos.NombreRazonProv);
            cmd.Parameters.AddWithValue("@parNUEVO_Nombre_Contacto_Prov", NuevosDatos.NombreContactoProv);
            cmd.Parameters.AddWithValue("@parNUEVO_Celular_Contacto_Prov", NuevosDatos.CelularContactoProv);
            cmd.Parameters.AddWithValue("@parNUEVO_Telefono_Prov", NuevosDatos.TelefonoProv);

            if (string.IsNullOrEmpty(NuevosDatos.DireccionProv))
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Direccion_Prov", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Direccion_Prov", NuevosDatos.DireccionProv);
            }

            if (string.IsNullOrEmpty(NuevosDatos.EmailProv))
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Email_Prov", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Email_Prov", NuevosDatos.EmailProv);
            }

            if (string.IsNullOrEmpty(NuevosDatos.NroCuentaProv))
            {
                cmd.Parameters.AddWithValue("@parNUEVO_NroCuenta_Prov", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parNUEVO_NroCuenta_Prov", NuevosDatos.NroCuentaProv);
            }
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

    }
}
