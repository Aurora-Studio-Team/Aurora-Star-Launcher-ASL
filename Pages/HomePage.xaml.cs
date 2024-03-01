using AuroraStarLauncher.Pages.LoginPages;

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
            ON.Content = new OffineLoginPage();
            LT.Content = new OtherLoginPage();
        }
    }
}
