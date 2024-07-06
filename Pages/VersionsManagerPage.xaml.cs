using StarLight_Core.Utilities;
using System.Windows.Controls;

namespace AuroraStarLauncher.Pages
{
    /// <summary>
    /// VersionsManagerPage.xaml 的交互逻辑
    /// </summary>
    public partial class VersionsManagerPage : Page
    {
        public static TextBox GamePath { get; set; } = new TextBox();
        public static ComboBox GameVer { get; set; } = new ComboBox();

        public VersionsManagerPage()
        {
            InitializeComponent();

            GamePath = Game_Path;
            GameVer = Game_Versions;

            // 自动寻找版本
            var versions = GameCoreUtil.GetGameCores(Game_Path.Text);
            Game_Versions.ItemsSource = versions;//绑定数据源
            Game_Versions.DisplayMemberPath = "Id";//设置comboBox显示的为版本Id
            Game_Versions.SelectedIndex = 0;
            Game_Versions_Manager_Settings_Name.Text = Game_Versions.SelectedValue != null ? Game_Versions.SelectedValue.ToString() : string.Empty;

        }
    }
}
