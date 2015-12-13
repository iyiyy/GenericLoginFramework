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
using GenericLoginFramework.Providers;

namespace GLFTestWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GLF.Instance.InitializeDB("WFTest");
            GLF.Instance.TypeOfProject = GLF.ProjectType.WF;
            //GenericLoginFramework.Providers.FacebookProvider.Instance.Enable("624408054367639");
            GenericLoginFramework.Providers.FacebookProvider.Instance.Enable("624408054367639", "3ee73a2a0c243edff171618669a7b1a3");
        }

        private void btn_facebook_Click(object sender, EventArgs e)
        {
            WFFacebook window = new WFFacebook();
            window.ShowDialog();
        }

        private void btn_google_Click(object sender, EventArgs e)
        {
            WFGoogle window = new WFGoogle();
            window.ShowDialog();
        }

        private void btn_generic_Click(object sender, EventArgs e)
        {
            WFGeneric window = new WFGeneric();
            window.ShowDialog();
        }

        private void btn_toolbox_Click(object sender, EventArgs e)
        {
            WFToolbox window = new WFToolbox();
            window.ShowDialog();
        }
    }
}
