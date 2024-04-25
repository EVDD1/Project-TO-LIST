using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Path = System.IO.Path;

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
        Bestandnaam bestandNaam;
        string BestandNaam1;
        public MainWindow()
        {
            InitializeComponent();
            items = new List<string>();

            


        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bestandNaam = new Bestandnaam(this);
            bestandNaam.Owner = this;
            bestandNaam.Show();
        }

        public void BestandToegvoegen(string bestandNaam)
        {
            BestandNaam1 = bestandNaam;
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

                    string json = JsonConvert.SerializeObject(items);

                    try
                    {
                        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string filePath = Path.Combine(desktopPath, $"{BestandNaam1}");
                        File.WriteAllText(filePath, json);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Er is een fout opgetreden: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
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