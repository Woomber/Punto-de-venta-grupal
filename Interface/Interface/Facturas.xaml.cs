using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Interface.WebService;


namespace Interface
{
    /// <summary>
    /// Lógica de interacción para Facturas.xaml
    /// </summary>
    public partial class Facturas : Window
    {
        puntoVentaSoapClient client;
        int facturaActual = 0;
        int clienteActual;

        public Facturas()
        {
            InitializeComponent();

            client = new puntoVentaSoapClient();



            txt_producto.ItemsSource = client.readClientes();
            txt_producto.DisplayMemberPath = "apellidos";

            ActualizarFacturas();

        }

        void ActualizarFacturas()
        {
            var ventas = from factura in client.readVenta()
                         join producto in client.readProductos()
                         on factura.id_producto equals producto.id
                         where factura.id_factura == facturaActual
                         select new
                         {
                             Producto = producto.nombre,
                             Cantidad = factura.cantidad,
                             PrecioUnitario = producto.precio,
                             Subtotal = factura.precio
                         };

            facturas.ItemsSource = ventas.ToList();
        }

        private void Productos_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();

            Ventas frm = new Ventas();
            frm.IdFactura = facturaActual;

            frm.Show();
        }


        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();

            CRUD frm = new CRUD();

            frm.Show();
        }

        private void Registro_Click(object sender, RoutedEventArgs e)
        {
            Clientes cliente = txt_producto.SelectedItem as Clientes;


            clienteActual = cliente.id;

            //Con valores temporales que se llenan al terminar la factura
            facturaActual = client.createFactura(
                clienteActual,
                0,
                0,
                0,
                0);

            Productos.IsEnabled = true;
            Registro.IsEnabled = false;
            txt_producto.IsEnabled = false;

        }

        private void Historial_Click(object sender, RoutedEventArgs e)
        {
            DateTime fecha = DateTime.Now;

            //Suma de los precios
            float sumaTotal = (float)
                            (from elemento in client.readVenta()
                             where elemento.id_factura == facturaActual
                             select elemento.precio
                            ).Sum();

            client.updateFactura(facturaActual, clienteActual, sumaTotal, fecha.Day, fecha.Month, fecha.Year);


            MessageBox.Show("Factura guardada.");

            this.Close();

        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            ActualizarFacturas();
        }
    }
}
