using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        PreparatViewModel PreparatVM;
        Frame Frame;
        public AddPage()
        {
            InitializeComponent();
        }

        public AddPage(Frame frame1, PreparatViewModel preparatVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.PreparatVM = preparatVM;
        }

        private void denumire_box_GotFocus(object sender, RoutedEventArgs e)
        {
            denumire_box.Text = "";
            denumire_box.FontStyle = FontStyles.Normal;
            denumire_box.FontWeight = FontWeights.Normal;
        }

        private void pret_box_GotFocus(object sender, RoutedEventArgs e)
        {
            pret_box.Text = "";
            pret_box.FontStyle = FontStyles.Normal;
            pret_box.FontWeight = FontWeights.Normal;
        }

        private void cant_box_GotFocus(object sender, RoutedEventArgs e)
        {
            cant_box.Text = "";
            cant_box.FontStyle = FontStyles.Normal;
            cant_box.FontWeight = FontWeights.Normal;
        }

        private void cant_tot_box_GotFocus(object sender, RoutedEventArgs e)
        {
            cant_tot_box.Text = "";
            cant_tot_box.FontStyle = FontStyles.Normal;
            cant_tot_box.FontWeight = FontWeights.Normal;
        }

        private void alergeni_box_GotFocus(object sender, RoutedEventArgs e)
        {
            cant_tot_box.FontStyle = FontStyles.Normal;
            cant_tot_box.FontWeight = FontWeights.Normal;
        }

        private void alergen_box_GotFocus(object sender, RoutedEventArgs e)
        {
            show_alergeni();
        }

     
        private void cat_box_GotFocus(object sender, RoutedEventArgs e)
        {
            show_categories();
        }

       
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Preparat preparat = new Preparat();
                preparat.Denumire = denumire_box.Text;
                preparat.Pret = int.Parse(pret_box.Text);
                preparat.Cantitate = int.Parse(cant_box.Text);
                preparat.Cantitate_Totala = int.Parse(cant_tot_box.Text);
                preparat.Categorie = cat_select.Text;
                preparat.Alergen = alergeni_box.Text;

                PreparatVM.AddRecordToRepo(preparat);
                MessageBox.Show("Preparat adaugat.");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Introduceti date valide.");
                return;
            }
        }
        private void show_categories()
        {
            // MessageBox.Show("Please navigate using the arrow keys. It's a feature, not a bug. :)");
            System.Data.SqlClient.SqlConnection con = new SqlConnection(Properties.Settings.Default.connString);
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

        private void cat_select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void alergeni_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void alergen_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
