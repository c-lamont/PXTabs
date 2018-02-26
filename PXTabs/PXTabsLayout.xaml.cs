using Xamarin.Forms;

namespace PXTabs
{
    public partial class PXTabsLayout : BasePXTabsLayout
    {
        public PXTabsLayout()
        {
            InitializeComponent();
        }

        public override PXTabsLayout TabsLayout => this;

        public BoxView SliderView => sliderView;
        public BoxView BorderView => borderView;
        public Grid TabsGrid => tabsGrid;
    }
}
