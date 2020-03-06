using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Lab2
{
    [Serializable]
    /// <summary>
    /// Класс, описывающий организацию
    /// </summary>
    public class Organization : Client
    {
        
        /// <summary>
        /// Номер счета
        /// </summary>        
        uint number;

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public Organization()
        {
        }

        /// <summary>
        /// Конструктор производного класса Organization
        /// </summary>
        /// <param name="name">Название организации</param>
        /// <param name="date">Дата открытия счета</param>
        /// <param name="account_size">Размер вклада</param>  
        /// <param name="number">Номер счета</param>
        public Organization(string name, DateTime date, float account_size, uint number) : base(name: name, date: date, account_size: account_size)
        {
            this.number = number;
            Trace.WriteLine("Конструктор класса Organization завершил работу");
        }

        public override bool GetClient(string name)
        {
            if (this.name == name)
            {
                Console.WriteLine("Название организации  " + this.name);
                Console.WriteLine("Дата открытия счета:  " + this.date);
                Console.WriteLine("Номер счета:          " + this.number);
                Console.WriteLine("Сумма на счету        " + this.account_size);
                Trace.WriteLine("Метод GetClient(string) класса Organization завершил работу");
                return true;
            }
            Trace.WriteLine("Метод GetClient(string) класса Organization завершил работу");
            return false;
        }

        public override bool GetClient(DateTime date)
        {
            if (this.date == date)
            {
                Console.WriteLine("{0} не найден", name);
                Console.WriteLine("Фамилия вкладчика:    " + this.name);
                Console.WriteLine("Дата открытия вклада: " + this.date);
                Console.WriteLine("Номер счета:          " + this.number);
                Console.WriteLine("Размер вклада:        " + this.account_size);
                Trace.WriteLine("Метод GetClient(DateTime) класса Organization завершил работу");
                return true;
            }
            Trace.WriteLine("Метод GetClient(DateTime) класса Organization завершил работу");
            return false;
        }

        public override void GetDataBase()
        {
            Console.WriteLine(this.name.PadRight(20) + "| " + this.date + " | " + Convert.ToString(this.account_size).PadRight(10) + " |     | " + this.number);
            Trace.WriteLine("Метод GetDataBase() класса Organization завершил работу");
        }
    }
}
