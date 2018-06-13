using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ElAmigo
{
    public class clsEmpleado
    {
        private int _IdEmpleado;
        private string _NombresEmp;
        private string _ApellidosEmp;
        private string _DNIEmp;
        private string _DireccionEmp;
        private string _TelefonoEmp;
        private char _GeneroEmp;
        private string _EmailEmp;
        private DateTime _FechaNacEmp;
        private DateTime _FechaInscripcionEmp;
        private clsCargo _CargoEmp;
        private string _NombreCargo;

        private string _Usuario;
        private string _Password;

        //constructores

        //constructor para insertar
        public clsEmpleado(string parNombresEmp, string parApellidosEmp, string parDNIEmp,
                            string parDireccionEmp, char parGeneroEmp,
                            DateTime parFechaNacEmp, clsCargo parCargoEmp,string parUsuario,string parPassword)
        {

            NombresEmp = parNombresEmp;
            ApellidosEmp = parApellidosEmp;
            DNIEmp = parDNIEmp;
            DireccionEmp = parDireccionEmp;
            GeneroEmp = parGeneroEmp;
            FechaNacEmp = parFechaNacEmp;
            CargoEmp = parCargoEmp;
            Usuario = parUsuario;
            Password = parPassword;

        }

        //constructor para listar todos
        public clsEmpleado(int parIdEmpleado, string parNombresEmp, string parApellidosEmp, string parDNIEmp,
                            string parDireccionEmp, string parTelefonoEmp, char parGeneroEmp, string parEmailEmp,
                            DateTime parFechaNacEmp, DateTime parFechaInscripcionEmp, string parNombreCargo, string parUsuario,string parPassword) 
        {

            IdEmpleado = parIdEmpleado;
            ApellidosEmp = parApellidosEmp;
            NombresEmp = parNombresEmp;
            DNIEmp = parDNIEmp;
            DireccionEmp = parDireccionEmp;
            TelefonoEmp = parTelefonoEmp;
            GeneroEmp = parGeneroEmp;
            EmailEmp = parEmailEmp;
            FechaNacEmp = parFechaNacEmp;
            FechaInscripcionEmp = parFechaInscripcionEmp;
            NombreCargo = parNombreCargo;
            Usuario = parUsuario;
            Password = parPassword;
        
        }

        //constructor para validacion de usuario
        public clsEmpleado(int parIdEmpleado, string parNombresEmp, string parApellidosEmp, string parDNIEmp,
                            string parDireccionEmp, string parTelefonoEmp, char parGeneroEmp, string parEmailEmp,
                            DateTime parFechaNacEmp, DateTime parFechaInscripcionEmp, string parNombreCargo)
        {

            IdEmpleado = parIdEmpleado;
            ApellidosEmp = parApellidosEmp;
            NombresEmp = parNombresEmp;
            DNIEmp = parDNIEmp;
            DireccionEmp = parDireccionEmp;
            TelefonoEmp = parTelefonoEmp;
            GeneroEmp = parGeneroEmp;
            EmailEmp = parEmailEmp;
            FechaNacEmp = parFechaNacEmp;
            FechaInscripcionEmp = parFechaInscripcionEmp;
            NombreCargo = parNombreCargo;

        }

        public int IdEmpleado
        {
            get { return _IdEmpleado; }
            set { _IdEmpleado = value; }
        }

        public string NombresEmp
        {
            get { return _NombresEmp; }
            set { _NombresEmp = value; }
        }

        public string ApellidosEmp
        {
            get { return _ApellidosEmp; }
            set { _ApellidosEmp = value; }
        }

        public string DNIEmp
        {
            get { return _DNIEmp; }
            set { _DNIEmp = value; }
        }

        public string DireccionEmp
        {
            get { return _DireccionEmp; }
            set { _DireccionEmp = value; }
        }

        public string TelefonoEmp
        {
            get { return _TelefonoEmp; }
            set { _TelefonoEmp = value; }
        }

        public char GeneroEmp
        {
            get { return _GeneroEmp; }
            set { _GeneroEmp = value; }
        }

        public string EmailEmp
        {
            get { return _EmailEmp; }
            set { _EmailEmp = value; }
        }

        public DateTime FechaNacEmp
        {
            get { return _FechaNacEmp; }
            set { _FechaNacEmp = value; }
        }

        public DateTime FechaInscripcionEmp
        {
            get { return _FechaInscripcionEmp; }
            set { _FechaInscripcionEmp = value; }
        }

        public clsCargo CargoEmp
        {
            get { return _CargoEmp; }
            set { _CargoEmp = value; }
        }

        public string NombreCargo
        {
            get { return _NombreCargo; }
            set { _NombreCargo = value; }
        }

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public void InsertarEmpleado()
        {
            SqlConnection  conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Empleado_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parNombres_Emp", NombresEmp);
            cmd.Parameters.AddWithValue("@parApellidos_Emp", ApellidosEmp);
            cmd.Parameters.AddWithValue("@parDNI_Emp", DNIEmp);
            cmd.Parameters.AddWithValue("@parDireccion_Emp", DireccionEmp);
            cmd.Parameters.AddWithValue("@parGenero_Emp", GeneroEmp);
            cmd.Parameters.AddWithValue("@parFechaNac_Emp", FechaNacEmp);
            cmd.Parameters.AddWithValue("@parIdCargo_Emp", CargoEmp.IdCargo);
            cmd.Parameters.AddWithValue("@parUsuario_Emp", Usuario);
            cmd.Parameters.AddWithValue("@parPassword_Emp", Password);


            if (string.IsNullOrEmpty(TelefonoEmp))
            {
                cmd.Parameters.AddWithValue("@parTelefono_Emp", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parTelefono_Emp", TelefonoEmp);
            }

            if (string.IsNullOrEmpty(EmailEmp))
            {
                cmd.Parameters.AddWithValue("@parEmail_Emp", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parEmail_Emp", EmailEmp);
            }

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public static List<clsEmpleado> ListarEmpleadoTodos()
        {
            List<clsEmpleado> x = new List<clsEmpleado>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Empleado_Listar_Todos", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsEmpleado MiObjeto;
                MiObjeto = new clsEmpleado(Convert.ToInt32(contenedor["IdEmpleado"]),
                                            contenedor["Nombre_Emp"].ToString(),
                                            contenedor["Apellidos_Emp"].ToString(),
                                            contenedor["DNI_Emp"].ToString(),
                                            contenedor["Direccion_Emp"].ToString(),
                                            contenedor["Telefono_Emp"].ToString(),
                                            Convert.ToChar(contenedor["Genero_Emp"]),
                                            contenedor["Email_Emp"].ToString(),
                                            Convert.ToDateTime(contenedor["FechaNac_Emp"]),
                                            Convert.ToDateTime(contenedor["FechaIncrip_Emp"]),
                                            contenedor["Nombre_Car"].ToString(),
                                            contenedor["Usuario_Emp"].ToString(),
                                            contenedor["Password_Emp"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsEmpleado> ListarEmpleadoPorNombres(string parametroNombres)
        {

            List<clsEmpleado> x = new List<clsEmpleado>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Empleado_ListarPorNombre", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parNombre_Emp", parametroNombres);

            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsEmpleado MiObjeto;
                MiObjeto = new clsEmpleado(Convert.ToInt32(contenedor["IdEmpleado"]),
                                            contenedor["Nombre_Emp"].ToString(),
                                            contenedor["Apellidos_Emp"].ToString(),
                                            contenedor["DNI_Emp"].ToString(),
                                            contenedor["Direccion_Emp"].ToString(),
                                            contenedor["Telefono_Emp"].ToString(),
                                            Convert.ToChar(contenedor["Genero_Emp"]),
                                            contenedor["Email_Emp"].ToString(),
                                            Convert.ToDateTime(contenedor["FechaNac_Emp"]),
                                            Convert.ToDateTime(contenedor["FechaIncrip_Emp"]),
                                            contenedor["Nombre_Car"].ToString(),
                                            contenedor["Usuario_Emp"].ToString(),
                                            contenedor["Password_Emp"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsEmpleado> ListarEmpleadoPorApellidos(string parametroApellidos)
        {

            List<clsEmpleado> x = new List<clsEmpleado>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Empleado_ListarPorApellido", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parApellidos_Emp", parametroApellidos);

            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsEmpleado MiObjeto;
                MiObjeto = new clsEmpleado(Convert.ToInt32(contenedor["IdEmpleado"]),
                                            contenedor["Nombre_Emp"].ToString(),
                                            contenedor["Apellidos_Emp"].ToString(),
                                            contenedor["DNI_Emp"].ToString(),
                                            contenedor["Direccion_Emp"].ToString(),
                                            contenedor["Telefono_Emp"].ToString(),
                                            Convert.ToChar(contenedor["Genero_Emp"]),
                                            contenedor["Email_Emp"].ToString(),
                                            Convert.ToDateTime(contenedor["FechaNac_Emp"]),
                                            Convert.ToDateTime(contenedor["FechaIncrip_Emp"]),
                                            contenedor["Nombre_Car"].ToString(),
                                            contenedor["Usuario_Emp"].ToString(),
                                            contenedor["Password_Emp"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsEmpleado> ListarEmpleadoPorId(int parametroId)
        {

            List<clsEmpleado> x = new List<clsEmpleado>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Empleado_ListarPorId", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parIdEmpleado", parametroId);

            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsEmpleado MiObjeto;
                MiObjeto = new clsEmpleado(Convert.ToInt32(contenedor["IdEmpleado"]),
                                            contenedor["Nombre_Emp"].ToString(),
                                            contenedor["Apellidos_Emp"].ToString(),
                                            contenedor["DNI_Emp"].ToString(),
                                            contenedor["Direccion_Emp"].ToString(),
                                            contenedor["Telefono_Emp"].ToString(),
                                            Convert.ToChar(contenedor["Genero_Emp"]),
                                            contenedor["Email_Emp"].ToString(),
                                            Convert.ToDateTime(contenedor["FechaNac_Emp"]),
                                            Convert.ToDateTime(contenedor["FechaIncrip_Emp"]),
                                            contenedor["Nombre_Car"].ToString(),
                                            contenedor["Usuario_Emp"].ToString(),
                                            contenedor["Password_Emp"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsEmpleado> ListarEmpleadoPorDNI(string parametroDNI)
        {

            List<clsEmpleado> x = new List<clsEmpleado>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Empleado_ListarPorDNI", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parDNI_Emp", parametroDNI);

            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsEmpleado MiObjeto;
                MiObjeto = new clsEmpleado(Convert.ToInt32(contenedor["IdEmpleado"]),
                                            contenedor["Nombre_Emp"].ToString(),
                                            contenedor["Apellidos_Emp"].ToString(),
                                            contenedor["DNI_Emp"].ToString(),
                                            contenedor["Direccion_Emp"].ToString(),
                                            contenedor["Telefono_Emp"].ToString(),
                                            Convert.ToChar(contenedor["Genero_Emp"]),
                                            contenedor["Email_Emp"].ToString(),
                                            Convert.ToDateTime(contenedor["FechaNac_Emp"]),
                                            Convert.ToDateTime(contenedor["FechaIncrip_Emp"]),
                                            contenedor["Nombre_Car"].ToString(),
                                            contenedor["Usuario_Emp"].ToString(),
                                            contenedor["Password_Emp"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsEmpleado> ListarEmpleadoPorCargo(string parametroCargo)
        {

            List<clsEmpleado> x = new List<clsEmpleado>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Empleado_ListarPorCargo", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parCargo_Emp", parametroCargo);

            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsEmpleado MiObjeto;
                MiObjeto = new clsEmpleado(Convert.ToInt32(contenedor["IdEmpleado"]),
                                            contenedor["Nombre_Emp"].ToString(),
                                            contenedor["Apellidos_Emp"].ToString(),
                                            contenedor["DNI_Emp"].ToString(),
                                            contenedor["Direccion_Emp"].ToString(),
                                            contenedor["Telefono_Emp"].ToString(),
                                            Convert.ToChar(contenedor["Genero_Emp"]),
                                            contenedor["Email_Emp"].ToString(),
                                            Convert.ToDateTime(contenedor["FechaNac_Emp"]),
                                            Convert.ToDateTime(contenedor["FechaIncrip_Emp"]),
                                            contenedor["Nombre_Car"].ToString(),
                                            contenedor["Usuario_Emp"].ToString(),
                                            contenedor["Password_Emp"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public void Actualizar(clsEmpleado NuevosDatos)
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand cmd = new SqlCommand("usp_Empleado_Actualizar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdEmpleado", IdEmpleado);
            cmd.Parameters.AddWithValue("@parNUEVO_Nombres_Emp", NuevosDatos.NombresEmp);
            cmd.Parameters.AddWithValue("@parNUEVO_Apellidos_Emp", NuevosDatos.ApellidosEmp);
            cmd.Parameters.AddWithValue("@parNUEVO_DNI_Emp", NuevosDatos.DNIEmp);
            cmd.Parameters.AddWithValue("@parNUEVO_Direccion_Emp", NuevosDatos.DireccionEmp);
            cmd.Parameters.AddWithValue("@parNUEVO_Genero_Emp", NuevosDatos.GeneroEmp);
            cmd.Parameters.AddWithValue("@parNUEVO_FechaNac_Emp", NuevosDatos.FechaNacEmp);
            cmd.Parameters.AddWithValue("@parNUEVO_IdCargo_Emp", NuevosDatos.CargoEmp.IdCargo);
            cmd.Parameters.AddWithValue("@parNUEVO_Usuario_Emp", NuevosDatos.Usuario);
            cmd.Parameters.AddWithValue("@parNUEVO_Password_Emp", NuevosDatos.Password);


            if (string.IsNullOrEmpty(NuevosDatos.TelefonoEmp))
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Telefono_Emp", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Telefono_Emp", NuevosDatos.TelefonoEmp);
            }

            if (string.IsNullOrEmpty(NuevosDatos.EmailEmp))
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Email_Emp", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Email_Emp", NuevosDatos.EmailEmp);
            }
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public static clsEmpleado Validar(string parUsuario,
                                        string parPassword)
        {
            clsEmpleado EmpleadoRetornado = null;
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Usuario_Validacion", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parUsuario_Emp", parUsuario);
            cmd.Parameters.AddWithValue("@parPassword_Emp", parPassword);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                EmpleadoRetornado = new clsEmpleado(Convert.ToInt32(contenedor["IdEmpleado"]),
                                            contenedor["Nombre_Emp"].ToString(),
                                            contenedor["Apellidos_Emp"].ToString(),
                                            contenedor["DNI_Emp"].ToString(),
                                            contenedor["Direccion_Emp"].ToString(),
                                            contenedor["Telefono_Emp"].ToString(),
                                            Convert.ToChar(contenedor["Genero_Emp"]),
                                            contenedor["Email_Emp"].ToString(),
                                            Convert.ToDateTime(contenedor["FechaNac_Emp"]),
                                            Convert.ToDateTime(contenedor["FechaIncrip_Emp"]),
                                            contenedor["Nombre_Car"].ToString());
            }
            conexion.Close();
            return EmpleadoRetornado;
        }


    }
}
