using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ElAmigo
{
    public class clsStock
    {
        private clsAlmacen _IdAlmacenST;
        private clsProducto _IdProductoST;
        private clsMedida _IdMedidaST;
        private decimal _CantidadST;
        //auxiliares
        private int _IdAlmacenInt;
        private int _IdProdructoInt;
        private int _IdMedidaInt;
        private string _DescripcionAlmacen;
        private string _DescripcionProducto;
        private string _DescripcionMedida;

        //constructor para insertar
        public clsStock(int parIdProductoInt, clsAlmacen parIdAlmacenST, clsMedida parIdMedidaST, decimal parCantidadSt)
        {
            IdProdructoInt = parIdProductoInt;
            IdAlmacenST = parIdAlmacenST;
            IdMedidaST = parIdMedidaST;
            CantidadST = parCantidadSt;
        }

        //constructor para listar por producto
        public clsStock(int parIdProductoInt,string parDescripcionProd , int parIdAlmacenInt,string parDescripcionAlm,
                          int parIdMedidaInt,string parDescripcionMedida, decimal parCantidadSt)
        {
            IdProdructoInt = parIdProductoInt;
            DescripcionProducto = parDescripcionProd;
            IdAlmacenInt = parIdAlmacenInt;
            DescripcionAlmacen = parDescripcionAlm;
            IdMedidaInt = parIdMedidaInt;
            DescripcionMedida = parDescripcionMedida;
            CantidadST = parCantidadSt;
        }

        public clsAlmacen IdAlmacenST
        {
            get { return _IdAlmacenST; }
            set { _IdAlmacenST = value; }
        }

        public clsProducto IdProductoST
        {
            get { return _IdProductoST; }
            set { _IdProductoST = value; }
        }

        public clsMedida IdMedidaST
        {
            get { return _IdMedidaST; }
            set { _IdMedidaST = value; }
        }

        public decimal CantidadST
        {
            get { return _CantidadST; }
            set { _CantidadST = value; }
        }

        public int IdAlmacenInt
        {
            get { return _IdAlmacenInt; }
            set { _IdAlmacenInt = value; }
        }

        public int IdProdructoInt
        {
            get { return _IdProdructoInt; }
            set { _IdProdructoInt = value; }
        }

        public int IdMedidaInt
        {
            get { return _IdMedidaInt; }
            set { _IdMedidaInt = value; }
        }

        public string DescripcionAlmacen
        {
            get { return _DescripcionAlmacen; }
            set { _DescripcionAlmacen = value; }
        }

        public string DescripcionProducto
        {
            get { return _DescripcionProducto; }
            set { _DescripcionProducto = value; }
        }

        public string DescripcionMedida
        {
            get { return _DescripcionMedida; }
            set { _DescripcionMedida = value; }
        }

        public void InsertarStock()
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Stock_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdProducto_St", IdProdructoInt);
            cmd.Parameters.AddWithValue("@parIdMedida_St", IdMedidaST.IdMedida);
            cmd.Parameters.AddWithValue("@parIdAlmacen_St", IdAlmacenST.IdAlmacen);
            cmd.Parameters.AddWithValue("@parCantidadStock", CantidadST);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public static List<clsStock> ListarStockPorProducto(int parIdProducto)
        {
            List<clsStock> x = new List<clsStock>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Stock_Listar_AlmCantMed", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdProducto", parIdProducto);
            conexion.Open();
            SqlDataReader cont;
            cont = cmd.ExecuteReader();


            while (cont.Read() == true)
            {
                clsStock MiObjeto;
                MiObjeto = new clsStock(Convert.ToInt32(cont["IdProducto_St"]), cont["Descripcion_Prod"].ToString(),
                                        Convert.ToInt32(cont["IdAlmacen_St"]), cont["Direccion_Alm"].ToString(),
                                        Convert.ToInt32(cont["IdMedida_St"]), cont["Descripcion_Med"].ToString(),
                                        Convert.ToDecimal(cont["CantidadStock"]));
                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

    }
}
