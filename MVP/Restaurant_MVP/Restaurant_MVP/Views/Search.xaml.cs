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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        PreparatViewModel PreparatVM;
        Frame Frame;
        Cont c;

        public Search()
        {
            InitializeComponent();
        }

        public Search(Frame frame, PreparatViewModel preparatVM, Cont cont)
        {
            InitializeComponent();
            this.Frame = frame;
            this.PreparatVM = preparatVM;
            this.c = cont;

            this.Loaded += SearchPage_Loaded;
            EditBtn.IsEnabled = false;
            DelBtn.IsEnabled = false;

            if (cont == null || cont.Tip_cont == false) 
            {
                EditBtn.Visibility = Visibility.Hidden;
                DelBtn.Visibility = Visibility.Hidden;
            }
        }

        private void SearchPage_Loaded(object sender, RoutedEventArgs e)
        {
            searchBox.Focusable = true;
            Keyboard.Focus(searchBox);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text == "")
            {
                return;
            }
            gridTable.DataContext = PreparatVM.searchRepo(searchBox.Text);
            gridTable.Columns[0].Visibility = Visibility.Hidden;
            if (c == null || c.Tip_cont == false)
            {
                gridTable.Columns[4].Visibility = Visibility.Hidden;
            }
            gridTable.Items.SortDescriptions.Add(new SortDescription("Categorie", ListSortDirection.Descending));

            if (gridTable.SelectedCells.Count == 0)
            {
                EditBtn.IsEnabled = false;
                DelBtn.IsEnabled = false;
            }
            else
            {
                EditBtn.IsEnabled = true;
                DelBtn.IsEnabled = true;
            }
        }

        private void searchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            searchBox.Text = "";
            searchBox.FontStretch = FontStretches.Normal;
            searchBox.FontStyle = FontStyles.Normal;
            searchBox.Foreground = Brushes.Black;
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Preparat preparat = (Preparat)gridTable.SelectedItem;
            PreparatVM.DeleteRecordFromRepo(preparat.Id);
            gridTable.DataContext = PreparatVM.searchRepo(searchBox.Text);     // Updating the DataTable
            gridTable.Columns[0].Visibility = Visibility.Hidden;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Preparat tempPreparat = (Preparat)gridTable.SelectedItem;
            Frame.Navigate(new EditPage(Frame, PreparatVM, tempPreparat));
        }

        private void gridTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridTable.SelectedCells.Count == 0)
            {
                EditBtn.IsEnabled = false;
                DelBtn.IsEnabled = false;
                return;
            }
            EditBtn.IsEnabled = true;
            DelBtn.IsEnabled = true;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        private void SearchWithout_Click(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text == "")
            {
                return;
            }
            gridTable.DataContext = PreparatVM.searchNotInRepo(searchBox.Text);
            gridTable.Columns[0].Visibility = Visibility.Hidden;
            if (c == null || c.Tip_cont == false)
            {
                gridTable.Columns[4].Visibility = Visibility.Hidden;
            }
            gridTable.Items.SortDescriptions.Add(new SortDescription("Categorie", ListSortDirection.Descending));

            if (gridTable.SelectedCells.Count == 0)         
            {
                EditBtn.IsEnabled = false;
                DelBtn.IsEnabled = false;
            }
            else
            {
                EditBtn.IsEnabled = true;
                DelBtn.IsEnabled = true;
            }
        }
    }
}
