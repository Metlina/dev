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
    public partial class ElectricalEngineering : PhoneApplicationPage
    {
        public ElectricalEngineering()
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
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }

        private void Pin_To_Start_Clik(object sender, EventArgs e)
        {
            ShellTile.Create(new Uri("/ElectricalEngineering.xaml", UriKind.Relative), new StandardTileData()
            {
                BackgroundImage = new Uri("isostore:/Shared/ShellContent/image.png", UriKind.Absolute),
                Title = "Electrical Engineering"
            });
        }
    }
}