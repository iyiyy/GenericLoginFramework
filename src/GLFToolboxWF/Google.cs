using System.Globalization;
using System;
using System.Windows.Forms;
using GenericLoginFramework;

namespace GLFToolboxWF
{
    [ProvideToolboxControl("GLFToolboxWF.Google", false)]
    public partial class Google : UserControl
    {
        public User User { private set; get; }
        public Google()
        {
            InitializeComponent();
        }

        private async void GoogleBtn_Click(object sender, EventArgs e)
        {
            User = await GLF.Instance.LoginWithGoogle();
        }
    }
}
