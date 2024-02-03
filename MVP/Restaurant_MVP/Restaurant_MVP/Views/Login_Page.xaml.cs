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

namespace Restaurant_MVP
{
    /// <summary>
    /// Interaction logic for Login_Page.xaml
    /// </summary>
    public partial class Login_Page : Page
    {
        ContViewModel ContVM;
        Frame Frame;
        Cont toCheck;

        public Login_Page()
        {
            InitializeComponent();
            user_box.Text = "";
        }

        public Login_Page(Frame frame1, ContViewModel contVM)
        {
            InitializeComponent();
            user_box.Text = "";
            this.Frame = frame1;
            this.ContVM = contVM;
        }

        private void user_box_GotFocus(object sender, RoutedEventArgs e)
        {
            user_box.Text = "";
            user_box.FontStyle = FontStyles.Normal;
            user_box.FontWeight = FontWeights.Normal;
        }

        private void parola_box_GotFocus(object sender, RoutedEventArgs e)
        {
            parola_box.Password = "";
            parola_box.FontStyle = FontStyles.Normal;
            parola_box.FontWeight = FontWeights.Normal;
        }

        private void ForgotBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                toCheck = ContVM.searchRepo(user_box.Text)[0];

                if (ContVM.checkPass(toCheck, parola_box.Password) == true)
                {

                    PreparatViewModel PreparatVM = new PreparatViewModel();
                    this.Frame.Navigate(new HomePage(this.Frame, PreparatVM, toCheck));
                }
                else
                {
                    MessageBox.Show("Parola gresita.");
                    parola_box.Password = "";
                    parola_box.FontStyle = FontStyles.Normal;
                    parola_box.FontWeight = FontWeights.Normal;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Utilizatorul nu exista in baza de date.");
                user_box.Text = "";
                user_box.FontStyle = FontStyles.Normal;
                user_box.FontWeight = FontWeights.Normal;
            }

        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        private void user_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

