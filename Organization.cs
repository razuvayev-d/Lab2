using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
  /// <summary>
  /// Класс, описывающий организацию
  /// </summary>
    class Organization : Client
    {
        
        /// <summary>
        /// Номер счета
        /// </summary>        
        uint number;

        public Organization(string name, DateTime date, float account_size, uint number) : base(name: name, date: date, account_size: account_size)
        {
            this.number = number;
        }

        public override bool GetClient(string name)
        {
            if (this.name == name)
            {
                Console.WriteLine("Название организации  " + this.name);
                Console.WriteLine("Дата открытия счета:  " + this.date);
                Console.WriteLine("Номер счета:          " + this.number);
                Console.WriteLine("Сумма на счету        " + this.account_size);
                return true;
            }
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
                return true;
            }
            return false;
        }

        public override void GetDataBase()
        {
            Console.WriteLine(this.name.PadRight(20) + "| " + this.date + " | " + Convert.ToString(this.account_size).PadRight(10) + " |     | " + this.number);
        }
    }
}
