﻿using System.Windows;
using StarLight_Core.Authentication;
using MessageBox = iNKORE.UI.WPF.Modern.Controls.MessageBox;
using System.Diagnostics;
using StarLight_Core.Launch;
using StarLight_Core.Models.Launch;
using StarLight_Core.Models.Authentication;
using Page = System.Windows.Controls.Page;
using StarLight_Core.Enum;

namespace AuroraStarLauncher.Pages.LoginPages
{
    /// <summary>
    /// MicrosoftLoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class MicrosoftLoginPage : Page
    {

        private MicrosoftAccount userInfo { get; set; }

        public MicrosoftLoginPage()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Microsoft网页加载过慢，如无法访问，请使用加速器等网络（代理）工具！", "温馨提示");
            var auth = new MicrosoftAuthentication("e1e383f9-59d9-4aa2-bf5e-73fe83b15ba0");
            var deviceCodeInfo = await auth.RetrieveDeviceCodeInfo();
            Process.Start("explorer.exe", deviceCodeInfo.VerificationUri);
            MessageBox.Show("请在浏览器中输入您的用户验证代码：" + deviceCodeInfo.UserCode, "Microsoft验证");
            var tokenInfo = await auth.GetTokenResponse(deviceCodeInfo);
            userInfo = await auth.MicrosoftAuthAsync(tokenInfo, x =>
            {
                Console.WriteLine(x);
            });
            MessageBox.Show("欢迎回来！" + userInfo.Name, "欢迎");
            User_Name.Text = userInfo.Name;
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
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
                        BaseAccount = userInfo // 账户
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.main_frame.Content = new VersionsManagerPage();
        }
    }
}
