using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TODO_lijst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> items;

        SerialPort serialPort  = new SerialPort();
        Opdrachten Opdrachten = new Opdrachten();
        public MainWindow()
        {
            InitializeComponent();
            items = new List<string>();

        }

        private void listBox_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(listBox.SelectedIndex != -1)
            {
                items.RemoveAt(listBox.SelectedIndex);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if(listBox.SelectedIndex != -1)
            {
                items[listBox.SelectedIndex] = txtbxVervangen.Text;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            listBox.ItemsSource = items;

            //tekstvak leeg maken
            txtbxtoevoegen.Clear();

        
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
          
            Opdrachten.Lijst = txtbxtoevoegen.Text;

            items.Add(Opdrachten.Toevoegen());

          
        }
    }
}