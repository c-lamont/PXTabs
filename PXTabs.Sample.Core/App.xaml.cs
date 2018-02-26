using Xamarin.Forms;

namespace PXTabs.Sample.Core
{
    public partial class App : Application
    {
        public App()
        {
            Application.Current.MainPage = new NavigationPage(new TabsPage());
        }
    }
}
