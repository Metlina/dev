using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.PersonalInformation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Xml.Linq;
using Cinestar.Data;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Windows.Web.Http;

namespace Cinestar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private HttpClient httpClient;
        private HttpResponseMessage response;

        private String feedAddress = "http://www.blitz-cinestar.hr/rss.aspx";

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            
            httpClient = new HttpClient();

            // Add a user-agent header
            var headers = httpClient.DefaultRequestHeaders;

            // HttpProductInfoHeaderValueCollection is a collection of 
            // HttpProductInfoHeaderValue items used for the user-agent header

            headers.UserAgent.ParseAdd("ie");
            headers.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
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


        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Uri resourceUri;
            if (!Uri.TryCreate(feedAddress.Trim(), UriKind.Absolute, out resourceUri))
            {
                return;
            }
            if (resourceUri.Scheme != "http" && resourceUri.Scheme != "https")
            {
                return;
            }

            string responseText = null;

            try
            {
                response = await httpClient.GetAsync(resourceUri);

                response.EnsureSuccessStatusCode();

                responseText = await response.Content.ReadAsStringAsync();
                
            }
            catch (Exception)
            {
            }

            List<RssItems> lstData = new List<RssItems>();
            XElement _xml = XElement.Parse(responseText);
            foreach (XElement value in _xml.Elements("channel").Elements("item"))
            {
                RssItems _item = new RssItems();

                _item.Title = value.Element("title").Value;
                _item.Description = value.Element("description").Value;
                _item.Director = value.Element("redatelj").Value;
                _item.Poster = value.Element("plakat").Value;
                lstData.Add(_item);
            }
            lssRss.DataContext = lstData;
        }

        private void LssRss_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = lssRss.SelectedItems as RssItems;
            
            //WebView webBrowserTask = new WebView();
            //Uri targetUri = new Uri(selected.Link);
        }
    }
}
