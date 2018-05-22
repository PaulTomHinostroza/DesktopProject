using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ElAmigo
{
    public class clsPrecio
    {
        private clsProducto _IdProducto;
        private clsMedida _IdMedida;
        private decimal _Precio;
        //axuiliares
        private int _IdProductoInt;
        private int _IdMedidaInt;
        private string _DescripcionMed;

        public clsProducto IdProducto
        {
            get { return _IdProducto; }
            set { _IdProducto = value; }
        }

        public clsMedida IdMedida
        {
            get { return _IdMedida; }
            set { _IdMedida = value; }
        }

        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        //auxiliares
        public string DescripcionMed
        {
            get { return _DescripcionMed; }
            set { _DescripcionMed = value; }
        }

        public int IdMedidaInt
        {
            get { return _IdMedidaInt; }
            set { _IdMedidaInt = value; }
        }

        public int IdProductoInt
        {
            get { return _IdProductoInt; }
            set { _IdProductoInt = value; }
        }
         
        public clsPrecio(clsProducto parIdProducto, clsMedida parIdMedida, decimal parPrecio)
        {
            IdProducto = parIdProducto;
            IdMedida = parIdMedida;
            Precio = parPrecio;
        }

        //CONSTRUCTOR PARA INSERTAR PRECIO
        public clsPrecio(int parIdProductoInt, clsMedida parIdMedida, decimal parPrecio)
        {
            IdProductoInt = parIdProductoInt;
            IdMedida = parIdMedida;
            Precio = parPrecio;
        }

        //CONSTRUCTOR PARA listar el producto con la medida y precio
        public clsPrecio(int parIdProductoInt, string parDescripcionMed, decimal parPrecio,int parIdMedidaInt)
        {
            IdProductoInt = parIdProductoInt;
            DescripcionMed = parDescripcionMed;
            Precio = parPrecio;
            IdMedidaInt = parIdMedidaInt;
        }

        //constructor para actualizar el precio
        public clsPrecio(int parIdProductoInt, int parIdMedidaInt, decimal parPrecio)
        {
            IdProductoInt = parIdProductoInt;
            IdMedidaInt = parIdMedidaInt;
            Precio = parPrecio;
        }

        //public clsPrecio(int parIdProductoInt, string parNombreMed)
        //{
        //    IdProductoInt = parIdProductoInt;
        //    NombreMedida = parNombreMed;
        //}      

        public void InsertarPrecio()
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Precio_Insertar", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdMedida_P", IdMedida.IdMedida);
            cmd.Parameters.AddWithValue("@parIdProducto_P", IdProductoInt);
            cmd.Parameters.AddWithValue("@parPrecio", Precio);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }


        public static List<clsPrecio> ListarPreciosProducto(int parIdProducto)
        {
            List<clsPrecio> x = new List<clsPrecio>();
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand cmd = new SqlCommand("usp_Producto_Listar_MedidaPrecio", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parIdProducto", parIdProducto);
            conexion.Open();
            SqlDataReader cont;
            cont = cmd.ExecuteReader();


            while (cont.Read() == true)
            {
                clsPrecio MiObjeto;
                MiObjeto = new clsPrecio(Convert.ToInt32(cont["IdProducto_P"]), cont["Descripcion_Med"].ToString(), Convert.ToDecimal(cont["Precio"]), Convert.ToInt32(cont["IdMedida_P"]));
                x.Add(MiObjeto);
            }
            conexion.Close();
            return x;
        }

        public void Actualizar(clsPrecio NuevosDatos)
        {
            SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
            SqlCommand comando = new SqlCommand("usp_Precio_Actualizar", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@parIdProducto_P", IdProductoInt);
            comando.Parameters.AddWithValue("@parIdMedida_P", IdMedidaInt);
            comando.Parameters.AddWithValue("@parNUEVO_Precio", NuevosDatos.Precio);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        //public static List<clsPrecio> ListarPreciosProductoMedida(int parIdProducto, string parNombreMed)
        //{
        //    List<clsPrecio> x = new List<clsPrecio>();
        //    SqlConnection conexion = new SqlConnection(mdlVariables.CadenaDeConexion);
        //    SqlCommand cmd = new SqlCommand("usp_Producto_Listar_PrecioMedida", conexion);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@parIdProducto", parIdProducto);
        //    cmd.Parameters.AddWithValue("@parNombre", parNombreMed);
        //    conexion.Open();
        //    SqlDataReader cont;
        //    cont = cmd.ExecuteReader();

        //    while (cont.Read() == true)
        //    {
        //        clsPrecio MiObjeto;
        //        MiObjeto = new clsPrecio(Convert.ToInt32(cont["IdProducto"]), cont["Nombre"].ToString(), Convert.ToDecimal(cont["Precio"]));
        //        x.Add(MiObjeto);
        //    }
        //    conexion.Close();
        //    return x;
        //}
    }
}
