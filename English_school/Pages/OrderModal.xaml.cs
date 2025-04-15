using English_school.Entity;
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
using System.Windows.Shapes;

namespace English_school.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderModal.xaml
    /// </summary>
    public partial class OrderModal : Window
    {
        private EnglishSchool _context;
        public OrderModal()
        {
            InitializeComponent();
            _context = new EnglishSchool();
            LoadClients();
            LoadServices();
        }

        private void LoadClients()
        {
            var clients = _context.Client.ToList();
            ComboBoxClients.ItemsSource = clients;
            ComboBoxClients.DisplayMemberPath = "FirstName"; // Укажите, как отображать имя клиента
            ComboBoxClients.SelectedValuePath = "ID"; // Укажите, как получать ID клиента
        }

        private void LoadServices()
        {
            var services = _context.Service.ToList();
            ComboBoxServices.ItemsSource = services;
            ComboBoxServices.DisplayMemberPath = "Title"; // Укажите, как отображать название услуги
            ComboBoxServices.SelectedValuePath = "ID"; // Укажите, как получать ID услуги
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxClients.SelectedValue != null && ComboBoxServices.SelectedValue != null)
            {
                var clientService = new ClientService
                {
                    ClientID = (int)ComboBoxClients.SelectedValue,
                    ServiceID = (int)ComboBoxServices.SelectedValue,
                    StartTime = DatePickerStartTime.SelectedDate ?? DateTime.Now,
                    Comment = TextBoxComment.Text
                };

                _context.ClientService.Add(clientService);
                _context.SaveChanges();

                MessageBox.Show("Запись успешно создана!");
                this.Close(); // Закрыть окно после создания записи
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента и услугу.");
            }
        }
    }
}
