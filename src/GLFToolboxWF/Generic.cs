using GenericLoginFramework;
using System.Globalization;
using System;
using System.Windows.Forms;

namespace GLFToolboxWF
{
    [ProvideToolboxControl("GLFToolboxWF.Generic", false)]
    public partial class Generic : UserControl
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Generic()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Username = UsernameTxtBx.Text;
            Password = PasswordTxtBx.Text;
        }
    }
}
