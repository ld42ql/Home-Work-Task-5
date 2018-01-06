using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace HomeWorkTask_5
{
    /// <summary>
    /// Класс для тестов
    /// </summary>
    class TestCorporation
    {
       static Random random = new Random();
       public ObservableCollection<Department> listDepartment;

       public ObservableCollection<Employee> listEmployee;

        /// <summary>
        /// Генерируем десять отделов
        /// </summary>
        /// <returns>Список с отделами</returns>
        ObservableCollection<Department> GenericDep()
        {
            listDepartment = new ObservableCollection<Department>();
            for (int i = 0; i < 10; i++)
            {
                listDepartment.Add(new Department(i, $"Отдел №{i + 1}", random.NextDouble()));
            }
            return listDepartment;
        }

        /// <summary>
        /// Генерируем работников
        /// </summary>
        /// <param name="count">Количество работников</param>
        public  void GenericEmployee(int count)
        {
           listDepartment = GenericDep();
            listEmployee = new ObservableCollection<Employee>();

            for (int i = 0; i < count; i++)
            {
                listEmployee.Add(new Employee(i + 1, RandomString(5), RandomString(10), random.Next(20, 500), listDepartment[random.Next(0,9)]));
            }
        }

        /// <summary>
        /// Создаем случайную строку
        /// </summary>
        /// <param name="count">Максимальное возможное количество букв</param>
        /// <returns></returns>
        string RandomString (int count)
        {
            int n = random.Next(5, count);
            string str = String.Empty;
            char[] arrayChar = new char[n];
            for (int i = 0; i < n; i++)
            {
                arrayChar[i] = (char)random.Next(0x0430, 0x44F);
                
                str += arrayChar[i];
            }
            return str;
        }
    }
}
