using GenericLoginFramework;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace GLFToolboxWPF
{
    /// <summary>
    /// Interaction logic for Google.xaml.
    /// </summary>
    [ProvideToolboxControl("Generic Login Framework", true)]
    public partial class Google : UserControl
    {
        public string Token { private set; get; }
        public event RoutedEventHandler Click;
        public Google()
        {
            InitializeComponent();
        }

        private void GoogleBtn_Click(object sender, RoutedEventArgs e)
        {
            Token = GLF.Instance.GetGoogleToken();
            if (this.Click != null)
                this.Click(sender, e);
        }
    }
}
