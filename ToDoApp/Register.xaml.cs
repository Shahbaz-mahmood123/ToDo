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
using ToDoApp.LoginPage;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        private void Submit(object sender, RoutedEventArgs e)
        {
            string username;
            string password;
            string emailAddress;
            int userid;
            userid = 5;
            var User = new User();
            username = Usernametxt.Text;
            password = PasswordTxt.Password;
            emailAddress = Email.Text;

            User.UserInsert(username, password, emailAddress, userid);

        }
        private void Return(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Register register = new Register();
            mainWindow.Show();
            register.Close();
        }

    }
}
