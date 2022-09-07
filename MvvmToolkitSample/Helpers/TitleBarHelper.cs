using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace MvvmToolkitSample.Helpers
{
    public static class TitleBarHelper
    {
        public static void StyleTitleBar()
        {
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

            titleBar.ForegroundColor = Colors.Transparent;
            titleBar.BackgroundColor = Colors.Transparent;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.InactiveBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }

        public static void ExpandViewIntoTitleBar()
        {
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
        }
    }
}
