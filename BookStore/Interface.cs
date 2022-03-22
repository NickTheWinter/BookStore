using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    internal class Interface
    {
        static string mainChoice;
        static string choice;
        static string header = "-----БАЗА ДАННЫХ: КНИЖНЫЙ МАГАЗИН-----\n\n" +
                               "Для использования функций необходимо ввести соответствующую " +
                               "цифру на клавиатуре.\n";
        static string mainList = "Основные функции программы:\n" +
                                 "1. Изменить состав перечислений.\n" +
                                 "2. Просмотреть или изменить список книг.\n" +
                                 "3. Произвести приобретение книг.\n" +
                                 "4. Произвести продажу книг.\n" +
                                 "Enter. Вернуться назад.\n";
        static string enumList = "Список перечислений:\n" +
                                 "1. Авторы.\n" +
                                 "2. Издательства.\n" +
                                 "3. Физические лица.\n" +
                                 "Enter. Вернуться назад.\n";
        static string func = "Функции:\n" +
                             "1. Просмотр.\n" +
                             "2. Создание.\n" +
                             "3. Изменение.\n" +
                             "4. Удаление.\n" +
                             "Enter. Вернуться назад.\n";
        static string Read()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }
        static void WriteHeader(string list)
        {
            Console.Clear();
            Console.WriteLine($"{header}\n{list}");
        }
        static void FuncWrite()
        {
            WriteHeader(func);
            switch (Read())
            {
                case "":
                    EnumListWrite();
                    break;
                case "1":

                    break;
                case "2":
                    if (mainChoice == "1")
                        Console.WriteLine("\nВведите новое наименование.\n" + Authors.Add(Read()));
                    break;
                case "3":

                    break;
                case "4":

                    break;
                default:
                    FuncWrite();
                    break;
            }
        }
        static void EnumListWrite()
        {
            WriteHeader(enumList);
            choice = Read();
            switch (choice)
            {
                case "":
                    MainWrite();
                    break;
                case "1":
                case "2":
                case "3":
                    FuncWrite();
                    break;
                default:
                    EnumListWrite();
                    break;
            }
        }
        public static void MainWrite()
        {
            WriteHeader(mainList);
            mainChoice = Read();
            switch (mainChoice)
            {
                case "":
                    break;
                case "1":
                    EnumListWrite();
                    break;
                case "2":
                case "3":
                case "4":
                    FuncWrite();
                    break;
                default:
                    MainWrite();
                    break;
            }
        }
    }
}
