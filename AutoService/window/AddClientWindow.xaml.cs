using AutoService.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoService.window
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        Client client = new Client();
        private EntitiesAutos db;
        StringBuilder errors = new StringBuilder();
        Client currentClient = new Client();

        public AddClientWindow(Client currentClient, EntitiesAutos db)
        {
            InitializeComponent();
            this.db = db;
            if (currentClient != null)
            {
                this.client = currentClient;
                LViewTags.ItemsSource = client.TagList;
            }
            else if (currentClient == null)
            {
                this.currentClient = currentClient;
                btnDeleteClient.IsEnabled = false;
                TagGrid.Visibility = Visibility.Collapsed;
            }
            DataContext = client;
            cmbGender.ItemsSource = db.Gender.ToList();
        }
        private bool ValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return !regex.IsMatch(s);
        }

        private bool ValidPhone(string s)
        {
            Regex regex = new Regex("[^0-9+() -]+");
            return !regex.IsMatch(s);
        }

        private bool ValidFIO(string s)
        {
            Regex regex = new Regex("[^a-zа-я -]+");
            return !regex.IsMatch(s);
        }

        private bool ValidColor(string s)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(s);
        }

        private void btnWriteAg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteAg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEnterImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string newText = textBox.Text + e.Text;
            bool isValid = ValidPhone(newText);

            if (!isValid)
            {
                MessageBox.Show("Некорректный номер телефона");
                e.Handled = true; 
            }

        }

        private void tbFirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string newText = textBox.Text + e.Text;
            bool isValid = ValidFIO(newText);

            if (!isValid)
            {
                MessageBox.Show("Некорректный ввод фамилии");
                e.Handled = true;
            }
        }

        private void tbLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string newText = textBox.Text + e.Text;
            bool isValid = ValidFIO(newText);

            if (!isValid)
            {
                MessageBox.Show("Некорректный ввод имени");
                e.Handled = true;
            }
        }

        private void tbPatronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string newText = textBox.Text + e.Text;
            bool isValid = ValidFIO(newText);

            if (!isValid)
            {
                MessageBox.Show("Некорректный ввод отчества");
                e.Handled = true;
            }
        }

        private void tbEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string newText = textBox.Text + e.Text;
            bool isValid = ValidEmailAddress(newText);

            if (!isValid)
            {
                MessageBox.Show("Некорректный ввод Email");
                e.Handled = true;
            }
        }

        private void tbColorTag_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string newText = textBox.Text + e.Text;
            bool isValid = ValidColor (newText);

            if (!isValid)
            {
                MessageBox.Show("Некорректный ввод цвета");
                e.Handled = true;
            }
        }

        private void btnDelTag_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddTag_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

