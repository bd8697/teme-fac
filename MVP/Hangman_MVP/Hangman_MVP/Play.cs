using System;
using System.Text;

namespace Hangman_MVP.Model
{
    class Game
    {
        public Gallow _gallow;
        private int step;
        private string _word;
        private string _secret;

        public string Word
        {
            get { return _word; }
            set { _word = value; }
        }

        public string Secret
        {
            get { return _secret; }
            set { _secret = value; }
        }

        public int Step
        {
            get { return step; }
            set { step = value; }
        }

        public Game(int nbPlayer, string str)
        {
            Step = 0;
            if (nbPlayer == 1)
                ChooseInDictionary(str);
            if (nbPlayer == 2)
                ChooseWord(str);
            _gallow = new Gallow();
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private void ChooseInDictionary(string str)
        {
            try
            {
                var linesArray = System.IO.File.ReadAllLines(str);
                int line = RandomNumber(1, linesArray.Length);
                Word = linesArray[line].ToUpper();
                HideLetters(Word);
            }
            catch (Exception e)
            {
                Environment.Exit(0);
            }
            finally { }
        }

        private void ChooseWord(string str)
        {
            Word = str.ToUpper();
            HideLetters(Word);
        }

        private void HideLetters(string str)
        {
            var secret = new StringBuilder(str);
            for (int i = 0; i < secret.Length; i++)
                secret[i] = '-';
            Secret = secret.ToString();
        }

        public void TestALetter(string letter)
        {
            Console.WriteLine("hell0");
            var word = new StringBuilder(Word);
            var secret = new StringBuilder(Secret);
            bool letterFound = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == Char.Parse(letter))
                {
                    secret[i] = word[i];
                    letterFound = true;
                }
            }
            Secret = secret.ToString();
            if (!letterFound)
                Step++;
        }

        public string DisplayGallow()
        {
            return _gallow.GetImageRef(Step);
        }

        public bool IsDead()
        {
            if (Step == 5)
                return true;
            else
                return false;
        }

        public bool WordIsFound()
        {
            if (Word.Equals(Secret))
                return true;
            else
                return false;
        }
    }
}
