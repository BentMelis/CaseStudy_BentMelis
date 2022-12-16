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

namespace CaseStudy_BentMelis
{
    /// <summary>
    /// Interaction logic for addrecept.xaml
    /// </summary>
    public partial class addrecept : Window
    {
        public addrecept()
        {
            InitializeComponent();
        }

        private void btnAddRecept_Click(object sender, RoutedEventArgs e)
        {
            using (UserDataContext context = new UserDataContext())
            {
                String naam = txtReceptnaam.Text;
                String recept = txtRecept.Text;
                int userid = Global.id;

                context.Recepten.Add(new Recept() { Name = naam, Stappenplan = recept, uId = userid });
                context.SaveChanges();
            }
            MessageBox.Show("Je recept is toegevoegd!");

            MainPage mainPage = new MainPage();
            mainPage.Show();

            this.Close();
        }


    }
}
