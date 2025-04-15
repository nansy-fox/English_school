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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace English_school.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceOfClient.xaml
    /// </summary>
    public partial class ServiceOfClient : Window
    {
        private readonly EnglishSchool _context;
        public ServiceOfClient(Service service)
        {
            InitializeComponent();
            _context = new EnglishSchool();
            LoadData(service);
            
        }

        public void LoadData(Service service)
        { 
            var clientServices = service.ClientService.ToList();
            var listToDataGrid = new List<DataGridClient>();
            foreach (var item in clientServices)
            {
                var temp = new DataGridClient();

                temp.Name = item.Client.FirstName+" "+item.Client.LastName;

                temp.Time = item.StartTime;

                listToDataGrid.Add(temp);
            }
            DataGridService.ItemsSource = listToDataGrid;
        }

        public class DataGridClient
        {
            public string Name { get; set; }
            public DateTime Time { get; set; }

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var n=new OrderModal();
            n.ShowDialog();
        }
    }
}
