using AutoService.model;
using AutoService.pages;
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
        Client currentClient = new Client();
        private ClientsAutoService clientsAutoService;

        public AddClientWindow(Client currentClient, EntitiesAutos db, ClientsAutoService clientPage)
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
            try
            {
                StringBuilder errors = new StringBuilder();
                if (tbColorTag.Text == "")
                {
                    MessageBox.Show("Введите цвет");
                }
                if (tbTitleTag.Text == "")
                {
                    MessageBox.Show("Введите наименование");
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                Tag tag = new Tag
                {
                    ID = db.Tag.Any() ? db.Tag.Max(t => t.ID) + 1 : 1,
                    Title = tbTitleTag.Text,
                    Color = tbColorTag.Text
                };
                client.Tag.Add(tag);
                db.SaveChanges();
                tbTitleTag.Text = ""; tbColorTag.Text = "";
                LViewTags.ItemsSource = client.TagList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnDeleteAg_Click(object sender, RoutedEventArgs e)
        {
            int count = LViewTags.SelectedItems.Count;
            if (count > 0)
            {
                if (MessageBox.Show($"Вы действительно хотите удалить {count} запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var selected = LViewTags.SelectedItems.Cast<Tag>().ToArray();
                        foreach (var item in selected)
                        {
                            db.Tag.Remove(item);
                        }
                        db.SaveChanges();
                        string about;
                        if (count == 1) about = "Тег удален!";
                        else about = "Теги удалены!";
                        MessageBox.Show(about, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        LViewTags.ItemsSource = client.TagList;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите теги для удаления", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void btnEnterImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog GetImageDialog = new OpenFileDialog();

                GetImageDialog.Filter = "Файлы изображений: (*.png, *.jpg, *jpeg)| *.png; *.jpg; *jpeg";
                GetImageDialog.InitialDirectory = "AutoService.Rule.Antuh\\Resourse\\Product";
                if (GetImageDialog.ShowDialog() == true) client.PhotoPath = GetImageDialog.SafeFileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string defaultImagePath = (string)FindResource("defaultImage"); 
                if (!string.IsNullOrEmpty(defaultImagePath))
                {
                    BitmapImage defaultImage = new BitmapImage(new Uri(defaultImagePath));
                    imgPhoto.Source = defaultImage; 
                }
                client.PhotoPath = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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
            int count = LViewTags.SelectedItems.Count;
            if (count > 0)
            {
                if (MessageBox.Show($"Вы действительно хотите удалить {count} запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var selected = LViewTags.SelectedItems.Cast<Tag>().ToArray();
                        foreach (var item in selected)
                        {
                            db.Tag.Remove(item);
                        }
                        db.SaveChanges();
                        string about;
                        if (count == 1) about = "Тег удален!";
                        else about = "Теги удалены!";
                        MessageBox.Show(about, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        LViewTags.ItemsSource = client.TagList;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите теги для удаления", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnAddTag_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                Errors(tbColorTag.Text == "", errors, "Введите цвет!");
                Errors(tbTitleTag.Text == "", errors, "Введите наименование тега!");
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                Tag tag = new Tag
                {
                    ID = db.Tag.Any() ? db.Tag.Max(t => t.ID) + 1 : 1,
                    Title = tbTitleTag.Text,
                    Color = tbColorTag.Text
                };
                client.Tag.Add(tag);
                db.SaveChanges();
                tbTitleTag.Text = ""; tbColorTag.Text = "";
                LViewTags.ItemsSource = client.TagList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Errors(bool expression, StringBuilder errors, string message)
        {
            if (expression)
            {
                errors.AppendLine(message);
            }
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (cmbGender.SelectedItem == null)
                { 
                    MessageBox.Show("Выберите пол клиента!"); 
                }

                if (tbFirstName.Text.Count() > 50)
                {
                    MessageBox.Show("Фамилия не может быть длиннее 50 символов!");
                }
                if (tbLastName.Text.Count() > 50)
                {
                    MessageBox.Show("Имя не может быть длиннее 50 символов!");
                }
                if (tbPatronymic.Text.Count() > 50)
                {
                    MessageBox.Show("Отчество не может быть длиннее 50 символов!");
                }
       
                if (tbFirstName.Text == "" || tbLastName.Text == "" || tbPhone.Text == "")
                {
                    MessageBox.Show("Не заполнена важная ифнормация!");
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                if (currentClient == null)
                {
                    client.RegistrationDate = DateTime.Now;
                    RefrData();
                    db.Client.Add(client);
                    SaveInDB("Добавление информации о клиенте завершено");
                }
                else
                {
                    RefrData();
                    SaveInDB("Обновление информации о клиенте завершено");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefrData()
        {
            client.Birthday = (DateTime)dpBirthDate.SelectedDate;
            client.GenderCode = (cmbGender.SelectedIndex + 1).ToString();
        }

        private void SaveInDB(string text)
        {
            db.SaveChanges();
            MessageBox.Show(text, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (client.ClientService.Count > 0)
                {
                    MessageBox.Show("Удаление не возможно, т.к. есть информация о посещении", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                foreach (Tag tag in client.Tag)
                {
                    db.Tag.Remove(tag);
                }
                db.Client.Remove(client);
                db.SaveChanges();
                MessageBox.Show("Удаление информации об клиенте завешено!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AddClientsWindow_Closed(object sender, EventArgs e)
        {
            try
            {
                if (clientsAutoService != null)
                {
                    clientsAutoService.Load(); // Вызываем метод на ClientPage
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
