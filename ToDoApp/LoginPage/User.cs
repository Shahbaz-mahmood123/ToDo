using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ToDoApp.LoginPage
{
    public class User   
    {

        private string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ToDo; Integrated Security = True";
        private string connectString;
        public User()
        {
            connectString = connectionString;
        }

        public static void LogIn(string username, string password)
        {
            SqlConnection Conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ToDo; Integrated Security = True");

            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                string query = "SELECT COUNT(1) from Users where Username =@Username and Password=@Password ";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow mainWindow = new MainWindow();
                    Home home = new Home();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password incorrect");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {
                Conn.Close();
            }
        }
        public void UserInsert(string userName, string password, string emailAddress, int userid)
        {
            //Initalise vairable and SQL connections

            //execute Stored procedure to insert initial user value into the user table. 
            using (SqlConnection cnn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand("USER_INSERT", cnn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AV_PASSWORD", SqlDbType.VarChar).Value = password;
                        cmd.Parameters.AddWithValue("@AV_USERNAME", SqlDbType.VarChar).Value = userName;
                        cmd.Parameters.AddWithValue("@AV_EMAILADDRESS", SqlDbType.VarChar).Value = emailAddress;
                        cmd.Parameters.AddWithValue("@AV_USERID", SqlDbType.Int).Value = userid;
                        //returning created user id to use in the preference insert stored procedure and exectuing the USER_INSERT Stored procedure
                        cmd.Parameters.Add("@USERId", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        int userId = (int)cmd.Parameters["@USERId"].Value;
                        cmd.Dispose();
                        cnn.Close();
                        MessageBox.Show("Account created" + "" + userId);

                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

        }
    }
}


       
     
