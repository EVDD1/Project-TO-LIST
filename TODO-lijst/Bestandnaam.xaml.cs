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
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string[] files = Directory.GetFiles(desktopPath,"*.txt");

            comboboxbestanden.Items.Add("None");
            foreach (string file in files)
            {
                 fileName = Path.GetFileName(file);
                comboboxbestanden.Items.Add(fileName);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Path.GetExtension(txtbestandNaam.Text).Equals(".txt", StringComparison.OrdinalIgnoreCase))
            {
                string BestandNaam = txtbestandNaam.Text;

                _mainWindow.BestandToegvoegen(BestandNaam);

                MessageBox.Show("Bestand toegevoegd!");

            
            }
            else
                MessageBox.Show("Je moet .txt achter bestandnaam zetten","Fout",MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void cmbxbestanden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxbestanden.SelectedItem.ToString() != "None")
            {
                string selectedFileName = comboboxbestanden.SelectedItem.ToString();
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, selectedFileName);
                string fileContent = File.ReadAllText(filePath);

                listboxbestand.Items.Add(fileContent);
               

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
