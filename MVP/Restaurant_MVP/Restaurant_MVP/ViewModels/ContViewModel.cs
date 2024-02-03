using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_MVP
{
    public class ContViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Cont> Conturi { get; set; }
        private ContRepository ContRepository { get; set; }

        public ContViewModel()
        {
            ContRepository = new ContRepository();
            Conturi = new ObservableCollection<Cont>(ContRepository.contRepository);
            Conturi.CollectionChanged += Conturi_CollectionChanged;       // Event Handler for change in collection
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Cont> searchRepo(string searchQuery)
        {
            if (searchQuery == "*" || searchQuery == " " || searchQuery == "")
                throw new Exception("Warning: Symbols such as '*' or whitespace are not acceptable");

            List<Cont> ConturiList =
                (from tempCont in Conturi
                 where tempCont.E_mail.Contains(searchQuery)
                 select tempCont).ToList();
            return ConturiList;
        }

        public bool checkPass(Cont cont, string pass)
        {
            if (cont.Parola == pass)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Cont> allFromRepo()
        {

            List<Cont> ConturiList =
                (from tempCont in Conturi
                 select tempCont).ToList();
            return ConturiList;
        }

        public void AddRecordToRepo(Cont Cont)
        {
            if (Cont == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Console.WriteLine(Cont);
            Conturi.Add(Cont);
        }

        public void DeleteRecordFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < Conturi.Count)
            {
                if (Conturi[index].Id == id)
                {
                    Conturi.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        public void UpdateRecordInRepo(Cont Cont)
        {
            if (Cont.Id < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while (index < Conturi.Count)
            {
                if (Conturi[index].Id == Cont.Id)
                {
                    Conturi[index] = Cont;
                    break;
                }
                index++;
            }
        }

        private void Conturi_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                ContRepository.addNewRecord(Conturi[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Cont> tempListOfRemovedItems = e.OldItems.OfType<Cont>().ToList();
                ContRepository.DelRecord(tempListOfRemovedItems[0].Id);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Cont> tempListOfConturi = e.NewItems.OfType<Cont>().ToList();
                ContRepository.UpdateRecord(tempListOfConturi[0]);
            }
        }
    }
}
