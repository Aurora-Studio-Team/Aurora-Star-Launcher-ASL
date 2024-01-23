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
using iNKORE.UI.WPF.Modern.Controls;

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
            MS.Content = new MicrosoftLoginPage();

        }
    }
}
