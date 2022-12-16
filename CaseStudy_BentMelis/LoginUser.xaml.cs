using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace CaseStudy_BentMelis
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
        public static string database()
        {
            String Url = "Data source = DataFile.db";
            return Url;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;

            using (UserDataContext context = new UserDataContext())
            {
                bool userFound = context.Users.Any(user => user.Name == username && user.Password == password);

                if (userFound)
                {
                    GrantAccess();
                    Close();
                }
                else
                {
                    MessageBox.Show("User not found...");
                }
            }
        }
        public void GrantAccess()
        {
            using (IDbConnection conn = new SqliteConnection(database()))
            {
                var output = conn.Query<User>("SELECT Id FROM Users WHERE name='" + txtUsername.Text + "';", new DynamicParameters()).ToList();

                try
                {
                    Global.id = output[0].Id;
                }
                catch
                {
                    Global.id = 0;

                }

            }

            MainPage main = new MainPage();
            main.Show();
        }
    }
}
