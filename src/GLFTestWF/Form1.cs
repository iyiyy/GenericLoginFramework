using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GLFTestWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
