
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    public partial class MainWindow : Window
    {
       
        double number2 = 0;
        double result = 0;
        string last_operation = "";
        double memory;
      //  String memInput;
        String input;
        Boolean displayMem;
        public MainWindow()
        {
            InitializeComponent();
            loadMemOp();
            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon("calc.ico");
            ni.Visible = true;
            ni.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
        }

        private void any_Click(object sender, RoutedEventArgs e)
        {
            Button nr = (Button)sender;
            if (screen.Text.EndsWith("."))
                {
                    number2 = number2 + double.Parse(nr.Content.ToString()) / 10.0;
                }
                else
                {
                    number2 = (number2 * 10) + double.Parse(nr.Content.ToString());
                }
                screen.Text = number2.ToString();
               // screen.Text = nr.Content.ToString();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
                operatie(last_operation);
                last_operation = "+";
            screeninter.Text += number2.ToString() + last_operation;
            number2 = 0;
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            operatie(last_operation);
            last_operation = "-";
            screeninter.Text += number2.ToString() + last_operation;
            number2 = 0;
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            operatie(last_operation);
            last_operation = "*";
            screeninter.Text += number2.ToString() + last_operation;
            number2 = 0;
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
                operatie(last_operation);
                last_operation = "/";
                screeninter.Text += number2.ToString() + last_operation;
                number2 = 0;
        }

        private void operatie(string op)
        {
            switch (op)
            {
                case "":
                    result = double.Parse(screen.Text);
                    screen.Text = result.ToString();
                    break;
                case "+":
                    result += double.Parse(screen.Text);
                    screen.Text = result.ToString();
               //     screeninter.Text = "";
               //     number1 = number1 + number2;
                    break;
                case "-":
                    result -= double.Parse(screen.Text);
                    screen.Text = result.ToString();
                    //      screeninter.Text = "";
                 //   number1 = number1 - number2;
                    break;
                case "*":
                    result *= double.Parse(screen.Text);
                    screen.Text = result.ToString();
                    //     screeninter.Text = "";
                  //  number1 = number1 * number2;
                    break;
                case "/":
                    if (number2 == 0)
                    {
                        MessageBox.Show("Can't divide by 0.");
                    }
                    else
                    {
                        result /= double.Parse(screen.Text);
                        screen.Text = result.ToString();
                        //    screeninter.Text = "";
                        //  number1 = number1 / number2;
                    }
                    break;
                    
            }
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            operatie(last_operation);
          //  screen.Text = (number1).ToString();
          //  screeninter.Text = screeninter.Text.Remove(screeninter.Text.Length - 1);
            screeninter.Text += number2 + "=" + result + "\n";
            number2 = result;
            last_operation = "";
        }

        private void clearEntity_Click(object sender, RoutedEventArgs e)
        {
            number2 = 0;
            screen.Text = "0";
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            number2 = 0;
            screen.Text = "";
            screeninter.Text = "";
            result = 0;
        }

        private void plusminus_Click(object sender, RoutedEventArgs e)
        {
                number2 *= -1;
                screen.Text = number2.ToString();
        }

        private void sqrt_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = (Math.Sqrt(double.Parse(screen.Text))).ToString();
            number2 = double.Parse(screen.Text);
        }

        private void backspace_Click(object sender, RoutedEventArgs e)
        {
                number2 = number2 / 10;
                screen.Text = number2.ToString();
        }

        private void point_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + ".";
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Numele programatorului: Birsan Dan\n" + "Processor Count: " + Environment.ProcessorCount + "\n");
        }

        private void _1divide_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = (1 / double.Parse(screen.Text)).ToString();
            number2 = double.Parse(screen.Text);
        }

        private void rid_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = (double.Parse(screen.Text) * double.Parse(screen.Text)).ToString();
            number2 = double.Parse(screen.Text);
        }

        private void valueCut(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(screen.Text);
            screen.Text = "0";
            number2 = 0;
        }

        private void valueCopy(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(screen.Text);
        }

        private void pasteValue(object sender, RoutedEventArgs e)
        {
            double numb;
            var x = Clipboard.GetData(DataFormats.Text) as string;
            if (!string.IsNullOrWhiteSpace(x))
            {
                bool isNumber = double.TryParse(x, out numb);
                if (isNumber)
                    screen.Text = System.Convert.ToString(numb);
                    number2 = numb;
            }
        }

        private void groupingClicked(object sender, RoutedEventArgs e)
        {
            SetDisplayValue(double.Parse(screen.Text));
        }

        private void SetDisplayValue(double value)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            screen.Text = value.ToString("N", nfi);
        }

        public void loadMemOp()
        {
            if (displayMem == true)
            {
                mr.IsEnabled = true;
                mc.IsEnabled = true;
                mplus.IsEnabled = true;
                mminus.IsEnabled = true;
            }
            else
            {
                mr.IsEnabled = false;
                mc.IsEnabled = false;
                mplus.IsEnabled = false;
                mminus.IsEnabled = false;
            }
        }

        private void mc_Click(object sender, RoutedEventArgs e)
        {
            memory = 0;
            screen.Text = memory.ToString();
            number2 = 0;
            displayMem = false;
            loadMemOp();
        }

        private void mr_Click(object sender, RoutedEventArgs e)
        {
            // memInput = screen.Text;
            number2 = memory;
            screen.Text = memory.ToString();
        }

        private void mplus_Click(object sender, RoutedEventArgs e)
        {
            input = screen.Text;
            double operand = double.Parse(input);
            memory = memory + operand;
            screen.Text = memory.ToString();
            number2 = memory;
        }

        private void mminus_Click(object sender, RoutedEventArgs e)
        {
            input = screen.Text;
            double operand = double.Parse(input);
            memory = memory - operand;
            screen.Text = memory.ToString();
            number2 = memory;
        }

        private void ms_Click(object sender, RoutedEventArgs e)
        {
            input = screen.Text;
            memory = double.Parse(input);
            displayMem = true;
            screen.Text = memory.ToString();
            screen.Text = "0";
            number2 = 0;
            loadMemOp();
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Minimized)
                this.Hide();

            base.OnStateChanged(e);
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch ((e.Key))
            {
                case Key.D0:
                    {
                        any_Click(zero, new RoutedEventArgs());
                        break;
                    }

                case Key.D1:
                    {
                        any_Click(one, new RoutedEventArgs());
                        break;
                    }
                case Key.D2:
                    {
                        any_Click(two, new RoutedEventArgs());
                        break;
                    }
                case Key.D3:
                    {
                        any_Click(three, new RoutedEventArgs());
                        break;
                    }
                case Key.D4:
                    {
                        any_Click(four, new RoutedEventArgs());
                        break;
                    }
                case Key.D5:
                    {
                        any_Click(five, new RoutedEventArgs());
                        break;
                    }
                case Key.D6:
                    {
                        any_Click(six, new RoutedEventArgs());
                        break;
                    }
                case Key.D7:
                    {
                        any_Click(seven, new RoutedEventArgs());
                        break;
                    }
                case Key.D8:
                    {
                        any_Click(eight, new RoutedEventArgs());
                        break;
                    }
                case Key.D9:
                    {
                        any_Click(nine, new RoutedEventArgs());
                        break;
                    }
                     case Key.Enter:
                         {
                             Console.WriteLine("Test");
                             equal_Click(sender, new RoutedEventArgs());
                             break;
                         }
                     case Key.Multiply:
                         {
                             multiply_Click(sender, new RoutedEventArgs());
                             break;
                         }
                     case Key.Add:
                         {
                             add_Click(sender, new RoutedEventArgs());
                             break;
                         }
                     case Key.Back:
                         {
                            backspace_Click(sender, new RoutedEventArgs());
                             break;
                         }
                     case Key.Subtract:
                         {
                             minus_Click(sender, new RoutedEventArgs());
                             break;
                         }
                     case Key.Divide:
                         {
                            divide_Click(sender, new RoutedEventArgs());
                             break;
                         }
                case Key.Escape:
                    {
                        clear_Click(sender, new RoutedEventArgs());
                        break;
                    }
                case Key.M:
                    {
                        WindowState = WindowState.Minimized;
                        break;
                    }
            }
        }

        private void screen_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void screeninter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
