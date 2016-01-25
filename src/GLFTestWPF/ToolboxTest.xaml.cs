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
    /// Interaction logic for ToolboxTest.xaml
    /// </summary>
    public partial class ToolboxTest : Window
    {
        public ToolboxTest()
        {
            InitializeComponent();

            btn_facebook.Click += async (sender, e) =>
            {
                string token = btn_facebook.Token;
                User user = await GLF.Instance.GetUserFromFacebookToken(token);
                txtbx_output.Text = GLF.UserToString(user);
            };

            btn_google.Click += async (sender, e) =>
            {
                string token = btn_google.Token;
                User user = await GLF.Instance.GetUserFromGoogleToken(token);
                txtbx_output.Text = GLF.UserToString(user);
            };

            btn_generic.Click += (sender, e) =>
            {
                User user = GLF.Instance.LoginWithGeneric(btn_generic.Username, btn_generic.Password);
                txtbx_output.Text = GLF.UserToString(user);
            };
        }
    }
}
