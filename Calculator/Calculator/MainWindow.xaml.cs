using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        double? op1;
        double? op2;
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button btnSender = (Button)sender;
            textbox.Text += btnSender.Content.ToString();
        }

        private void Solve_Click(object sender, RoutedEventArgs e)
        {
            string[] splitted = textbox.Text.Split(char.Parse(lb_operator.Content.ToString()));
            op1 = double.Parse(splitted[0]);
            lb_op1.Content = splitted[0];
            op2 = double.Parse(splitted[1]);
            lb_op2.Content = splitted[1];
            switch (lb_operator.Content.ToString()) 
            {
                case "+":
                    lb_solve.Content =op1+op2;
                    textbox.Text = lb_solve.Content.ToString();
                    break;
                case "-":
                    lb_solve.Content = op1 - op2;
                    textbox.Text = lb_solve.Content.ToString();
                    break;
                case "/":
                    lb_solve.Content = op1 / op2;
                    textbox.Text = lb_solve.Content.ToString();
                    break;
                case "*":
                    lb_solve.Content = op1 * op2;
                    textbox.Text = lb_solve.Content.ToString();
                    break;
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button btnSender = (Button)sender;
            textbox.Text += btnSender.Content.ToString();
            lb_operator.Content=btnSender.Content.ToString();
        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            Button btnSender = (Button)sender;
            textbox.Text += btnSender.Content.ToString();
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsNumericOrOperator(e.Text))
            {
                e.Handled = true;
            }
        }

        private bool IsNumericOrOperator(string input)
        {
            return input.All(char.IsDigit) || "+-*/".Contains(input);
        }

    }
}