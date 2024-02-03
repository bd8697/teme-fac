using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Interaction logic for AddMeniuPage.xaml
    /// </summary>
    public partial class AddMeniuPage : Page
    {
        Meniu_preparatViewModel Meniu_preparatVM;
        Frame Frame;
        int pretTotal = 0;
        int cantTotal = 0;
        string den_str = "";
        string pret_str = "";
        string cant_str = "";
        string cant_tot_str = "";
        int x_reducere = System.Int32.Parse(ConfigurationManager.AppSettings["x_reducere"]);
        public AddMeniuPage()
        {
            InitializeComponent();
        }

        public AddMeniuPage(Frame frame1, Meniu_preparatViewModel meniu_preparatVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.Meniu_preparatVM = meniu_preparatVM;
            MessageBox.Show("Se va aplcia o reducere de " + x_reducere + " % preparatelor adaugate in meniu.");
        }

        private void denumire_box_GotFocus(object sender, RoutedEventArgs e)
        {
            denumire_box.FontStyle = FontStyles.Normal;
            denumire_box.FontWeight = FontWeights.Normal;
        }

        private void pret_box_GotFocus(object sender, RoutedEventArgs e)
        {
            pret_box.FontStyle = FontStyles.Normal;
            pret_box.FontWeight = FontWeights.Normal;
        }

        private void cant_box_GotFocus(object sender, RoutedEventArgs e)
        {
            cant_box.FontStyle = FontStyles.Normal;
            cant_box.FontWeight = FontWeights.Normal;
        }

        private void cant_tot_box_GotFocus(object sender, RoutedEventArgs e)
        {
            cant_tot_box.FontStyle = FontStyles.Normal;
            cant_tot_box.FontWeight = FontWeights.Normal;
        }

        private void alergen_box_GotFocus(object sender, RoutedEventArgs e)
        {
            show_alergeni();
        }

        private void alergeni_box_GotFocus(object sender, RoutedEventArgs e)
        {
            cant_tot_box.FontStyle = FontStyles.Normal;
            cant_tot_box.FontWeight = FontWeights.Normal;
        }

        private void prep_box_GotFocus(object sender, RoutedEventArgs e)
        {
            show_prep();
        }

    
        private void cat_box_GotFocus(object sender, RoutedEventArgs e)
        {
            show_categories();
        }

      
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Meniu_preparat meniu_preparat = new Meniu_preparat();
            meniu_preparat.Denumire = denumire_box.Text;
            meniu_preparat.Pret = pret_box.Text;
            meniu_preparat.Cantitate = cant_box.Text;
            meniu_preparat.Cantitate_Totala = cant_tot_box.Text;
            meniu_preparat.Categorie = cat_select.Text;
            meniu_preparat.Alergen = alergen_box.Text;

            Meniu_preparatVM.AddRecordToRepo(meniu_preparat);
            MessageBox.Show("Meniu adaugat.");
        }
        private void show_categories()
        {
            // MessageBox.Show("Please navigate using the arrow keys. It's a feature, not a bug. :)");
            SqlConnection con = new SqlConnection(Properties.Settings.Default.connString);
            try
            {
                con.Open();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                SqlDataAdapter category_data = new SqlDataAdapter("SELECT * FROM Categorii", con);
                System.Data.DataSet ds = new System.Data.DataSet();
                category_data.Fill(ds, "t");

                //  System.Console.WriteLine(category_data.ToString());
                cat_select.ItemsSource = ds.Tables["t"].DefaultView;
                //   System.Windows.Input.Keyboard.ClearFocus();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public string Pret { get; set; }
            public string Cantitate { get; set; }
            public string Cantitate_Totala { get; set; }
            public string Categorie { get; set; }
            public string Alergeni { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void show_prep()
        {
            string sqlQuery = "SELECT * FROM Preparate";
            using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connString))
            {
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read()) // simuleaza un Preparat, pe care-l retine in ComboBox
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = sqlReader["Denumire"].ToString();
                    item.Pret = sqlReader["Pret"].ToString();
                    item.Cantitate = sqlReader["Cantitate"].ToString();
                    item.Cantitate_Totala = sqlReader["Cantitate_Totala"].ToString();
                    prep_select.Items.Add(item);
                }

                sqlReader.Close();
            }
        }

        private void show_alergeni()
        {
            alergen_box.Items.Clear();
            string sqlQuery = "SELECT * FROM Alergeni";
            using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.connString))
            {
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    alergen_box.Items.Add(sqlReader["Denumire"]);
                }
                sqlReader.Close();
            }
        }

      
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        private void denumire_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void prep_select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (den_str == "")
            {
                den_str += (prep_select.SelectedItem as ComboboxItem).Text;
            }
            else
            {
                den_str += ", " + (prep_select.SelectedItem as ComboboxItem).Text;
            }
            if (pret_str == "")
            {
                pret_str += (System.Int32.Parse((prep_select.SelectedItem as ComboboxItem).Pret) - (int)((float)x_reducere / 100 * System.Int32.Parse((prep_select.SelectedItem as ComboboxItem).Pret))).ToString();
            }
            else
            {
                pret_str += " + " + (System.Int32.Parse((prep_select.SelectedItem as ComboboxItem).Pret) - (int)((float)x_reducere / 100 * System.Int32.Parse((prep_select.SelectedItem as ComboboxItem).Pret))).ToString();
            }

            if (cant_str == "")
            {
                cant_str += (prep_select.SelectedItem as ComboboxItem).Cantitate;
            }
            else
            {
                cant_str += " + " + (prep_select.SelectedItem as ComboboxItem).Cantitate;
            }

            if (cant_tot_str == "")
            {
                cant_tot_str += (prep_select.SelectedItem as ComboboxItem).Cantitate_Totala;
            }
            else
            {
                cant_tot_str += " + " + (prep_select.SelectedItem as ComboboxItem).Cantitate_Totala;
            }

            denumire_box.Text = den_str;
            pretTotal += System.Int32.Parse((prep_select.SelectedItem as ComboboxItem).Pret);
            pret_box.Text = ((int)(pretTotal - (float)x_reducere / 100 * pretTotal)).ToString() + " ( " + pret_str + ")";
            cantTotal += System.Int32.Parse((prep_select.SelectedItem as ComboboxItem).Cantitate);
            cant_box.Text = cantTotal.ToString() + " ( " + cant_str + ")";
            cant_tot_box.Text = "( " + cant_tot_str + ")";
        }

        private void alergeni_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cat_select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void alergeni_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (alergen_box.SelectedItem != null)
            {
                if (alergeni_box.Text.Length != 0)
                {
                    alergeni_box.AppendText(", ");
                }
                alergeni_box.AppendText(alergen_box.SelectedItem.ToString());
            }
        }
    }
}
