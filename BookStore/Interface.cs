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
        static string secondChoice;
        static string choice;
        static int level;
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
        static string[] bookParams = { "\nНазвание книги", "Автор", "Цена", "Издательство", "Год издания", "Кол-во страниц" };
        static string Read(string text)
        {
            Console.Write($"{text}:> ");
            return Console.ReadLine();
        }
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
            level = 2;
            WriteHeader(func);
            switch (Read())
            {
                case "":
                    if(mainChoice == "1")
                        Movement(level - 1);
                    else
                        Movement(level - 2);
                    break;
                case "1":
                    if (mainChoice == "1")
                    {
                        switch (secondChoice)
                        {
                            case "1":
                                Console.WriteLine(Authors.Read());
                                level = 2;
                                Read();
                                break;
                            case "2":
                                Console.WriteLine(Publishers.Read());
                                level = 2;
                                Read();
                                break;
                            case "3":
                                Console.WriteLine(Persons.Read());
                                level = 2;
                                Read();
                                break;
                        }
                        FuncWrite();
                    }
                    else if (mainChoice == "2")
                    {
                        Console.WriteLine(Books.Read()); 
                        level = 1;
                        Read();
                        FuncWrite();
                    }
                    break;
                case "2":
                    if (mainChoice == "1")
                    {
                        switch (secondChoice)
                        {
                            case "1":
                                Console.WriteLine($"\nВведите новое наименование.\n");
                                Authors.Add(Read());
                                level = 2;
                                break;
                            case "2":
                                Console.WriteLine($"\nВведите новое наименование.\n");
                                Publishers.Add(Read());
                                level = 2;
                                break;
                            case "3":
                                Console.WriteLine($"\nВведите новое наименование.\n");
                                Persons.Add(Read());
                                level = 2;
                                break;
                        }
                        FuncWrite();
                    }
                    else if(mainChoice == "2")
                    {
                        string[] book = new string[6];
                        for (int i = 0; i < book.Length; i++)
                            book[i] = Read(bookParams[i]);
                        Console.WriteLine();
                        Books.Add(book);
                        level = 1;
                        FuncWrite();
                    }
                    break;
                case "3":
                    if (mainChoice == "1")
                    {
                        switch (secondChoice)
                        {
                            case "1":
                                Console.WriteLine($"\nВведите номер строки и новое наименование.\n");
                                Authors.Change(Read(),Read());
                                break;
                            case "2":
                                Console.WriteLine($"\nВведите номер строки и новое наименование.\n");
                                Publishers.Change(Read(), Read());
                                break;
                            case "3":
                                Console.WriteLine($"\nВведите номер строки и новое наименование.\n");
                                Persons.Change(Read(), Read());
                                break;
                        }
                        FuncWrite();
                    }
                    else if (mainChoice == "2")
                    {
                        string[] book = new string[6];
                        for (int i = 0; i < book.Length; i++)
                            book[i] = Read(bookParams[i]);
                        Console.WriteLine();
                        Books.Add(book);
                    }
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
            level = 1;
            WriteHeader(enumList);
            choice = Read();
            switch (choice)
            {
                case "":
                    MainWrite();
                    break;
                case "1":
                    secondChoice = "1";
                    FuncWrite();
                    break;
                case "2":
                    secondChoice = "2";
                    FuncWrite();
                    break;
                case "3":
                    secondChoice = "3";
                    FuncWrite();
                    break;
                default:
                    EnumListWrite();
                    break;
            }
        }
        public static void Movement(int moveSet)
        {
            switch (moveSet)
            {
                case 0:
                    MainWrite();
                    break;
                case 1:
                    EnumListWrite();
                    break;
                case 2:
                    FuncWrite();
                    break;
            }
        }
        public static void MainWrite()
        {
            level = 0;
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
                    FuncWrite();
                    break;
                case "3":

                    break;
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
