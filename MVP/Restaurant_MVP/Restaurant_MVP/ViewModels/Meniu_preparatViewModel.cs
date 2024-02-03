using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_MVP
{
    public class Meniu_preparatViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Meniu_preparat> Meniu_preparate { get; set; }
        private Meniu_preparatRepository Meniu_preparatRepository { get; set; }

        public Meniu_preparatViewModel()
        {
            Meniu_preparatRepository = new Meniu_preparatRepository();
            Meniu_preparate = new ObservableCollection<Meniu_preparat>(Meniu_preparatRepository.preparatRepository);
            Meniu_preparate.CollectionChanged += Meniu_preparate_CollectionChanged;       // Event Handler for change in collection
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Meniu_preparat> searchRepo(string searchQuery)
        {
            if (searchQuery == "*" || searchQuery == " ")
                throw new Exception("Warning: Symbols such as '*' or whitespace are not acceptable");

            List<Meniu_preparat> Meniu_preparateList =                // Temporary list for storing results returned from search query
                (from tempMeniu_preparat in Meniu_preparate
                 where tempMeniu_preparat.Denumire.Contains(searchQuery)
                 select tempMeniu_preparat).ToList();
            return Meniu_preparateList;
        }

        public List<Meniu_preparat> searchNotInRepo(string searchQuery)
        {
            if (searchQuery == "*" || searchQuery == " ")
                throw new Exception("Warning: Symbols such as '*' or whitespace are not acceptable");

            List<Meniu_preparat> Meniu_preparateList =
                (from tempMeniu_preparat in Meniu_preparate
                 where !(tempMeniu_preparat.Alergen.Contains(searchQuery))
                 select tempMeniu_preparat).ToList();
            return Meniu_preparateList;
        }

        public List<Meniu_preparat> allFromRepo()
        {

            List<Meniu_preparat> Meniu_preparateList =
                (from tempMeniu_preparat in Meniu_preparate
                 select tempMeniu_preparat).ToList();
            return Meniu_preparateList;
        }

        public void AddRecordToRepo(Meniu_preparat Meniu_preparat)
        {
            if (Meniu_preparat == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Console.WriteLine(Meniu_preparat);
            Meniu_preparate.Add(Meniu_preparat);
        }

        public void DeleteRecordFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < Meniu_preparate.Count)
            {
                if (Meniu_preparate[index].Id == id)
                {
                    Meniu_preparate.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        public void UpdateRecordInRepo(Meniu_preparat Meniu_preparat)
        {
            if (Meniu_preparat.Id < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while (index < Meniu_preparate.Count)
            {
                if (Meniu_preparate[index].Id == Meniu_preparat.Id)
                {
                    Meniu_preparate[index] = Meniu_preparat;
                    break;
                }
                index++;
            }
        }

        private void Meniu_preparate_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                Meniu_preparatRepository.addNewRecord(Meniu_preparate[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Meniu_preparat> tempListOfRemovedItems = e.OldItems.OfType<Meniu_preparat>().ToList();
                Meniu_preparatRepository.DelRecord(tempListOfRemovedItems[0].Id);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Meniu_preparat> tempListOfMeniu_preparate = e.NewItems.OfType<Meniu_preparat>().ToList();
                Meniu_preparatRepository.UpdateRecord(tempListOfMeniu_preparate[0]);
            }
        }
    }
}