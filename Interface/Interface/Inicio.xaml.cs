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

namespace Interface
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();
        }
        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Registro_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            MainWindow frm = new MainWindow();

            frm.Show();
        }

        private void Productos_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            CRUD frm = new CRUD();

            frm.Show();
        }

        private void Historial_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Historial frm = new Historial();

            frm.Show();
        }

        private void Venta_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Facturas frm = new Facturas();

            frm.Show();
        }
    }

}
