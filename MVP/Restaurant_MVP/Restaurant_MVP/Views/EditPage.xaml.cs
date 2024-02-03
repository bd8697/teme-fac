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
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private Frame Frame;
        private PreparatViewModel PreparatVM;
        private Preparat Preparat;

        public EditPage()
        {
            InitializeComponent();
        }
        private void cat_box_GotFocus(object sender, RoutedEventArgs e)
        {
            show_categories();
        }

        private void alergeni_box_GotFocus(object sender, RoutedEventArgs e)
        {
            // show_categories();
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
                System.Data.SqlClient.SqlDataAdapter category_data = new SqlDataAdapter("SELECT * FROM Categorii", con);
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

        public EditPage(Frame frame, PreparatViewModel preparatVM, Preparat preparat)
        {
            InitializeComponent();
            this.Frame = frame;
            this.PreparatVM = preparatVM;
            this.Preparat = preparat;
            // Loading Record into TextBoxes
            this.denumire_box.Text = preparat.Denumire;
            this.pret_box.Text = preparat.Pret.ToString();
            this.cant_box.Text = preparat.Cantitate.ToString();
            this.cant_tot_box.Text = preparat.Cantitate_Totala.ToString();
            this.cat_select.Text = preparat.Categorie;
            this.alergeni_box.Text = preparat.Alergen;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Preparat tempPreparat = new Preparat();
            tempPreparat.Id = Preparat.Id;
            tempPreparat.Denumire = denumire_box.Text;
            tempPreparat.Pret = int.Parse(pret_box.Text.ToString());
            tempPreparat.Cantitate = int.Parse(cant_box.Text.ToString());
            tempPreparat.Cantitate_Totala = int.Parse(cant_tot_box.Text.ToString());
            tempPreparat.Categorie = cat_select.Text;
            tempPreparat.Alergen = alergeni_box.Text;
            PreparatVM.UpdateRecordInRepo(tempPreparat);
            MessageBox.Show("S-a updatat preparatul", "Update");
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        private void LostFocus_TextBox(object sender, RoutedEventArgs e)
        {
            if (!(this.Preparat.Denumire.Equals(this.denumire_box.Text)
                && this.Preparat.Pret.Equals(int.Parse(this.pret_box.Text))
                && this.Preparat.Cantitate.Equals(int.Parse(this.cant_box.Text))
                && this.Preparat.Cantitate_Totala.Equals(int.Parse(this.cant_tot_box.Text))
                && this.Preparat.Categorie.Equals(this.cat_select.Text)
                && this.Preparat.Alergen.Equals(this.alergeni_box.Text)))
            {
                UpdateBtn.IsEnabled = true;
            }
        }

        private void alergeni_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
