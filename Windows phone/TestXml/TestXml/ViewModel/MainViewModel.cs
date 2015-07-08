using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Xml.Linq;
using Windows.Data.Xml;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using GalaSoft.MvvmLight;
using TestXml.Helpers;
using TestXml.Model;

namespace TestXml.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string url = "http://www.hakom.hr/operatorSWC.aspx?brojTel=00385918810499&lng=en&android=false";

        private bool _isLoading;
        private bool _isLoaded;
        
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
                HttpClient client = new HttpClient();
                var httpResponseMessage = await client.GetAsync(new Uri(url));
                if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                {
                    var xmlStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    XDocument xml = XDocument.Load(xmlStream);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml.ToString());

                    content = xmlDoc.InnerText;
                    Items.Add(new Data(xmlDoc));
                }

                IsLoaded = true;
            }
            catch (Exception ex)
            {
                //ex.Log();
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}