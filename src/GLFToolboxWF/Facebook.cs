﻿using System.Globalization;
using System;
using System.Windows.Forms;
using GenericLoginFramework;

namespace GLFToolboxWF
{
    [ProvideToolboxControl("GLFToolboxWF.Facebook", false)]
    public partial class Facebook : UserControl
    {
        public User User { private set; get; }

        public Facebook()
        {
            InitializeComponent();
        }

        private async void FacebookBtn_Click(object sender, EventArgs e)
        {
            User = await GLF.Instance.LoginWithFacebook();
        }
    }
}
