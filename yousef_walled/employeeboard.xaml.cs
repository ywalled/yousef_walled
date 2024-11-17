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

namespace yousef_walled
{
   
    public partial class employeeboard : Window
    {
        public dbconnection context = new dbconnection();
        public employeeboard()
        {
            InitializeComponent();
            load_data();
        }
        public string name;
        public void load_data()
        {
            com_tasks.ItemsSource = context.Tasks.Where(c => c.status == "complete"&& c.eployeeid == MainWindow.id).ToList();
            tasks.ItemsSource = context.Tasks.Where(c => c.status == "inprogres" || c.status == "pending" && c.eployeeid == MainWindow.id).ToList();

        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            name = task_text.Text;
            var x = context.Tasks.FirstOrDefault(c => c.title == name);
            if (x != null)
            {
                x.status = "inprogres";
                context.SaveChanges();
                MessageBox.Show("task started");
                load_data();







            }






        }

        private void complete_Click_1(object sender, RoutedEventArgs e)
        {

            name = task_text.Text;
            var x = context.Tasks.FirstOrDefault(c => c.title == name);
            if (x != null)
            {
                x.status = "complete";
                context.SaveChanges();
                MessageBox.Show("task completed");
                load_data();







            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
