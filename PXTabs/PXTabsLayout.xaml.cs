using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PXTabs
{
    public partial class PXTabsLayout : ContentView
    {
        public PXTabsLayout()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TabsProperty.PropertyName)
            {
                SetTabs();
                return;
            }

            if (propertyName == BorderColorProperty.PropertyName)
            {
                borderView.BackgroundColor = BorderColor;
                return;
            }

            if (propertyName == IsBorderVisibleProperty.PropertyName)
            {
                borderView.IsVisible = IsBorderVisible;
                return;
            }

            if (propertyName == SliderColorProperty.PropertyName)
            {
                sliderView.BackgroundColor = SliderColor;
                return;
            }

            if (propertyName == IsSliderVisibleProperty.PropertyName)
            {
                sliderView.IsVisible = IsSliderVisible;
                return;
            }

            if (propertyName == WidthProperty.PropertyName)
            {
                SetSliderWidth();
                return;
            }
        }

        public void SetTabs()
        {
            tabsGrid.Children.Clear();
            foreach (var tab in Tabs)
            {
                var index = Tabs.IndexOf(tab);
                tabsGrid.Children.Add(tab, index, 0);
                tab.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => TabSelected(tab)) });
            }
            SetSliderWidth();
            TabSelected(Tabs.ElementAt(0));
        }

        private void TabSelected(PXTab selectedTab)
        {
            foreach (var tab in Tabs)
            {
                tab.IsSelected = tab == selectedTab;
            }
            TabSelectedCommand?.Execute(selectedTab);

            SetSliderPosition(Tabs.IndexOf(selectedTab));
        }

        private void SetSliderWidth()
        {
            if (Tabs != null)
            {
                sliderView.WidthRequest = (this.Width / Tabs.Count());
            }
        }

        private void SetSliderPosition(int index)
        {
            var xPos = sliderView.Width * (index);
            sliderView.TranslateTo(xPos, 0, 250, Easing.SinInOut);
        }

        public static readonly BindableProperty TabSelectedCommandProperty =
            BindableProperty.Create(
                nameof(TabSelectedCommand),
                typeof(Command<PXTab>),
                typeof(PXTabsLayout),
                null,
                BindingMode.OneWay);

        public Command<PXTab> TabSelectedCommand
        {
            get => (Command<PXTab>)GetValue(TabSelectedCommandProperty);
            set => SetValue(TabSelectedCommandProperty, value);
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

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(
                nameof(BorderColor),
                typeof(Color),
                typeof(PXTabsLayout),
                Color.Gray,
                BindingMode.OneWay);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty IsBorderVisibleProperty =
            BindableProperty.Create(
                nameof(IsBorderVisible),
                typeof(bool),
                typeof(PXTabsLayout),
                true,
                BindingMode.OneWay);

        public bool IsBorderVisible
        {
            get => (bool)GetValue(IsBorderVisibleProperty);
            set => SetValue(IsBorderVisibleProperty, value);
        }

        public static readonly BindableProperty SliderColorProperty =
            BindableProperty.Create(
                nameof(SliderColor),
                typeof(Color),
                typeof(PXTabsLayout),
                Color.Gray,
                BindingMode.OneWay);

        public Color SliderColor
        {
            get => (Color)GetValue(SliderColorProperty);
            set => SetValue(SliderColorProperty, value);
        }

        public static readonly BindableProperty IsSliderVisibleProperty =
            BindableProperty.Create(
                nameof(IsSliderVisible),
                typeof(bool),
                typeof(PXTabsLayout),
                true,
                BindingMode.OneWay);

        public bool IsSliderVisible
        {
            get => (bool)GetValue(IsSliderVisibleProperty);
            set => SetValue(IsSliderVisibleProperty, value);
        }
    }
}
