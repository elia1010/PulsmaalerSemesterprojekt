using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using global::RPI;
using global::RPI.Controller;
using global::RPI.Display;
using global::RPI.Heart_Rate_Monitor;
using global::RPI.IO;
using Pulsmåler_Semesterprojekt;

namespace PulsmaalerSemesterProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
         
        HeartRateController heartRateController;

        public MainWindow()
        {
            heartRateController = new HeartRateController();
            InitializeComponent();
        }

        private void readyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateName(patientTB.Text))
            {
                MessageBox.Show($"The name {patientTB.Text} is invalid");
            }
            else
            {
                readyButton.IsEnabled = false;
                resetButton.IsEnabled = false;
                heartRateController.Start(patientTB.Text);

            }
            
            UpdateListBox();
            resetButton.IsEnabled = true;


        }
        private bool ValidateName(string patientName)
        {
            if (patientName.Length == 0) { return false; }

            if (patientName.Length >= 15) { return false; }

            return true;

        }
        private void UpdateListBox()
        {
            ListBox box = patientListBox;
            box.Items.Clear();

            foreach (Measurements m in heartRateController.Measurements)
            {
                box.Items.Add(m);
            }
            
        }
        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            heartRateController.reset();
            patientTB.Text = string.Empty;
            readyButton.IsEnabled = true;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void patientTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void patientListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }

}

