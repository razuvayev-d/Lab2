using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Lab2
{
    [Serializable]
    /// <summary>
    /// Класс описывающий вкладчика
    /// </summary>
    public class Contributor : Client
    {
        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public Contributor()
        {
        }


        /// <summary>
        /// Процент по вкладу
        /// </summary>
        float percent;
        /// <summary>
        /// Конструктор производного класса Contributor
        /// </summary>
        /// <param name="name">Имя вкладчика</param>
        /// <param name="date">Дата открытия счета</param>
        /// <param name="account_size">Размер вклада</param>  
        /// <param name="percent">Процент по вкладу</param>
        public Contributor(string name, DateTime date, float account_size, float percent) : base(name: name, date: date, account_size: account_size)
        {
            this.percent = percent;
            Trace.WriteLine("Конструктор класса Contributor завершил работу");
        }    

        public override bool GetClient(string name)
        {
            if (this.name == name)
            {
                Console.WriteLine("Фамилия вкладчика:    " + this.name);
                Console.WriteLine("Дата открытия вклада: " + this.date);
                Console.WriteLine("Размер вклада:        " + this.account_size);
                Console.WriteLine("Процент по вкладу:    " + this.percent);
                Trace.WriteLine("Метод GetClient(string) класса Contributor завершил работу");
                return true;
            }
            Trace.WriteLine("Метод GetClient(string) класса Contributor завершил работу");
            return false;
        }


        public override bool GetClient(DateTime date)
        {
            if (this.date == date)
            {                
                Console.WriteLine("Фамилия вкладчика:    " + this.name);
                Console.WriteLine("Дата открытия вклада: " + this.date);
                Console.WriteLine("Размер вклада:        " + this.account_size);
                Console.WriteLine("Процент по вкладу:     " + this.percent);
                Trace.WriteLine("Метод GetClient(DateTime) класса Contributor завершил работу");
                return true;
            }
            Trace.WriteLine("Метод GetClient(DateTime) класса Contributor завершил работу");
            return false;
        }

        public override void GetDataBase()
        {
            Console.WriteLine(this.name.PadRight(20) + "| " + this.date + " | " + Convert.ToString(this.account_size).PadRight(10) + " | " + Convert.ToString(this.percent).PadRight(3) + " |");
            Trace.WriteLine("Метод GetDataBase() класса Contributor завершил работу");
        }

    }
}
