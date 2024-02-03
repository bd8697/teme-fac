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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private Frame Frame;
        ContViewModel ContVM;
        PreparatViewModel PreparatVM;
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(Frame frame1, ContViewModel contVM, PreparatViewModel preparatVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.ContVM = contVM;
            this.PreparatVM = preparatVM;
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new Create_Account_Page(this.Frame, this.ContVM));
        }

        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
           this.Frame.Navigate(new Login_Page(this.Frame, this.ContVM));
        }

        private void No_Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new HomePage(this.Frame, this.PreparatVM));
        }
    }
}