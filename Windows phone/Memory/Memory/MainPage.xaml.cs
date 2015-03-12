using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Memory
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Random _random = new Random();

        List<string> icons = new List<string>()
        {
             "!", "!", "N", "N", ",", ",", "k", "k",
             "P", "P", "t", "t",
             "b", "b", "v", "v", "w", "w", "z", "z"
        }; 

        public MainPage()
        {
            this.InitializeComponent();

            var brojevi = new Brojevi();

            Button.DataContext = brojevi;

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void AssingIconToButton()
        {
           
        }

        private void AboutClick(object sender, RoutedEventArgs e)
        {

        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            BindingExpression expression = Button.GetBindingExpression(Button.ContentProperty);
            if (expression != null) expression.UpdateSource();
        }
    }
}
