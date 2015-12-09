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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GenericLoginFramework.Providers;

namespace GenericLoginFramework.Views
{
    /// <summary>
    /// Interaction logic for GLFRedirectWPF.xaml
    /// </summary>
    public partial class GLFRedirectWPF : UserControl
    {
        public string Response { get; private set; } = "";

        public GLFRedirectWPF(string URI, GLF.ProviderFlow flow)
        {
            InitializeComponent();

            this.browser.Navigated += new NavigatedEventHandler(delegate (object sender, NavigationEventArgs e)
            {
                if ((e.Uri.Scheme + "://" + e.Uri.Host + e.Uri.AbsolutePath).Contains(FacebookProvider.Instance.RedirectURI))
                {
                    Console.WriteLine(e.Uri.AbsoluteUri);
                    string[] queryParams;

                    if (flow == GLF.ProviderFlow.AuthorizationCode)
                        queryParams = e.Uri.AbsoluteUri.Split('?')[1].Split('#')[0].Split('&');
                    else if (flow == GLF.ProviderFlow.Implicit)
                        queryParams = e.Uri.AbsoluteUri.Split('#')[1].Split('&');
                    else
                        throw new NotImplementedException("A unimplemented flow was being used.");

                    foreach (string s in queryParams)
                    {
                        Console.WriteLine(s);
                        string[] queryParameter = s.Split('=');
                        if (queryParameter[0].ToLower() == "code" || queryParameter[0].ToLower() == "access_token")
                        {
                            this.Response = queryParameter[1];
                            break;
                        }
                    }

                    Window parent = Window.GetWindow(this);
                    parent.DialogResult = true;
                    parent.Close();
                }
            });

            this.browser.Navigate(new Uri(@URI));
        }
    }
}
