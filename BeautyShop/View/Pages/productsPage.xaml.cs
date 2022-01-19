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
using BeautyShop.Entities;

namespace BeautyShop.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для productsPage.xaml
    /// </summary>
    public partial class productsPage : Page
    {
        public productsPage()
        {
            InitializeComponent();
            productsList.ItemsSource = DBContext.Context.Product.ToList();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void salesHistoryBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
