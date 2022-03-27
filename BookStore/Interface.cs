using System;
using System.Diagnostics;
using static System.Console;
using static System.Convert;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    internal class Interface
    {
        static string choice;
        static string current;
        static int width = ToInt32(Round(LargestWindowWidth / 1.25));
        static int height = ToInt32(Round(LargestWindowHeight / 1.25));
        public static void Initialize()
        {
            SetWindowSize(width, height);
            MainList();
        }
        static string header = "-----БАЗА ДАННЫХ: КНИЖНЫЙ МАГАЗИН-----\n\n" +
                               "Для использования функций необходимо ввести соответствующую " +
                               "цифру на клавиатуре.\n";
        static string mainList = "Основные объекты программы:\n" +
                                 "1. Перечисления.\n" +
                                 "2. Список книг.\n" +
                                 "3. Приобретение книг.\n" +
                                 "4. Продажа книг.\n" +
                                 "Enter. Вернуться назад.\n";
        static string enumList = "Список перечислений:\n" +
                                 "1. Авторы.\n" +
                                 "2. Издательства.\n" +
                                 "3. Физические лица.\n" +
                                 "Enter. Вернуться назад.\n";
        static string funcList = "Функции:\n" +
                                 "1. Создание.\n" +
                                 "2. Просмотр.\n" +
                                 "3. Выборка.\n" +
                                 "4. Изменение.\n" +
                                 "5. Удаление.\n" +
                                 "Enter. Вернуться назад.\n";
        public static string[] bookParams = { "Название книги", "Автор", "Цена", "Издательство", "Год издания", "Страниц" };
        static string[] booksTitle = { "\tСтрока\t|", "\tНазвание\t|", "\tАвтор\t|", "\tЦена\t|", "\tИздатель\t|", "\tГод\t|", "\tСтраниц\n" };
        static string Input()
        {
            Write("\t> ");
            return ReadLine();
        }
        static string Input(string text)
        {
            Write($"{text}\n\t> ");
            return ReadLine();
        }
        static string Input(out string input)
        {
            Write("\t> ");
            input = ReadLine();
            return input;
        }
        static void OutputHeader(string list)
        {
            Clear();
            WriteLine($"{header}\n{list}");
        }
        static string SetChoice()
        {
            choice += Input(out current);
            return current;
        }
        static void ReturnTo()
        {
            if (choice[1] == '0')
                MainList();
            else
                EnumList();
        }
        static void MainList()
        {
            choice = "";
            OutputHeader(mainList);
            switch (SetChoice())
            {
                case "":
                    break;
                case "1":
                    EnumList();
                    break;
                case "2":
                case "3":
                case "4":
                    FuncList();
                    break;
                default:
                    MainList();
                    break;
            }
        }
        static void EnumList()
        {
            choice = choice[0].ToString();
            OutputHeader(enumList);
            switch (SetChoice())
            {
                case "":
                    MainList();
                    break;
                case "1":
                case "2":
                case "3":
                    FuncList();
                    break;
                default:
                    EnumList();
                    break;
            }
        }
        static void FuncList()
        {
            if (choice.Length == 1)
                choice += "0";
            choice = choice.Substring(0, 2);
            OutputHeader(funcList);
            switch (SetChoice())
            {
                case "":
                    ReturnTo();
                    break;
                case "1":
                    break;
                case "2":
                    WriteLine(Database.Read(choice.Substring(1, 2)));
                    Input("Enter. Что бы продолжить.");
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                default:
                    FuncList();
                    break;
            }
        }
    }
}
