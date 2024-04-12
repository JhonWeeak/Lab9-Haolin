using Microsoft.Maui.Controls;

namespace Lab9
{
    public partial class MainPage : ContentPage
    {
        private string currentEntry = "";
        private double result = 0;
        private string currentOperator = "";
        private bool newOperation = true;
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (newOperation)
            {
                currentEntry = button.Text;
                newOperation = false;
            }
            else
            {
                currentEntry += button.Text;
            }
            ResultLabel.Text = currentEntry;
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            if (!newOperation)
            {
                PerformCalculation(currentEntry);
                newOperation = true;
            }
            var button = (Button)sender;
            currentOperator = button.Text;
            currentEntry = "";
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            PerformCalculation(currentEntry);
            currentOperator = "";
            newOperation = true;
        }

        private void PerformCalculation(string nextEntry)
        {
            double nextNumber;
            if (double.TryParse(nextEntry, out nextNumber))
            {
                switch (currentOperator)
                {
                    case "+": result += nextNumber; break;
                    case "-": result -= nextNumber; break;
                    case "*": result *= nextNumber; break;
                    case "/": result = nextNumber != 0 ? result / nextNumber : double.NaN; break;
                    default: result = nextNumber; break;
                }
                ResultLabel.Text = result.ToString();
                currentEntry = result.ToString();
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            result = 0;
            currentEntry = "";
            currentOperator = "";
            newOperation = true;
            ResultLabel.Text = "0";
        }
    }
}
