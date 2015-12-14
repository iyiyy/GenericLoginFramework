using System.Globalization;
using System;
using System.Windows.Forms;
using GenericLoginFramework;
using System.ComponentModel;

namespace GLFToolboxWF
{
    [ProvideToolboxControl("GLFToolboxWF.Facebook", false)]
    public partial class Facebook : UserControl
    {
        public string Token { get; set; }

        public Facebook()
        {
            InitializeComponent();
        }

        private void FacebookBtn_Click(object sender, EventArgs e)
        {
            Token = GLF.Instance.GetFacebookToken();
            this.OnClick(e);            
        }
    }
}
