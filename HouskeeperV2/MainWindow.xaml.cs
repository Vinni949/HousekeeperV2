using HousekeeperV2.Controller;
using HousekeeperV2.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace HousekeeperV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        Logic logic = new Logic();
        public MainWindow()
        {
            InitializeComponent();
            TeacherList.ItemsSource = logic.OutputAllTeachers();
            KeyList.ItemsSource = logic.OutputAllKey();
            returnKeyList.ItemsSource = logic.IssuedKeyList();
            HistorusDay.ItemsSource = logic.HistorusDay();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (logic.InputAdmin(Log_text.Text, Pas_text.Text) == true)
            {
                var newForm = new Admin();
                newForm.Show();
                this.Close();
            }
            else
                MessageBox.Show("не верный логин или пароль!");
        }
        private void returnKey_Click(object sender, RoutedEventArgs e)
        {
            string teacher = returnKeyList.SelectedItem as string;
            MessageBox.Show(logic.ReturnTeacherToKey(teacher));
            TeacherList.ItemsSource = logic.OutputAllTeachers();
            KeyList.ItemsSource = logic.OutputAllKey();
            returnKeyList.ItemsSource = logic.IssuedKeyList();

        }
        private void IssueAKey_Click(object sender, RoutedEventArgs e)
        {
            var teacher = TeacherList.SelectedItem as Object;
            var key = KeyList.SelectedItem as Object;
            MessageBox.Show(logic.IssuedTeacherKey(teacher, key));
            TeacherList.ItemsSource = logic.OutputAllTeachers();
            KeyList.ItemsSource = logic.OutputAllKey();
            returnKeyList.ItemsSource = logic.IssuedKeyList();

        }

    }
}
