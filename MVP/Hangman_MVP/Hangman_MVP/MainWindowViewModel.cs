using Hangman_MVP;
using Hangman_MVP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hangman.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string str = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(str));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {

        }

        Game myGame;

        public MainWindowViewModel()
        {
        }

        private string _contentVisibility = "Hidden";
        public string ContentVisibility
        {
            get { return _contentVisibility; }
            set
            {
                if (value != _contentVisibility)
                {
                    _contentVisibility = value;
                    NotifyPropertyChanged("ContentVisibility");
                }
            }
        }

        private string _gallowImage;
        public string GallowImage
        {
            get { return _gallowImage; }
            set
            {
                if (value != _gallowImage)
                {
                    _gallowImage = value;
                    NotifyPropertyChanged("GallowImage");
                }
            }
        }

        private string _isEnabledA;
        public string IsEnabledA
        {
            get { return _isEnabledA; }
            set
            {
                if (value != _isEnabledA)
                {
                    _isEnabledA = value;
                    NotifyPropertyChanged("IsEnabledA");
                }
            }
        }

        private string _isEnabledB;
        public string IsEnabledB
        {
            get { return _isEnabledB; }
            set
            {
                if (value != _isEnabledB)
                {
                    _isEnabledB = value;
                    NotifyPropertyChanged("IsEnabledB");
                }
            }
        }

        private string _isEnabledC;
        public string IsEnabledC
        {
            get { return _isEnabledC; }
            set
            {
                if (value != _isEnabledC)
                {
                    _isEnabledC = value;
                    NotifyPropertyChanged("IsEnabledC");
                }
            }
        }

        private string _isEnabledD;
        public string IsEnabledD
        {
            get { return _isEnabledD; }
            set
            {
                if (value != _isEnabledD)
                {
                    _isEnabledD = value;
                    NotifyPropertyChanged("IsEnabledD");
                }
            }
        }

        private string _isEnabledE;
        public string IsEnabledE
        {
            get { return _isEnabledE; }
            set
            {
                if (value != _isEnabledE)
                {
                    _isEnabledE = value;
                    NotifyPropertyChanged("IsEnabledE");
                }
            }
        }

        private string _isEnabledF;
        public string IsEnabledF
        {
            get { return _isEnabledF; }
            set
            {
                if (value != _isEnabledF)
                {
                    _isEnabledF = value;
                    NotifyPropertyChanged("IsEnabledF");
                }
            }
        }

        private string _isEnabledG;
        public string IsEnabledG
        {
            get { return _isEnabledG; }
            set
            {
                if (value != _isEnabledG)
                {
                    _isEnabledG = value;
                    NotifyPropertyChanged("IsEnabledG");
                }
            }
        }

        private string _isEnabledH;
        public string IsEnabledH
        {
            get { return _isEnabledH; }
            set
            {
                if (value != _isEnabledH)
                {
                    _isEnabledH = value;
                    NotifyPropertyChanged("IsEnabledH");
                }
            }
        }

        private string _isEnabledI;
        public string IsEnabledI
        {
            get { return _isEnabledI; }
            set
            {
                if (value != _isEnabledI)
                {
                    _isEnabledI = value;
                    NotifyPropertyChanged("IsEnabledI");
                }
            }
        }

        private string _isEnabledJ;
        public string IsEnabledJ
        {
            get { return _isEnabledJ; }
            set
            {
                if (value != _isEnabledJ)
                {
                    _isEnabledJ = value;
                    NotifyPropertyChanged("IsEnabledJ");
                }
            }
        }

        private string _isEnabledK;
        public string IsEnabledK
        {
            get { return _isEnabledK; }
            set
            {
                if (value != _isEnabledK)
                {
                    _isEnabledK = value;
                    NotifyPropertyChanged("IsEnabledK");
                }
            }
        }

        private string _isEnabledL;
        public string IsEnabledL
        {
            get { return _isEnabledL; }
            set
            {
                if (value != _isEnabledL)
                {
                    _isEnabledL = value;
                    NotifyPropertyChanged("IsEnabledL");
                }
            }
        }

        private string _isEnabledM;
        public string IsEnabledM
        {
            get { return _isEnabledM; }
            set
            {
                if (value != _isEnabledM)
                {
                    _isEnabledM = value;
                    NotifyPropertyChanged("IsEnabledM");
                }
            }
        }

        private string _isEnabledN;
        public string IsEnabledN
        {
            get { return _isEnabledN; }
            set
            {
                if (value != _isEnabledN)
                {
                    _isEnabledN = value;
                    NotifyPropertyChanged("IsEnabledN");
                }
            }
        }

        private string _isEnabledO;
        public string IsEnabledO
        {
            get { return _isEnabledO; }
            set
            {
                if (value != _isEnabledO)
                {
                    _isEnabledO = value;
                    NotifyPropertyChanged("IsEnabledO");
                }
            }
        }

        private string _isEnabledP;
        public string IsEnabledP
        {
            get { return _isEnabledP; }
            set
            {
                if (value != _isEnabledP)
                {
                    _isEnabledP = value;
                    NotifyPropertyChanged("IsEnabledP");
                }
            }
        }

        private string _isEnabledQ;
        public string IsEnabledQ
        {
            get { return _isEnabledQ; }
            set
            {
                if (value != _isEnabledQ)
                {
                    _isEnabledQ = value;
                    NotifyPropertyChanged("IsEnabledQ");
                }
            }
        }

        private string _isEnabledR;
        public string IsEnabledR
        {
            get { return _isEnabledR; }
            set
            {
                if (value != _isEnabledR)
                {
                    _isEnabledR = value;
                    NotifyPropertyChanged("IsEnabledR");
                }
            }
        }

        private string _isEnabledS;
        public string IsEnabledS
        {
            get { return _isEnabledS; }
            set
            {
                if (value != _isEnabledS)
                {
                    _isEnabledS = value;
                    NotifyPropertyChanged("IsEnabledS");
                }
            }
        }

        private string _isEnabledT;
        public string IsEnabledT
        {
            get { return _isEnabledT; }
            set
            {
                if (value != _isEnabledT)
                {
                    _isEnabledT = value;
                    NotifyPropertyChanged("IsEnabledT");
                }
            }
        }

        private string _isEnabledU;
        public string IsEnabledU
        {
            get { return _isEnabledU; }
            set
            {
                if (value != _isEnabledU)
                {
                    _isEnabledU = value;
                    NotifyPropertyChanged("IsEnabledU");
                }
            }
        }

        private string _isEnabledV;
        public string IsEnabledV
        {
            get { return _isEnabledV; }
            set
            {
                if (value != _isEnabledV)
                {
                    _isEnabledV = value;
                    NotifyPropertyChanged("IsEnabledV");
                }
            }
        }

        private string _isEnabledW;
        public string IsEnabledW
        {
            get { return _isEnabledW; }
            set
            {
                if (value != _isEnabledW)
                {
                    _isEnabledW = value;
                    NotifyPropertyChanged("IsEnabledW");
                }
            }
        }

        private string _isEnabledX;
        public string IsEnabledX
        {
            get { return _isEnabledX; }
            set
            {
                if (value != _isEnabledX)
                {
                    _isEnabledX = value;
                    NotifyPropertyChanged("IsEnabledX");
                }
            }
        }

        private string _isEnabledY;
        public string IsEnabledY
        {
            get { return _isEnabledY; }
            set
            {
                if (value != _isEnabledY)
                {
                    _isEnabledY = value;
                    NotifyPropertyChanged("IsEnabledY");
                }
            }
        }

        private string _isEnabledZ;
        public string IsEnabledZ
        {
            get { return _isEnabledZ; }
            set
            {
                if (value != _isEnabledZ)
                {
                    _isEnabledZ = value;
                    NotifyPropertyChanged("IsEnabledZ");
                }
            }
        }

        private string _secret;
        public string Secret
        {
            get { return _secret; }
            set
            {
                if (value != _secret)
                {
                    _secret = value;
                    NotifyPropertyChanged("Secret");
                }
            }
        }


        public ICommand NewOnePlayerCommand
        {
            get
            {
                if (_newOnePlayerCommand == null)
                {
                    _newOnePlayerCommand = new RelayCommand<string>(param => this.NewOnePlayerCommandExecute(param), param => this.NewOnePlayerCommandCanExecute);
                }
                return _newOnePlayerCommand;
            }
        }

        void NewOnePlayerCommandExecute(string param)
        {
            string str;
            if (param != null)
            {
                RefreshContent();
                if (param == "other")
                {
                    str = GetDictionaryFileName();
                    myGame = new Game(1, str);
                }
                if (param != "other")
                    myGame = new Game(1, param + ".dico");

                GallowImage = myGame.DisplayGallow();
                Display();
            }
            else
                ResetContent();
        }

        bool NewOnePlayerCommandCanExecute
        {
            get { return true; }
        }

        private string GetDictionaryFileName()
        {

            var dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".dico";
            dlg.Filter = "Dictionary files (.dico)|*.dico|Text files (.txt)|*.txt|All files (.)|*.";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
                return dlg.FileName;
            else
                return null;

        }

        //void NewTwoPlayersCommandExecute()
        //{
        //    ResetContent();
        //    WordDialog dialog = new WordDialog();
        //    dialog.DataContext = new WordDialogViewModel();
        //    dialog.ShowDialog();
        //    var word = dialog.word.Text;
        //    if (RegexHelper.IsValidString(word))
        //    {
        //        List<string> wordList = new List<string>() { word };
        //        File.AppendAllLines("mydico.dico", wordList);
        //        RefreshContent();
        //        myGame = new Game(2, word);
        //        GallowImage = myGame.DisplayGallow();
        //        Display();
        //    }
        //}

        bool NewTwoPlayersCommandCanExecute
        {
            get { return true; }
        }


        public void RefreshContent()
        {
            ContentVisibility = "Visible";
            IsEnabledA = "True";
            IsEnabledB = "True";
            IsEnabledC = "True";
            IsEnabledD = "True";
            IsEnabledE = "True";
            IsEnabledF = "True";
            IsEnabledG = "True";
            IsEnabledH = "True";
            IsEnabledI = "True";
            IsEnabledJ = "True";
            IsEnabledK = "True";
            IsEnabledK = "True";
            IsEnabledL = "True";
            IsEnabledM = "True";
            IsEnabledN = "True";
            IsEnabledO = "True";
            IsEnabledP = "True";
            IsEnabledQ = "True";
            IsEnabledR = "True";
            IsEnabledS = "True";
            IsEnabledT = "True";
            IsEnabledU = "True";
            IsEnabledV = "True";
            IsEnabledW = "True";
            IsEnabledX = "True";
            IsEnabledY = "True";
            IsEnabledZ = "True";
            Secret = "";
        }

        public void ResetContent()
        {
            RefreshContent();
            ContentVisibility = "Hidden";
        }


        public ICommand LetterCommand
        {
            get
            {
                if (_letterCommand == null)
                {
                    _letterCommand = new RelayCommand<string>(param => this.LetterCommandExecute(param), param => this.LetterCommandCanExecute);
                }
                return _letterCommand;
            }
        }

        void LetterCommandExecute(string param)
        {
            switch (param)
            {
                case "A":
                    IsEnabledA = "False";
                    break;
                case "B":
                    IsEnabledB = "False";
                    break;
                case "C":
                    IsEnabledC = "False";
                    break;
                case "D":
                    IsEnabledD = "False";
                    break;
                case "E":
                    IsEnabledE = "False";
                    break;
                case "F":
                    IsEnabledF = "False";
                    break;
                case "G":
                    IsEnabledG = "False";
                    break;
                case "H":
                    IsEnabledH = "False";
                    break;
                case "I":
                    IsEnabledI = "False";
                    break;
                case "J":
                    IsEnabledJ = "False";
                    break;
                case "K":
                    IsEnabledK = "False";
                    break;
                case "L":
                    IsEnabledL = "False";
                    break;
                case "M":
                    IsEnabledM = "False";
                    break;
                case "N":
                    IsEnabledN = "False";
                    break;
                case "O":
                    IsEnabledO = "False";
                    break;
                case "P":
                    IsEnabledP = "False";
                    break;
                case "Q":
                    IsEnabledQ = "False";
                    break;
                case "R":
                    IsEnabledR = "False";
                    break;
                case "S":
                    IsEnabledS = "False";
                    break;
                case "T":
                    IsEnabledT = "False";
                    break;
                case "U":
                    IsEnabledU = "False";
                    break;
                case "V":
                    IsEnabledV = "False";
                    break;
                case "W":
                    IsEnabledW = "False";
                    break;
                case "X":
                    IsEnabledX = "False";
                    break;
                case "Y":
                    IsEnabledY = "False";
                    break;
                case "Z":
                    IsEnabledZ = "False";
                    break;
            }
            myGame.TestALetter(param);
            Display();
            if (myGame.WordIsFound())
                Ending();
            if (myGame.IsDead())
                Dead();
        }

        bool LetterCommandCanExecute
        {
            get { return true; }
        }

        void Display()
        {
            Secret = myGame.Secret;
            GallowImage = myGame.DisplayGallow();
        }

        void Ending()
        {
            MessageBox.Show("You won !", "End", MessageBoxButton.OK, MessageBoxImage.Information);
            ResetContent();
        }

        void Dead()
        {
            MessageBox.Show("You are dead ! The word was " + myGame.Word, "Dead", MessageBoxButton.OK, MessageBoxImage.Error);
            ResetContent();
        }


        public ICommand AboutCommand
        {
            get
            {
                if (_aboutCommand == null)
                {
                    _aboutCommand = new RelayCommand<object>(param => this.AboutCommandExecute(), param => this.AboutCommandCanExecute);
                }
                return _aboutCommand;
            }
        }

        void AboutCommandExecute()
        {
            MessageBox.Show("This Hangman was created by Corky Maigre in\nISIMs Engineering School."
                + "\nVisit www.corkymaigre.be", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        bool AboutCommandCanExecute
        {
            get { return true; }
        }


        public ICommand HelpCommand
        {
            get
            {
                if (_helpCommand == null)
                {
                    _helpCommand = new RelayCommand<object>(param => this.HelpCommandExecute(), param => this.HelpCommandCanExecute);
                }
                return _helpCommand;
            }
        }

        void HelpCommandExecute()
        {
            MessageBox.Show("You have five attempts to find the\nword otherwise you will die.", "About", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        bool HelpCommandCanExecute
        {
            get { return true; }
        }


    }
}


