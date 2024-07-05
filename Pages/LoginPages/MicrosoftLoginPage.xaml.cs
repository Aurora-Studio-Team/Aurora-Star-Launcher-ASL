using System.Windows;
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

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", "https://aurora.thzstudent.top/apps/asl/HowLogin/Microsoft/");
        }
    }
}
