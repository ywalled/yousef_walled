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
   
    public partial class managerboard : Window
    {
       public dbconnection context = new dbconnection();
        public managerboard()
        {
            InitializeComponent();
            load_data();
        }
        public void load_data()
        {
            tasktable.ItemsSource = context.Tasks.ToList();
        }
        public int id;
        public string title;
        public string description;
        public int empid;

        private void add_Click(object sender, RoutedEventArgs e)
        {
            title = title_text.Text;
            description = des_text.Text;
            empid = int.Parse(emp_id.Text);
            Task x = new Task();
            x.describtion = description;
            x.eployeeid = empid;
            x.title = title;
            x.status = "pending";
            context.Tasks.Add(x);
            context.SaveChanges();
            MessageBox.Show("task added succ");
            load_data();

                 






        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            id = int.Parse(id_text.Text);
            title = title_text.Text;
            description = des_text.Text;
            empid = int.Parse(emp_id.Text);
            var x = context.Tasks.FirstOrDefault(c => c.taskid == id);
            if (x != null)
            {
                x.title = title;
                x.describtion = description;
                x.eployeeid = empid;
                context.SaveChanges();
                MessageBox.Show("task updated succ");
                load_data();



            }
            else
            {

                MessageBox.Show("task not found");

            }






        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            id = int.Parse(id_text.Text);
            var x = context.Tasks.FirstOrDefault(c => c.taskid == id);
            if (x != null)
            {
                context.Tasks.Remove(x);
                context.SaveChanges();
                MessageBox.Show("task deleted suc");
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
