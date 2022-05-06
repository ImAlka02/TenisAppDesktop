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

namespace TenisMVVM.Views
{
    /// <summary>
    /// Lógica de interacción para TenisVista.xaml
    /// </summary>
    public partial class TenisVista : UserControl
    {
        public TenisVista()
        {
            InitializeComponent();
        }

       

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de eliminar la pelicula?", "Confirme",
                           MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ((TenisMVVM.ViewModels.TenisViewModel)this.DataContext).EliminarCommand.Execute(null);
            }
        }
    }
}
