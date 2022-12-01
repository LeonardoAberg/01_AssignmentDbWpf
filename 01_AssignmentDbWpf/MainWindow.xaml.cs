using _01_AssignmentDbWpf.Models;
using _01_AssignmentDbWpf.Models.Entities;
using _01_AssignmentDbWpf.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _01_AssignmentDbWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;
        private readonly OrderService _orderService;

        public MainWindow(CustomerService customerService, ProductService productService, OrderService orderService)
        {
            InitializeComponent();
            _customerService = customerService;
            _productService = productService;
            _orderService = orderService;
            PopulateCustomer().ConfigureAwait(false);
            RefreshOrder().ConfigureAwait(false);
        }

        public async Task PopulateCustomer()
        {
            var collection = new ObservableCollection<KeyValuePair<int, string>>();
            foreach (var customer in await _customerService.GetAll())
                collection.Add(new KeyValuePair<int, string>(customer.Id, customer.Name));

            cb_customer_name.ItemsSource = collection;
        }

        private async void Btn_customer_save_Click(object sender, RoutedEventArgs e)
        {
            await _customerService.Create(new CustomerEntity
            {
                Name = tb_customer_name.Text,
                Email = tb_customer_email.Text
            });
            tb_customer_name.Text = string.Empty;
            tb_customer_email.Text = string.Empty;
        }

        private async void Btn_product_save_Click(object sender, RoutedEventArgs e)
        {

            await _productService.Create(new ProductEntity
            {
                ProductName = tb_product_name.Text,
                Description = tb_product_description.Text,
                Price = decimal.Parse(tb_product_price.Text)
            });
            tb_product_name.Text = string.Empty;
            tb_product_description.Text = string.Empty;
            tb_product_price.Text = string.Empty;
        }

        private async void Btn_order_save_Click(object sender, RoutedEventArgs e)
        {
            await _orderService.Create(new OrderEntity
            {
                Date = DateTime.Now,
                TotalCost = decimal.Parse(tb_order_totalcost.Text)
            });
            tb_order_totalcost.Text = string.Empty;

        }

        private async Task RefreshOrder()
        {
            var collection = new ObservableCollection<KeyValuePair<int, decimal>>();
            foreach (var order in await _orderService.GetAll())
                collection.Add(new KeyValuePair<int, decimal>(order.Id, order.TotalCost));

            cb_order_idcost.ItemsSource = collection;

        }
    }
}
