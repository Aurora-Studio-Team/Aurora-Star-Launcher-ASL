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
using iNKORE.UI.WPF.Modern.Controls;
using Newtonsoft.Json;
using StarLight_Core.Utilities;
using MessageBox = iNKORE.UI.WPF.Modern.Controls.MessageBox;
using Page = System.Windows.Controls.Page;
using HandyControl.Controls;

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
                Console.WriteLine("User: " + loginResponse.user);
                //Console.WriteLine("Login Time: " + loginResponse.loginTime);
                //Console.WriteLine("Token: " + loginResponse.token);
                //Console.WriteLine("PN: " + loginResponse.pn);
                //Console.WriteLine("Status: " + loginResponse.status);
                //Console.WriteLine("Message: " + loginResponse.msg);

                pn_User_Name.Content = loginResponse.user;

                Growl.Success("登录成功！", "SuccessMsg");
                Growl.Success("欢迎回来,"+loginResponse.user+"!", "SuccessMsg");
            }
            catch (Exception ex)
            {
                MessageBox.Show("登陆失败" + ex, "提示");
            }
        }

        private async void pn_Reg_ALL_Click(object sender, RoutedEventArgs e)
        {
            string pnLoginUser = pn_Reg_User_Name.Text;
            string pnloginPassword = pn_Reg_User_Password.Text;
            string pnloginEmail = pn_Reg_User_Email.Text;
            var pnRegData = new
            {
                user = pnLoginUser,
                password = pnloginPassword,
                email = pnloginEmail,
            };
            var json = JsonConvert.SerializeObject(pnRegData);
         
            try
            {
                var loginData =
                    await HttpUtil.SendHttpPostRequest("https://PolarisNetwork.cloud:5555/api/v1/Auth/register",
                        JsonConvert.SerializeObject(pnRegData), "application/json");
                LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(loginData);

                //解析内容
                //Console.WriteLine("User: " + loginResponse.user);
                //Console.WriteLine("Login Time: " + loginResponse.loginTime);
                //Console.WriteLine("Token: " + loginResponse.token);
                //Console.WriteLine("PN: " + loginResponse.pn);
                //Console.WriteLine("Status: " + loginResponse.status);
                //Console.WriteLine("Message: " + loginResponse.msg);、

                Growl.Success("注册成功！", "SuccessMsg");
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册失败" + ex, "提示");
            }
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
