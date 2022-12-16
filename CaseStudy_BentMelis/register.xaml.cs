using DevExpress.Data.Browsing;
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


namespace CaseStudy_BentMelis
{
    /// <summary>
    /// Interaction logic for register.xaml
    /// </summary>
    public partial class register : Window
    {
        public register()
        {
            InitializeComponent();
        }
        public void Create()
        {
            using (UserDataContext context = new UserDataContext())
            {
                String username = txtUsername.Text;
                String password = txtPassword.Text;

                context.Users.Add(new User() { Name = username, Password = password });
                context.SaveChanges();
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Create();
            MessageBox.Show("User created succesfully!");
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Close();
        }
    }
}
