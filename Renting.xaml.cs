using System;
using System.Collections.Generic;
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

namespace FinalPOE
{
    /// <summary>
    /// Interaction logic for Renting.xaml
    /// </summary>
    public partial class Renting : Window
    {
        double rent = 0.00;        


        public Renting()
        {
            InitializeComponent();
        }

        // Button click method which calls other methods and then closes the window
        private void Submit_Renting_Click(object sender, RoutedEventArgs e)
        {
            UserEntry();
            
        }


        // close button
        private void Close_Renting_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }





        // Error handling to ensure the user enters digits
        public void UserEntry()
        {
            try
            {
                rent = Convert.ToDouble(userRent.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");
                
            }
        }






        // Getters
        public double GetRent()
        {
            return rent;
        }

        
    }
}
