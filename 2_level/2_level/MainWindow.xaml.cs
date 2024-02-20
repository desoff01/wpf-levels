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

namespace _2_level
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //массив пользователей для условной авторизации
        string[,] users = {
            {"username", "password", "user"},
            {"admin", "12345", "admin" },
            {"Petr", "qwerty", "admin"},
            {"Olya", "zxc", "user"}
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogin_clicked(object sender, RoutedEventArgs e)
        {
            bool bExist = false;
            for (int i = 0; i < users.GetLength(0); i++) {
                if (users.GetValue(i, 0).ToString() == TextBoxLogin.Text)
                {
                    if (users.GetValue(i, 1).ToString() == TextBoxPasswd.Text)
                    {
                        bExist = true;
                        if (users.GetValue(i, 2).ToString() == "admin")
                        {
                            FramePage.Navigate(new PageAdmin());
                        } else
                        {
                            WindowUser wnd = new WindowUser();
                            wnd.Show();
                            Close();
                        }
                    }
                }
            }
            if (!bExist) { MessageBox.Show("Неверное имя пользователя или пароль"); }
        }
    }
}
