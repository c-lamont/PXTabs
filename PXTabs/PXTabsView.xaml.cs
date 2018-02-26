using System.Linq;

namespace PXTabs
{
    public partial class PXTabsView : BasePXTabsLayout
    {
        public PXTabsView()
        {
            InitializeComponent();
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
