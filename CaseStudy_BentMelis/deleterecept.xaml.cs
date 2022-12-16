using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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

namespace CaseStudy_BentMelis
{
    /// <summary>
    /// Interaction logic for deleterecept.xaml
    /// </summary>
    public partial class deleterecept : Window
    {
        private List<Recept> gerechten;
        public deleterecept()
        {
            InitializeComponent();
            gerechten = GetData();
            foreach (Recept recept in gerechten)
            {
                cmbGerechten.Items.Add(recept.Name);
            }
        }
        public static string database()
        {
            String Url = "Data source = DataFile.db";
            return Url;
        }
        public static List<Recept> GetData()
        {
            using (IDbConnection conn = new SqliteConnection(database()))
            {
                var output = conn.Query<Recept>("select Name from Recepten where uId = " + Global.id +"; ", new DynamicParameters());
                return output.ToList();
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            String name = cmbGerechten.Text;
            using (IDbConnection conn = new SqliteConnection(database()))
            {
                conn.Query<User>("DELETE FROM Recepten WHERE name = '" + name + "'; ", new DynamicParameters());
                conn.Close();
                MessageBox.Show("Recept deleted succesfully!");
                MainPage mainPage = new MainPage();
                mainPage.Show();
                this.Close();
            }
        }
    }
}
