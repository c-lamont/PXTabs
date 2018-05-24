using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Plugin.ProXamTabs.Shared
{
    public abstract class BasePXTabsLayout : ContentView
    {
        public abstract PXTabsLayout TabsLayout { get; }

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
                TabsLayout.BorderView.BackgroundColor = BorderColor;
                return;
            }

            if (propertyName == IsBorderVisibleProperty.PropertyName)
            {
                TabsLayout.BorderView.IsVisible = IsBorderVisible;
                return;
            }

            if (propertyName == IsBorderOnBottomProperty.PropertyName)
            {
                SetBorderPosition();
                return;
            }

            if (propertyName == SliderColorProperty.PropertyName)
            {
                TabsLayout.SliderView.BackgroundColor = SliderColor;
                return;
            }

            if (propertyName == IsSliderVisibleProperty.PropertyName)
            {
                TabsLayout.SliderView.IsVisible = IsSliderVisible;
                return;
            }

            if (propertyName == WidthProperty.PropertyName)
            {
                SetSliderWidth();
                return;
            }

            if (propertyName == IsSliderOnBottomProperty.PropertyName)
            {
                SetSliderLocation();
                return;
            }

            if (propertyName == BackgroundImageSourceProperty.PropertyName)
            {
                TabsLayout.BackgroundImage.Source = BackgroundImageSource;
                return;
            }

            if (propertyName == SelectedTabIndexProperty.PropertyName)
            {
                TabSelected(SelectedTabIndex);
                return;
            }
        }

        public void SetTabs()
        {
            TabsLayout.TabsGrid.Children.Clear();
            foreach (var tab in Tabs)
            {
                var index = Tabs.IndexOf(tab);
                TabsLayout.TabsGrid.Children.Add(tab, index, 0);
                tab.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => TabSelected(tab)) });
            }
            SetSliderWidth();
            SetSliderLocation();
            TabSelected(SelectedTabIndex);
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

        private void TabSelected(int index)
        {            
            if (Tabs?.Count() > index)
            {
                TabSelected(Tabs.ElementAt(index));
            }
        }

        public static readonly BindableProperty SelectedTabIndexProperty =
            BindableProperty.Create(
                nameof(SelectedTabIndex),
                typeof(int),
                typeof(BasePXTabsLayout),
                0,
                BindingMode.TwoWay);

        public int SelectedTabIndex
        {
            get => (int)GetValue(SelectedTabIndexProperty);
            set => SetValue(SelectedTabIndexProperty, value);
        }

        private void SetSliderWidth()
        {
            if (Tabs != null)
            {
                TabsLayout.SliderView.WidthRequest = (this.Width / Tabs.Count());
                SetSliderPosition(Tabs.IndexOf(Tabs.FirstOrDefault(t => t.IsSelected)));
            }
        }

        private void SetSliderLocation()
        {
            var yPos = IsSliderOnBottom ? 1 : 0;
            AbsoluteLayout.SetLayoutBounds(TabsLayout.SliderView, new Rectangle(0, yPos, TabsLayout.SliderView.Width, TabsLayout.SliderView.Height));
            AbsoluteLayout.SetLayoutFlags(TabsLayout.SliderView, AbsoluteLayoutFlags.PositionProportional);
        }

        private void SetSliderPosition(int index)
        {
            var xPos = TabsLayout.SliderView.WidthRequest * (index);
            TabsLayout.SliderView.TranslateTo(xPos, 0, 250, Easing.SinInOut);
        }

        private void SetBorderPosition()
        {
            var yPos = IsBorderOnBottom ? 1 : 0;
            AbsoluteLayout.SetLayoutBounds(TabsLayout.BorderView, new Rectangle(0, yPos, 1, 0.5));
            AbsoluteLayout.SetLayoutFlags(TabsLayout.BorderView, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
        }

        public static readonly BindableProperty TabSelectedCommandProperty =
            BindableProperty.Create(
                nameof(TabSelectedCommand),
                typeof(Command<PXTab>),
                typeof(BasePXTabsLayout),
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
                typeof(BasePXTabsLayout),
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
                typeof(BasePXTabsLayout),
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
                typeof(BasePXTabsLayout),
                true,
                BindingMode.OneWay);

        public bool IsBorderVisible
        {
            get => (bool)GetValue(IsBorderVisibleProperty);
            set => SetValue(IsBorderVisibleProperty, value);
        }

        public static readonly BindableProperty IsBorderOnBottomProperty =
           BindableProperty.Create(
               nameof(IsBorderOnBottom),
               typeof(bool),
               typeof(BasePXTabsLayout),
               false,
               BindingMode.OneWay);

        public bool IsBorderOnBottom
        {
            get => (bool)GetValue(IsBorderOnBottomProperty);
            set => SetValue(IsBorderOnBottomProperty, value);
        }

        public static readonly BindableProperty SliderColorProperty =
            BindableProperty.Create(
                nameof(SliderColor),
                typeof(Color),
                typeof(BasePXTabsLayout),
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
                typeof(BasePXTabsLayout),
                true,
                BindingMode.OneWay);

        public bool IsSliderVisible
        {
            get => (bool)GetValue(IsSliderVisibleProperty);
            set => SetValue(IsSliderVisibleProperty, value);
        }

        public static readonly BindableProperty IsSliderOnBottomProperty =
            BindableProperty.Create(
                nameof(IsSliderOnBottom),
                typeof(bool),
                typeof(BasePXTabsLayout),
                false,
                BindingMode.OneWay);

        public bool IsSliderOnBottom
        {
            get => (bool)GetValue(IsSliderOnBottomProperty);
            set => SetValue(IsSliderOnBottomProperty, value);
        }

        public static readonly BindableProperty BackgroundImageSourceProperty =
            BindableProperty.Create(
                nameof(BackgroundImageSource),
                typeof(ImageSource),
                typeof(BasePXTabsLayout),
                null,
                BindingMode.OneWay);

        public ImageSource BackgroundImageSource
        {
            get => (ImageSource)GetValue(BackgroundImageSourceProperty);
            set => SetValue(BackgroundImageSourceProperty, value);
        }
    }
}
