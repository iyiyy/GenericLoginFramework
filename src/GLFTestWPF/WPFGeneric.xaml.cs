﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GenericLoginFramework;

namespace GLFTestWPF
{
    /// <summary>
    /// Interaction logic for WPFGeneric.xaml
    /// </summary>
    public partial class WPFGeneric : Window
    {
        public WPFGeneric()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            User user = GLF.Instance.LoginWithGeneric(box_uname.Text, box_pwd.Password);
            box_result.Text = GLF.UserToString(user);
        }
    }
}
