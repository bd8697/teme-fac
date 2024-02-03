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
    /// Interaction logic for SeePreparateEpuizare.xaml
    /// </summary>
    public partial class SeePreparateEpuizare : Page
    {
        public SeePreparateEpuizare()
        {
            InitializeComponent();
        }
        PreparatViewModel PreparatVM;
        Frame Frame;
        List<Preparat> orderList = new List<Preparat>();

        public SeePreparateEpuizare(Frame frame, PreparatViewModel preparatVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.PreparatVM = new PreparatViewModel();
        }

        private void showEpuizare()
        {
            gridTable.DataContext = PreparatVM.epuizareFromRepo();
            gridTable.Visibility = Visibility.Hidden;

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

        private void PreparateEpuizareBtn_Click(object sender, RoutedEventArgs e)
        {
            showEpuizare();
            gridTable.Visibility = Visibility.Visible;
            for (int i = 0; i < gridTable.Columns.Count; i++)
                if (i != 1 && i != 4)
                {
                    gridTable.Columns[i].Visibility = Visibility.Hidden;
                }

        }
    }
}

