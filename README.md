# PXTabs
- A tab layout that is more customizable and easier to use than trying to implement the native layouts. 
- Written entirely in Forms with no native code.
- Check out the `TabsPage` in the examples for implementation.

## NuGet
https://www.nuget.org/packages/pro.xamarin.forms.tabs/

## Implementation
All properties are bindable.

### PXTabsView
1. If implementing in Xaml, add the namespace `xmlns:pxTabs="clr-namespace:PXTabs;assembly=PXTabs"`.
2. Add the view to your page:
```
<pxTabs:PXTabsView
    x:Name="tabsView"
    BorderColor="Teal"
    SliderColor="Teal"
    IsBorderVisible="true"
    IsSliderVisible="true" />
```
3. Create a list of `PXTab`s and and them to the tab view: `tabsView.Tabs = [YourListOfTabs];`, or bind the list directly. The `PXTab` is fully customisable:
```
new PXTab()
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
```
4. Setting the `TabView` property of a `PXTab` will be the view that will be shown when the tab is selected.

### PXTabsLayout
If you do not want the `PXTabsView` to handle the switching of the views, you can simply use the `PXTabsLayout` which will give you the tab bar that you can place anywhere in your view. Use the `Command<PXTab> TabSelectedCommand` property to detect the change in tab selection. 
