using Xamarin.Forms;

namespace PXTabs
{
    public partial class PXTab : ContentView
    {
        public PXTab()
        {
            InitializeComponent();
        }

        public int TabId { get; set; }

        private void SetAll()
        {
            SetImageSource();
            SetImageSize();
            SetText();
            SetTextColor();
            SetTextAttribute();
        }

        private void SetSelectedState()
        {
            SetImageSource();
            SetTextColor();
            SetTextAttribute();
        }

        private void SetImageSource()
        {
            tabImage.Source = IsSelected ? SelectedImage : UnselectedImage;
        }

        private void SetImageSize()
        {
            AbsoluteLayout.SetLayoutBounds(tabImage, new Rectangle(.5, .5, ImageSize, ImageSize));
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

        private void SetTextAttribute()
        {
            tabLabel.FontAttributes = IsSelected ? FontAttributes.Bold : FontAttributes.None;
        }

        private void SetTextSize()
        {
            tabLabel.FontSize = TextSize;
        }

        private void SetBadge()
        {
            badgeLayout.IsVisible = BadgeCount > 0;
            badgeLabel.Text = BadgeCount > 99 ? "99" : BadgeCount.ToString();
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
                SetText();
                return;
            }

            if (propertyName == UnSelectedColorProperty.PropertyName)
            {
                SetText();
                return;
            }

            if (propertyName == SelectedImageProperty.PropertyName)
            {
                SetImageSource();
                return;
            }

            if (propertyName == UnselectedImageProperty.PropertyName)
            {
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
                SetBadge();
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
    }
}
