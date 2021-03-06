﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace GenericLoginFramework.Views
{
    public partial class GLFRedirectWF : UserControl
    {
        public string Response { get; set; }
        public Window ParentWindow { get; set; }

        public GLFRedirectWF(string URI, string redirectURI, GLF.ProviderFlow flow)
        {
            InitializeComponent();

            browser.Navigated += new WebBrowserNavigatedEventHandler(delegate (object sender, WebBrowserNavigatedEventArgs e)
            {
                Console.WriteLine(e.Url.AbsoluteUri);
                if ((e.Url.Scheme + "://" + e.Url.Host + e.Url.AbsolutePath).Contains(redirectURI))
                {
                    string[] queryParams;

                    if (flow == GLF.ProviderFlow.AuthorizationCode)
                        queryParams = e.Url.AbsoluteUri.Split('?')[1].Split('#')[0].Split('&');
                    else if (flow == GLF.ProviderFlow.Implicit)
                        queryParams = e.Url.AbsoluteUri.Split('#')[1].Split('&');
                    else
                        throw new NotImplementedException(String.Format("Flow {0} not support.", flow.ToString()));

                    foreach(string s in queryParams)
                    {
                        string[] queryParameter = s.Split('=');
                        if(queryParameter[0].ToLower() == "code" || queryParameter[0].ToLower() == "access_token")
                        {
                            Response = queryParameter[1];
                            break;
                        }
                    }
              
                    ParentWindow.Close();
                }
                else if(e.Url.AbsoluteUri.Contains("approval"))
                {
                    string code = ((dynamic)browser.Document).Title;

                    string[] queryParameter = code.Split('=');
                    Response = queryParameter[1];

                    ParentWindow.Close();
                }
            });

            browser.Navigate(new Uri(@URI));
        }
    }
}
