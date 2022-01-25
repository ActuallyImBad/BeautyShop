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
            sortByCostCmbx.Items.Insert(0, "");
            sortByCostCmbx.Items.Insert(1, "Цена");
            sortByCostCmbx.SelectedIndex = 0;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.mainFrame.GoBack();
        }
        private void Sorting()
        {
            var sortedItems = DBContext.Context.Product.ToList();
            if (ownerCmbx.SelectedIndex > 0)
                sortedItems = sortedItems.Where(x => x.ManufacturerID == ownerCmbx.SelectedIndex).ToList();
            if (string.IsNullOrWhiteSpace(searchTxt.Text) == false)
            {
                sortedItems = sortedItems.Where(x => x.Title.StartsWith(searchTxt.Text) || x.Description.StartsWith(searchTxt.Text)).ToList();
            }
            switch (sortByCostCmbx.SelectedIndex)
            {
                case 1:
                    {
                        if (ascDescCheck.IsChecked == true)
                        {
                            sortedItems = sortedItems.OrderByDescending(x => x.Cost).ToList();
                        }
                        else
                        {
                            sortedItems = sortedItems.OrderBy(x => x.Cost).ToList();
                        }
                        break;
                    }
            }
            productListV.ItemsSource = sortedItems;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sorting();
        }

        private void ownerCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sorting();
        }

        private void productListV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editBtn.Visibility = Visibility.Visible;
            historyBtn.Visibility = Visibility.Visible;
            deleteBtn.Visibility = Visibility.Visible;
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            var itemInfo = productListV.SelectedItem;
            FrameObj.mainFrame.Navigate(new addProductPage(itemInfo as Product));
            productListV.ItemsSource = DBContext.Context.Product.ToList();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var itemToDelete = productListV.SelectedItem as Product;
            if (MessageBox.Show($"Вы хотите удалить продукт №{itemToDelete.ID}?", "Удаление данных", MessageBoxButton.YesNo, 
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DBContext.Context.Product.Remove(itemToDelete);
                    DBContext.Context.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    productListV.ItemsSource = DBContext.Context.Product.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void sortByCostCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sorting();
        }

        private void ascDescCheck_Checked(object sender, RoutedEventArgs e)
        {
            Sorting();
        }

        private void ascDescCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            Sorting();
        }
    }
}
