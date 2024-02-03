namespace Hangman_MVP.Model
{
    class Gallow
    {
        private string _src_0 = "/Hangman_MVP/Images/0.png";
        private string _src_1 = "/Hangman_MVP/Images/1.png";
        private string _src_2 = "/Hangman_MVP/Images/2.png";
        private string _src_3 = "/Hangman_MVP/Images/3.png";
        private string _src_4 = "/Hangman_MVP/Images/4.png";
        private string _src_5 = "/Hangman_MVP/Images/5.png";

        public int Src_0 { get; set; }
        public int Src_1 { get; set; }
        public int Src_2 { get; set; }
        public int Src_3 { get; set; }
        public int Src_4 { get; set; }
        public int Src_5 { get; set; }

        public string GetImageRef(int step)
        {
            switch (step)
            {
                case 0: return _src_0;
                case 1: return _src_1;
                case 2: return _src_2;
                case 3: return _src_3;
                case 4: return _src_4;
                case 5: return _src_5;
                default: return _src_5;
            }
        }

    }
}