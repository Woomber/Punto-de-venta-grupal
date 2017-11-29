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
    /// Lógica de interacción para Historial.xaml
    /// </summary>
    public partial class Historial : Window
    {

        puntoVentaSoapClient client;

        public Historial()
        {
            InitializeComponent();
            client = new puntoVentaSoapClient();

            historial.ItemsSource = from facturas in client.readFactura()
                                    join clientes in client.readClientes()
                                    on facturas.id_cliente equals clientes.id
                                    select new
                                    {
                                        ID = facturas.id,
                                        Apellidos = clientes.apellidos,
                                        Nombres = clientes.nombres,
                                        Total = facturas.precio_total,
                                        Dia = facturas.dia,
                                        Mes = facturas.mes,
                                        Año = facturas.anio
                                    };
        }
        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Inicio frm = new Inicio();

            frm.Show();
        }
    }
}
