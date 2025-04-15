using English_school.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace English_school.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateService.xaml
    /// </summary>
    public partial class CreateService : Window
    {
        private readonly EnglishSchool _context;
        public CreateService()
        {
            InitializeComponent();
            _context = new EnglishSchool();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            // Создаем новую услугу
            var newService = new Service
            {
                Title = textBoxName.Text,
                Cost = decimal.Parse(textBoxPrice.Text), // Убедитесь, что вводимое значение корректно
                DurationInSeconds = Convert.ToInt32(textBoxDuration.Text),
                Description = textBoxDescription.Text
            };

            // Добавляем услугу в контекст
            _context.Service.Add(newService);

            // Сохраняем изменения в базе данных
            _context.SaveChanges();

            // Закрываем окно после сохранения
            MessageBox.Show("Услуга успешно создана!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}

