using iNKORE.UI.WPF.Modern.Controls;
using System.Windows;
using AuroraStarLauncher.Pages;
using iNKORE.UI.WPF.Modern.Media.Animation;
using iNKORE.UI.WPF.Modern;
using System.IO;
using System.Reflection;
using System.Windows.Controls;

namespace AuroraStarLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static iNKORE.UI.WPF.Modern.Controls.Frame main_frame { get; set; } = new iNKORE.UI.WPF.Modern.Controls.Frame();

        public MainWindow()
        {
            InitializeComponent();

            main_frame = frame;
            NavView.Header = "启动";

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
            if (navPageType is not null && !Equals(navPageType, preNavPageType))
            {
                if (navPageType == typeof(HomePage))
                {
                    frame.Content = new HomePage();
                    NavView.Header = "启动";
                }
                if (navPageType == typeof(VersionsManagerPage))
                {
                    frame.Content = new VersionsManagerPage();
                    NavView.Header = "版本管理";
                }
                if (navPageType == typeof(DownloadPage))
                {
                    frame.Content = new DownloadPage();
                    NavView.Header = "下载";
                }
                if (navPageType == typeof(LinksPage))
                {
                    frame.Content = new LinksPage();
                    NavView.Header = "联机";
                }
                if (navPageType == typeof(HelpsPage))
                {
                    frame.Content = new HelpsPage();
                    NavView.Header = "帮助";
                }
                if (navPageType == typeof(SettingsPage))
                {
                    frame.Content = new SettingsPage();
                    NavView.Header = "设置";
                }
                if (navPageType == typeof(AboutPage))
                {
                    frame.Content = new AboutPage();
                    NavView.Header = "关于";
                }
            }       
        }
    }
}