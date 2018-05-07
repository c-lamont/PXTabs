using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Plugin.ProXamTabs.Shared
{
    public partial class PXTabViewTemplate : ContentView
    {
        public PXTabViewTemplate()
        {
            InitializeComponent();
        }
        
                public static readonly BindableProperty TabsProperty =
            BindableProperty.Create(
                nameof(Tabs),
                typeof(IEnumerable<PXTab>),
                typeof(PXTabsLayout),
                null,
                BindingMode.OneWay);

        public IEnumerable<PXTab> Tabs
        {
            get => (IEnumerable<PXTab>)GetValue(TabsProperty);
            set => SetValue(TabsProperty, value);
        }
        
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
