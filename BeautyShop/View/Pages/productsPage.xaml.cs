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
            var manufacturerCmb = DBContext.Context.Manufacturer.ToList();
            manufacturerCmb.Insert(0, new Manufacturer { Name = "Все производители" });
            ownerCmbx.ItemsSource = manufacturerCmb;
            ownerCmbx.SelectedIndex = 0;
        }

        private void productListV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            productListV.ItemsSource = DBContext.Context.Product.Where(x => x.Title.StartsWith(searchTxt.Text) || x.Description.StartsWith(searchTxt.Text)).ToList();
        }

        private void ownerCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ownerCmbx.SelectedIndex == 0)
            {
                productListV.ItemsSource = DBContext.Context.Product.ToList();
            }
            else
            {
                productListV.ItemsSource = DBContext.Context.Product.Where(x => x.ManufacturerID == ownerCmbx.SelectedIndex).ToList();
            }
            
        }

        private void productListV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editBtn.Visibility = Visibility.Visible;
            historyBtn.Visibility = Visibility.Visible;
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            var itemInfo = productListV.SelectedItem;
            FrameObj.mainFrame.Navigate(new addProductPage(itemInfo as Product));
        }
    }
}
