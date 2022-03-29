using System.Collections.Generic;
using static System.Console;
using static System.Convert;
using static System.Math;
using static BookStore.StoredData;

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
        static string Input()
        {
            Write($"{next}\n\t> ");
            return ReadKey().ToString();
        }
        static string Input(string text)
        {
            Write($"\n{text}\n\t> ");
            return ReadLine();
        }
        static List<string> InputList()
        {
            Clear();
            OutputHeader();
            List<string> entry = new List<string>();
            switch (choice)
            {
                case "111":
                case "121":
                case "131":
                    entry.Add(Input(nameInput));
                    break;
                case "201":
                    foreach (string s in booksElementFields)
                        entry.Add(Input(s));
                    break;
                case "301":
                case "401":
                    foreach (string s in movesElementFields)
                        entry.Add(Input(s));
                    break;
                case "113":
                case "123":
                case "133":
                case "114":
                case "124":
                case "134":
                    foreach (string s in enumFields)
                        entry.Add(Input(s));
                    break;
                case "203":
                case "204":
                    foreach (string s in booksFields)
                        entry.Add(Input(s));
                    break;
                case "303":
                case "403":
                case "304":
                case "404":
                    foreach (string s in movesFields)
                        entry.Add(Input(s));
                    break;
            }
            return entry;
        }
        static string Input(out string input)
        {
            Write("\t> ");
            input = ReadLine();
            return input;
        }
        static void Next()
        {
            Input();
            FuncList();
        }
        static void OutputHeader()
        {
            Clear();
            WriteLine(header);
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
                    Result(Database.Add(choice, InputList()));
                    break;
                case "2":
                    Result(Database.Read(choice));
                    break;
                case "3":
                    Result(Database.Select(choice, InputList()));
                    break;
                case "4":
                    Result(Database.Change(choice, InputList()));
                    break;
                case "5":
                    Clear();
                    OutputHeader();
                    Result(Database.Remove(choice, Input(idInput)));
                    break;
                default:
                    FuncList();
                    break;
            }
        }
        static void Result(string text)
        {
            OutputHeader();
            WriteLine(text);
            if (choice[2].ToString() != "2" & choice[2].ToString() != "3")
                TraceLog.WriteLog(text);
            Next();
        }
    }
}
