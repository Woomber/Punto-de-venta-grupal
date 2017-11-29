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

        List<Productos> misProductos;

        public Eliminar()
        {
            InitializeComponent();

            client = new puntoVentaSoapClient();

            actualizar();
           
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

        void actualizar()
        {
            misProductos = client.readProductos().ToList();
            var linq = from elemento in misProductos
                       select new
                       {
                           Nombre = elemento.nombre,
                           Precio = elemento.precio,
                           Stock = elemento.stock,
                           Descripción = elemento.descripcion
                       };
            productos.ItemsSource = linq.ToList();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
                int eliminado = productos.SelectedIndex;

                if (eliminado == -1) return;

               

                if(client.deleteProductos(misProductos[eliminado].id) == -1)
                    MessageBox.Show("No es posible eliminar este producto");
                else
                    MessageBox.Show("Eliminado.");
                actualizar();
                

        }
    }
}
