using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_MVP
{
    public class ComandaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Comanda> Comenzi { get; set; }
        private ComandaRepository ComandaRepository { get; set; }

        public ComandaViewModel()
        {
            ComandaRepository = new ComandaRepository();
            Comenzi = new ObservableCollection<Comanda>(ComandaRepository.comandaRepository);
            Comenzi.CollectionChanged += Comenzi_CollectionChanged;       // Event Handler for change in collection
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Comanda> searchRepo(string searchQuery)
        {
            if (searchQuery == "*" || searchQuery == " ")
                throw new Exception("Warning: Symbols such as '*' or whitespace are not acceptable");

            List<Comanda> ComenziList =
                (from tempComanda in Comenzi
                 where tempComanda.Client.Contains(searchQuery)
                 select tempComanda).ToList();
            return ComenziList;
        }

        public List<Comanda> searchActiveRepo(string searchQuery)
        {
            if (searchQuery == "*" || searchQuery == " ")
                throw new Exception("Warning: Symbols such as '*' or whitespace are not acceptable");

            List<Comanda> ComenziList =
                (from tempComanda in Comenzi
                 where tempComanda.Client.Contains(searchQuery)
                 where !tempComanda.Stare.Contains("livrata")
                 where !tempComanda.Stare.Contains("anulata")
                 select tempComanda).ToList();
            return ComenziList;
        }

        public List<Comanda> allFromRepo()
        {

            List<Comanda> ComenziList =
                (from tempComanda in Comenzi
                 select tempComanda).ToList();
            return ComenziList;
        }

        public List<Comanda> allActiveFromRepo()
        {

            List<Comanda> ComenziList =
                (from tempComanda in Comenzi
                 where !tempComanda.Stare.Contains("livrata")
                 where !tempComanda.Stare.Contains("anulata")
                 select tempComanda).ToList();
            return ComenziList;
        }

        public void AddRecordToRepo(Comanda Comanda)
        {
            if (Comanda == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Console.WriteLine(Comanda);
            Comenzi.Add(Comanda);
        }

        public void DeleteRecordFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < Comenzi.Count)
            {
                if (Comenzi[index].Id == id)
                {
                    Comenzi.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        public void UpdateRecordInRepo(Comanda Comanda)
        {
            if (Comanda.Id < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while (index < Comenzi.Count)
            {
                if (Comenzi[index].Id == Comanda.Id)
                {
                    Comenzi[index] = Comanda;
                    break;
                }
                index++;
            }
        }


        private void Comenzi_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                ComandaRepository.addNewRecord(Comenzi[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Comanda> tempListOfRemovedItems = e.OldItems.OfType<Comanda>().ToList();
                ComandaRepository.DelRecord(tempListOfRemovedItems[0].Id);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Comanda> tempListOfComenzi = e.NewItems.OfType<Comanda>().ToList();
                ComandaRepository.UpdateRecord(tempListOfComenzi[0]);
            }
        }
    }
}
