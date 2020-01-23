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

namespace WpfApp50
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Database1Entities db1 = new Database1Entities();
        public MainWindow()
        {
            InitializeComponent();
            emp_dtgrid.ItemsSource = db1.employee.ToList();
        }

        private void add_worker_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddWorker addWorker = new AddWorker(emp_dtgrid,db1);
            addWorker.ShowDialog();
            emp_dtgrid.ItemsSource = db1.employee.ToList();
            this.Show();
        }

        private void delete_worker_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DeleteWorker deleteWorker = new DeleteWorker(db1);
            deleteWorker.ShowDialog();
            emp_dtgrid.ItemsSource = db1.employee.ToList();
            this.Show();
        }

        private void clients_services_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ext_btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
