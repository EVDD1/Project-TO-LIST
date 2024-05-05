using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
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
        MainWindow mainWindow;
        Bewerken bewerken;
        string BestandNaam1;

        string nieuweTaak;
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
        public void GegevensBewerkenOpenen(string tekst,string naam,string bestand)
        {
            bestandNaam.Close();

            bewerken = new Bewerken(this);
            bewerken.Owner = this;
            bewerken.Show();

            
            bewerken.Gegevens(tekst);

            bewerken.BestandNaam(naam,bestand);

        }
        public void BestandToegvoegen(string Naam)
        {

            bestandNaam.Close();
      
            BestandNaam1 = Naam;

            txtblckbestand.Text = Naam;


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

       
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string datum = txtbxDatum.Text;
            int controle = 0;
            try
            {
               if(DateTime.TryParse(datum, out DateTime result))
                {
                    Opdrachten.Datum = result;
                    controle++;
                  
                }
               else
                  MessageBox.Show("Geen geldige invoer voor datum!","Fout",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            try
            {
                if (txtbxtoevoegen.Text != "" )
                {
                    Opdrachten.Lijst = txtbxtoevoegen.Text;

                    controle++;
                }
                else
                    MessageBox.Show("Je moet eerst iets intypen!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //toevoegen als allebij de voorwaarden juist zijn
            if (controle == 2)
            {
                nieuweTaak = Opdrachten.Toevoegen();

                listBox.Items.Add(nieuweTaak);

                txtbxDatum.Clear();
                //tekstvak leeg maken
                txtbxtoevoegen.Clear();

                controle = 0;
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            foreach(string item in listBox.Items)
            {
               items.Add(item);
            }
            
            string json = JsonConvert.SerializeObject(items);

            try
            {

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, $"{BestandNaam1}");
                File.WriteAllText(filePath, json);

                MessageBox.Show("Items zijn opgeslagen!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //als je op terug klikt dan moet alles gecleard worden  
            items.Clear();
            listBox.Items.Clear();
            txtblckbestand.Text = string.Empty; //clearen

            KnopTerug();
        }
        
        public void KnopTerug()
        {
            //het eerste venster weer openen
            bestandNaam = new Bestandnaam(this);
            bestandNaam.Owner = this;
            bestandNaam.Show();
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //venster sluiten
            this.Close();
        }
    }
}