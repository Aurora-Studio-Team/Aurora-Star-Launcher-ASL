using iNKORE.UI.WPF.Modern.Controls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AuroraStarLauncher.Pages;
using iNKORE.UI.WPF.Modern.Media.Animation;
using iNKORE.UI.WPF.Modern.Helpers.Styles;

namespace AuroraStarLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.Content = new HomePage();
        }
        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            AcrylicHelper.Apply(this, true);
        }
        private void NavigationView_ItemInvoked(iNKORE.UI.WPF.Modern.Controls.NavigationView sender, iNKORE.UI.WPF.Modern.Controls.NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                NavigationView_Navigate(typeof(int), args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                NavigationView_Navigate(Type.GetType(args.InvokedItemContainer.Tag.ToString()), args.RecommendedNavigationTransitionInfo);
            }
        }
        private void NavigationView_Navigate(Type navPageType, NavigationTransitionInfo transitionInfo)
        {
            Type preNavPageType = frame.Content.GetType();
            if (navPageType is not null && !Type.Equals(navPageType, preNavPageType))
            {
                if (navPageType == typeof(HomePage))
                {
                    frame.Content = new HomePage();
                }
                if (navPageType == typeof(DownloadPage))
                {
                    frame.Content = new DownloadPage();
                }
                if (navPageType == typeof(LinksPage))
                {
                    frame.Content = new LinksPage();
                }
                if (navPageType == typeof(NewsPage))
                {
                    frame.Content = new NewsPage();
                }
                if (navPageType == typeof(HelpsPage))
                {
                    frame.Content = new HelpsPage();
                }
                if (navPageType == typeof(SettingsPage))
                {
                    frame.Content = new SettingsPage();
                }
                if (navPageType == typeof(AboutPage))
                {
                    frame.Content = new AboutPage();
                }
            }
        }
    }
}