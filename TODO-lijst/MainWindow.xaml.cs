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
            try
            {
                if (listBox.SelectedIndex != -1)
                {
                    listBox.Items.Remove(listBox.SelectedItem);
                    
                }

                else
                {
                    MessageBox.Show("Eerst een opdracht aanklikken!","Fout",MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
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

            try
            {
                if (txtbxtoevoegen.Text != "")
                {
                    Opdrachten.Lijst = txtbxtoevoegen.Text;

                    string nieuweTaak = Opdrachten.Toevoegen();

                    items.Add(nieuweTaak);

                    listBox.Items.Add(nieuweTaak);

                    //tekstvak leeg maken
                    txtbxtoevoegen.Clear();
                }
                else
                    MessageBox.Show("Je moet eerst iets intypen!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}