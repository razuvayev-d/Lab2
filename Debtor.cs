using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /// <summary>
    /// Класс, описывающий заёмщика
    /// </summary>
    class Debtor : Client
    {
        /// <summary>
        /// Процент по кредиту
        /// </summary>
        float percent;
        /// <summary>
        /// Остаток долга
        /// </summary>
        float balance;
        public Debtor(string name, DateTime date, float account_size, float percent, float balance) : base(name: name, date: date, account_size: account_size)
        {
            this.percent = percent;
            this.balance = balance;
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
                return true;
            }
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
                return true;
            }
            return false;
        }
        
        public override void GetDataBase()
        {          
            Console.WriteLine(this.name.PadRight(20) + "| " + this.date + " | " + Convert.ToString(this.account_size).PadRight(10) + " | " + Convert.ToString(this.percent).PadRight(3) + " | " + this.balance);
        }
    }
}
