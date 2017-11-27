using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace puntoVentaWebService
{
    /// <summary>
    /// Summary description for puntoVenta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public class puntoVenta : System.Web.Services.WebService
    {
        puntoventa7a1Entities DB;
        public puntoVenta()
        {
            DB = new puntoventa7a1Entities();
        }


        [WebMethod]
        public bool createClientes(int id, string nombres, string apellidos, string direccion, string correo)
        {
            Clientes nuevoCliente = new Clientes {id=id, nombres=nombres, apellidos=apellidos, direccion=direccion, correo=correo };
            DB.Clientes.Add(nuevoCliente);
            if (DB.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        [WebMethod]
        public List<Clientes> readClientes()
        {
            return DB.Clientes.ToList();
        }
        [WebMethod]
        public int updateClientes(int id, string nombres, string apellidos, string direccion, string correo)
        {
            try
            {
                var cliente = DB.Clientes.Where(x=>x.id==id).FirstOrDefault();
                cliente.nombres = nombres;
                cliente.apellidos = apellidos;
                cliente.direccion = direccion;
                cliente.correo = correo;
                return DB.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }
        [WebMethod]
        public int deleteClientes(int id)
        {
            try
            {
                var cliente = DB.Clientes.Where(x => x.id == id).FirstOrDefault();
                DB.Clientes.Remove(cliente);
                return DB.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }
       
       
        [WebMethod]
        public bool createProductos(string nombre, double precio, int stock, string descripcion)
        {
            Productos nuevoProducto = new Productos { nombre = nombre, precio = precio, stock = stock, descripcion = descripcion };
            DB.Productos.Add(nuevoProducto);
            if (DB.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        [WebMethod]
        public int updateProductos(int id, string nombre, double precio, int stock, string descripcion)
        {
            try
            {
                var producto = DB.Productos.Where(x => x.id == id).FirstOrDefault();
                producto.nombre = nombre;
                producto.precio = precio;
                producto.stock = stock;
                producto.descripcion = descripcion;
                return DB.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }
        [WebMethod]
        public int deleteProductos(int id)
        {
            try
            {
                var producto = DB.Productos.Where(x => x.id == id).FirstOrDefault();
                DB.Productos.Remove(producto);
                return DB.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }

        }
        [WebMethod]
        public List<Productos> readProductos()
        {
            return DB.Productos.ToList();
        }
       
    }
}
