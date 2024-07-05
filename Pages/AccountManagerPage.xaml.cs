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
using AuroraStarLauncher.Pages.LoginPages;

namespace AuroraStarLauncher.Pages
{
    /// <summary>
    /// AccountMangerPage.xaml 的交互逻辑
    /// </summary>
    public partial class AccountManagerPage : Page
    {
        public AccountManagerPage()
        {
            InitializeComponent();

            MicrosoftLogin_Switch.Content = new MicrosoftLoginPage();
        }
    }
}
