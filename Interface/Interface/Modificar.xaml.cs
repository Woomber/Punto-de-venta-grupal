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
    /// Lógica de interacción para Modificar.xaml
    /// </summary>
    public partial class Modificar : Window
    {
        puntoVentaSoapClient soap;
        Productos[] lista;
        public Modificar()
        {
            InitializeComponent();
            soap = new puntoVentaSoapClient();
            lista = soap.readProductos();
            for (int i = 0; i < lista.Length; i++)
            {
                cBox_nombre.Items.Add(lista[i].nombre);
            }
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            soap.updateProductos(lista[cBox_nombre.SelectedIndex].id, Convert.ToString(cBox_nombre.SelectedItem), Convert.ToDouble(txt_precio.Text), Convert.ToInt32(txt_stock.Text), txt_descripcion.Text);
            MessageBox.Show("Modificado.");
        }

        private void cBox_nombre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            txt_descripcion.Text = lista[cBox_nombre.SelectedIndex].descripcion;
            txt_precio.Text = Convert.ToString(lista[cBox_nombre.SelectedIndex].precio);
            txt_stock.Text = Convert.ToString(lista[cBox_nombre.SelectedIndex].stock);
        }
    }
}
