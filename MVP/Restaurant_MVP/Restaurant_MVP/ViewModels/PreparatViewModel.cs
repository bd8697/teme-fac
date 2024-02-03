using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_MVP
{
    public class PreparatViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Preparat> Preparate { get; set; }
        private PreparatRepository PreparatRepository { get; set; }

        public PreparatViewModel()
        {
            PreparatRepository = new PreparatRepository();
            Preparate = new ObservableCollection<Preparat>(PreparatRepository.preparatRepository);
            Preparate.CollectionChanged += Preparate_CollectionChanged;       // Event Handler for change in collection
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Preparat> searchRepo(string searchQuery)
        {
            if (searchQuery == "*" || searchQuery == " ")
                throw new Exception("Warning: Symbols such as '*' or whitespace are not acceptable");

            List<Preparat> PreparateList =
                (from tempPreparat in Preparate
                 where tempPreparat.Denumire.Contains(searchQuery)
                 select tempPreparat).ToList();
            return PreparateList;
        }

        public List<Preparat> searchNotInRepo(string searchQuery)
        {
            if (searchQuery == "*" || searchQuery == " ")
                throw new Exception("Warning: Symbols such as '*' or whitespace are not acceptable");

            List<Preparat> PreparateList =
                (from tempPreparat in Preparate
                 where !(tempPreparat.Alergen.Contains(searchQuery))
                 select tempPreparat).ToList();
            return PreparateList;
        }

        public List<Preparat> allFromRepo()
        {

            List<Preparat> PreparateList =
                (from tempPreparat in Preparate
                 select tempPreparat).ToList();
            return PreparateList;
        }

        public List<Preparat> epuizareFromRepo()
        {
            List<Preparat> PreparateList =
                (from tempPreparat in Preparate
                 where tempPreparat.Cantitate_Totala < System.Int32.Parse(ConfigurationManager.AppSettings["c_cant"])
                 select tempPreparat).ToList();
            return PreparateList;
        }

        public void AddRecordToRepo(Preparat Preparat)
        {
            if (Preparat == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Console.WriteLine(Preparat);
            Preparate.Add(Preparat);
        }

        public void DeleteRecordFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < Preparate.Count)
            {
                if (Preparate[index].Id == id)
                {
                    Preparate.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        public void UpdateRecordInRepo(Preparat Preparat)
        {
            if (Preparat.Id < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while (index < Preparate.Count)
            {
                if (Preparate[index].Id == Preparat.Id)
                {
                    Preparate[index] = Preparat;
                    break;
                }
                index++;
            }
        }

        private void Preparate_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                PreparatRepository.addNewRecord(Preparate[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Preparat> tempListOfRemovedItems = e.OldItems.OfType<Preparat>().ToList();
                PreparatRepository.DelRecord(tempListOfRemovedItems[0].Id);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Preparat> tempListOfPreparate = e.NewItems.OfType<Preparat>().ToList();
                PreparatRepository.UpdateRecord(tempListOfPreparate[0]);
            }
        }
    }
}