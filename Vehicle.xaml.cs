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
    /// Interaction logic for Vehicle.xaml
    /// </summary>
    public partial class Vehicle : Window
    {
        // delcaring variables
        string modelMake;
        double vehiclePrice, vehicleTotalDeposit, vehicleIntRate, estimatedInsurancePremuim, monthlyCarRepayment = 0.00;

        public Vehicle()
        {
            InitializeComponent();
        }




        // Button click method which calls other methods and then closes the window
        private void Submit_Vehicle_Click(object sender, RoutedEventArgs e)
        {
            UserEntry();
            Calculations();
            
        }


        // error handling to ensure user enters the correct values 
        public void UserEntry()
        {
            modelMake = userModelMake.Text;

            try
            {
                vehiclePrice = Convert.ToDouble(userVehiclePrice.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");
            }
            try
            {
                vehicleTotalDeposit = Convert.ToDouble(userVehicleDeposit.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");
            }
            try
            {
                vehicleIntRate = Convert.ToDouble(userVehicleIntRate.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");
            }
            try
            {
                estimatedInsurancePremuim = Convert.ToDouble(userInsurancePremium.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");
            }
        }


        // Button click to close window
        private void Close_Vehicle_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        // Calculation method calculate the monthly car repyament 
        public void Calculations()
        {
            int n = 60 / 12;
            double newIntRate = vehicleIntRate / 100;
            monthlyCarRepayment = ((vehiclePrice - vehicleTotalDeposit) * (1 + newIntRate * n)) / 60;


        }






        // Getters
        public double GetInsurance()
        {
            return estimatedInsurancePremuim;
        }

        public double GetDeposit()
        {
            return vehicleTotalDeposit;
        }

        public double GetMonthlyCarRepayment()
        {
            return monthlyCarRepayment;
        }
    }
}
