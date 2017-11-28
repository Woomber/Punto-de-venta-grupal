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
        public bool createFactura(int id, int id_cliente, float precio_total, int dia, int mes, int anio)
        {
            Facturas nuevaFactura = new Facturas { id = id, id_cliente = id_cliente, precio_total = precio_total, anio=anio,mes=mes,dia=dia };
            DB.Facturas.Add(nuevaFactura);
            if (DB.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        [WebMethod]
        public List<Facturas> readFactura()
        {
            return DB.Facturas.ToList();
        }
        [WebMethod]
        public int updateFactura(int id, int id_cliente, float precio_total, int dia, int mes, int anio)
        {
            try
            {
                var factura = DB.Facturas.Where(x => x.id == id).FirstOrDefault();
                factura.id_cliente = id_cliente;
                factura.precio_total = precio_total;
                factura.dia = dia;
                factura.mes = mes;
                factura.anio = anio;
                return DB.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }
        [WebMethod]
        public int deleteFactura(int id)
        {
            try
            {
                var factura = DB.Facturas.Where(x => x.id == id).FirstOrDefault();
                DB.Facturas.Remove(factura);
                return DB.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        [WebMethod]
        public bool createVenta(int id, int id_factura, int id_producto, float precio, int cantidad)
        {
            Ventas nuevaVenta = new Ventas { id = id, id_factura = id_factura, id_producto = id_producto, precio = precio, cantidad = cantidad };
            DB.Ventas.Add(nuevaVenta);
            if (DB.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        [WebMethod]
        public List<Ventas> readVenta()
        {
            return DB.Ventas.ToList();
        }
        [WebMethod]
        public int updateVenta(int id, int id_factura, int id_producto, float precio, int cantidad)
        {
            try
            {
                var venta = DB.Ventas.Where(x => x.id == id).FirstOrDefault();
                venta.id_factura = id_factura;
                venta.id_producto = id_producto;
                venta.precio = precio;
                venta.cantidad = cantidad;
                return DB.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }
        [WebMethod]
        public int deleteVenta(int id)
        {
            try
            {
                var venta = DB.Ventas.Where(x => x.id == id).FirstOrDefault();
                DB.Ventas.Remove(venta);
                return DB.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
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
        public bool createProductos(int id, string nombre, double precio, int stock, string descripcion)
        {
            Productos nuevoProducto = new Productos {id=id, nombre = nombre, precio = precio, stock = stock, descripcion = descripcion };
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
