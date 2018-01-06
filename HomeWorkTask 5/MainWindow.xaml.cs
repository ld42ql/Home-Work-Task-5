using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;


namespace HomeWorkTask_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Тестовая таблица
        /// </summary>
        TestCorporation test = new TestCorporation();
        /// <summary>
        /// Коллекция с работниками
        /// </summary>
        ObservableCollection<Employee> listEmployee;
        /// <summary>
        /// Коллекция отделов
        /// </summary>
        ObservableCollection<Department> listDepartment;

        public MainWindow()
        {
            InitializeComponent();
            test.GenericEmployee(200);
            listEmployee = test.listEmployee;
            listDepartment = test.listDepartment;
            listView.ItemsSource = listEmployee;
            departmentView.ItemsSource = test.listDepartment;
            BtnExit.Click += Exit;
        }
        
        /// <summary>
        /// Применить изменение отдела в данных работников
        /// </summary>
        private void BtnApplyEdit_Click(object sender, RoutedEventArgs e)
        {
            int j = listView.SelectedIndex;
            if (j > -1)
            {
                listEmployee[j] = new Employee(listEmployee[j].ID, listEmployee[j].Name, listEmployee[j].Surname,
                listEmployee[j].Salary, listDepartment[departmentView.SelectedIndex]);
            }
        }

        /// <summary>
        /// Показывает отдел у выбраного работника
        /// </summary>
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedIndex > -1)
            {
            departmentView.SelectedIndex = listEmployee[Convert.ToInt32(listView.SelectedIndex.ToString())].IDDepartment;
            }
        }

        /// <summary>
        /// Скрывает меню, добавляет к "Применить" метод изменения отдела у данного работника
        /// </summary>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            HideMenu();
            BtnApply.Click += BtnApplyEdit_Click;
        }

        /// <summary>
        /// Показывает меню, меняет у "Выхода" метод 
        /// </summary>
        private void ViewStartMenu(object sender, RoutedEventArgs e)
        {
            BtnApply.Visibility = Visibility.Collapsed;
            PanelAddEmployee.Visibility = Visibility.Collapsed;
            departmentView.IsEnabled = false;
            BtnAdd.Visibility = Visibility.Visible;
            BtnEdit.Visibility = Visibility.Visible;
            BtnExit.Click -= ViewStartMenu;
            BtnExit.Click += Exit;
        }

        /// <summary>
        /// Выключет программу
        /// </summary>
        private void Exit(object sender, RoutedEventArgs e)
        {
            Application application = Application.Current;
            application.Shutdown();
        }

        /// <summary>
        /// Скрывает меню, включает меню нового работника. "Применить" добавляет нового работника
        /// </summary>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            PanelAddEmployee.Visibility = Visibility.Visible;
            HideMenu();
            BtnApply.Click += BtnApplyAdd_Click;

        }

        /// <summary>
        /// Добавляет нового работника
        /// </summary>
        private void BtnApplyAdd_Click(object sender, RoutedEventArgs e) => listEmployee.Add(new Employee(listEmployee.Count + 1, TxtNameEmployee.Text, TxtSurnameEmployee.Text,
               Convert.ToInt32(TxtSalaryEmployee.Text), listDepartment[departmentView.SelectedIndex]));

        /// <summary>
        /// Скрываем меню
        /// </summary>
        private void HideMenu()
        {
            BtnApply.Visibility = Visibility.Visible;
            departmentView.IsEnabled = true;
            BtnAdd.Visibility = Visibility.Collapsed;
            BtnEdit.Visibility = Visibility.Collapsed;
            BtnApply.Click -= BtnApplyAdd_Click;
            BtnApply.Click -= BtnApplyEdit_Click;

            BtnExit.Click -= Exit;
            BtnExit.Click += ViewStartMenu;
        }
        
        /// <summary>
        /// Проверка, что в поле "зарплата" вводят цифры
        /// </summary>
        private void TxtSalaryEmployee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
