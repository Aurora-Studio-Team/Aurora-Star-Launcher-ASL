using System.Windows;
using System.Windows.Controls;
using StarLight_Core.Authentication;
using MessageBox = iNKORE.UI.WPF.Modern.Controls.MessageBox;
using System.Diagnostics;

namespace AuroraStarLauncher.Pages.LoginPages
{
    /// <summary>
    /// MicrosoftLoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class MicrosoftLoginPage : Page
    {
        public MicrosoftLoginPage()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Microsoft网页加载过慢，如无法访问，请使用加速器等网络（代理）工具！", 
                "温馨提示"
                );
            var auth = new MicrosoftAuthentication("a0ceb477-0738-47fa-8c93-52d892aa866a");
            var deviceCodeInfo = await auth.RetrieveDeviceCodeInfo();
            Process.Start("explorer.exe", deviceCodeInfo.VerificationUri);
            MessageBox.Show(
                "请在浏览器中输入您的用户验证代码：" + deviceCodeInfo.UserCode, 
                "Microsoft验证"
                );
            var tokenInfo = await auth.GetTokenResponse(deviceCodeInfo);
            var userInfo = await auth.MicrosoftAuthAsync(tokenInfo, x =>
            {
                Console.WriteLine(x);
            });
            MessageBox.Show("欢迎回来！" + userInfo.Name, "欢迎");
            User_Name.Text = userInfo.Name;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
