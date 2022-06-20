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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalPOE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        // declaring variables
        double sum, grossIncome, taxDeducted, groceries, utilities, travelCosts, cellPhone, averageOtherExpenses, totalExpenditures = 0.00;


        // Instantiating classes
        Vehicle carvehicle = new Vehicle();
        Buying buying = new Buying();
        Renting renting = new Renting();
        Saving saving = new Saving();



        // Radio Buttons to open other windows
        private void RentingRadioButtonOption_Checked(object sender, RoutedEventArgs e)
        {
            renting.Show();
        }

        private void BuyingRadioButtonOption_Checked(object sender, RoutedEventArgs e)
        {
            buying.Show();
        }

        private void VehicleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            carvehicle.Show();
        }

        private void SavingRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            saving.Show();
        }    


        // Button method that calls user entry method, the calculations and prompots a message box to show the user their avaiable funds
        private void Calculate_Main_Click(object sender, RoutedEventArgs e)
        {
            if (!UserEntries())
            {
                UserEntries();
                Calculations();
                MessageBox.Show("Your available funds is R: " + totalExpenditures);
            }
        }


        // button method to display a message box to the user the expenses that are stored in a dictionary in descending order
        private void View_Expenses_Main_Click(object sender, RoutedEventArgs e)
        {
            if (!UserEntries())
            {
                ExpensesCollection();
                var View = new System.Text.StringBuilder();
                foreach (var item in d.OrderByDescending(key => key.Value))
                {
                    View.AppendLine($"{item.Key}: R{item.Value}");
                }

                MessageBox.Show(View.ToString());
            }
        }        




        // Error Handling of User Entries
        public bool UserEntries()
        {
            bool errocheck = false;

            try
            {
                grossIncome = Convert.ToDouble(userIncome.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");
                errocheck = true;
            }

            try
            {
                taxDeducted = Convert.ToDouble(userTax.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");
                errocheck = true;
            }
            try
            {
                groceries = Convert.ToDouble(userGroceries.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");
                errocheck = true;
            }
            try
            {
                utilities = Convert.ToDouble(userUtilities.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");
                errocheck = true;
            }
            try
            {
                travelCosts = Convert.ToDouble(userTravel.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");
                errocheck = true;
            }
            try
            {
                cellPhone = Convert.ToDouble(userCellPhone.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");
                errocheck = true;
            }
            try
            {
                averageOtherExpenses = Convert.ToDouble(userOtherExpenses.Text);
            }
            catch
            {
                MessageBox.Show("Please enter digits");
                errocheck = true;
            }

            return errocheck;
        }




        // Calculations method for total expenditures
        public void Calculations()
        {
            totalExpenditures = grossIncome - (taxDeducted + groceries + utilities + travelCosts + cellPhone + averageOtherExpenses);
        }




        // Expenses stored in a Dictionary
        Dictionary<string, double> d = new Dictionary<string, double>();


        // Generic Collection for expenses stored in a dictionary
        public void ExpensesCollection()
        {
            // User expenses
            d["Tax"] = taxDeducted;
            d["Groceries"] = groceries;
            d["Utilities"] = utilities;
            d["Travelling"] = travelCosts;
            d["Cell Phone Bill"] = cellPhone;
            d["Other Expenses"] = averageOtherExpenses;

            // Home Loan expenses
            d["Home Loan Deposit"] = buying.GetDeposit();
            d["Home Repayments"] = buying.GetMonthlyRepayment();

            // Renting Expenses
            d["Rent"] = renting.GetRent();

            //Vehicle Expenses
            d["Estimated Insruance Premium"] = carvehicle.GetInsurance();
            d["Vehicle Total Deposit"] = carvehicle.GetDeposit();
            d["Monthly Car Repayment"] = carvehicle.GetMonthlyCarRepayment();

            // Savings
            d["Period Payment for Savings"] = saving.GetSavingAmount();

            

            sum = d.Sum(x => x.Value); // sum of all the value items in the dictionary
           

        }



        // References 
        // (Troelson, Jakipse; 2017; Pro C# 7: With .NET and .NET Core)
        // PROG6221 Guru Videos - Youtube Playlist - https://www.youtube.com/playlist?list=PL480DYS-b_keHacwHfXhHmHpWSI1n3Ff9




    }
}
    

