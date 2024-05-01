using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;
using Path = System.IO.Path;

namespace TODO_lijst
{
    /// <summary>
    /// Interaction logic for Bewerken.xaml
    /// </summary>
    public partial class Bewerken : Window
    {
        Bestandnaam _bestandnaam;
        MainWindow _mainWindow;
        Bewerken bewerken;
        public Bewerken(MainWindow mainWindow)
        {
            InitializeComponent();

            _mainWindow = mainWindow;


            
        }
        public void BestandNaam(string naam)
        {
            txtblckbnaam.Text = naam;
        }
        public void Gegevens(string list)
        {
           string[] splitsen = list.Split(',');
           foreach (string s in splitsen)
            {
                listboxbewerken.Items.Add(s.Trim('[', ']', '"'));
            }


                
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
