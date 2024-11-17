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

namespace yousef_walled
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public dbconnection context = new dbconnection();
        public static int id;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void log_in_Click(object sender, RoutedEventArgs e)
        {
            string emaillll = email.Text;
            string passs = pass.Password;
            var x = context.Users.FirstOrDefault(c => c.email == emaillll && c.password == passs);
            if (x !=null)
            {
                if (x.roll == "employee")
                {
                    id= x.userid;
                    employeeboard employeeboard = new employeeboard();
                    employeeboard.Show();
                    this.Close();
                    MessageBox.Show("you loged as employee");

                }
                else if(x.roll== "manager")
                {
                    managerboard managerboard = new managerboard();
                    managerboard.Show();
                    this.Close();
                    MessageBox.Show("you loged as manager");


                }
            }
            else
            {

                MessageBox.Show("wrong email or pass");
            }
            




        }
    }
}
