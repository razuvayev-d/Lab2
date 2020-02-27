using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace Lab2
{
    static class Program
    {
        public static void Main(string[] args)
        {             
            string path = "Input.txt";

            Client[] clients = null;
            List<string> ErrorLog = null;
            try
            {
                Input(in path, out clients, out ErrorLog);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine("Для завершения работы программы нажмите любую клавишу");
                Console.ReadKey();
                Environment.Exit(0);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден, повторите попытку");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Убедитесь, что количество строк, указанных в начале файла совпадает с их реальным количеством");
                Console.WriteLine("Для завершения работы программы нажмите любую клавишу");
                Console.ReadKey();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (ErrorLog.Count == 0) Console.WriteLine("База данных успешно создана");
            else
            {
                Console.WriteLine("База данных создана, однако возникло несколько ошибок.\n" +
                    "Количество отклоненных записей: " + ErrorLog.Count + ". Вы хотите посмотреть журнал ошибок? y/n");
                if(Console.ReadLine() == "y")
                {
                    Console.WriteLine("Отклоненные записи: ");
                    int i = 0;
                    while (i < ErrorLog.Count) Console.WriteLine(ErrorLog[i++]);
                }
            }
                      
            while (true)
            {                
                Console.WriteLine("Выберете необходимое действие: \n" +
                    "1) Вывести базу данных на экран \n" +
                    "2) Найти клиента\n" +
                    "3) Выйти из программы");
                int command;
                if (!Int32.TryParse(Console.ReadLine(), out command)) { Console.WriteLine("Пожалуйста, введите число"); continue; }

                int i = 0;
                if (command == 1)
                {
                    while (i < clients.Length - ErrorLog.Count)
                    {
                        clients[i++].GetDataBase();
                    }
                }
                else if (command == 2)
                {
                    Console.WriteLine("Введите имя или дату для поиска: ");
                    string str = Console.ReadLine();
                    DateTime date;
                    try
                    {
                        bool flag = false;
                        date = StringToDate(str);
                        while (i < clients.Length - ErrorLog.Count)
                        {
                            if (clients[i++].GetClient(date)) flag = true;
                        }
                        if (!flag) Console.WriteLine("{0} не совершено никаких операций по открытию", date);
                    }
                    catch
                    {                        
                        bool flag = false;
                        while (i < clients.Length - ErrorLog.Count)
                        {
                            if (clients[i++].GetClient(str)) { flag = true; break; }
                        }
                        if (!flag) Console.WriteLine("Клиент с идентификатором {0} не найден", str);
                    }
                }
                else if (command == 3)
                {
                    Environment.Exit(0);
                }
                else Console.WriteLine("Пожалуйста, введите команду от 1 до 3");
                              
            }           
        }
        /// <summary>
        /// Преобразует данные из файла в массив экземпляров класса Client
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="clients">Массив экземпляров класса Client</param>
        /// <param name="ErrorLog">Список отклоненных строк из файла</param>
        public static void Input(in string path, out Client[] clients, out List<string> ErrorLog)
        {
            StreamReader ifile = new StreamReader(path);
            string strClient;         
            string[] fields;
            
            int n;
            if (!Int32.TryParse(ifile.ReadLine(), out n))
            {
                throw new FormatException("В первой строке передано некорректное (не целочисленное) значение");
            } 

            clients = new Client[n];
            ErrorLog = new List<string>();           

            uint i = 0;

            while (!ifile.EndOfStream)
            {
                strClient = ifile.ReadLine();
                fields = strClient.Split(';');
                Trim(ref fields);
                
                try
                {
                    if (fields[0] == "d")
                    {
                        clients[i] = new Debtor(fields[1], StringToDate(fields[2]), StringToFloat(fields[3]), StringToFloat(fields[4]), StringToFloat(fields[5]));
                        i++;
                    }
                    else if (fields[0] == "c")
                    {
                        clients[i] = new Contributor(fields[1], StringToDate(fields[2]), StringToFloat(fields[3]), StringToFloat(fields[4]));
                        i++;
                    }
                    else if (fields[0] == "o")
                    {
                        clients[i] = new Organization(fields[1], StringToDate(fields[2]), StringToFloat(fields[3]), Convert.ToUInt32(fields[4]));
                        i++;
                    }
                    else
                    {
                        ErrorLog.Add(strClient);
                    }
                    
                }
                catch
                {
                    ErrorLog.Add(strClient);              
                }

            }
            ifile.Close();
        }
        /// <summary>
        /// Преобразовывает строковое представление даты в DateTime
        /// </summary>
        /// <param name="date">Строка, содержащая дату в формате "dd.mm.yyyy".
        /// Допускаются разделители ".", "-", "/".</param>
        /// <returns></returns>
        static DateTime StringToDate(string date)
        {
            if (date == null) throw new ArgumentNullException("Строковое представление даты не может быть null");
            try
            {
                int year = Convert.ToInt32(Regex.Replace(date, "[0-9]{2}[./-][0-9]{2}[./-]", ""));
                int month = Convert.ToInt32(Regex.Replace(Regex.Replace(date, "^[0-9]{2}[./-]", ""), "[./-][0-9]{4}", ""));
                int day = Convert.ToInt32(Regex.Replace(date, "[./-][0-9]{2}[./-][0-9]{4}", ""));
                DateTime dt = new DateTime(year, month, day);
                return dt;
            }
            catch
            {
                throw new FormatException("Строковое представление даты отличается от формата dd.mm.yyyy");
            }
     }
        /// <summary>
        /// Преобразовает строковое представление числа в тип float. 
        /// </summary>
        /// <param name="digit">Строка, содержащее число в формате "d.d". Допускаются разделители "." и ",".</param>
        /// <returns></returns>
        static float StringToFloat(string digit)
        {
            return Convert.ToSingle(digit.Replace('.',','));
        }
        /// <summary>
        /// Удаляет все начальные и конечные символы-разделители каждого элемента массива
        /// </summary>
        /// <param name="fields">Массив строк</param>
        static void Trim(ref string[] fields)
        {
            int i = 0;
            while (i < fields.Length)
            {
                fields[i] = fields[i].Trim();
                i++;
            }         
        }                 
    }

}

    
