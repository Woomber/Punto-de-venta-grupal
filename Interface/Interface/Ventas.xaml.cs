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
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {

        public int IdFactura { get; set; }

        puntoVentaSoapClient client;

        int cantidad;
        double precio;

        public Ventas()
        {
            InitializeComponent();

            client = new puntoVentaSoapClient();

            txt_producto.ItemsSource = client.readProductos().ToList();
            txt_producto.DisplayMemberPath = "nombre";
            

            actualizarCantidad();

        }
        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Facturas frm = new Facturas();

            frm.Show();
        }

        void actualizarCantidad()
        {
            Productos producto = txt_producto.SelectedItem as Productos;
            try
            {
                cantidad = int.Parse(txt_cantidad.Text);
                precio = cantidad * producto.precio;
            }
            catch (Exception ex)
            {
                cantidad = 0;
            }
            txt_precioa.Text = precio.ToString();
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Productos producto = txt_producto.SelectedItem as Productos;

            client.createVenta(IdFactura, producto.id, (float) precio, cantidad);

            MessageBox.Show("Venta realizada.");

            this.Close();
        }

        private void txt_cantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualizarCantidad();

         
        }
        private void txt_producto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            actualizarCantidad();
        }

       

      
    }
}
