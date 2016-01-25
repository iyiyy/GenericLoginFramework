using GenericLoginFramework;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace GLFToolboxWPF
{
    /// <summary>
    /// Interaction logic for Facebook.xaml.
    /// </summary>
    [ProvideToolboxControl("Generic Login Framework", true)]
    public partial class Facebook : UserControl
    {
        public string Token { private set; get; }
        public event RoutedEventHandler Click;
        public Facebook()
        {
            InitializeComponent();
        }

        private void FacebookBtn_Click(object sender, RoutedEventArgs e)
        {
            Token = GLF.Instance.GetFacebookToken();
            if (this.Click != null)
                this.Click(sender, e);
        }
    }
}
