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

namespace TODO_lijst
{
    /// <summary>
    /// Interaction logic for Bestandnaam.xaml
    /// </summary>
    public partial class Bestandnaam : Window
    {
         MainWindow _mainWindow;
        public Bestandnaam(MainWindow mainWindow)
        {
            InitializeComponent();

           _mainWindow = mainWindow;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string BestandNaam = txtbestandNaam.Text;

            _mainWindow.BestandToegvoegen(BestandNaam);
        }
    }
}
