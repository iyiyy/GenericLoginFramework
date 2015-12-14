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
    public partial class WFToolbox : Form
    {
        public WFToolbox()
        {
            InitializeComponent();
            
        }

        private async void tlbx_facebook_Click(object sender, EventArgs e)
        {
            User user = await GLF.Instance.GetUserFromFacebookToken(tlbx_facebook.Token);
            txtbx_user.Text = GLF.UserToString(user);
        }

        private async void tlbx_google_Click(object sender, EventArgs e)
        {
            User user = await GLF.Instance.GetUserFromGoogleToken(tlbx_google.Token);
            txtbx_user.Text = GLF.UserToString(user);
        }
    }
}
