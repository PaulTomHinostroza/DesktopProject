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
    }
}
