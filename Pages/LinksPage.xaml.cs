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
using iNKORE.UI.WPF.Modern.Media.Animation;

namespace AuroraStarLauncher.Pages
{
    /// <summary>
    /// LinksPage.xaml 的交互逻辑
    /// </summary>
    public partial class LinksPage : Page
    {
        public LinksPage()
        {
            InitializeComponent();
        }

        private void pm_Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch
            {
                MessageBox.Show("无法连接至星光网络服务器，可能是网络原因，如多次无法登录/注册，则可能已被DDOS。", "提示");
            }
        }
    }
}
