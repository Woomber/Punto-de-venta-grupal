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
    /// Lógica de interacción para Eliminar.xaml
    /// </summary>
    public partial class Eliminar : Window
    {
        puntoVentaSoapClient client;

        public Eliminar()
        {
            InitializeComponent();

            client = new puntoVentaSoapClient();

            productos.ItemsSource = client.readProductos();
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Productos eliminado = productos.SelectedItem as Productos;

                client.deleteProductos(eliminado.id);
                MessageBox.Show("Eliminado.");
            }
           catch(Exception ex)
            {

            }

        }
    }
}
