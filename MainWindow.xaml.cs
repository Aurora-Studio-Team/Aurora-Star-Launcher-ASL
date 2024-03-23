using iNKORE.UI.WPF.Modern.Controls;
using System.Windows;
using AuroraStarLauncher.Pages;
using iNKORE.UI.WPF.Modern.Media.Animation;
using iNKORE.UI.WPF.Modern;
using System.IO;
using System.Reflection;

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

            //默认主题
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;

            //默认页面
            frame.Content = new HomePage();
            try
            {
                //生成ASL文件夹
                string applicationDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string FolderName = "ASL";
                string FolderPath = Path.Combine(applicationDirectory, FolderName);
                if (!Directory.Exists(FolderPath))
                {
                    try
                    {
                        Directory.CreateDirectory(FolderPath);
                    }
                    catch
                    {
                    }
                }

                //生成Config.json文件
                string FileName = "config.json";
                string FilePath = Path.Combine(FolderPath, FileName);
                if (!File.Exists(FilePath))
                {
                    try
                    {
                        using (File.Create(FilePath)) ;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch
            {

            }

        }
        //导航栏
        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
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
                if (navPageType == typeof(VersionsManagerPage))
                {
                    frame.Content = new VersionsManagerPage();
                }
                if (navPageType == typeof(DownloadPage))
                {
                    frame.Content = new DownloadPage();
                }
                if (navPageType == typeof(LinksPage))
                {
                    frame.Content = new LinksPage();
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