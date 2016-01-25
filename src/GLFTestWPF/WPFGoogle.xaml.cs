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
using System.Windows.Shapes;
using GenericLoginFramework;

namespace GLFTestWPF
{
    /// <summary>
    /// Interaction logic for WPFGoogle.xaml
    /// </summary>
    public partial class WPFGoogle : Window
    {
        public WPFGoogle()
        {
            InitializeComponent();
        }

        private async void btn_google_login_Click(object sender, RoutedEventArgs e)
        {
            string token;
            User user;

            token = GLF.Instance.GetGoogleToken();
            user = await GLF.Instance.GetUserFromGoogleToken(token);
            txtbx_user_result.Text = GLF.UserToString(user);
        }
    }
}
