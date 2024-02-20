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
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        Client client;
        public PageAdd(Client _client)
        {
            InitializeComponent();
            client = _client;
            DataContext = client;
        }

        private void ButtonAdd_clicked(object sender, RoutedEventArgs e)
        {
            if (client.Id == 0)
            {
                Ispr2335BarskovIaAsadContext.init().Clients.Add(client);
                Ispr2335BarskovIaAsadContext.init().SaveChanges();
            }
        }
    }
}
