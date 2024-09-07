using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Home
{
    internal class Program
    {
        /// <summary>
        /// Метод для создания файла и записи строк
        /// </summary>
        /// <param name="strings">Данные о человеке</param>
        /// <returns>Заполненный файл</returns>
        static string CreateF(string strings)
        {

            int ID = 0;
            if (File.Exists("Сотрудники.csv") == false)
            {
                using (StreamWriter sw = new StreamWriter("Сотрудники.csv", true, Encoding.Unicode))
                {
                    string title = "ID \tДата и время \tФИО \tВозраст \tРост \tДата рождения \tМесто рождения";
                    sw.WriteLine(title);
                    sw.Flush();
                    sw.Close();
                }
            }
            
            using (StreamReader sr = new StreamReader("Сотрудники.csv", Encoding.Unicode))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    ID++;
                }
            }

            using (StreamWriter sw = new StreamWriter("Сотрудники.csv", true, Encoding.Unicode))
            {
                char key = '2';

                do
                {
                    string note = string.Empty;

                    note += $"{ID}\t";

                    DateTime now = new DateTime();
                    now = DateTime.Now;

                    Console.WriteLine($"Дата и время добавления записи: {now}");
                    note += $"{now}\t";

                    Console.Write("\nВведите ФИО сотрудника: ");
                    note += $"{Console.ReadLine()}\t";

                    Console.Write("Введите возраст сотрудника: ");
                    note += $"{Console.ReadLine()}\t";

                    Console.Write("Введите рост сотрудника: ");
                    note += $"{Console.ReadLine()}\t";

                    Console.Write("Введите дату рождения сотрудника: ");
                    note += $"{Console.ReadLine()}\t";

                    Console.Write("Введите место рождения сотрудника: ");
                    note += $"{Console.ReadLine()}\t";

                    sw.WriteLine(note);
                    Console.WriteLine("\nНажмите 1, чтобы показать информацию о сотрудниках, или 2, чтобы записать нового сотрудника\n");
                    ID++;
                    key = Console.ReadKey(true).KeyChar;

                } while (char.ToLower(key) == '2');
                sw.Flush();
                sw.Close();
                if (char.ToLower(key) == '1')
                {
                    Print(strings);
                }
            }
            return "Сотрудники.scv";
        }

        /// <summary>
        /// Метод вывода информации о сотрудниках
        /// </summary>
        /// <param name="info">Справочник</param>
        /// <returns>Данные из справочника</returns>
        static string Print(string info)
        {
            char key = '1';
            if (File.Exists("Сотрудники.csv") == false)
            {
                Console.WriteLine("Данные отсутствуют. Добавьте запись");
                CreateF(info);
            }
            using (StreamReader sr = new StreamReader("Сотрудники.csv", Encoding.Unicode))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('\t');
                    Console.WriteLine($"{data[0]}{data[1],25}{data[2],25}{data[3],10}{data[4],10}{data[5],20} {data[6],20}");
                }

                if ((line = sr.ReadLine()) == null)
                {
                    Console.WriteLine("\nНажмите 2, чтобы добавить новую запись\n");
                    sr.Close();
                    key = Console.ReadKey(true).KeyChar;
                    if (char.ToLower(key) == '2')
                    {
                        CreateF(info);
                    }
                }
            }
            return "Сотрудники.csv";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Справочник 'Сотрудники'");
            Console.WriteLine("\nНажмите 1, чтобы показать информацию о сотрудниках, или 2, чтобы записать нового сотрудника\n");
            string oneTwo = Console.ReadLine();
            if (oneTwo == "1")
            {
                Print(oneTwo);
            }
            else
            {
                CreateF(oneTwo);
            }
            Console.ReadKey();
        }
    }
}
