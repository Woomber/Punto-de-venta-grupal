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
    /// Lógica de interacción para Insertar.xaml
    /// </summary>
    public partial class Insertar : Window
    {

        puntoVentaSoapClient client;

        public Insertar()
        {
            InitializeComponent();
            client = new puntoVentaSoapClient();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombre = txt_nombre.Text;
                float precio = float.Parse(txt_precio.Text);
                int stock = int.Parse(txt_stock.Text);
                string desc = txt_descripcion.Text;

                client.createProductos(nombre, (double)precio, stock, desc);

                MessageBox.Show("Elemento agregado.");
                CRUD frm = new CRUD();

                frm.Show();
                this.Close();

            } catch (Exception ex)
            {
                MessageBox.Show("Datos inválidos.");
            }
            

        }
    }
}
