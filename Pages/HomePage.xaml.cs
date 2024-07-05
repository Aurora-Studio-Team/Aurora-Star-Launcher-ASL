using AuroraStarLauncher.Pages.LoginPages;
using StarLight_Core.Enum;
using StarLight_Core.Launch;
using StarLight_Core.Models.Launch;
using System.Windows.Controls;
using MessageBox = iNKORE.UI.WPF.Modern.Controls.MessageBox;

namespace AuroraStarLauncher.Pages
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
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
                        // BaseAccount = userInfo // 账户
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
                if (la.Status == Status.Succeeded)
                {
                    MessageBox.Show(la.Args.ToString());
                }
            }
            catch
            {
                MessageBox.Show("启动失败！");
            }
        }
    }
}
