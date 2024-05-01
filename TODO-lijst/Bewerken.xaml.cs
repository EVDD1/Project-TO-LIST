using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private List<string> items;
        Bestandnaam bestandNaam;
        MainWindow _mainWindow;
        Bewerken bewerken;
        Opdrachten opdrachten = new Opdrachten();

        string nieuweTaak;
        string filepath;
        public Bewerken(MainWindow mainWindow)
        {
            InitializeComponent();

            _mainWindow = mainWindow;

            items = new List<string>();


        }
        public void BestandNaam(string naam,string bestand)
        {
            txtblckbnaam.Text = naam;
            filepath = bestand;
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
            try
            {
                if (listboxbewerken.SelectedIndex != -1)
                {
                    listboxbewerken.Items.Remove(listboxbewerken.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Eerst een opdracht aanklikken!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string datum = txtbxDatum.Text;
            int controle = 0;
            try
            {
                if (DateTime.TryParse(datum, out DateTime result))
                {
                    opdrachten.Datum = result;
                    controle++;

                }
                else
                    MessageBox.Show("Geen geldige invoer voor datum!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            try
            {
                if (txtbxOprdracht.Text != "")
                {
                    opdrachten.Lijst = txtbxOprdracht.Text;

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
                nieuweTaak = opdrachten.Toevoegen();

                listboxbewerken.Items.Add(nieuweTaak);

                txtbxDatum.Clear();
                //tekstvak leeg maken
                txtbxOprdracht.Clear();

                controle = 0;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (string item in listboxbewerken.Items)
                {
                    items.Add(item);
                }
                string json = JsonConvert.SerializeObject(items);

                File.WriteAllText(filepath, json);

                MessageBox.Show("Wijzigingen zijn opgeslagen!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();

            _mainWindow.KnopTerug();
        }
    }
}
