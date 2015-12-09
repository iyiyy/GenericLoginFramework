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

namespace GLFTestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_facebook_Click(object sender, RoutedEventArgs e)
        {
            WPFFacebook window = new WPFFacebook();
            window.ShowDialog();
        }

        private void btn_google_Click(object sender, RoutedEventArgs e)
        {
            WPFGoogle window = new WPFGoogle();
            window.ShowDialog();
        }

        private void btn_generic_Click(object sender, RoutedEventArgs e)
        {
            WPFGeneric window = new WPFGeneric();
            window.ShowDialog();
        }
    }
}
