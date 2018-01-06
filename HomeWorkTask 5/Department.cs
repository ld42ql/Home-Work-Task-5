using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTask_5
{
    /// <summary>
    /// Класс Отдел
    /// </summary>
    class Department
    {
        private string department;

        private int id;
        /// <summary>
        /// Индивидуальный номер отдела
        /// </summary>
        public int ID => id;

        private double coefficient;
        /// <summary>
        /// Коэфициент ставки
        /// </summary>
        public double Coefficient => coefficient;

        /// <summary>
        /// Отдел
        /// </summary>
        /// <param name="department">Наименнование отдела</param>
        /// <param name="coefficient">Коэфициент ставки</param>
        public Department(int id, string department, double coefficient)
        {
            this.id = id;
            this.department = department;
            this.coefficient = coefficient;
        }

        /// <summary>
        /// Выводит название отдела
        /// </summary>
        public override string ToString() => $"{department}";
    }
}
