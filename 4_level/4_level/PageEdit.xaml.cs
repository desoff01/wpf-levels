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
    /// Логика взаимодействия для PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {
        Client client;
        public PageEdit(Client _client)
        {
            InitializeComponent();
            client = _client;
            DataContext = client;
        }

        private void visClientChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (client.Id != 0)
            {
                Ispr2335BarskovIaAsadContext.init().Entry(client).Reload();
            }
            Ispr2335BarskovIaAsadContext.init().SaveChanges(true);
        }

        private void ButtonEdit_clicked(object sender, RoutedEventArgs e)
        {
            Ispr2335BarskovIaAsadContext.init().Clients.Update(client);
            Ispr2335BarskovIaAsadContext.init().SaveChanges();
        }
    }
}
