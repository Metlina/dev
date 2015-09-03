using GalaSoft.MvvmLight.Ioc;

namespace MvvmLightToolkitWindows10_test
{
    class ViewModelLocator 
    {
        public ViewModelLocator() 
        {
            Initialize();
        }

        private void Initialize()
        {
            SimpleIoc.Default.GetInstance<MainViewModel>();
        }
    }
}
