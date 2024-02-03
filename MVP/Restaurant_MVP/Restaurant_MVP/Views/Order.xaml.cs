using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public Order()
        {
            InitializeComponent();
        }

        PreparatViewModel PreparatVM;
        Meniu_preparatViewModel Meniu_preparatVM;
        ComandaViewModel ComandaVM;
        Frame Frame;
        List<Preparat> orderList = new List<Preparat>();
        List<Meniu_preparat> orderList2 = new List<Meniu_preparat>();
        String FinalOrder = "";
        int FinalPret = 0;
        Cont cont;
        readonly int y_val_min_reducere = System.Int32.Parse(ConfigurationManager.AppSettings["y_val_min_reducere"]);
        readonly int w_reducere = System.Int32.Parse(ConfigurationManager.AppSettings["w_reducere"]);
        readonly int x_reducere = System.Int32.Parse(ConfigurationManager.AppSettings["x_reducere"]);
        readonly int z_comenzi = System.Int32.Parse(ConfigurationManager.AppSettings["z_comenzi"]);
        readonly int t_interval = System.Int32.Parse(ConfigurationManager.AppSettings["t_interval"]);
        readonly int a_min = System.Int32.Parse(ConfigurationManager.AppSettings["a_min"]);
        readonly int b_val = System.Int32.Parse(ConfigurationManager.AppSettings["b_val"]);


        public Order(Frame frame, PreparatViewModel preparatVM, Meniu_preparatViewModel meniu_preparatVM, Cont c)
        {
            InitializeComponent();
            this.Frame = frame;
            this.PreparatVM = preparatVM;
            this.Meniu_preparatVM = meniu_preparatVM;
            this.ComandaVM = new ComandaViewModel();
            this.cont = c;

            showMenu();
        }

        private void showMenu()
        {
            gridTable.DataContext = PreparatVM.allFromRepo();
            gridTable.Visibility = Visibility.Hidden;
            gridTableMenu.DataContext = Meniu_preparatVM.allFromRepo();
            gridTableMenu.Visibility = Visibility.Hidden;

        }

        private void gridTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (gridTable.SelectedCells.Count == 0)
            {
                return;
            }
        }

        private void gridTableMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (gridTableMenu.SelectedCells.Count == 0)
            {
                return;
            }
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            gridTable.Visibility = Visibility.Visible;
            gridTable.Columns[0].Visibility = Visibility.Hidden;
            gridTable.Columns[4].Visibility = Visibility.Hidden;
            gridTableMenu.Visibility = Visibility.Visible;
            gridTableMenu.Columns[0].Visibility = Visibility.Hidden;
            gridTableMenu.Columns[4].Visibility = Visibility.Hidden;
        }

        private void orderTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void orderBtn_Click(object sender, RoutedEventArgs e)
        {
            var final_order = orderList.GroupBy(i => i);

            if (final_order.Count() > 0)
            {
                foreach (var ord in final_order)
                {
                    FinalOrder += ord.Count().ToString() + " * " + ord.Key.Denumire.ToString() + " + ";
                    FinalPret += ord.Key.Pret * ord.Count();
                }
            }

            var final_order2 = orderList2.GroupBy(i => i);

            if (final_order2.Count() > 0)
            {
                foreach (var ord in final_order2)
                {
                    FinalOrder += ord.Count().ToString() + " * " + ord.Key.Denumire.ToString() + " + ";
                    string pret = ord.Key.Pret.Split()[0];
                    FinalPret += Int32.Parse(pret) * ord.Count();
                }
            }

            if (FinalPret > y_val_min_reducere)
            {
                FinalPret -= (int)((float)w_reducere / 100 * FinalPret);
            }
            if (FinalPret < a_min)
            {
                MessageBox.Show("Comanda costa " + FinalPret + " lei, deci se adauga cost de transport in valoare de " + b_val + " lei.");
                FinalPret += b_val;
            }
            if(FinalOrder.Length > 3)
            {
                FinalOrder = FinalOrder.Remove(FinalOrder.Length - 3); // sterge ultimu "+" din comanda
            }
            Console.WriteLine(FinalOrder);
            Console.WriteLine(FinalPret);

            Comanda comanda = new Comanda();
            comanda.Client = cont.Nume + " " + cont.Prenume;
            comanda.Continut = FinalOrder;
            comanda.Stare = "inregistrata";
            comanda.Pret = FinalPret;
            comanda.Data = DateTime.Now.ToString("dd.MM.yyy");
            comanda.Ora_Livrare = DateTime.Now.ToString("HH:mm:ss tt");

            ComandaVM.AddRecordToRepo(comanda);
            MessageBox.Show("Comanda plasata.");
            Application.Current.MainWindow.Height = 450;
            Application.Current.MainWindow.Top = 250;
            this.Frame.NavigationService.GoBack();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (gridTable.SelectedItem != null)
            {
                Preparat tempPreparat = (Preparat)gridTable.SelectedItem;
                if (tempPreparat.Cantitate_Totala - tempPreparat.Cantitate >= 0)
                {
                    orderList.Add(tempPreparat);
                    Console.WriteLine(orderList.Count());
                    orderTable.ItemsSource = null;
                    orderTable.ItemsSource = orderList;
                    orderTable.Columns[0].Visibility = Visibility.Hidden;
                    orderTable.Columns[4].Visibility = Visibility.Hidden;

                    tempPreparat.Cantitate_Totala -= tempPreparat.Cantitate;
                    PreparatVM.UpdateRecordInRepo(tempPreparat);
                }
                else
                {
                    MessageBox.Show("Preparatul nu mai e pe stoc.");
                }
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Height = 450;
            Application.Current.MainWindow.Top = 250;
            this.Frame.NavigationService.GoBack();
        }

        private void gridTableMeniu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            if (gridTable.SelectedItem != null)
            {
                Meniu_preparat tempMeniu = (Meniu_preparat)gridTableMenu.SelectedItem;
                orderList2.Add(tempMeniu);
                orderTableMenu.ItemsSource = null;
                orderTableMenu.ItemsSource = orderList2;
                orderTableMenu.Columns[0].Visibility = Visibility.Hidden;
                orderTableMenu.Columns[4].Visibility = Visibility.Hidden;
            }
        }

        private void orderTableMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

