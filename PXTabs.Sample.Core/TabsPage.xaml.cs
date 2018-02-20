using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PXTabs.Sample.Core
{
    public partial class TabsPage : ContentPage
    {
        public TabsPage()         {             InitializeComponent();             SetTabs();         }          private void SetTabs()         {             List<PXTab> tabs = new List<PXTab>()             {                  new PXTab(),                  new PXTab(),                  new PXTab()             };             tabsLayout.Tabs = tabs;
        }
    }
}
