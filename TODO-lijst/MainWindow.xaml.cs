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

        SerialPort serialPort  = new SerialPort();
        Opdrachten Opdrachten = new Opdrachten();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void listBox_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<string> opdrachtenLijst = new List<string>();

            Opdrachten.Lijst = txtbxtoevoegen.Text;

            
            opdrachtenLijst.Add(Opdrachten.Toevoegen());

            listBox.ItemsSource = opdrachtenLijst;

            //tekstvak leeg maken
            txtbxtoevoegen.Clear();
        }
    }
}