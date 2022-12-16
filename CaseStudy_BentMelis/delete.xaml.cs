using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Security.Policy;
using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace CaseStudy_BentMelis
{
    /// <summary>
    /// Interaction logic for delete.xaml
    /// </summary>
    public partial class delete : Window
    {
        private List<User> DatabaseUsers;

        public delete()
        {
            InitializeComponent();
            DatabaseUsers = GetData();
            foreach (User user in DatabaseUsers)
            {
                cmbUsers.Items.Add(user.Name);
            }
            
        }
        public static string database()
        {
            String Url = "Data source = DataFile.db";
            return Url;
        }
        public static List<User> GetData()
        {
            using (IDbConnection conn = new SqliteConnection(database()))
            {
                var output = conn.Query<User>("select Name from Users", new DynamicParameters());
                return output.ToList();
                conn.Close();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            String name = cmbUsers.Text;
            using (IDbConnection conn = new SqliteConnection(database()))
            {
                conn.Query<User>("DELETE FROM Users WHERE name = '" + name + "'; ", new DynamicParameters());
                conn.Close();
                MessageBox.Show("User deleted succesfully!");

                MainPage mainPage = new MainPage();
                mainPage.Show();

                this.Close();
            }
            
        }
    }
}
