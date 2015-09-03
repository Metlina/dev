using System;

namespace Leviton.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public DateTime DateTime { get { return Get<DateTime>(); } private set { Set(value); } }

        public string Sunrise { get { return Get<string>(); } private set { Set(value); } }

        public string Sunset { get { return Get<string>(); } private set { Set(value); } }

        public bool AreTroubles { get { return Get<bool>(); } private set { Set(value); } }

        public string Security { get { return Get<string>(); } private set { Set(value); } }

        public MainViewModel()
        {
            DateTime = DateTime.Now;
        }
    }
}
