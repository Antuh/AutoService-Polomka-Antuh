using AutoService.model;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoService.pages
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Page
    {
        Client client = new Client();

        private bool _editClient = false;

        public AddClient(Client currentClient)
        {
            InitializeComponent();
            if (currentClient != null)
            {
                _editClient = true;
                client = currentClient;
                btnDeleteClient.Visibility = Visibility.Visible;
            }
            DataContext = client;
            txtGender.ItemsSource = EntitiesAutos.GetContext().Gender.ToList();
        }

        private void btnEnterImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog GetImageDialog = new OpenFileDialog();

                GetImageDialog.Filter = "Файлы изображений: (*.png, *.jpg, *jpeg)| *.png; *.jpg; *jpeg";
                GetImageDialog.InitialDirectory = "AutoService\\image\\Клиенты";
                if (GetImageDialog.ShowDialog() == true) client.PhotoPath = GetImageDialog.SafeFileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы жействительно хотите удалить {client}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    EntitiesAutos.GetContext().Client.Remove(client);
                    EntitiesAutos.GetContext().SaveChanges();
                    MessageBox.Show("Запись удалена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private bool IsLettersOnly(string input)
        {
            // Используем регулярное выражение для проверки, что строка состоит только из букв
            return !string.IsNullOrEmpty(input) && Regex.IsMatch(input, "^[a-zA-Z]+$");
        }

        private void btnSaveClient_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) ||
            string.IsNullOrEmpty(txtLastName.Text) ||
            string.IsNullOrEmpty(txtPatronymic.Text) ||
            string.IsNullOrEmpty(txtEmail.Text) ||
            string.IsNullOrEmpty(txtPhone.Text) ||
            txtGender.SelectedItem == null ||
            dtbirth.SelectedDate == null)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else if (!IsLettersOnly(txtFirstName.Text) || !IsLettersOnly(txtPatronymic.Text))
            {
                MessageBox.Show("Имя и отчество должны содержать только буквы");
            }
            else
            {
                if (_editClient == false)
                {
                    
                    var client = new Client
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Patronymic = txtPatronymic.Text,
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text,
                        Gender = txtGender.SelectedItem as Gender,
                        Birthday = dtbirth.SelectedDate,
                        RegistrationDate = DateTime.Now
                    };

                    EntitiesAutos.GetContext().Client.Add(client);
                }

                try
                {
                    EntitiesAutos.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
