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

namespace _1_level
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
        MenuPage page = new MenuPage();
        private void MyFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            sozia.Navigate(page);
            sozia.Visibility = Visibility.Visible;
        }


        /*        private void ButtonSecondPage_click(object sender, RoutedEventArgs e)
                {
                    MyFrame.Navigate(page);
                    page.Visibility = Visibility.Visible;

                }

                private void ButtonWindow_click(object sender, RoutedEventArgs e)
                {
                    SecondWindow wnd = new SecondWindow();
                    wnd.Show();
                }*/
    }
}
