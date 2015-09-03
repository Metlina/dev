using Windows.UI.Xaml.Controls;

namespace Leviton.SnapLink.Views
{
    public sealed partial class Shell
    {
        public Shell(Frame frame)
        {
            this.InitializeComponent();
            SplitView.Content = frame;
        }

        internal void TogglePane()
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }
    }
}
