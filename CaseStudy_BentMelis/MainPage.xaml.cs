using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace CaseStudy_BentMelis
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        private List<Recept> gerechten;

        public MainPage()
        {
            InitializeComponent();
            gerechten = GetData();
            foreach (Recept recept in gerechten)
            {
                cmbRecepten.Items.Add(recept.Name);
            }

            using (IDbConnection conn = new SqliteConnection(database()))
            {
                var output = conn.Query<User>("SELECT name FROM Users WHERE id=" + Global.id + ";", new DynamicParameters()).ToList();

                try
                {
                    txtUsername.Content = output[0].Name;
                }
                catch
                {
                    txtUsername.Content = "GAAT FOUT!!";

                }

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
                var output = conn.Query<Recept>("select Name from Recepten where uId = " + Global.id +";", new DynamicParameters() );
                return output.ToList();
                conn.Close();
            }

        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            register register = new register();
            register.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            delete delete = new delete();
            delete.Show();
            this.Close();
        }

        private void btnAddRecept_click(object sender, RoutedEventArgs e)
        {
            addrecept addrecept = new addrecept();
            addrecept.Show();
            this.Close();
        }
        private void btnDeleteRecept_click(object sender, RoutedEventArgs e)
        {
            deleterecept deleterecept = new deleterecept();
            deleterecept.Show();
            this.Close();
        }

        private void cmbRecepten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (IDbConnection conn = new SqliteConnection(database()))
            {
                var output = conn.Query<Recept>("select Stappenplan from Recepten where Name='" + cmbRecepten.SelectedValue + "';", new DynamicParameters()).ToList();

                try
                {
                    txtBereiding.Text = output[0].Stappenplan;
                }
                catch 
                {
                    txtBereiding.Text = "Er gaat iets fout";
                    
                }

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginuser = new MainWindow();
            loginuser.Show();
            this.Close();
        }
    }
}
