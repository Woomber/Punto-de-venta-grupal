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
    /// Lógica de interacción para CRUD.xaml
    /// </summary>
    public partial class CRUD : Window
    {
        public CRUD()
        {
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Insertar frm = new Insertar();

            frm.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Modificar frm = new Modificar();

            frm.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Eliminar frm = new Eliminar();

            frm.Show();
        }
    }
}
