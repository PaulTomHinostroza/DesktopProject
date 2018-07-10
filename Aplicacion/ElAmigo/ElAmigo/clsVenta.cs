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
        private int _IdVenta;
        private clsCliente _IdCliente;
        private clsEmpleado _IdEmpleado;
        private DateTime _FechaEmision;
        private int _NroVenta;
        private int _Serie;
        private string _TipoDoc;
        private decimal _TotalVenta;
        //auxiliar
        private int _IdClienteVInt;
        private int _IdEmpleadoVInt;


        //contructor para insertar
        public clsVenta(int parIdClienteInt, int parIdEmpleadoInt,int parNroVenta, int parSerie, string parTipoDoc,
                        decimal parTotalVenta)
        {
            IdClienteVInt = parIdClienteInt;
            IdEmpleadoVInt = parIdEmpleadoInt;
            NroVenta=parNroVenta;
            Serie = parSerie;
            TipoDoc = parTipoDoc;
            TotalVenta = parTotalVenta;

        }

        //contructor para listar idventa
        public clsVenta(int parIdVenta, int parIdClienteInt, int parIdEmpleadoInt, int parNroVenta, int parSerie, string parTipoDoc,
                        decimal parTotalVenta)
        {
            IdVenta = parIdVenta;
            IdClienteVInt = parIdClienteInt;
            IdEmpleadoVInt = parIdEmpleadoInt;
            NroVenta = parNroVenta;
            Serie = parSerie;
            TipoDoc = parTipoDoc;
            TotalVenta = parTotalVenta;

        }

        public clsVenta(int parNroVenta, int parSerie)
        {
            NroVenta = parNroVenta;
            Serie = parSerie;
        }


        public int IdVenta
        {
            get { return _IdVenta; }
            set { _IdVenta = value; }
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

        public int NroVenta
        {
            get { return _NroVenta; }
            set { _NroVenta = value; }
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
            cmd.Parameters.AddWithValue("@parNroVenta", NroVenta);
            cmd.Parameters.AddWithValue("@parSerie", Serie);
            cmd.Parameters.AddWithValue("@parTipoDocumento", TipoDoc);
            cmd.Parameters.AddWithValue("@parTotalVenta", TotalVenta);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public static List<clsVenta> generarSerieNumeroComprobante(string tipoComprobante)
        {
            List<clsVenta> x = new List<clsVenta>();

            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("sp_venta_generar_serie_numero_comprobante", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@partipo_comprobante", tipoComprobante);
            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsVenta MiObjeto;
                MiObjeto = new clsVenta(Convert.ToInt32(contenedor["Serie"]),
                                        Convert.ToInt32(contenedor["NroVenta"]));

                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public static List<clsVenta> BuscarIdVenta(int idCliente, int idEmpleado, int NroVentaId, int SerieId,
                                                    string TipoDocumento, decimal TotalVentaId)
        {
            List<clsVenta> x = new List<clsVenta>();

            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Venta_Id", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdCliente", idCliente);
            cmd.Parameters.AddWithValue("@parIdEmpleado", idEmpleado);
            cmd.Parameters.AddWithValue("@parNroVenta", NroVentaId);
            cmd.Parameters.AddWithValue("@parSerie", SerieId);
            cmd.Parameters.AddWithValue("@parTipoDocumento", TipoDocumento);
            cmd.Parameters.AddWithValue("@parTotalVenta", TotalVentaId);

            conexion.Open();
            SqlDataReader contenedor;
            contenedor = cmd.ExecuteReader();
            while (contenedor.Read() == true)
            {
                clsVenta MiObjeto;
                MiObjeto = new clsVenta(Convert.ToInt32(contenedor["IdVenta"]), Convert.ToInt32(contenedor["IdEmpleado_V"]), Convert.ToInt32(contenedor["IdCliente_V"]),
                                        Convert.ToInt32(contenedor["NroVenta"]), Convert.ToInt32(contenedor["Serie"]),
                                         contenedor["TipoDocumento"].ToString(), Convert.ToDecimal(contenedor["TotalVenta"]));

                x.Add(MiObjeto);

            }
            conexion.Close();
            return x;
        }
    }
}
