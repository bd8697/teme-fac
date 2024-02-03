using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_MVP
{
    public class CategorieViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Categorie> Categorii { get; set; }
        private CategorieRepository CategorieRepository { get; set; }

        public CategorieViewModel()
        {
            CategorieRepository = new CategorieRepository();
            Categorii = new ObservableCollection<Categorie>(CategorieRepository.categorieRepository);
            Categorii.CollectionChanged += Categorii_CollectionChanged;       // Event Handler for change in collection
        }

        public event PropertyChangedEventHandler PropertyChanged;


        // Saves time and resources by searching in Collection in memory rather than in database.

        public List<Categorie> searchRepo(string searchQuery)
        {
            if (searchQuery == "*" || searchQuery == " ")
                throw new Exception("Warning: Symbols such as '*' or whitespace are not acceptable");

            List<Categorie> CategoriiList =
                (from tempCategorie in Categorii
                 where tempCategorie.Title.Contains(searchQuery)
                 select tempCategorie).ToList();
            return CategoriiList;
        }

        public void AddRecordToRepo(Categorie Categorie)
        {
            if (Categorie == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Console.WriteLine(Categorie);
            Categorii.Add(Categorie);
        }

        public void DeleteRecordFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < Categorii.Count)
            {
                if (Categorii[index].Id == id)
                {
                    Categorii.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        private void Categorii_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                CategorieRepository.addNewRecord(Categorii[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Categorie> tempListOfRemovedItems = e.OldItems.OfType<Categorie>().ToList();
                CategorieRepository.DelRecord(tempListOfRemovedItems[0].Id);
            }
        }
    }
}