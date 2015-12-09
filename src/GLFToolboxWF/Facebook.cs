using System.Globalization;
using System;
using System.Windows.Forms;

namespace GLFToolboxWF
{
    [ProvideToolboxControl("GLFToolboxWF.Facebook", false)]
    public partial class Facebook : UserControl
    {
        //public User User { private set; get; }

        public Facebook()
        {
            InitializeComponent();
        }

        private void FacebookBtn_Click(object sender, EventArgs e)
        {
            //User = GLF.LoginWithFacebook();
        }
    }
}
