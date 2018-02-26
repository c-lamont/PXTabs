using System.Collections.Generic;
using Xamarin.Forms;

namespace PXTabs.Sample.Core
{
    public partial class TabsPage : ContentPage
    {
        public TabsPage()         {             InitializeComponent();             SetTabs();         }          private void SetTabs()         {             List<PXTab> tabs = new List<PXTab>()             {                  CreateTab("Home", "ic_home_32dp", "ic_home_gray_32dp", Color.Gray, Color.Gray, 0),
                 CreateTab("Contacts", "ic_contact_32dp", "ic_contact_gray_32dp", Color.Blue, Color.Gray, 3),
                 CreateTab("Search", "ic_search_32dp", "ic_search_gray_32dp", Color.Red, Color.Gray, 200)             };             tabsLayout.Tabs = tabs;
        }

        private PXTab CreateTab(string text, string selectedImage, string unselectedImage, Color selectedColor, Color unselectedColor, int badgeCount = 0)
        {
            return new PXTab()
            {
                Text = text,
                SelectedImage = selectedImage,
                UnselectedImage = unselectedImage,
                SelectedColor = selectedColor,
                UnSelectedColor = unselectedColor,
                TextSize = 12,
                ImageSize = 24,
                BadgeCount = badgeCount,
                BadgeColor = Color.Blue
            };
        }
    }
}
