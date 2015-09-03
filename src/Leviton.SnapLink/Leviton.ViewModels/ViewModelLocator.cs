using Windows.UI.Core;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Leviton.ViewModels
{
    public class ViewModelLocator
    {
        private static bool _initialized;

        public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public ViewModelLocator()
        {
            Initialize();
        }

        private static void Initialize()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();

            _initialized = true;
        }

        public static void Ensure()
        {
            if (_initialized)
                return;

            Initialize();
        }
    }
}
