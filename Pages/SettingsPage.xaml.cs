using iNKORE.UI.WPF.Modern;
using iNKORE.UI.WPF.Modern.Controls;
using StarLight_Core.Utilities;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Resources;
using Page = System.Windows.Controls.Page;

namespace AuroraStarLauncher.Pages
{
    /// <summary>
    /// SettingsPage.xaml 的交互逻辑
    /// </summary>
    public partial class SettingsPage : Page
    {
        public static ComboBox Java { get; set; } = new ComboBox();
        public static TextBox Window_W { get; set; } = new TextBox();
        public static TextBox Window_H { get; set; } = new TextBox();
        public static TextBox MemoryBox_Maxi { get; set; } = new TextBox();
        public static TextBox MemoryBox_Mini { get; set; } = new TextBox();

        public SettingsPage()
        {
            InitializeComponent();

            Java = Game_Java;
            Window_W = Game_Window_Width;
            Window_H = Game_Window_Height;
            MemoryBox_Maxi = Game_Maximum_Memory;
            MemoryBox_Mini = Game_Minimum_Memory;

            // 自动寻找Java
            var javaInfo = JavaUtil.GetJavas();
            string javaPath = javaInfo.First().JavaPath;
            Java.DisplayMemberPath = "JavaLibraryPath";
            Java.SelectedValuePath = "JavaLibraryPath";
            Java.ItemsSource = javaInfo;
            Java.SelectedItem = 0;
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

        private void LanguageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LanguageManager.Instance.ChangeLanguage(new CultureInfo((sender as ComboBox).SelectedItem.ToString()));
        }
    }
}
