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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Interface.WebService;

namespace Interface
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        puntoVentaSoapClient soap;
        public MainWindow()
        {
            soap = new puntoVentaSoapClient();
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Inicio frm = new Inicio();

            frm.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            soap.createClientes(txt_nombrem.Text, txt_apellido.Text, txt_direccion.Text, txt_correo.Text);
            Inicio frm = new Inicio();

            frm.Show();
            this.Close();


        }
    }
}
