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
    /// Interaction logic for Create_Account_Page.xaml
    /// </summary>
    public partial class Create_Account_Page : Page
    {
        ContViewModel ContVM;
        Frame Frame;
        public Create_Account_Page()
        {
            InitializeComponent();
        }

        public Create_Account_Page(Frame frame1, ContViewModel contVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.ContVM = contVM;
        }

        private void nume_box_GotFocus(object sender, RoutedEventArgs e)
        {
            nume_box.Text = "";
            nume_box.FontStyle = FontStyles.Normal;
            nume_box.FontWeight = FontWeights.Normal;
        }

        private void prenume_box_GotFocus(object sender, RoutedEventArgs e)
        {
            prenume_box.Text = "";
            prenume_box.FontStyle = FontStyles.Normal;
            prenume_box.FontWeight = FontWeights.Normal;
        }

        private void mail_box_GotFocus(object sender, RoutedEventArgs e)
        {
            mail_box.Text = "";
            mail_box.FontStyle = FontStyles.Normal;
            mail_box.FontWeight = FontWeights.Normal;
        }

        private void tel_box_GotFocus(object sender, RoutedEventArgs e)
        {
            tel_box.Text = "";
            tel_box.FontStyle = FontStyles.Normal;
            tel_box.FontWeight = FontWeights.Normal;
        }

        private void adresa_box_GotFocus(object sender, RoutedEventArgs e)
        {
            adresa_box.Text = "";
            adresa_box.FontStyle = FontStyles.Normal;
            adresa_box.FontWeight = FontWeights.Normal;
        }

        private void parola_box_GotFocus(object sender, RoutedEventArgs e)
        {
            parola_box.Password = "";
            parola_box.FontStyle = FontStyles.Normal;
            parola_box.FontWeight = FontWeights.Normal;
        }

        private void parola2_box_GotFocus(object sender, RoutedEventArgs e)
        {
            parola2_box.Password = "";
            parola2_box.FontStyle = FontStyles.Normal;
            parola2_box.FontWeight = FontWeights.Normal;
        }

        private void parola2_box_LostFocus(object sender, RoutedEventArgs e)
        {
            if (parola2_box.Password != parola_box.Password)
            {
                MessageBox.Show("Passwords do not match, please try again.");
                parola2_box.Password = "";
                parola2_box.FontStyle = FontStyles.Normal;
                parola2_box.FontWeight = FontWeights.Normal;
            }
        }


        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            Cont cont = new Cont();
            cont.Nume = nume_box.Text;
            cont.Prenume = prenume_box.Text;
            cont.E_mail = mail_box.Text;
            cont.Telefon = tel_box.Text;
            cont.Adresa = adresa_box.Text;
            cont.Parola = parola2_box.Password;
            cont.Tip_cont = (bool)AngajatBtn.IsChecked;

            ContVM.AddRecordToRepo(cont);
            MessageBox.Show("Cont creat.");
            this.Frame.NavigationService.GoBack();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        private void parola2_box_PasswordChanged(object sender, RoutedEventArgs args)
        {

        }

        private void AngajatBtn_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Se va crea un cont de angajat.");
        }
    }
}