using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Lab2
{
    [Serializable]
    /// <summary>
    /// Класс, описывающий заёмщика
    /// </summary>
    public class Debtor : Client
    {
        /// <summary>
        /// Процент по кредиту
        /// </summary>
        float percent;
        /// <summary>
        /// Остаток долга
        /// </summary>
        float balance;

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public Debtor()
        {
        }

        /// <summary>
        /// Конструктор производного класса Debtor
        /// </summary>
        /// <param name="name">Идентификатор клиента</param>
        /// <param name="date">Дата открытия счета</param>
        /// <param name="account_size">Размер кредита</param>  
        /// <param name="percent">Процент по кредиту</param>
        /// <param name="balance">Остаток долга</param>
        public Debtor(string name, DateTime date, float account_size, float percent, float balance) : base(name: name, date: date, account_size: account_size)
        {
            this.percent = percent;
            this.balance = balance;
            Trace.WriteLine("Конструктор класса Debtor завершил работу");
        }

        public override bool GetClient(string name)
        {
            if (this.name == name)
            {
                Console.WriteLine("Фамилия заёмщика:    " + this.name);
                Console.WriteLine("Дата взятия кредита: " + this.date);
                Console.WriteLine("Размер кредита:      " + this.account_size);
                Console.WriteLine("Процент по кредиту:  " + this.percent);
                Console.WriteLine("Остаток долга:       " + this.balance);
                Trace.WriteLine("Метод GetClient(string) класса Debtor завершил работу");
                return true;
            }
            Trace.WriteLine("Метод GetClient(string) класса Debtor завершил работу");
            return false;
        }

        public override bool GetClient(DateTime date)
        {
            if (this.date == date)
            {
                Console.WriteLine("Фамилия заёмщика:    " + this.name);
                Console.WriteLine("Дата взятия кредита: " + this.date);
                Console.WriteLine("Размер кредита:      " + this.account_size);
                Console.WriteLine("Процент по кредиту:  " + this.percent);
                Console.WriteLine("Остаток долга:       " + this.balance);
                Trace.WriteLine("Метод GetClient(DateTime) класса Debtor завершил работу");
                return true;
            }
            Trace.WriteLine("Метод GetClient(DateTime) класса Debtor завершил работу");
            return false;
        }
        
        public override void GetDataBase()
        {          
            Console.WriteLine(this.name.PadRight(20) + "| " + this.date + " | " + Convert.ToString(this.account_size).PadRight(10) + " | " + Convert.ToString(this.percent).PadRight(3) + " | " + this.balance);
            Trace.WriteLine("Метод GetDataBase() класса Debtor завершил работу");
        }
    }
}
