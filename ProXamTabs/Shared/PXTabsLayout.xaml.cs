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
	public partial class PXTabsLayout : BasePXTabsLayout
    {
		public PXTabsLayout ()
		{
			InitializeComponent ();
		}

        public override PXTabsLayout TabsLayout => this;

        public BoxView SliderView => sliderView;
        public BoxView BorderView => borderView;
        public Grid TabsGrid => tabsGrid;
        public Image BackgroundImage => backgroundImage;
    }
}