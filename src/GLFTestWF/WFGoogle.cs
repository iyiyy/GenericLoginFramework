﻿using System;
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
    public partial class WFGoogle : Form
    {
        public WFGoogle()
        {
            InitializeComponent();
        }
        private async void loginBtn_Click(object sender, EventArgs e)
        {
            string token;
            User user;
            token = GLF.Instance.GetGoogleToken();
            user = await GLF.Instance.GetUserFromGoogleToken(token);
            resultTxtbx.Text = GLF.UserToString(user);
        }
    }
}
