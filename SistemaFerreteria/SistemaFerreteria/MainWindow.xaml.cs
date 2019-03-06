using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SistemaFerreteria
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Resumen.Items.Add(new ItemVendido
            {
                Importe = "Efectivo",
                Hora = "0"
            });
            Resumen.Items.Add(new ItemVendido
            {
                Importe = "Tarjeta",
                Hora = "0"
            });
            Resumen.Items.Add(new ItemVendido
            {
                Importe = "AFIP",
                Hora = "0"
            });
            Resumen.Items.Add(new ItemVendido
            {
                Importe = "Factura A",
                Hora = "0"
            });
            var anio = new DateTime(DateTime.Now.Year, 1, 1);
            for (var i = 0; i < 12; i++)
            {
                ResumenMensual.Items.Add(new ResumenMensualData
                {
                    Mes = anio.ToString("MMMM"),
                    Efectivo = "100",
                    Tarjeta = "100",
                    Afip = "100",
                    FacturaA = "100"
                });
                anio = anio.AddMonths(1);
            }
            PagoProveedores.Items.Add(new PagoProveedores
            {
                Proveedor = "Carlos",
                Deuda = "$200",
                Pagar = "$0"
            });
        }

        private void IngresoEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            var valor = 0m;
            var resultado = decimal.TryParse(IngresoEfectivo.Text, out valor);
            

            if (e.Key == Key.Return && !string.IsNullOrEmpty(IngresoEfectivo.Text) && resultado)
            {
                var vendido = new ItemVendido
                {
                    Importe = "$" + IngresoEfectivo.Text,
                    Hora = DateTime.Now.ToString("hh:mm")
                };

                Efectivo.Items.Add(vendido);
                var border = VisualTreeHelper.GetChild(Efectivo, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }
                IngresoEfectivo.Text = string.Empty;
                var r = 0m;
                foreach (var c in Efectivo.Items)
                {
                    r += decimal.Parse(((ItemVendido)c).Importe.Replace('$', '0'));
                    ((ItemVendido)Resumen.Items[0]).Hora = r.ToString();
                }
                ((ItemVendido)Resumen.Items[0]).Hora = "$" + ((ItemVendido)Resumen.Items[0]).Hora;
                Resumen.Items.Refresh();
            }
        }

        private void IngresoEfectivo_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = string.Empty;
        }

        private void IngresoEfectivo_LostFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "$ 0,0";
        }

        private void IngresoEfectivo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regext = new Regex(@"([0-9])|([,])|([0-9])$");
            e.Handled = !regext.IsMatch(e.Text) || IngresoEfectivo.Text.Contains(",") && e.Text == ",";
        }
    }
    public class ItemVendido
    {
        public string Importe { get; set; }
        public string Hora { get; set; }
        public string IdTipo { get; set; }
    }
    public class ResumenMensualData
    {
        public string Mes { get; set; }
        public string Efectivo { get; set; }
        public string Tarjeta { get; set; }
        public string Afip { get; set; }
        public string FacturaA { get; set; }
    }
    public class PagoProveedores
    {
        public string Proveedor { get; set; }
        public string Deuda { get; set; }
        public string Pagar { get; set; }
    }
}
