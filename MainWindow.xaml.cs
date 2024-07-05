using System.Windows;
using AuroraStarLauncher.Pages;
using iNKORE.UI.WPF.Modern.Media.Animation;
using iNKORE.UI.WPF.Modern;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using iNKORE.UI.WPF.Modern.Controls.Helpers;
using iNKORE.UI.WPF.Modern.Controls;
using Page = System.Windows.Controls.Page;

namespace AuroraStarLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Page Home = new HomePage();
        private Page VersionsManager = new VersionsManagerPage();
        private Page AccountManager = new AccountManagerPage();
        private Page Download = new DownloadPage();
        private Page Links = new LinksPage();
        private Page Helps = new HelpsPage();
        private Page Settings = new SettingsPage();
        private Page About = new AboutPage();
        private Page Test = new TestPage();
        public MainWindow()
        {
            InitializeComponent();

            NavView.Header = "首页";

            //默认主题
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;

            //默认页面
            CurrentPage.Content = new HomePage();
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
        private void NavigationTriggered(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                NavigateTo(typeof(int), args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                NavigateTo(Type.GetType(args.InvokedItemContainer.Tag.ToString()), args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavigateTo(Type navPageType, NavigationTransitionInfo transitionInfo)
        {
            Type preNavPageType = CurrentPage.Content.GetType();
            if (navPageType is not null && !Equals(navPageType, preNavPageType))
            {
                if (navPageType == typeof(HomePage))
                {
                    CurrentPage.Navigate(Home);
                    NavView.Header = "首页";
                }
                if (navPageType == typeof(AccountManagerPage))
                {
                    CurrentPage.Navigate(AccountManager);
                    NavView.Header = "账户管理";
                }
                if (navPageType == typeof(VersionsManagerPage))
                {
                    CurrentPage.Navigate(VersionsManager);
                    NavView.Header = "版本管理";
                }
                if (navPageType == typeof(DownloadPage))
                {
                    CurrentPage.Navigate(Download);
                    NavView.Header = "下载";
                }
                if (navPageType == typeof(LinksPage))
                {
                    CurrentPage.Navigate(Links);
                    NavView.Header = "联机";
                }
                if (navPageType == typeof(HelpsPage))
                {
                    CurrentPage.Navigate(Helps);
                    NavView.Header = "帮助";
                }
                if (navPageType == typeof(SettingsPage))
                {
                    CurrentPage.Navigate(Settings);
                    NavView.Header = "设置";
                }
                if (navPageType == typeof(AboutPage))
                {
                    CurrentPage.Navigate(About);
                    NavView.Header = "关于";
                }
                if (navPageType == typeof(TestPage))
                {
                    CurrentPage.Navigate(Test);
                    NavView.Header = "调试";
                }
            }
        }
    }
}