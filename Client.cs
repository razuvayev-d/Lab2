using System;
using System.Diagnostics;

namespace Lab2
{
    /// <summary>
    /// Абстрактный класс для клиента банка
    /// </summary>
    public abstract class Client
    {      
        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public Client()
        {
        }

        /// <summary>
        /// Идентификатор клиента
        /// </summary>
         protected string name;
        /// <summary>
        /// Дата открытия счета
        /// </summary>
         protected DateTime date;
        /// <summary>
        /// Размер вклада/кредита
        /// </summary>
         protected float account_size;
        /// <summary>
        /// Конструктор базового класса Client
        /// </summary>
        /// <param name="name">Идентификатор клиента</param>
        /// <param name="date">Дата открытия счета</param>
        /// <param name="account_size">Размер вклада/кредита</param>        
        public Client(string name, DateTime date, float account_size)
        {
            this.name = name;
            this.date = date;
            this.account_size = account_size;
            Trace.WriteLine("Конструктор абстрактного класса Client завершил работу");
        }

        /// <summary>
        /// Выводит информацию о клиенте с определенным идентификатором
        /// </summary>
        /// <param name="name">идентификатор клиента</param>
        /// /// <returns>true, если нашелся экземпляр с полем name равным параметру name, false в противном случае</returns>
        public abstract bool GetClient(string name);
        /// <summary>
        /// Выводит информацию о клиенте, который открыл счет в указанную дату
        /// </summary>
        /// <param name="date">Дата открытия счета или взятия кредита</param>
        /// <returns>true, если нашелся экземпляр с полем date равным параметру date, false в противном случае</returns>
        public abstract bool GetClient(DateTime date);
        //Выводит
        /// <summary>
        /// Выводит строчку сконкатенированных полей экземпляра класса
        /// </summary>
        public abstract void GetDataBase();
        
       
    }
}
