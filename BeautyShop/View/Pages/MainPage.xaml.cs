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
using System.Windows.Threading;
using BeautyShop.AppData;


namespace BeautyShop.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void productBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.mainFrame.Navigate(new productsPage()); 
        }

        private void addProductBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.mainFrame.Navigate(new addProductPage());
        }
    }
}
