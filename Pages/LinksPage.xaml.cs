using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;

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

        private async Task pn_Login_ALL_Click (object sender, RoutedEventArgs e)
        {
            string PNloginUser = pn_Login_User_Name.Text;
            string PNloginPassword = pn_Login_User_Password.Text;
            var PNLoginData = new
            {
                user = PNloginUser,
                password = PNloginPassword,
            };
            var json = JsonConvert.SerializeObject(PNLoginData);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);

                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage res = await client.PostAsync("https://PolarisNetwork.cloud:5555/api/v1/Auth/login", content);

                    if (res.IsSuccessStatusCode)
                    {
                        string responseJson = await res.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        throw new HttpRequestException($"HTTP POST 请求失败，状态代码 {res.StatusCode}");
                    }
                }
            }
            catch
            {
                MessageBox.Show("登陆失败", "提示");
            }

            MessageBox.Show("登陆", "提示");
        }
    }
}
