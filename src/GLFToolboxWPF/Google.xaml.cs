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
        public User User { private set; get; }
        public Google()
        {
            InitializeComponent();
        }

        private async void GoogleBtn_Click(object sender, RoutedEventArgs e)
        {
            User = await GLF.Instance.LoginWithGoogle();
        }
    }
}
