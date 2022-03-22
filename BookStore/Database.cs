using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    internal class Database
    {
        /*static string repeatNameException = $"Такой элемент уже существует! {errorMessage}";
        static string repeatIdException = $"Такой id уже используется! {errorMessage}";
        static string outOfRangeException = $"Вы вышли за пределы допустимых значений id! {errorMessage}";
        static string errorMessage = "Перечисление не было изменено!";
        static string successMessage = "Перечисление было изменено!";*/
    }
    internal class Authors
    {
        static List<string> authors = new List<string>();
        public static bool Add(string name)
        {
            if (!authors.Contains(name))
            {
                authors.Add(name);
                return true;
            }
            return false;
        }
        public static string Read()
        {
            string table = "";
            foreach (string item in authors)
                table += Templates.Enum(item, authors);
            return table;
        }
        public static string Select(string id, string set)
        {
            string table = "";
            foreach (string item in authors)
                if (authors.IndexOf(item).ToString().Contains(id) & item.ToLower().Contains(set.ToLower()))
                    table += Templates.Enum(item, authors);
            return table;
        }
        public static bool Change(string idString, string name)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                string item = authors[id];
                if (item != name)
                {
                    authors[id] = name;
                    return true;
                }
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return false;
        }
        public static bool Remove(string idString)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                authors.RemoveAt(id);
                return true;
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return false;
        }
    }
    internal class Persons
    {
        static List<string> persons = new List<string>();
        public static bool Add(string name)
        {
            if (!persons.Contains(name))
            {
                persons.Add(name);
                return true;
            }
            return false;
        }
        public static string Read()
        {
            string table = "";
            foreach (string item in persons)
                table += Templates.Enum(item, persons);
            return table;
        }
        public static string Select(string id, string set)
        {
            string table = "";
            foreach (string item in persons)
                if (persons.IndexOf(item).ToString().Contains(id) & item.ToLower().Contains(set.ToLower()))
                    table += Templates.Enum(item, persons);
            return table;
        }
        public static bool Change(string idString, string name)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                string item = persons[id];
                if (item != name)
                {
                    persons[id] = name;
                    return true;
                }
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return false;
        }
        public static bool Remove(string idString)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                persons.RemoveAt(id);
                return true;
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return false;
        }
    }
    internal class Publishers
    {
        static List<string> publishers = new List<string>();
        public static bool Add(string name)
        {
            if (!publishers.Contains(name))
            {
                publishers.Add(name);
                return true;
            }
            return false;
        }
        public static string Read()
        {
            string table = "";
            foreach (string item in publishers)
                table += Templates.Enum(item, publishers);
            return table;
        }
        public static string Select(string id, string set)
        {
            string table = "";
            foreach (string item in publishers)
                if (publishers.IndexOf(item).ToString().Contains(id) & item.ToLower().Contains(set.ToLower()))
                    table += Templates.Enum(item, publishers);
            return table;
        }
        public static bool Change(string idString, string name)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                string item = publishers[id];
                if (item != name)
                {
                    publishers[id] = name;
                    return true;
                }
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return false;
        }
        public static bool Remove(string idString)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                publishers.RemoveAt(id);
                return true;
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return false;
        }
    }

}
