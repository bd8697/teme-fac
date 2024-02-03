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
    /// Interaction logic for ViewPage.xaml
    /// </summary>
    public partial class ViewPage : Page
    {
        PreparatViewModel PreparatVM;
        Meniu_preparatViewModel Meniu_preparatVM;
        Frame Frame;

        public ViewPage()
        {
            InitializeComponent();
        }

        public ViewPage(Frame frame, PreparatViewModel preparatVM, Meniu_preparatViewModel Meniu_preparatVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.PreparatVM = preparatVM;
            this.Meniu_preparatVM = Meniu_preparatVM;
            showMenu();
        }

        private void showMenu()
        {
            gridTable.DataContext = PreparatVM.allFromRepo();
            gridTable.Visibility = Visibility.Hidden;
            gridTable_meniuri.DataContext = Meniu_preparatVM.allFromRepo();
            gridTable_meniuri.Visibility = Visibility.Hidden;
        }

        private void gridTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (gridTable.SelectedCells.Count == 0)
            {
                return;
            }
        }

        private void gridTable_meniuri_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (gridTable_meniuri.SelectedCells.Count == 0)
            {
                return;
            }
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            gridTable.Visibility = Visibility.Visible;
            gridTable.Columns[0].Visibility = Visibility.Hidden;
            gridTable.Columns[4].Visibility = Visibility.Hidden;
        }

        private void refreshMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            gridTable_meniuri.Visibility = Visibility.Visible;
            gridTable_meniuri.Columns[0].Visibility = Visibility.Hidden;
            gridTable_meniuri.Columns[4].Visibility = Visibility.Hidden;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Height = 450;
            this.Frame.NavigationService.GoBack();
        }
    }
}

