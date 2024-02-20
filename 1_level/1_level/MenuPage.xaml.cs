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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }
        MyPage.MyPage page = new MyPage.MyPage();
        private void ButtonSecondPage_click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(page);
            MyFrame.Visibility = Visibility.Visible;
        }

        private void ButtonWindow_click(object sender, RoutedEventArgs e)
        {
            SecondWindow wnd = new SecondWindow();
            wnd.Show();
        }
    }
}
