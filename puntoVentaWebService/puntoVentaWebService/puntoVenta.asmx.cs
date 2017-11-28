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
        PuntoVenta_GEntities DB;
        public puntoVenta()
        {
            DB = new PuntoVenta_GEntities();
        }

        [WebMethod]
        public int createFactura( int id_cliente, float precio_total, int dia, int mes, int anio)
        {
            var ultimaFact = DB.Facturas.ToList().LastOrDefault();
            Facturas nuevaFactura = new Facturas { id = ultimaFact.id+1, id_cliente = id_cliente, precio_total = precio_total, anio=anio,mes=mes,dia=dia };
            DB.Facturas.Add(nuevaFactura);
            if (DB.SaveChanges() > 0)
            {
                return ultimaFact.id+1;
            }
            return -1;
        }
        [WebMethod]
        public List<Facturas> readFactura()
        {
            return DB.Facturas.ToList<Facturas>();
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
        public int createVenta(int id_factura, int id_producto, float precio, int cantidad)
        {
            var ultimaVenta = DB.Ventas.ToList().LastOrDefault();
            Ventas nuevaVenta = new Ventas { id = ultimaVenta.id+1, id_factura = id_factura, id_producto = id_producto, precio = precio, cantidad = cantidad };
            DB.Ventas.Add(nuevaVenta);
            if (DB.SaveChanges() > 0)
            {
                return ultimaVenta.id+1;
            }
            return -1;
        }
        [WebMethod]
        public List<Ventas> readVenta()
        {
            return DB.Ventas.ToList<Ventas>();
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
        public int createClientes(string nombres, string apellidos, string direccion, string correo)
        {
            var ultimoCliente = DB.Clientes.ToList().LastOrDefault();
            Clientes nuevoCliente = new Clientes {id=ultimoCliente.id+1, nombres=nombres, apellidos=apellidos, direccion=direccion, correo=correo };
            DB.Clientes.Add(nuevoCliente);
            if (DB.SaveChanges() > 0)
            {
                return ultimoCliente.id+1;
            }
            return -1;
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
        public int createProductos(string nombre, double precio, int stock, string descripcion)
        {
            var ultimoProducto = DB.Productos.ToList().LastOrDefault();
            Productos nuevoProducto = new Productos {id= ultimoProducto.id+1, nombre = nombre, precio = precio, stock = stock, descripcion = descripcion };
            DB.Productos.Add(nuevoProducto);
            if (DB.SaveChanges() > 0)
            {
                return ultimoProducto.id+1;
            }
            return -1;
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
