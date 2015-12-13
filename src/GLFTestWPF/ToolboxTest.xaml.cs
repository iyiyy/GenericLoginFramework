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
                string token = GLF.Instance.GetFacebookToken();
                User user = await GLF.Instance.GetUserFromFacebookToken(token);
                txtbx_output.Text = GLF.UserToString(user);
            };
        }
    }
}
