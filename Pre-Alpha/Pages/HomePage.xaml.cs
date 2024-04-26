using AuroraStarLauncher.Pages.LoginPages;
using System.Windows.Controls;

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

            Login_Pages.Navigate(typeof(MicrosoftLoginPage));
        }

        private void Use_Login_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var t = (ComboBoxItem)Use_Login.SelectedItem;
                switch (t.Tag)
                {
                    case "Microsoft":
                        Login_Pages.Navigate(typeof(MicrosoftLoginPage));
                        break;
                    case "Offine":
                        Login_Pages.Navigate(typeof(OffineLoginPage));
                        break;
                    case "Other":
                        Login_Pages.Navigate(typeof(OtherLoginPage));
                        break;
                }
            }
            catch { }
        
        }
    }
}
