using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /// <summary>
    /// Класс описывающий вкладчика
    /// </summary>
    class Contributor : Client
    {
        /// <summary>
        /// Процент по вкладу
        /// </summary>
        float percent;

        public Contributor(string name, DateTime date, float account_size, float percent) : base(name: name, date: date, account_size: account_size)
        {
            this.percent = percent;

        }    

        public override bool GetClient(string name)
        {
            if (this.name == name)
            {
                Console.WriteLine("Фамилия вкладчика:    " + this.name);
                Console.WriteLine("Дата открытия вклада: " + this.date);
                Console.WriteLine("Размер вклада:        " + this.account_size);
                Console.WriteLine("Процент по вкладу:    " + this.percent);
                return true;
            }
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
                return true;
            }
            return false;
        }

        public override void GetDataBase()
        {
            Console.WriteLine(this.name.PadRight(20) + "| " + this.date + " | " + Convert.ToString(this.account_size).PadRight(10) + " | " + Convert.ToString(this.percent).PadRight(3) + " |");
        }

    }
}
