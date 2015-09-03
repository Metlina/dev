using Ekobit.PostaSI.ViewModels;

namespace MvvmLightToolkitWindows10_test
{
    class MainViewModel : ViewModelBase
    {
        private int _propgala;

        public int Propgala
        {
            get { return _propgala; }
            set { Set(ref _propgala, value); }
        }

        public string Dugi
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
        
        public int Kratki { get { return Get<int>(); } set { Set(value); } }

        public string Short { get { return Get<string>(); } set { Set(value); } }

        public string Long
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
    }
}
