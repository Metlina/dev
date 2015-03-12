using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Erasmus.Resources;

namespace Erasmus
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();


            //navigation
            NavigationInTransition navigateInTransition = new NavigationInTransition();
            navigateInTransition.Backward = new SlideTransition { Mode = SlideTransitionMode.SlideDownFadeIn };
            navigateInTransition.Forward = new SlideTransition { Mode = SlideTransitionMode.SlideUpFadeIn };

            NavigationOutTransition navigateOutTransition = new NavigationOutTransition();
            navigateOutTransition.Backward = new SlideTransition { Mode = SlideTransitionMode.SlideDownFadeOut };
            navigateOutTransition.Forward = new SlideTransition { Mode = SlideTransitionMode.SlideUpFadeOut };
            TransitionService.SetNavigationInTransition(this, navigateInTransition);
            TransitionService.SetNavigationOutTransition(this, navigateOutTransition);
            
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/settings.xaml", UriKind.Relative));
        }

        private void Pin_To_Start_Clik(object sender, EventArgs e)
        {
            ShellTile.Create(new Uri("/MainPage.xaml", UriKind.Relative), new StandardTileData()
            {
                BackgroundImage = new Uri("isostore:/Shared/ShellContent/image.png", UriKind.Absolute),
                Title = "Computing"
            });
        }

        //ShellTile.Create(new Uri("/MainPage.xaml", UriKind.Relative), new StandardTileData()
        //{
        //    BackgroundImage = new Uri("",UriKind.Absolute);
        //    Title = "Computing";
        //}

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}