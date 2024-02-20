using _3level.dbModel;
using Microsoft.EntityFrameworkCore;
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

namespace _3level
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
        bool bPage = false;
        bool bPageFirstListView = false;
        PageFirstListView pFirstLV = new PageFirstListView();
        Page.PageListView page1 = new Page.PageListView();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (bPageFirstListView)
            {
                pFirstLV.ListViewFirst.ItemsSource = CoreModel.init().Clients.ToList();
            } else
            {
                DataGridClient.ItemsSource = CoreModel.init().Clients.ToList();
            }
        }

        private void ButtonSecondTable(object sender, RoutedEventArgs e)
        {
            if (bPage)
            {
                page1.ListView1.ItemsSource = CoreModel.init().ClientServices.Include(c => c.Client).ToList();
            } else
            {
                DataGridClient.ItemsSource = CoreModel.init().ClientServices.Include(c => c.Client).ToList();
            }
        }

        private void ButtonThirdTable(object sender, RoutedEventArgs e)
        {
            if (bPage)
            {
                page1.ListView1.ItemsSource = CoreModel.init().ClientServices.Include(c => c.Client)
                .ThenInclude(g => g.GenderCodeNavigation).ToList();
            } else
            {
                DataGridClient.ItemsSource = CoreModel.init().ClientServices.Include(c => c.Client)
                .ThenInclude(g => g.GenderCodeNavigation).ToList();
            }
        }

        private void ChangePage(object sender, RoutedEventArgs e)
        {
            if (bPage)
            {
                page1.Visibility = Visibility.Collapsed;
                bPage = false;
            } else {
                MyFrame.Navigate(page1);
                page1.Visibility = Visibility.Visible;
                bPage = true;
            }
        }

        private void ButtonFirstTableListView_click(object sender, RoutedEventArgs e)
        {
            if (bPageFirstListView)
            {
                MyFrame.Visibility = Visibility.Collapsed;
                bPageFirstListView = false;
            }
            else
            {
                MyFrame.Navigate(pFirstLV);
                MyFrame.Visibility = Visibility.Visible;
                bPageFirstListView = true;
            }
        }
    }
}
