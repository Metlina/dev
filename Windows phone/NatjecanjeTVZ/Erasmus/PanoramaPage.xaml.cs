using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Erasmus
{
    public partial class PanoramaPage : PhoneApplicationPage
    {
        public PanoramaPage()
        {
            InitializeComponent();
        }

        private void Button_Click_ElectricalEngineering(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ElectricalEngineering.xaml", UriKind.Relative));
        }

        private void Button_Click_CivilEngineering(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CivilEngineering.xaml", UriKind.Relative));
        }

        private void Button_Click_InfrormationTechonologies(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InformationTechnologies.xaml", UriKind.Relative));
        }

        private void Button_Click_Mechatronics(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Mechatronics.xaml", UriKind.Relative));
        }

        private void Button_Click_Computing(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void Button_ClickSettings(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }

        private void Button_ClickAbout(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }


        private void Button_ClickContact(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Contact.xaml", UriKind.Relative));
        }
    }
}