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
using BeautyShop.AppData;

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
            productListV.ItemsSource = DBContext.Context.Product.ToList();
        }

        private void productListV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
