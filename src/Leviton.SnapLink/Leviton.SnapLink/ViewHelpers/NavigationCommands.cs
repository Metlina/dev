using GalaSoft.MvvmLight.Command;
using Leviton.Common.Mvvm;
using Leviton.SnapLink.Views;

namespace Leviton.SnapLink.ViewHelpers
{
    public class NavigationCommands
    {
        public RelayCommand Rooms { get; private set; }
        public RelayCommand Status { get; private set; }
        public RelayCommand Control { get; private set; }
        public RelayCommand Security { get; private set; }
        public RelayCommand Buttons { get; private set; }
        public RelayCommand Temps { get; private set; }
        public RelayCommand Audio { get; private set; }
        public RelayCommand Cameras { get; private set; }
        public RelayCommand Access { get; private set; }
        public RelayCommand UserSettings { get; private set; }
        public RelayCommand Events { get; private set; }

        public NavigationCommands()
        {
            //Rooms = new NavigateCommand<RoomsView>();
            Status = new NavigateCommand<MainView>();
            //Control = new NavigateCommand<ControlView>();
            //Security = new NavigateCommand<SecurityView>();
            Buttons = new NavigateCommand<ButtonsView>();
            //Temps = new NavigateCommand<TempsView>();
            //Audio = new NavigateCommand<AudioView>();
            //Cameras = new NavigateCommand<CamerasView>();
            //Access = new NavigateCommand<AccessView>();
            //UserSettings = new NavigateCommand<UserSettingsView>();
            //Events = new NavigateCommand<EventsView>();
        }
    }
}
