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
        public User User { private set; get; }
        public Facebook()
        {
            InitializeComponent();
        }

        private async void FacebookBtn_Click(object sender, RoutedEventArgs e)
        {
            User = await GLF.Instance.LoginWithFacebook();
        }
    }
}
