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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private Frame Frame;
        PreparatViewModel PreparatVM;
        Cont cont;

        public HomePage()
        {
            InitializeComponent();
        }

        public HomePage(Frame frame1, PreparatViewModel preparatVM, Cont c)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.PreparatVM = preparatVM;
            this.cont = c;
            if (cont.Tip_cont == false) // daca avem cont de client
            {
                addBtn.Visibility = Visibility.Hidden;
                addPreparatBtn.Visibility = Visibility.Hidden;
                addCategorieBtn.Visibility = Visibility.Hidden;
                editMeniuriBtn.Visibility = Visibility.Hidden;
                editPreparateBtn.Visibility = Visibility.Hidden;
                seePreparateBtn.Visibility = Visibility.Hidden;
                seeOrdersBtn.Margin = new Thickness(243, 101, 242, 0);
                seeOrdersBtn.Width = 170;
                seeOrdersBtn.Height = 30;
            }
            else
            {
                SearchBtn.Visibility = Visibility.Hidden;
                SearchMeniuriBtn.Visibility = Visibility.Hidden;
                viewBtn.Visibility = Visibility.Hidden;
                orderBtn.Visibility = Visibility.Hidden;
            }
            CreateBtn.Visibility = Visibility.Hidden;
        }

        public HomePage(Frame frame1, PreparatViewModel preparatVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.PreparatVM = preparatVM;
            seeOrdersBtn.Visibility = Visibility.Hidden;
            addBtn.Visibility = Visibility.Hidden;
            orderBtn.Visibility = Visibility.Hidden;
            seeOrdersBtn.Visibility = Visibility.Hidden;
            addPreparatBtn.Visibility = Visibility.Hidden;
            editPreparateBtn.Visibility = Visibility.Hidden;
            seePreparateBtn.Visibility = Visibility.Hidden;
            editMeniuriBtn.Visibility = Visibility.Hidden;
            addCategorieBtn.Visibility = Visibility.Hidden;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new Search(this.Frame, this.PreparatVM, cont));
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new AddMeniuPage(this.Frame, new Meniu_preparatViewModel()));
        }
        private void addPreparatBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new AddPage(this.Frame, this.PreparatVM));
        }

        private void addCategorieBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new AddCategorie(this.Frame, new CategorieViewModel()));
        }

        private void viewBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Height = 550;
            this.Frame.Navigate(new ViewPage(this.Frame, this.PreparatVM, new Meniu_preparatViewModel()));

        }

        private void orderBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Height = 1000;
            Application.Current.MainWindow.Top = 10;
            this.Frame.Navigate(new Order(this.Frame, this.PreparatVM, new Meniu_preparatViewModel(), cont));

        }

        private void seeOrersBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new SeeOrdersPage(this.Frame, this.PreparatVM, cont));
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new MainPage(this.Frame, new ContViewModel(), new PreparatViewModel()));
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new Create_Account_Page(this.Frame, new ContViewModel()));
        }

        private void editMeniuriBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new SearchMeniuri(this.Frame, new Meniu_preparatViewModel(), cont));
        }

        private void editPreparateBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new Search(this.Frame, this.PreparatVM, cont));
        }

        private void seePreparateBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new SeePreparateEpuizare(this.Frame, this.PreparatVM));
        }

        private void viewMeniuriBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new SearchMeniuri(this.Frame, new Meniu_preparatViewModel(), cont));
        }
    }
}
