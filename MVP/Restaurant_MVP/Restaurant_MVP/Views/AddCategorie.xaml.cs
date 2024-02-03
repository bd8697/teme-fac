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
    /// Interaction logic for AddCategorie.xaml
    /// </summary>
    public partial class AddCategorie : Page
    {
        CategorieViewModel CategorieVM;
        Frame Frame;
        public AddCategorie(Frame frame1, CategorieViewModel categorieVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.CategorieVM = categorieVM;
        }

        private void denumire_box_GotFocus(object sender, RoutedEventArgs e)
        {
            denumire_box.Text = "";
            denumire_box.FontStyle = FontStyles.Normal;
            denumire_box.FontWeight = FontWeights.Normal;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Categorie categorie = new Categorie();
            categorie.Title = denumire_box.Text;

            CategorieVM.AddRecordToRepo(categorie);
            MessageBox.Show("Categorie adaugata.");
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        private void denumire_box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}