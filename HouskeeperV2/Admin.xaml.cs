using HousekeeperV2.Models;
using HousekeeperV2.Controllers;
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

namespace HousekeeperV2
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        AdminController adminController = new AdminController();

        public Admin()
        {
            InitializeComponent();
            History.ItemsSource = adminController.AdminHistories();
        }

        private void DeletedTeacher_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(adminController.DeletedTeacher(Convert.ToInt32(DellIdTeacherText.Text)));
            DellIdTeacherText.Clear();
        }

        private void DelletedKey_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(adminController.DeletedKey(Convert.ToInt32(KeyID.Text)));
            KeyID.Clear();
        }

        private void AddTeacher_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(adminController.AddTeacher(AddTeacher.Text));
            AddTeacher.Clear();
        }

        private void AddKey_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(adminController.AddKey(KeyAdd.Text));
            KeyAdd.Clear();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new MainWindow();
            newForm.Show();
            this.Close();
        }
    }
}
