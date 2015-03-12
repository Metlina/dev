using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TipCalculatorUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Tip tip;

        public MainPage()
        {
            this.InitializeComponent();

            tip = new Tip();
        }

        private void amountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            BillAmountTextBox.Text = tip.BillAmount;
        }

        private void billAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            performCalculation();
        }

        private void amountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            BillAmountTextBox.Text = "";
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            performCalculation();
        }

        private void performCalculation()
        {
            var selecetedRadio = MyStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

            tip.CalculateTip(BillAmountTextBox.Text, double.Parse(selecetedRadio.Tag.ToString()));

            AmountToTipTextBlock.Text = tip.TipaAmount;
            TotalTextBlock.Text = tip.TotalAmount;
        }
    }
}
