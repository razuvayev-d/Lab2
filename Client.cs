using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab2
{
    /// <summary>
    /// Абстрактный класс для клиента банка
    /// </summary>
    abstract class Client
    {       
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
               
        public Client(string name, DateTime date, float account_size)
        {
            this.name = name;
            this.date = date;
            this.account_size = account_size;         
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
