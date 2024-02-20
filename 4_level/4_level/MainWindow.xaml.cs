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

namespace _4_level
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            update();

            ComboBoxSort.Items.Add("По возрастанию");
            ComboBoxSort.Items.Add("По убыванию");
            ComboBoxSort.SelectedIndex = 0;

            List<Client> cl = Ispr2335BarskovIaAsadContext.init().Clients.ToList();
            cl.Insert(0, new Client { FirstName = "все типы" });

            ComboBoxFilter.ItemsSource = cl;
            ComboBoxFilter.SelectedIndex = 0;
        }

        bool bPage = false;
        PageAdd page = new PageAdd(new Client());

        private void ShowTable_Click(object sender, RoutedEventArgs e)
        {
            DataGrid1.ItemsSource = Ispr2335BarskovIaAsadContext.init().Clients.Include(p => p.GenderCodeNavigation).ToList();
        }

        private void update()
        {
            IEnumerable<Client> clients = Ispr2335BarskovIaAsadContext.init().Clients
                .Where(p => p.FirstName.Contains(TextBoxSearch.Text));

            switch(ComboBoxSort.SelectedIndex)
            {
                case 0:
                    clients = clients.OrderBy(p => p.FirstName).ToList();
                    break;
                case 1:
                    clients = clients.OrderByDescending(p => p.FirstName).ToList();
                    break;
            }

            if (ComboBoxFilter.SelectedIndex > 0)
            {
                clients = clients.Where(p => p.FirstName == (ComboBoxFilter.SelectedItem as Client).FirstName);
            }

            DataGrid1.ItemsSource = clients.ToList();
        }

        private void TextBoxSearch_changed(object sender, TextChangedEventArgs e)
        {
            update();
        }

        private void ComboBoxSortChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void ComboBoxFilterChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void ButtonAddPage_clicked(object sender, RoutedEventArgs e)
        {
            if (bPage)
            {
                bPage = false;
                framePage.Visibility = Visibility.Collapsed;
            } else {
                bPage = true;
                framePage.Navigate(page);
                framePage.Visibility = Visibility.Visible;
            }
        }

        private void ButtonEditPage_clicked(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItems.Count < 0) { return; }

            Client client = DataGrid1.SelectedItem as Client;

            if (bPage)
            {
                bPage = false;
                frameEditPage.Visibility = Visibility.Collapsed;
            }
            else
            {
                bPage = true;
                frameEditPage.Navigate(new PageEdit(client));
                frameEditPage.Visibility = Visibility.Visible;
            }
        }
    }
}
