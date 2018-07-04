using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ElAmigo
{
    public class clsCliente
    {
        //campos
        private int _IdCliente;
        private string _NombresCli;
        private string _ApellidosCli;
        private string _DNICli;
        private string _DireccionCli;
        private string _TelefonoCli;
        private char _GeneroCli;
        private string _RUCCli;
        private string _EmailCli;
        private DateTime _FechaInscripcion;

        
        //constructor para insertar cliente
        public clsCliente(string parNombresCli, string parApellidosCli, string parDNICli,
                            string parDireccionCli, char parGeneroCli)
        {
            NombresCli = parNombresCli;
            ApellidosCli = parApellidosCli;
            DNICli = parDNICli;
            DireccionCli = parDireccionCli;
            GeneroCli = parGeneroCli;
        }

        //constructor para lista todos los clientes
        public clsCliente(int parIdCliente, string parNombresCli, string parApellidosCli,
                          string parDNICli, string parDireccionCli, string parTelefonoCli, char parGeneroCli,
                          string parRUCCli, DateTime parFechaInscripcion, string parEmailCli)
        {
            IdCliente = parIdCliente;
            NombresCli = parNombresCli;
            ApellidosCli = parApellidosCli;
            DNICli = parDNICli;
            DireccionCli = parDireccionCli;
            TelefonoCli = parTelefonoCli;
            GeneroCli = parGeneroCli;
            RUCCli = parRUCCli;
            FechaInscripcion = parFechaInscripcion;
            EmailCli = parEmailCli;


        }

        public string NombresCli
        {
            get { return _NombresCli; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El nombre no debe quedar vacío.");
                }
                else if (value.Length > 60)
                {
                    throw new Exception("El nombre del cliente no debe exceder mas de 60 caracteres");
                }
                else
                {
                    _NombresCli = value.ToUpper();
                }
            }
        }

        public string ApellidosCli
        {
            get { return _ApellidosCli; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El apellido no debe quedar vacío.");
                }
                else if (value.Length > 100)
                {
                    throw new Exception("El apellido del cliente no debe exceder mas de 100 caracteres");
                }
                else
                {
                    _ApellidosCli = value.ToUpper();
                }
            }
        }
        public string DNICli
        {
            get { return _DNICli; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El DNI no debe quedar vacío.");
                }
                else if (value.Length !=8)
                {
                    throw new Exception("El DNI del cliente no debe exceder mas de 8 caracteres");
                }
                else
                {
                    _DNICli = value.ToUpper();
                } 
            }
        }

        public string DireccionCli
        {
            get { return _DireccionCli; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("La dirección no debe quedar vacío.");
                }
                else if (value.Length > 80)
                {
                    throw new Exception("La direccion del cliente no debe exceder mas de 80 caracteres");
                }
                else
                {
                    _DireccionCli = value.ToUpper();
                }
            }
        }
        public string TelefonoCli
        {
            get { return _TelefonoCli; }
            set
            {

                if (value.Length > 20)
                {
                    throw new Exception("El telefono del cliente no debe exceder mas de 20 caracteres");
                }
                else
                {
                    _TelefonoCli = value.ToUpper();
                }
                
            }
        }


        public char GeneroCli
        {
            get { return _GeneroCli; }
            set { _GeneroCli = value; }
        }

        public string RUCCli
        {
            get { return _RUCCli; }
            set
            {
                if (value.Length > 30)
                {
                    throw new Exception("El RUC del cliente debe tener  30 caracteres");
                }
                else
                {
                    _RUCCli = value.ToUpper();
                }
            }
        }

        public string EmailCli
        {
            get { return _EmailCli; }
            set
            {
                if (value.Length > 50)
                {
                    throw new Exception("El Correo electronico del cliente no debe exceder mas de 50 caracteres");
                }
                else
                {
                    _EmailCli = value.ToUpper();
                }
            }

        }
        public DateTime FechaInscripcion
        {
            get { return _FechaInscripcion; }
            set { _FechaInscripcion = value; }
        }

        public int IdCliente
        {
            get { return _IdCliente;}
            set { _IdCliente = value; }
        }


        //Metodo insertar cliente

        public void InsertarCliente()
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Cliente_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parNombres_Cli", NombresCli);
            cmd.Parameters.AddWithValue("@parApellidos_Cli", ApellidosCli);
            cmd.Parameters.AddWithValue("@parDNI_Cli", DNICli);
            cmd.Parameters.AddWithValue("@parDireccion_Cli", DireccionCli);
            cmd.Parameters.AddWithValue("@parGenero_Cli", GeneroCli);

            if (string.IsNullOrEmpty(RUCCli))
            {
                cmd.Parameters.AddWithValue("@parRUC_Cli", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parRUC_Cli", TelefonoCli);
            }

            if (string.IsNullOrEmpty(TelefonoCli))
            {
                cmd.Parameters.AddWithValue("@partelefono_Cli", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@partelefono_Cli", TelefonoCli);
            }

            if (string.IsNullOrEmpty(EmailCli))
            {
                cmd.Parameters.AddWithValue("@parEmail_Cli", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parEmail_Cli", EmailCli);
            }

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public static List<clsCliente> ListarClienteTodos()
        {
            List<clsCliente> x = new List<clsCliente>();

            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand comando;
            comando = new SqlCommand("usp_Cliente_Listar_Todos", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            conexion.Open();
            SqlDataReader contenedor;
            contenedor = comando.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsCliente MiObjeto;
                MiObjeto = new clsCliente(Convert.ToInt32(contenedor["IdCliente"]),
                                            contenedor["Nombres_Cli"].ToString(),
                                            contenedor["Apellidos_Cli"].ToString(),
                                            contenedor["DNI_Cli"].ToString(),
                                            contenedor["Direccion_Cli"].ToString(),
                                            contenedor["Telefono_Cli"].ToString(),
                                            Convert.ToChar(contenedor["Genero_Cli"]),
                                            contenedor["RUC_Cli"].ToString(),
                                            Convert.ToDateTime(contenedor["FechaInscrip_Cli"]),
                                            contenedor["Email_Cli"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsCliente> ListarClientePorNombres(string parametroNombres)
        {

            List<clsCliente> x = new List<clsCliente>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Cliente_ListarPorNombre", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parNombres_Cli", parametroNombres);

            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsCliente MiObjeto;
                MiObjeto = new clsCliente(Convert.ToInt32(contenedor["IdCliente"]),
                                            contenedor["Nombres_Cli"].ToString(),
                                            contenedor["Apellidos_Cli"].ToString(),
                                            contenedor["DNI_Cli"].ToString(),
                                            contenedor["Direccion_Cli"].ToString(),
                                            contenedor["Telefono_Cli"].ToString(),
                                            Convert.ToChar(contenedor["Genero_Cli"]),
                                            contenedor["RUC_Cli"].ToString(),
                                            Convert.ToDateTime(contenedor["FechaInscrip_Cli"]),
                                            contenedor["Email_Cli"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsCliente> ListarClientePorApellidos(string parametroApellidos)
        {

            List<clsCliente> x = new List<clsCliente>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Cliente_ListarPorApellido", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parApellidos_Cli", parametroApellidos);

            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsCliente MiObjeto;
                MiObjeto = new clsCliente(Convert.ToInt32(contenedor["IdCliente"]),
                                            contenedor["Nombres_Cli"].ToString(),
                                            contenedor["Apellidos_Cli"].ToString(),
                                            contenedor["DNI_Cli"].ToString(),
                                            contenedor["Direccion_Cli"].ToString(),
                                            contenedor["Telefono_Cli"].ToString(),
                                            Convert.ToChar(contenedor["Genero_Cli"]),
                                            contenedor["RUC_Cli"].ToString(),
                                            Convert.ToDateTime(contenedor["FechaInscrip_Cli"]),
                                            contenedor["Email_Cli"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsCliente> ListarClientePorId(int parametroId)
        {

            List<clsCliente> x = new List<clsCliente>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Cliente_ListarPorId", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parIdCliente", parametroId);

            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsCliente MiObjeto;
                MiObjeto = new clsCliente(Convert.ToInt32(contenedor["IdCliente"]),
                                            contenedor["Nombres_Cli"].ToString(),
                                            contenedor["Apellidos_Cli"].ToString(),
                                            contenedor["DNI_Cli"].ToString(),
                                            contenedor["Direccion_Cli"].ToString(),
                                            contenedor["Telefono_Cli"].ToString(),
                                            Convert.ToChar(contenedor["Genero_Cli"]),
                                            contenedor["RUC_Cli"].ToString(),
                                            Convert.ToDateTime(contenedor["FechaInscrip_Cli"]),
                                            contenedor["Email_Cli"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsCliente> ListarClientePorDNI(string parametroDNI)
        {

            List<clsCliente> x = new List<clsCliente>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Cliente_ListarPorDNI", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parDNI_Cli", parametroDNI);

            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsCliente MiObjeto;
                MiObjeto = new clsCliente(Convert.ToInt32(contenedor["IdCliente"]),
                                            contenedor["Nombres_Cli"].ToString(),
                                            contenedor["Apellidos_Cli"].ToString(),
                                            contenedor["DNI_Cli"].ToString(),
                                            contenedor["Direccion_Cli"].ToString(),
                                            contenedor["Telefono_Cli"].ToString(),
                                            Convert.ToChar(contenedor["Genero_Cli"]),
                                            contenedor["RUC_Cli"].ToString(),
                                            Convert.ToDateTime(contenedor["FechaInscrip_Cli"]),
                                            contenedor["Email_Cli"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsCliente> Listar_PorFechasDeRegistro(DateTime parDesde,DateTime parHasta)
        {
            List<clsCliente> x = new List<clsCliente>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Cliente_Listar_Entre_FechasRegistro", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parFechaDeRegistroDesde", parDesde);
            cmd.Parameters.AddWithValue("@parFechaDeRegistroHasta", parHasta);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsCliente MiObjeto;
                MiObjeto = new clsCliente(Convert.ToInt32(contenedor["IdCliente"]),
                                            contenedor["Nombres_Cli"].ToString(),
                                            contenedor["Apellidos_Cli"].ToString(),
                                            contenedor["DNI_Cli"].ToString(),
                                            contenedor["Direccion_Cli"].ToString(),
                                            contenedor["Telefono_Cli"].ToString(),
                                            Convert.ToChar(contenedor["Genero_Cli"]),
                                            contenedor["RUC_Cli"].ToString(),
                                            Convert.ToDateTime(contenedor["FechaInscrip_Cli"]),
                                            contenedor["Email_Cli"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public void Actualizar(clsCliente NuevosDatos)
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand cmd = new SqlCommand("usp_Cliente_Actualizar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdCliente", IdCliente);
            cmd.Parameters.AddWithValue("@parNUEVO_Nombres_Cli", NuevosDatos.NombresCli);
            cmd.Parameters.AddWithValue("@parNUEVO_Apellidos_Cli", NuevosDatos.ApellidosCli);
            cmd.Parameters.AddWithValue("@parNUEVO_DNI_Cli", NuevosDatos.DNICli);
            cmd.Parameters.AddWithValue("@parNUEVO_Direccion_Cli", NuevosDatos.DireccionCli);
            cmd.Parameters.AddWithValue("@parNUEVO_Genero_Cli", NuevosDatos.GeneroCli);

            if (string.IsNullOrEmpty(NuevosDatos.RUCCli))
            {
                cmd.Parameters.AddWithValue("@parNUEVO_RUC_Cli", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parNUEVO_RUC_Cli", NuevosDatos.RUCCli);
            }

            if (string.IsNullOrEmpty(NuevosDatos.TelefonoCli))
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Telefono_Cli", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Telefono_Cli", NuevosDatos.TelefonoCli);
            }

            if (string.IsNullOrEmpty(NuevosDatos.EmailCli))
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Email_Cli", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parNUEVO_Email_Cli", NuevosDatos.EmailCli);
            }
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
