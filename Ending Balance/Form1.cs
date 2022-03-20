using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ending_Balance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            const decimal INTERES_RATE = 0.005m;
            decimal balance;
            int months;

            //loop counter 
            int count = 1;

            // get starting balance
            if(decimal.TryParse(startingBalTextBox.Text, out balance))
            {
                if(int.TryParse(monthsTextBox.Text, out months))
                {
                    while(count <= months)
                    {
                        //add this month's interest to the balance
                        balance = balance + (INTERES_RATE * balance);
                        count++;
                    }

                    //display ending balance
                    endingBalanceLabel.Text = balance.ToString("c");
                }
                else
                {
                    MessageBox.Show("Invalid months entered");
                }
            }
            else
            {
                MessageBox.Show("Invalid ending balance entered");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
             startingBalTextBox.Text = "";
             monthsTextBox.Text = "";
             endingBalanceLabel.Text = "";
           
             // Reset the focus.
             startingBalTextBox.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
