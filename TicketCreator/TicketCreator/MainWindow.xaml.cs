using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using TicketCreator.ticketService;

namespace TicketCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // code from https://code.msdn.microsoft.com/input-validation-in-b9d3de0c

        bool IsValid = false;


        public MainWindow()
        {
            InitializeComponent();
            nameLabelOutput.Content = Environment.MachineName + "\\" + Environment.UserName.ToUpper();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (emailText.Text.Contains("@") && emailText.Text.Contains(".") && descriptionText.Text != "")
            {
                int responseInt = -1;
                bool responseBool = false;

                ticketService.Service1 ticket = new ticketService.Service1();

                bool tryagain = true;
                int counter = 0;
                while (tryagain)
                {
                    try
                    {
                        ticket.SubmitTicket(nameLabelOutput.Content.ToString(), emailText.Text, descriptionText.Text, out responseInt, out responseBool);
                        tryagain = false;
                    }
                    catch (Exception)
                    {
                        responseLabel.Content = "Server not responding";
                        if (counter < 3)
                        {
                            counter++;
                        }
                        else
                        {
                            tryagain = false;
                        }
                    }
                }

                if (responseInt == -1)
                {
                    responseLabel.Content = "Unable to submit ticket please try again in a few minutes";
                }
                else
                {
                    responseLabel.Content = "Ticket submitted with TicketID " + responseInt;
                }
            }
            else
            {
                if (!(emailText.Text.Contains("@") && emailText.Text.Contains(".")))
                {
                    emailText.Background = Brushes.Red;
                }
                else
                {
                    emailText.Background = Brushes.Green;
                }

                if (descriptionText.Text == "")
                {
                    descriptionText.Background = Brushes.Red;
                }
                else
                {
                    descriptionText.Background = Brushes.Green;
                }

                responseLabel.Content = "Please enter a valid email address and description";
            }

        } // end Button_click

        private void emailText_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            
        }

        private void emailText_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            emailText.Background = Brushes.White;
        }

        private void descriptionText_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            descriptionText.Background = Brushes.White;
        }
    }
}
