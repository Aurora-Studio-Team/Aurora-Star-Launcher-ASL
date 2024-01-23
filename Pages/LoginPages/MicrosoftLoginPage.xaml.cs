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
using StarLight_Core.Authentication;
using StarLight_Core.Launch;
using HandyControl.Controls;
using MessageBox = iNKORE.UI.WPF.Modern.Controls.MessageBox;

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

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Microsoft网页加载过慢，如无法访问，请使用加速器等网络（代理）工具！", 
                "温馨提示"
                );
        }
    }
}
