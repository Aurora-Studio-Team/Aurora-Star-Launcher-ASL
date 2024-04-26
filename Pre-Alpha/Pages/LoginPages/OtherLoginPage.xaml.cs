using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using StarLight_Core.Authentication;
using MessageBox = iNKORE.UI.WPF.Modern.Controls.MessageBox;
using System.Diagnostics;
using StarLight_Core.Launch;
using StarLight_Core.Models.Launch;
using StarLight_Core.Models.Authentication;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using Page = System.Windows.Controls.Page;

namespace AuroraStarLauncher.Pages.LoginPages
{
    /// <summary>
    /// OtherLoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class OtherLoginPage : Page
    {
        public OtherLoginPage()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Start_1_Click(object sender, RoutedEventArgs e)
        {
            var auth = new UnifiedPassAuthenticator(User_Name_1.Text,User_Password_1.Password,Login_Server_1.Text);
            var account = await auth.UnifiedPassAuthAsync();
            try
            {
                LaunchConfig args = new() // 配置启动参数
                {
                    GameWindowConfig = new()
                    {
                        Height = int.Parse(SettingsPage.Window_H.Text), // 高
                        Width = int.Parse(SettingsPage.Window_W.Text), // 宽
                        IsFullScreen = false // 启用全屏,自动忽略上面的参数
                    },
                    Account = new()
                    {
                        BaseAccount = account // 账户
                    },
                    GameCoreConfig = new()
                    {
                        Root = VersionsManagerPage.GamePath.Text, // MC 路径(可以是绝对的也可以是相对的,自动判断)
                        Version = "1.16.5",
                        IsVersionIsolation = true,
                    },
                    JavaConfig = new()
                    {
                        JavaPath = SettingsPage.Java.SelectedValue + "\\javaw.exe", // Java 路径(绝对路径)
                        MaxMemory = int.Parse(SettingsPage.MemoryBox_Maxi.Text),
                        MinMemory = int.Parse(SettingsPage.MemoryBox_Mini.Text)
                    }
                };
                var launch = new MinecraftLauncher(args); // 实例化启动器
                var la = await launch.LaunchAsync(ReportProgress); // 启动
                static void ReportProgress(ProgressReport report)
                {
                    Console.WriteLine($"{report.Description} ({report.Percentage}%)"); // 显示当前操作与进度
                }
            }
            catch
            {
                MessageBox.Show("启动失败！");
            }
        }

        private void Versions_Manager_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.main_frame.Content = new VersionsManagerPage();
        }
    }
}
