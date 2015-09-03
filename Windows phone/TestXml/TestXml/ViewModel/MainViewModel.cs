using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using TestXml.Model;

namespace TestXml.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //private string url = "http://www.hakom.hr/operatorSWC.aspx?brojTel=00385918810499&lng=en&android=false";

        private string url = "http://tstupomobile.posta.si/api/exchange/LogOn?TerminalId=TEST&Username=99991&Password=P0letje2016";

        private bool _isLoading;
        private bool _isLoaded;

        public HttpClient HttpClient;

        private string httpResponseMessage;

        public ObservableCollection<Data> Items { get; private set; }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { Set(ref _isLoading, value); }
        }

        public bool IsLoaded
        {
            get { return _isLoaded; }
            set { Set(ref _isLoaded, value); }
        }


        public MainViewModel()
        {
            Items = new ObservableCollection<Data>();
        }

        public async  void LoadAsync()
        {
            string content = null;

            if (IsLoading || IsLoaded)
                return;

            IsLoading = true;

            try
            {
                HttpClient = new HttpClient();
                httpResponseMessage = await HttpClient.GetStringAsync(new Uri(url));
                //if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                {
                    //var xmlStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    //XDocument xml = XDocument.Load(xmlStream);
                    //XmlDocument xmlDoc = new XmlDocument();
                    //xmlDoc.LoadXml(xml.ToString());

                    //content = xmlDoc.InnerText;
                    //Items.Add(new Data(xmlDoc));
                }

                IsLoaded = true;
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.ToString());
                await dialog.ShowAsync();
                Debug.WriteLine(ex.ToString());
                //ex.Log();
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}