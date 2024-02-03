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
    /// Interaction logic for EditMeniuriPage.xaml
    /// </summary>
    public partial class EditMeniuriPage : Page
    {
        private Frame Frame;
        private Meniu_preparatViewModel Meniu_preparatVM;
        private Meniu_preparat Meniu_preparat;
        public EditMeniuriPage()
        {
            InitializeComponent();
        }

        private void cat_box_GotFocus(object sender, RoutedEventArgs e)
        {
            show_categories();
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

        private void cant_tot_box_GotFocus(object sender, RoutedEventArgs e)
        {
            cant_tot_box.FontStyle = FontStyles.Normal;
            cant_tot_box.FontWeight = FontWeights.Normal;
        }

        private void alergeni_box_GotFocus(object sender, RoutedEventArgs e)
        {
            cant_tot_box.FontStyle = FontStyles.Normal;
            cant_tot_box.FontWeight = FontWeights.Normal;
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

        public EditMeniuriPage(Frame frame, Meniu_preparatViewModel meniu_preparatVM, Meniu_preparat meniu_preparat)
        {
            InitializeComponent();
            this.Frame = frame;
            this.Meniu_preparatVM = meniu_preparatVM;
            this.Meniu_preparat = meniu_preparat;
            this.denumire_box.Text = meniu_preparat.Denumire;
            this.pret_box.Text = meniu_preparat.Pret.ToString();
            this.cant_box.Text = meniu_preparat.Cantitate.ToString();
            this.cant_tot_box.Text = meniu_preparat.Cantitate_Totala.ToString();
            this.cat_select.Text = meniu_preparat.Categorie;
            this.alergeni_box.Text = meniu_preparat.Alergen;
        }

        /*
         * Function: Event Handler for Update Button
         * Updates the record in Collection
         */
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Meniu_preparat tempMeniu = new Meniu_preparat();
            tempMeniu.Id = Meniu_preparat.Id;
            tempMeniu.Denumire = denumire_box.Text;
            tempMeniu.Pret = pret_box.Text.ToString();
            tempMeniu.Cantitate = cant_box.Text.ToString();
            tempMeniu.Cantitate_Totala = cant_tot_box.Text.ToString();
            tempMeniu.Categorie = cat_select.Text;
            tempMeniu.Alergen = alergeni_box.Text;
            Meniu_preparatVM.UpdateRecordInRepo(tempMeniu);
            MessageBox.Show("S-a updatat meniul", "Update");
        }


        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }
        private void LostFocus_TextBox(object sender, RoutedEventArgs e)
        {
            if (!(this.Meniu_preparat.Denumire.Equals(this.denumire_box.Text)
                && this.Meniu_preparat.Pret.Equals(this.pret_box.Text)
                && this.Meniu_preparat.Cantitate.Equals(this.cant_box.Text)
                && this.Meniu_preparat.Cantitate_Totala.Equals(this.cant_tot_box.Text)
                && this.Meniu_preparat.Categorie.Equals(this.cat_select.Text)
                && this.Meniu_preparat.Alergen.Equals(this.alergeni_box.Text)))
            {
                UpdateBtn.IsEnabled = true;
            }
        }

        private void alergeni_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cat_select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cant_tot_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cant_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void pret_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void denumire_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
