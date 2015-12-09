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
    /// Interaction logic for WPFFacebook.xaml
    /// </summary>
    public partial class WPFFacebook : Window
    {
        public WPFFacebook()
        {
            InitializeComponent();
        }

        private async void btn_facebook_login_Click(object sender, RoutedEventArgs e)
        {
            User user = await GLF.Instance.LoginWithFacebook(GLF.ProjectType.WPF);
            txtbx_user_result.Text = user.ToString();
        }
    }
}
