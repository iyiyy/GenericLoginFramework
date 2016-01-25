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
    public partial class WFGeneric : Form
    {
        public WFGeneric()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            User user = GLF.Instance.LoginWithGeneric(box_uname.Text, box_pwd.Text);
            box_result.Text = GLF.UserToString(user);
        }
    }
}
