using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace TODO_lijst
{
    /// <summary>
    /// Interaction logic for Bestandnaam.xaml
    /// </summary>
    public partial class Bestandnaam : Window
    {
         MainWindow _mainWindow;

        string fileName;
        public Bestandnaam(MainWindow mainWindow)
        {
            InitializeComponent();

           _mainWindow = mainWindow;

            comboboxbestanden.Items.Add("None");

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string[] files = Directory.GetFiles(desktopPath,"*.txt");

           
            foreach (string file in files)
            {
                 fileName = Path.GetFileName(file);
                comboboxbestanden.Items.Add(fileName);
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Path.GetExtension(txtbestandNaam.Text).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    string BestandNaam = txtbestandNaam.Text;

                    _mainWindow.BestandToegvoegen(BestandNaam);

                    MessageBox.Show("Bestand toegevoegd!");


                }
                else
                    MessageBox.Show("Je moet .txt achter bestandnaam zetten", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cmbxbestanden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listboxbestand.Items.Clear();


            try
            {
                if (comboboxbestanden.SelectedItem != null && comboboxbestanden.SelectedItem.ToString() != "None")
                {
                    string selectedFileName = comboboxbestanden.SelectedItem.ToString();
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string filePath = Path.Combine(desktopPath, selectedFileName);
                    string fileContent = File.ReadAllText(filePath);

                    listboxbestand.Items.Add(fileContent);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            try
            {
                if (comboboxbestanden.SelectedItem != null && comboboxbestanden.SelectedItem.ToString() != "None")
                {
                    string selectedFileName = comboboxbestanden.SelectedItem.ToString();
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string filePath = Path.Combine(desktopPath, selectedFileName);

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        MessageBox.Show("Het bestand is verwijderd!");

                        // Verwijder het geselecteerde item uit de combobox
                        comboboxbestanden.Items.Remove(comboboxbestanden.SelectedItem);
                        // Wis de selectie in de combobox
                        comboboxbestanden.SelectedIndex = 0;

                    }
                    else
                    {
                        MessageBox.Show("Het geselecteerde bestand kan niet worden gevonden.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecteer eerst een bestand om te verwijderen.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden: " + ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
