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
    /// Interaction logic for DeleteWorker.xaml
    /// </summary>
    public partial class DeleteWorker : Window
    {
        private Database1Entities db1 =  new Database1Entities();
        private employee dlt_wrkr;
        public DeleteWorker( Database1Entities db1)
        {
            this.db1 = db1;
            InitializeComponent();
        }

        private void dlt_worker_Click(object sender, RoutedEventArgs e)
        {
            bool flg = false;
            if (deleted_id_txb.Text != "")
            {
                List<employee> lst_emp = new List<employee>();
                lst_emp = db1.employee.ToList();
                foreach (employee employee in lst_emp)
                {
                    if (employee.id_number == deleted_id_txb.Text)
                    {
                        dlt_wrkr = employee;
                        flg = true;
                    }
                }
                if (flg == false)
                    lstb.Items.Add("Failure! the worker does not exist or has already been deleted");
                else
                {
                    db1.employee.Remove(dlt_wrkr);
                    db1.SaveChanges();
                    this.Close();
                }
            }
            else
                lstb.Items.Add("Failure! enter the id of the worker you want to delete");
        }
    }
}
