using iNKORE.UI.WPF.Modern;
using iNKORE.UI.WPF.Modern.Controls;
using System.Windows;
using System.Windows.Controls;
using Page = System.Windows.Controls.Page;

namespace AuroraStarLauncher.Pages
{
    /// <summary>
    /// SettingsPage.xaml 的交互逻辑
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        // 主题切换
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
                Theme_Dark.IsChecked = false;
                Footer_Tip.Severity = InfoBarSeverity.Success;
                Footer_Tip.Title = "切换成功！";
                Footer_Tip.IsOpen = true;
            }
            catch
            {
                Footer_Tip.Severity = InfoBarSeverity.Error;
                Footer_Tip.Title = "切换失败！";
                Footer_Tip.IsOpen = true;
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
                Theme_Light.IsChecked = false;
                Footer_Tip.Severity = InfoBarSeverity.Success;
                Footer_Tip.Title = "切换成功！";
                Footer_Tip.IsOpen = true;
            }
            catch
            {
                Footer_Tip.Severity = InfoBarSeverity.Error;
                Footer_Tip.Title = "切换失败！";
                Footer_Tip.IsOpen = true;
            }
        }
    }
}
