using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for SeeOrdersPage.xaml
    /// </summary>
    public partial class SeeOrdersPage : Page
    {
        public SeeOrdersPage()
        {
            InitializeComponent();
        }

        ComandaViewModel ComandaVM;
        Frame Frame;
        List<Comanda> orderList = new List<Comanda>();
        Cont cont;

        public SeeOrdersPage(Frame frame, PreparatViewModel preparatVM, Cont c)
        {
            InitializeComponent();
            this.Frame = frame;
            this.ComandaVM = new ComandaViewModel();
            this.cont = c;
        }

        private void showComenzi()
        {
            gridTable.DataContext = ComandaVM.searchRepo(cont.Nume + " " + cont.Prenume);
            gridTable.Visibility = Visibility.Hidden;

        }

        private void showActiveComenzi()
        {
            gridTable.DataContext = ComandaVM.searchActiveRepo(cont.Nume + " " + cont.Prenume);
            gridTable.Visibility = Visibility.Hidden;

        }

        private void showAllComenzi()
        {
            gridTable.DataContext = ComandaVM.allFromRepo();
            gridTable.Visibility = Visibility.Hidden;
            gridTable.Items.SortDescriptions.Add(new SortDescription("Data", ListSortDirection.Descending)); // daca data e stocata sub  mai multe formate, poate sorta gresit
            gridTable.Items.SortDescriptions.Add(new SortDescription("Ora", ListSortDirection.Descending));
        }

        private void showAllActiveComenzi()
        {
            gridTable.DataContext = ComandaVM.allActiveFromRepo();
            gridTable.Visibility = Visibility.Hidden;
            gridTable.Items.SortDescriptions.Add(new SortDescription("Data", ListSortDirection.Descending)); // daca data e stocata sub  mai multe formate, poate sorta gresit
            gridTable.Items.SortDescriptions.Add(new SortDescription("Ora", ListSortDirection.Descending));
        }

        private void gridTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (gridTable.SelectedCells.Count == 0)
            {
                return;
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }


        private void AllOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            if (cont.Tip_cont == true) // daca avem cont de angajat
            {
                showAllComenzi();
            }
            else
            {
                showComenzi();
            }
            gridTable.Visibility = Visibility.Visible;
            gridTable.Columns[0].Visibility = Visibility.Hidden;
            gridTable.Columns[4].Visibility = Visibility.Hidden;
        }

        private void AllActiveOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            if (cont.Tip_cont == true) // daca avem cont de angajat
            {
                showAllActiveComenzi();
            }
            else
            {
                showActiveComenzi();
            }
            gridTable.Visibility = Visibility.Visible;
            gridTable.Columns[0].Visibility = Visibility.Hidden;
            gridTable.Columns[4].Visibility = Visibility.Hidden;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (gridTable.SelectedItem != null)
            {
                Comanda tempCom = (Comanda)gridTable.SelectedItem;
                tempCom.Stare = "anulata";
                ComandaVM.UpdateRecordInRepo(tempCom);
                MessageBox.Show("Comanda Anulata.");
            }
        }
    }
}
