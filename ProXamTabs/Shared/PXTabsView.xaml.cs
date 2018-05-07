using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.ProXamTabs.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PXTabsView : BasePXTabsLayout
    {
        public PXTabsView()
        {
            InitializeComponent();
            CarouselView view = new CarouselView();
        }

        public override PXTabsLayout TabsLayout => tabsLayout;

        protected override void OnPropertyChanged(string propertyName = null)
        {
            if (propertyName == TabsProperty.PropertyName)
            {
                viewContainer.Children.Clear();
                foreach (var tab in Tabs.Where(t => t.TabView != null))
                {
                    tab.TabView.IsVisible = false;
                    viewContainer.Children.Add(tab.TabView);
                }
            }
            base.OnPropertyChanged(propertyName);
        }
    }
}