using System.Globalization;
using System;
using System.Windows.Forms;
using GenericLoginFramework;

namespace GLFToolboxWF
{
    [ProvideToolboxControl("GLFToolboxWF.Google", false)]
    public partial class Google : UserControl
    {
        public string Token { private set; get; }

        public Google()
        {
            InitializeComponent();
        }

        private void GoogleBtn_Click(object sender, EventArgs e)
        {
            Token = GLF.Instance.GetGoogleToken();
            this.OnClick(e);
        }
    }
}
