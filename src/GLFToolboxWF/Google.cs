using System.Globalization;
using System;
using System.Windows.Forms;

namespace GLFToolboxWF
{
    [ProvideToolboxControl("GLFToolboxWF.Google", false)]
    public partial class Google : UserControl
    {
        //public User User { private set; get; }
        public Google()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format(CultureInfo.CurrentUICulture, "We are inside {0}.Button1_Click()", this.ToString()));
        }

        private void GoogleBtn_Click(object sender, EventArgs e)
        {
            //User = GLF.LoginWithGoogle();
        }
    }
}
