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
    /// Interaction logic for Saving.xaml
    /// </summary>
    /// 
    public partial class Saving : Window
    {
        // declaring variables
        double amountToBeSaved, savingIntRate, noOfMonthsToSave, i , t, periodPayment  = 0.00;


        // Butto click to close window
        private void Close_Savings_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        // Button click method which calls other methods and then closes the window
        private void Submit_Saving_Click(object sender, RoutedEventArgs e)
        {
            UserEntry();
            Calculation();            
        }


        public Saving()
        {
            InitializeComponent();
        }


        // Error handling to ensure the user enters digits
        public void UserEntry()
        {
            try
            {
                amountToBeSaved = Convert.ToDouble(userSavingAmount.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");

            }
            try
            {
                savingIntRate = Convert.ToDouble(userSavingIntRate.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");

            }
            try
            {
                noOfMonthsToSave = Convert.ToDouble(userSavingMonths.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");

            }

        }


        // calculations method to calculate the period payment amount they should be saving to reach their goal
        public void Calculation()
        {
            i = savingIntRate / 100;
            t = noOfMonthsToSave / 12;

            periodPayment = amountToBeSaved * ((i / noOfMonthsToSave) / (Math.Pow(1 + i / noOfMonthsToSave,  noOfMonthsToSave * t) - 1));           



        }


        // Getters
        public double GetSavingAmount()
        {
            return periodPayment;
        }




        
    }
}
