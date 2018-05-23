using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ElAmigo
{
    public class clsCargo
    {
        private int _IdCargo;
        private string _NombreCargo;
        private string _DescripcionCargo;

        //constructor para insertar
        public clsCargo(string parNombreCargo) 
        {
            NombreCargo = parNombreCargo;
        }

        //constructor para listar
        public clsCargo(int parIdCargo, string parNombreCargo, string parDescripcionCargo)
        {
            IdCargo = parIdCargo;
            NombreCargo = parNombreCargo;
            DescripcionCargo=parDescripcionCargo;
        }

        
        public int IdCargo
        {
            get { return _IdCargo; }
            set { _IdCargo = value; }
        }

        public string NombreCargo
        {
            get { return _NombreCargo; }
            set { _NombreCargo = value; }
        }

        public string DescripcionCargo
        {
            get { return _DescripcionCargo; }
            set { _DescripcionCargo = value; }
        }


        public void InsertarCargo()
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Cargo_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parNombre_Car", NombreCargo);

            if (string.IsNullOrEmpty(DescripcionCargo))
            {
                cmd.Parameters.AddWithValue("@parDescripcion_Car", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@parDescripcion_Car", DescripcionCargo);
            }

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public static List<clsCargo> ListarCargoTodos()
        {
            List<clsCargo> x = new List<clsCargo>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Cargo_Listar_Todos", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();

            while (contenedor.Read() == true)
            {
                clsCargo MiObjeto;
                MiObjeto = new clsCargo(Convert.ToInt32(contenedor["IdCargo"]), contenedor["Nombre_Car"].ToString(), contenedor["Descripcion_Car"].ToString());

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsCargo> ListarCargoPorNombre(string parametroNombre)
        {
            List<clsCargo> x = new List<clsCargo>();

            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand comando;
            comando = new SqlCommand("usp_Cargo_ListarPorNombre", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@parNombre_Car", parametroNombre);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = comando.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsCargo MiObjeto;
                MiObjeto = new clsCargo(Convert.ToInt32(contenedor["IdCargo"]), contenedor["Nombre_Car"].ToString(), contenedor["Descripcion_Car"].ToString());
                x.Add(MiObjeto);
            }
            conexion.Close();

            return x;
        }

        public static List<clsCargo> ListarCargoPorId(int parametroId)
        {
            List<clsCargo> x = new List<clsCargo>();

            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.CadenaDeConexion);

            SqlCommand comando;
            comando = new SqlCommand("usp_Cargo_ListarPorId", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@parIdCargo", parametroId);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = comando.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsCargo MiObjeto;
                MiObjeto = new clsCargo(Convert.ToInt32(contenedor["IdCargo"]), contenedor["Nombre_Car"].ToString(), contenedor["Descripcion_Car"].ToString());
                x.Add(MiObjeto);
            }
            conexion.Close();

            return x;
        }
    }
}
