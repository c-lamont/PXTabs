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
		public PXTabsView ()
		{
			InitializeComponent ();
		}

        public override PXTabsLayout TabsLayout => tabsLayout;

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TabsProperty.PropertyName)
            {
                viewContainer.Children.Clear();
                foreach (var tab in Tabs.Where(t => t.TabView != null))
                {
                    tab.TabView.IsVisible = false;
                    viewContainer.Children.Add(tab.TabView);
                }
                return;
            }

            if (propertyName == IsTabBarOnTopProperty.PropertyName)
            {
                SetTabBarPosition();
            }            
        }

        private RowDefinition AutoRowDefinition => new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) };
        private RowDefinition StarRowDefinition => new RowDefinition { Height = new GridLength(1, GridUnitType.Star) };
        private void SetTabBarPosition()
        {
            tabViewGrid.Children.Clear();
            tabViewGrid.RowDefinitions.Clear();
            if (IsTabBarOnTop)
            {
                tabViewGrid.RowDefinitions.Add(AutoRowDefinition);
                tabViewGrid.RowDefinitions.Add(StarRowDefinition);
                tabViewGrid.Children.Add(tabsLayout, 0, 0);
                tabViewGrid.Children.Add(viewContainer, 0, 1);
            }
            else
            {
                tabViewGrid.RowDefinitions.Add(StarRowDefinition);
                tabViewGrid.RowDefinitions.Add(AutoRowDefinition);
                tabViewGrid.Children.Add(viewContainer, 0, 0);
                tabViewGrid.Children.Add(tabsLayout, 0, 1);
            }

            IsBorderOnBottom = IsTabBarOnTop;
            IsSliderOnBottom = IsTabBarOnTop;
        }

        public static readonly BindableProperty IsTabBarOnTopProperty =
            BindableProperty.Create(
                nameof(IsTabBarOnTop),
                typeof(bool),
                typeof(PXTabsView),
                false,
                BindingMode.OneWay);

        public bool IsTabBarOnTop
        {
            get => (bool)GetValue(IsTabBarOnTopProperty);
            set => SetValue(IsTabBarOnTopProperty, value);
        }
    }
}