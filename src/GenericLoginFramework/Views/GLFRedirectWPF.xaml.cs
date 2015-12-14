using System;
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

        public GLFRedirectWPF(string URI, string redirectURI, GLF.ProviderFlow flow)
        {
            InitializeComponent();

            browser.Navigated += new NavigatedEventHandler(delegate (object sender, NavigationEventArgs e)
            {
                Console.WriteLine(e.Uri.AbsoluteUri);
                if((e.Uri.Scheme + "://" + e.Uri.Host + e.Uri.AbsolutePath).Contains(redirectURI))
                {
                    string[] queryParams;

                    if (flow == GLF.ProviderFlow.AuthorizationCode)
                        queryParams = e.Uri.AbsoluteUri.Split('?')[1].Split('#')[0].Split('&');
                    else if(flow == GLF.ProviderFlow.Implicit)
                        queryParams = e.Uri.AbsoluteUri.Split('#')[1].Split('&');
                    else
                        throw new NotImplementedException(String.Format("Flow {0} not support.", flow.ToString()));

                    foreach(string s in queryParams)
                    {
                        string[] queryParameter = s.Split('=');
                        if (queryParameter[0].ToLower() == "code" || queryParameter[0].ToLower() == "access_token")
                        {
                            Response = queryParameter[1];
                            break;
                        }
                    }


                    Window parent = Window.GetWindow(this);
                    parent.DialogResult = true;
                    parent.Close();
                }
                else if(e.Uri.AbsoluteUri.Contains("approval"))
                {
                    Console.WriteLine("Approved");
                    string code = ((dynamic)browser.Document).Title;

                    string[] queryParameter = code.Split('=');
                    Response = queryParameter[1];

                    Window parent = Window.GetWindow(this);
                    parent.DialogResult = true;
                    parent.Close();
                }
            });

            browser.Navigate(new Uri(@URI));
        }
    }
}
