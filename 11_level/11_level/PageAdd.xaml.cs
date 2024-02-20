using _11_level.dbModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace _11_level
{
    /// <summary>
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        Product product;
        /// <summary>
        /// Инициализация страницы
        /// </summary>
        /// <param name="_product"></param>
        public PageAdd(Product _product)
        {
            InitializeComponent();
            product = _product;
            DataContext = product;
        }

        /// <summary>
        /// Получение нового объекта Product
        /// </summary>
        /// <param name="_product"></param>
        public void NewProduct(Product _product)
        {
            product = _product;
            DataContext = product;
        }
        /// <summary>
        /// Функция выбора изображения
        /// </summary>
        private void ImageEditClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog { Filter = "Jpeg files|*.jpg|Png Files|*.png|All Files|*.*" };
            if (OpenFile.ShowDialog() == true)
            {
                product.MainImagePath = File.ReadAllBytes(OpenFile.FileName);
            }
        }

        /// <summary>
        /// Функция добавления записи в таблицу
        /// </summary>
        private void ButtonAdd_clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (product.Id == 0)
                {
                    CoreModel.init().Products.Add(product);
                    CoreModel.init().SaveChanges();
                }
            } catch (Exception ex) // Отлов ошибки при добавлении записи
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
