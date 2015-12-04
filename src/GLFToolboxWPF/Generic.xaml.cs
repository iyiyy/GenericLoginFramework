using GenericLoginFramework;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace GLFToolboxWPF
{
    /// <summary>
    /// Interaction logic for Generic.xaml.
    /// </summary>
    [ProvideToolboxControl("GLFToolboxWPF.Generic", true)]
    public partial class Generic : UserControl
    {
        public User User { private set; get; }

        public Generic()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            //User = GLF.LoginWithGeneric(usernameBox.Text, passwordBox.Password);
        }
    }
}
}
