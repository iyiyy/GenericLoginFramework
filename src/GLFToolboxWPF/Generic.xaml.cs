using GenericLoginFramework;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace GLFToolboxWPF
{
    /// <summary>
    /// Interaction logic for Generic.xaml.
    /// </summary>
    [ProvideToolboxControl("Generic Login Framework", true)]
    public partial class Generic : UserControl
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public event RoutedEventHandler Click;

        public Generic()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            Username = usernameBox.Text;
            Password = passwordBox.Password;
            if (this.Click != null)
                this.Click(sender, e);
        }
    }
}
