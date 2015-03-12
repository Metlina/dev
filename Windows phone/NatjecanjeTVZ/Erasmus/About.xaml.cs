using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Erasmus
{
    public partial class About : PhoneApplicationPage
    {
        public About()
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

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            ShowInBrowser("http://natjecanje.tvz.hr/2014");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask()
            {
                Subject = "message subject",
                Body = "message body",
                To = "tinopetrina@live.com",
                Cc = "cc@example.com",
                Bcc = "bcc@example.com"
            };

            emailComposeTask.Show();
        }

       private void ShowInBrowser(string url)
       {
           Microsoft.Phone.Tasks.WebBrowserTask wbt = new Microsoft.Phone.Tasks.WebBrowserTask();
           wbt.Uri = new Uri(url);
           wbt.Show();
       }
    }
}