using _11_level.dbModels;
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
using static System.Net.Mime.MediaTypeNames;

namespace _11_level
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool bPage = false;
        PageAdd page = new PageAdd(new Product());
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Показать/обновить таблицу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonShowTable_click(object sender, RoutedEventArgs e)
        {
            ListViewProducts.ItemsSource = CoreModel.init().Products.ToList();
        }

        /// <summary>
        /// Переключение между страницами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSwitchAddPage(object sender, RoutedEventArgs e)
        {
            if (bPage)
            {
                MyFrame.Visibility = Visibility.Collapsed;
                page.NewProduct(new Product());
                bPage = false;
            }
            else
            {
                MyFrame.Navigate(page);
                MyFrame.Visibility = Visibility.Visible;
                bPage = true;
            }
        }
    }
}
