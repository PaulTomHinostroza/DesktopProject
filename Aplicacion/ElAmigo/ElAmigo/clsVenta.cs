using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ElAmigo
{
    public class clsVenta
    {
        private int _IdNroVenta;
        private clsCliente _IdCliente;
        private clsEmpleado _IdEmpleado;
        private DateTime _FechaEmision;
        private int _Serie;
        private string _TipoDoc;
        private decimal _TotalVenta;
        //auxiliar
        private int _IdClienteVInt;
        private int _IdEmpleadoVInt;


        //contructor para insertar
        public clsVenta(int parIdClienteInt, int parIdEmpleadoInt, int parSerie, string parTipoDoc,
                        decimal parTotalVenta)
        {
            IdClienteVInt = parIdClienteInt;
            IdEmpleadoVInt = parIdEmpleadoInt;
            Serie = parSerie;
            TipoDoc = parTipoDoc;
            TotalVenta = parTotalVenta;

        }


        public int IdNroVenta
        {
            get { return _IdNroVenta; }
            set { _IdNroVenta = value; }
        }

        public clsCliente IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        public clsEmpleado IdEmpleado
        {
            get { return _IdEmpleado; }
            set { _IdEmpleado = value; }
        }

        public DateTime FechaEmision
        {
            get { return _FechaEmision; }
            set { _FechaEmision = value; }
        }

        public int Serie
        {
            get { return _Serie; }
            set { _Serie = value; }
        }

        public string TipoDoc
        {
            get { return _TipoDoc; }
            set { _TipoDoc = value; }
        }

        public decimal TotalVenta
        {
            get { return _TotalVenta; }
            set { _TotalVenta = value; }
        }

        public int IdClienteVInt
        {
            get { return _IdClienteVInt; }
            set { _IdClienteVInt = value; }
        }

        public int IdEmpleadoVInt
        {
            get { return _IdEmpleadoVInt; }
            set { _IdEmpleadoVInt = value; }
        }

        public void InsertarVenta()
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Venta_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdCliente_DV", IdClienteVInt);
            cmd.Parameters.AddWithValue("@parIdEmpleado_DV", IdEmpleadoVInt);
            cmd.Parameters.AddWithValue("@parSerie", Serie);
            cmd.Parameters.AddWithValue("@parTipoDocumento", TipoDoc);
            cmd.Parameters.AddWithValue("@parTotalVenta", TotalVenta);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
