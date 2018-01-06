using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTask_5
{
    /// <summary>
    /// Класс наемные рабочие
    /// </summary>
    class Employee
    {
        private int id;
        /// <summary>
        /// Индивидуальный номер
        /// </summary>
        public int ID => id;

        private string name = String.Empty;
        /// <summary>
        /// Имя рабочего
        /// </summary>
        public string Name => name;

        private string surname = String.Empty;
        /// <summary>
        /// Фамилия рабочего
        /// </summary>
        public string Surname => surname;

        private int salary;
        /// <summary>
        /// Ставка рабочего
        /// </summary>
        public int Salary { get => salary; set => salary = value; }

        Department department;

        /// <summary>
        /// Номер отдела к которому прикреплен рабочей
        /// </summary>
        public int IDDepartment => department.ID;

        /// <summary>
        /// Наемный рабочий
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="department">Отдел</param>
        public Employee(int id, string name, string surname, int salary, Department department)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.salary = salary;
            this.department = department;
        }

        /// <summary>
        /// Данные о работнике в виде строки
        /// </summary>
        public override string ToString() => $"Номер: {id}; Имя: {name}; Фамилия: {surname}." +
            $" Отдел: {department.ToString()}, зарплата: {(salary * department.Coefficient):F2}";
    }
}
