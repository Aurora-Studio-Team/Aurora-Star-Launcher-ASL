using iNKORE.UI.WPF.Modern.Controls;
using StarLight_Core.Installer;
using StarLight_Core.Utilities;
using System.Windows.Controls;
using Page = System.Windows.Controls.Page;

namespace AuroraStarLauncher.Pages
{
    /// <summary>
    /// DownloadPage.xaml 的交互逻辑
    /// </summary>
    public partial class DownloadPage : Page
    {
        public DownloadPage()
        {
            InitializeComponent();
        }

        private async void GetVersionsList_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                Minecraft_List.Items.Clear();
                await Task.Run(async () =>
                {
                    var gameCores = await InstallUtil.GetGameCoresAsync();
                    var res = await InstallUtil.GetGameCoresAsync();
                    res.ToList().ForEach(x =>
                    {
                        if (x.Type is "release")
                            Dispatcher.BeginInvoke(() => { Minecraft_List.Items.Add(x); });
                    });
                });
                Footer_Tip.Severity = InfoBarSeverity.Success;
                Footer_Tip.Title = "版本获取成功！";
                Footer_Tip.IsOpen = true;
            }
            catch
            {
                Footer_Tip.Severity = InfoBarSeverity.Error;
                Footer_Tip.Title = "无法获取版本列表！";
                Footer_Tip.IsOpen = true;
            }
        }

        private async void Install_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                string id = (sender as ListBox).SelectedItem.ToString();
                MessageBox.Show(id);
                MinecraftInstaller installer = new MinecraftInstaller(id);
                await installer.InstallAsync(id, true);

                Footer_Tip.Severity = InfoBarSeverity.Success;
                Footer_Tip.Title = "版本安装成功！";
                Footer_Tip.IsOpen = true;
            }
            catch 
            {
                Footer_Tip.Severity = InfoBarSeverity.Error;
                Footer_Tip.Title = "版本安装失败！";
                Footer_Tip.IsOpen = true;
            }
        }
    }  
}
