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
using StarLight_Core.Utilities;

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

        private async void Pn_Login_ALL_Click (object sender, RoutedEventArgs e)
        {
            string pnLoginUser = pn_Login_User_Name.Text;
            string pnloginPassword = pn_Login_User_Password.Text;
            var pnLoginData = new
            {
                user = pnLoginUser,
                password = pnloginPassword,
            };
            var json = JsonConvert.SerializeObject(pnLoginData);
            try
            {
                var loginData =
                    await HttpUtil.SendHttpPostRequest("https://PolarisNetwork.cloud:5555/api/v1/Auth/login",
                        JsonConvert.SerializeObject(pnLoginData),"application/json");
                LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(loginData);
                
                //解析内容
                //Console.WriteLine("User: " + loginResponse.user);
                //Console.WriteLine("Login Time: " + loginResponse.loginTime);
                //Console.WriteLine("Token: " + loginResponse.token);
                //Console.WriteLine("PN: " + loginResponse.pn);
                //Console.WriteLine("Status: " + loginResponse.status);
                //Console.WriteLine("Message: " + loginResponse.msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("登陆失败" + ex, "提示");
            }
            MessageBox.Show("登陆", "提示");
        }
    }
    
    public class LoginResponse
    {
        public string user { get; set; }
        public DateTime loginTime { get; set; }
        public string token { get; set; }
        public int pn { get; set; }
        public bool status { get; set; }
        public string msg { get; set; }
    }
}
