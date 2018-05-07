using System.Collections.Generic;
using Plugin.ProXamTabs.Shared;
using Xamarin.Forms;

namespace PXTabs.Sample.Core
{
    public partial class TabsPage : ContentPage
    {
        public TabsPage()         {             InitializeComponent();             SetTabs();         }          private void SetTabs()         {             List<PXTab> tabs = new List<PXTab>()             {                  CreateTab(new HomeView(), "Home", "ic_home_32dp", "ic_home_gray_32dp", Color.Gray, Color.Gray, 0),
                 CreateTab(new ContactsView(), "Contacts", "ic_contact_32dp", "ic_contact_gray_32dp", Color.Blue, Color.Gray, 3),
                 CreateTab(new SearchView(), "Search", "ic_search_32dp", "ic_search_gray_32dp", Color.Red, Color.Gray, 200)             };

            tabsView.TabSelectedCommand = new Command<PXTab>(tab => Title = tab.Text);
            tabsView.Tabs = tabs;
        }

        private PXTab CreateTab(View view, string text, string selectedImage, string unselectedImage, Color selectedColor, Color unselectedColor, int badgeCount = 0)
        {
            return new PXTab()
            {
                TabView = view,
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

            return new PXTab()
            {
                TabView = new HomeView(),
                Text = "Home",
                SelectedImage = "tab_home",
                UnselectedImage = "tab_home_gray",
                SelectedColor = Color.Gray,
                UnSelectedColor = Color.Black,
                TextSize = 12,
                ImageSize = 24,
                BadgeCount = 3,
                BadgeColor = Color.Blue
            };
        }
    }
}
