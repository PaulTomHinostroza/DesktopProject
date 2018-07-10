using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ElAmigo
{
    public class clsDetalleVenta
    {
        private int _IdVentaDV;
        private int _IdProductoDV;
        private int _IdMedidaDV;
        private decimal _Cantidad;

        //constructor insertar
        public clsDetalleVenta(int parIdVentaDV, int parIdProductoDV, int parIdMedidaDV, decimal parCantidad)
        {
            IdVentaDV = parIdVentaDV;
            IdProductoDV = parIdProductoDV;
            IdMedidaDV = parIdMedidaDV;
            Cantidad = parCantidad;
        }

        public int IdVentaDV
        {
            get { return _IdVentaDV; }
            set { _IdVentaDV = value; }
        }

        public int IdProductoDV
        {
            get { return _IdProductoDV; }
            set { _IdProductoDV = value; }
        }

        public int IdMedidaDV
        {
            get { return _IdMedidaDV; }
            set { _IdMedidaDV = value; }
        }

        public decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public void InsertarDetalleVenta()
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_DetalleVenta_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdVenta_DV", IdVentaDV);
            cmd.Parameters.AddWithValue("@parIdProducto_DV", IdProductoDV);
            cmd.Parameters.AddWithValue("@parIdMedida_DV", IdMedidaDV);
            cmd.Parameters.AddWithValue("@parCantidad", Cantidad);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
