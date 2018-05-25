using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.ProXamTabs.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PXTab : ContentView
    {
        public PXTab()
        {
            InitializeComponent();
        }

        public int TabId { get; set; }

        public Label TabLabel => tabLabel;
        public Image TabImageSelected => tabImageSelected;
        public Image TabImageUnselected => tabImageUnselected;
        public Frame BadgeFrame => badgeLayout;
        public Label BadgeLabel => badgeLabel;

        private void SetSelectedState()
        {
            SetImageSource();
            SetTextColor();
            SetTabView();
            SetTextAttribute();
        }

        private void SetTextAttribute()
        {
            tabLabel.FontAttributes = IsSelected ? FontAttributes.Bold : FontAttributes.None;
        }

        private void SetImageSource()
        {
            tabImageSelected.IsVisible = IsSelected;
            tabImageUnselected.IsVisible = !IsSelected;
        }

        private void SetImageSize()
        {
            AbsoluteLayout.SetLayoutBounds(tabImageUnselected, new Rectangle(.5, .5, ImageSize, ImageSize));
            AbsoluteLayout.SetLayoutBounds(tabImageSelected, new Rectangle(.5, .5, ImageSize, ImageSize));
            tabImageLayout.WidthRequest = ImageSize + 12;
            tabImageLayout.HeightRequest = ImageSize + 12;
        }

        private void SetText()
        {
            tabLabel.Text = Text;
            tabLabel.IsVisible = string.IsNullOrEmpty(Text) ? false : true;
        }

        private void SetTextColor()
        {
            tabLabel.TextColor = IsSelected ? SelectedColor : UnSelectedColor;
        }

        private void SetTextSize()
        {
            tabLabel.FontSize = TextSize;
        }

        private void SetBadgeCount()
        {
            badgeLayout.IsVisible = BadgeCount > 0;
            badgeLabel.Text = BadgeCount > 99 ? "99" : BadgeCount.ToString();
        }

        private void SetBadgeColor()
        {
            badgeLayout.BackgroundColor = BadgeColor;
        }

        private void SetTabView()
        {
            if (TabView != null)
            {
                TabView.IsVisible = IsSelected;
            }
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == IsSelectedProperty.PropertyName)
            {
                SetSelectedState();
                return;
            }

            if (propertyName == TextProperty.PropertyName)
            {
                SetText();
                return;
            }

            if (propertyName == SelectedColorProperty.PropertyName)
            {
                SetTextColor();
                return;
            }

            if (propertyName == UnSelectedColorProperty.PropertyName)
            {
                SetTextColor();
                return;
            }

            if (propertyName == SelectedImageProperty.PropertyName)
            {
                tabImageSelected.Source = SelectedImage;
                SetImageSource();
                return;
            }

            if (propertyName == UnselectedImageProperty.PropertyName)
            {
                tabImageUnselected.Source = UnselectedImage;
                SetImageSource();
                return;
            }

            if (propertyName == ImageSizeProperty.PropertyName)
            {
                SetImageSize();
                return;
            }

            if (propertyName == TextSizeProperty.PropertyName)
            {
                SetTextSize();
                return;
            }

            if (propertyName == BadgeCountProperty.PropertyName)
            {
                SetBadgeCount();
                return;
            }

            if (propertyName == BadgeColorProperty.PropertyName)
            {
                SetBadgeColor();
                return;
            }

            if (propertyName == TabPaddingProperty.PropertyName)
            {
                tabContainer.Padding = TabPadding;
                return;
            }            
        }

        public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(
                nameof(IsSelected),
                typeof(bool),
                typeof(PXTab),
                false,
                BindingMode.OneWay);

        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public static readonly BindableProperty SelectedColorProperty =
            BindableProperty.Create(
                nameof(SelectedColor),
                typeof(Color),
                typeof(PXTab),
                Color.Blue,
                BindingMode.OneWay);

        public Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }

        public static readonly BindableProperty UnSelectedColorProperty =
            BindableProperty.Create(
                nameof(UnSelectedColor),
                typeof(Color),
                typeof(PXTab),
                Color.Gray,
                BindingMode.OneWay);

        public Color UnSelectedColor
        {
            get => (Color)GetValue(UnSelectedColorProperty);
            set => SetValue(UnSelectedColorProperty, value);
        }

        public static readonly BindableProperty SelectedImageProperty =
            BindableProperty.Create(
                nameof(SelectedImage),
                typeof(ImageSource),
                typeof(PXTab),
                null,
                BindingMode.OneWay);

        public ImageSource SelectedImage
        {
            get => (ImageSource)GetValue(SelectedImageProperty);
            set => SetValue(SelectedImageProperty, value);
        }

        public static readonly BindableProperty UnselectedImageProperty =
            BindableProperty.Create(
                nameof(UnselectedImage),
                typeof(ImageSource),
                typeof(PXTab),
                null,
                BindingMode.OneWay);

        public ImageSource UnselectedImage
        {
            get => (ImageSource)GetValue(UnselectedImageProperty);
            set => SetValue(UnselectedImageProperty, value);
        }

        public static readonly BindableProperty ImageSizeProperty =
            BindableProperty.Create(
                nameof(ImageSize),
                typeof(double),
                typeof(PXTab),
                24d,
                BindingMode.OneWay);

        public double ImageSize
        {
            get => (double)GetValue(ImageSizeProperty);
            set => SetValue(ImageSizeProperty, value);
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(
                nameof(Text),
                typeof(string),
                typeof(PXTab),
                string.Empty,
                BindingMode.OneWay);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty TextSizeProperty =
            BindableProperty.Create(
                nameof(TextSize),
                typeof(double),
                typeof(PXTab),
                14d,
                BindingMode.OneWay);

        public double TextSize
        {
            get => (double)GetValue(TextSizeProperty);
            set => SetValue(TextSizeProperty, value);
        }

        public static readonly BindableProperty BadgeCountProperty =
            BindableProperty.Create(
                nameof(BadgeCount),
                typeof(int),
                typeof(PXTab),
                0,
                BindingMode.OneWay);

        public int BadgeCount
        {
            get => (int)GetValue(BadgeCountProperty);
            set => SetValue(BadgeCountProperty, value);
        }

        public static readonly BindableProperty BadgeColorProperty =
           BindableProperty.Create(
               nameof(BadgeColor),
               typeof(Color),
               typeof(PXTab),
               Color.Red,
               BindingMode.OneWay);

        public Color BadgeColor
        {
            get => (Color)GetValue(BadgeColorProperty);
            set => SetValue(BadgeColorProperty, value);
        }

        public static readonly BindableProperty TabViewProperty =
           BindableProperty.Create(
               nameof(TabView),
               typeof(View),
               typeof(PXTab),
               null,
               BindingMode.OneWay);

        public View TabView
        {
            get => (View)GetValue(TabViewProperty);
            set => SetValue(TabViewProperty, value);
        }

        public static readonly BindableProperty TabPaddingProperty =
            BindableProperty.Create(
                nameof(TabPadding),
                typeof(int),
                typeof(PXTab),
                8,
                BindingMode.OneWay);

        public int TabPadding
        {
            get => (int)GetValue(TabPaddingProperty);
            set => SetValue(TabPaddingProperty, value);
        }
    }
}