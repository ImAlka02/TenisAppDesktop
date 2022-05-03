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

namespace TenisMVVM.Views
{
    /// <summary>
    /// Lógica de interacción para ColeccionView.xaml
    /// </summary>
    public partial class ColeccionView : Window
    {
        public ColeccionView()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de eliminar la pelicula?", "Confirme",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                    tvm.EliminarCommand.Execute(null);
            }
        }
    }
}
