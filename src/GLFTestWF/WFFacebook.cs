using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenericLoginFramework;

namespace GLFTestWF
{
    public partial class WFFacebook : Form
    {
        public WFFacebook()
        {
            InitializeComponent();
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            string token;
            User user;
            token = GLF.Instance.GetFacebookToken();
            user = await GLF.Instance.GetUserFromFacebookToken(token);
            resultTxtbx.Text = GLF.UserToString(user);
        }
    }
}
