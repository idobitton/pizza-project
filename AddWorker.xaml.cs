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

namespace WpfApp50
{
    /// <summary>
    /// Interaction logic for AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {
        private Database1Entities db1 = new Database1Entities();
        private DataGrid emp_dtgrid;
        public AddWorker(DataGrid emp, Database1Entities db1)
        {
            this.emp_dtgrid = emp;
            this.db1 = db1;
            InitializeComponent();
        }

        private void sbmt_btn_Click(object sender, RoutedEventArgs e)
        {
            int slryphour = 0;
            string gndr = "";
            if (num_id_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter your id");
            else if (name_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter your name");
            else if (phne_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter your phone");
            else if (city_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter your city");
            else if (strt_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter your street");
            else if (house_num_txb.Text == "")
                msg_lsb.Items.Add("Failure! Enter your house number");
            else if (female_rdb.IsChecked == false && male_rdb.IsChecked == false)
                msg_lsb.Items.Add("Failure Enter your gender");
            else if (emp_cmbbx.SelectedItem == null)
                msg_lsb.Items.Add("Failure! Enter your Type");
            else
            {
                if (male_rdb.IsChecked == true)
                    gndr = "male";
                else
                    gndr = "female";
                if (emp_cmbbx.Text == "Manager")
                    slryphour = 120;
                else if (emp_cmbbx.Text == "Chef")
                    slryphour = 32;
                else if (emp_cmbbx.Text == "Shift manager")
                    slryphour = 38;
                else
                    slryphour = 29;
                msg_lsb.Items.Add("The worker have been added");
                employee_type employee_Type = db1.employee_type.Add(new employee_type {type=emp_cmbbx.Text, salaryperhour=slryphour});
                postal_code postal_Code = db1.postal_code.Add(new postal_code { city = city_txb.Text, street = strt_txb.Text, house_number = house_num_txb.Text });
                employee employ = new employee { deleted = 0, id_number = num_id_txb.Text, name = name_txb.Text, phone = phne_txb.Text, gender = gndr, employee_type = employee_Type, postal_code = postal_Code };

                db1.employee.Add(employ);
                emp_dtgrid.ItemsSource = db1.employee.ToList();
                this.db1.SaveChanges();
                this.Close();
            }
        }
    }
}
