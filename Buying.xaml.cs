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
    /// Interaction logic for Buying.xaml
    /// </summary>
    public partial class Buying : Window
    {
        // delcaring variables 
        double purchasePrice, totalDeposit, interestRate, noOfMonthsToRepay, monthlyRepayment, n = 0.00;


        // Button click method which calls other methods and then closes the window
        private void Submit_Buying_Click(object sender, RoutedEventArgs e)
        {
            UserEntry();
            Calculations();            
        }


        // Close Button 
        private void Close_Buying_Click(object sender, RoutedEventArgs e)
        {
           Close();
        }



        public Buying()
        {
            InitializeComponent();
        }


        


        // Error Handiling to ensure user enters correct values for all text boxes
        public void UserEntry()
        {
            try
            {
                purchasePrice = Convert.ToDouble(userPropertyPrice.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");
                
            }
            try
            {
                totalDeposit = Convert.ToDouble(userPropertyDeposit.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");

            }
            try
            {
                interestRate = Convert.ToDouble(userPropertyIntRate.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");

            }
            try
            {
                noOfMonthsToRepay = Convert.ToDouble(userMonthstoRepay.Text);
                
                if (noOfMonthsToRepay < 240 || noOfMonthsToRepay > 360)
                {
                    throw new ArgumentOutOfRangeException("noOfMonthsToRepay", "Number of months to repay must be between 240 and 360.");
                }

            }
            catch
            {
                
                MessageBox.Show("Please enter digits between 240-360");

            }
             
        }     



        // calculation method to caluclate monthlyrepayment on the home
        public void Calculations()
        {
            n = noOfMonthsToRepay / 12; // declaring n as a variable

            // declaring and calculating the value of their rent and budget 
            double newIntHouseRate = interestRate / 100;
            monthlyRepayment = ((purchasePrice - totalDeposit) * (1 + newIntHouseRate * n)) / noOfMonthsToRepay;
        }




        // Getters 
        public double GetDeposit()
        {
            return totalDeposit;
        }

        public double GetMonthlyRepayment()
        {
            return monthlyRepayment;
        }
    }
}
