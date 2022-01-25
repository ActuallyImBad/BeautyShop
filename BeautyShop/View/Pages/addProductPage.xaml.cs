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
    /// Логика взаимодействия для addProductPage.xaml
    /// </summary>
    public partial class addProductPage : Page
    {
        private Product currentProduct = new Product(); 
        public addProductPage(Product itemInfo)
        {
            InitializeComponent();


            currentProduct = itemInfo ?? new Product();
            
            ownerCmbx.ItemsSource = DBContext.Context.Manufacturer.ToList();

            DataContext = currentProduct;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.mainFrame.GoBack();
        }
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(currentProduct.Title))
                errors.AppendLine("Укажите название продукта");
            if (string.IsNullOrWhiteSpace(currentProduct.Cost.ToString()))
                errors.AppendLine("Укажите цену продукта");
            if (currentProduct.Cost.ToString().StartsWith("-"))
                errors.AppendLine("Цена не может быть отрицательной");
            if (currentProduct.Manufacturer == null)
                errors.AppendLine("Выберите производителя");
            if (string.IsNullOrWhiteSpace(currentProduct.Description))
                currentProduct.Description = "";


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (currentProduct.ID == 0)
            {
                DBContext.Context.Product.Add(currentProduct);
            }


            try
            {
                DBContext.Context.SaveChanges();
                MessageBox.Show("Информация сохранена");
                FrameObj.mainFrame.GoBack();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }
    }
}
