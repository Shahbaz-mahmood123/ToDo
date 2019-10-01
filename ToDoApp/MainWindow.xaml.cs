using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoApp.LoginPage;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogOn(object sender, RoutedEventArgs e)
        {

            string username;
            string password;
            var  User = new User();
            username = Usernametxt.Text;
            password = PasswordTxt.Password;
            User.LogIn(username, password);
          
         

        }
        private void Register( object sender, RoutedEventArgs e)
        {
            Register register= new Register();
            this.Close();
            register.Show();

        }
    }
}
