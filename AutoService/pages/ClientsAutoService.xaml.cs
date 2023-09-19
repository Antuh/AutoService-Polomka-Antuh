using AutoService.model;
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
/*
 * private static EntitiesAuto _context;

        public static EntitiesAuto GetContext()
        {
            if (_context == null)
                _context = new EntitiesAuto();
            return _context;
        }
 */
/*
 * public string ImgPath
        {
            get
            {
                var path = "pack://application:,,,/image/" + this.PhotoPath;
                return path;
            }
        }
 */

namespace AutoService.pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsAutoService.xaml
    /// </summary>
    public partial class ClientsAutoService : Page
    {
        public ClientsAutoService()
        {
            InitializeComponent();
            var client = EntitiesAutos.GetContext().Client.ToList();
            LViewClient.ItemsSource = client;
            DataContext = this;
        }
        public string[] SortingList { get; set; } =
        {
            "Без сортировки",
            "По возрастанию алфавита",
            "По убыванию алфавита"
        };
        public string PhotoPath { get; internal set; }

        private void UpdateData()
        {
            var result = EntitiesAutos.GetContext().Client.ToList();

            if (cmbSorting.SelectedIndex == 1) result = result.OrderBy(p => p.LastName).ToList();
            if (cmbSorting.SelectedIndex == 2) result = result.OrderByDescending(p => p.LastName).ToList();

            /*if (cmbFilter.SelectedIndex == 1) result = result.Where(p => p.ProductDiscountAmount >= 0 && p.ProductDiscountAmount < 10).ToList();;*/

            result = result.Where(p =>
            p.FirstName.ToLower().Contains(txtSearch.Text.ToLower()) ||
            p.LastName.ToLower().Contains(txtSearch.Text.ToLower()) ||
            p.Phone.ToLower().Contains(txtSearch.Text.ToLower()) ||
            p.Patronymic.ToLower().Contains(txtSearch.Text.ToLower())
            ).ToList();
            LViewClient.ItemsSource = result;
            txtResultAmount.Text = result.Count().ToString();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbSorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void txtSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private void btnEditClient_Click(object sender, RoutedEventArgs e)
        {
            /*Client selectedClient = (sender as Button).DataContext as Client;

            if (selectedClient != null)
            {
                NavigationService.Navigate(new EditClient(selectedClient));
            }*/
        }

        private void btnAddNewClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClient(null));
        }
    }
}
