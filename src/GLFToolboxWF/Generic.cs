using GenericLoginFramework;
using System.Globalization;
using System;
using System.Windows.Forms;

namespace GLFToolboxWF
{
    [ProvideToolboxControl("GLFToolboxWF.Generic", false)]
    public partial class Generic : UserControl
    {
        public User User { private set; get; }

        public Generic()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            //User = GLF.LoginWithGeneric(UsernameTxtBx.Text, PasswordTxtBx.Text);
        }
    }
}
