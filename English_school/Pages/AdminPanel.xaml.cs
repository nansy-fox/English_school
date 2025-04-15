using English_school.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        private List<Service> service { get; set; }
        private int outElement = 10;
        private int countSendElement = 0;
        private int pageNumber = 0;
        private int allClient = 0;
        private int flagSort = -1;
        public AdminPanel(Frame mainFrame)
        {
            InitializeComponent();
            DataGridService.ItemsSource = service;
            LoadData();
        }
        public void LoadData()
        {
            using (EnglishSchool _context = new EnglishSchool())
            {
                List<Service> services = _context.Service.ToList();
                try
                {
                    services = services.ToList();

                    switch (flagSort)
                    {
                        case 0:
                            services = services.OrderByDescending(o => o.Title).ToList();
                            break;
                        case 1:
                            services = services.OrderBy(o => o.Title).ToList();
                            break;
                        default:
                            break;
                    }
                    DataGridService.ItemsSource = services;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }
            }
        }

        private void ComboBoxSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxSort.SelectedItem is ComboBoxItem selectedItem)
            {

                flagSort = Convert.ToInt32(selectedItem.Tag);
                LoadData();
            }
        }
    
        private void DataGridClient_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            using (var context = new EnglishSchool())
            {
                context.ClientService.Load();
                var cs = context.Service.Single(x => x.ID == ((Service)DataGridService.SelectedItem).ID);
                if (DataGridService.SelectedItem != null)
                {
                    var clientService = new ServiceOfClient(cs);
                    clientService.ShowDialog();
                }
            }
        }
    }
}
