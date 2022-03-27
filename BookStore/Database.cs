using System;
using System.Collections.Generic;
using static BookStore.StoredData;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    internal class Database
    {
        public static string Read(string choice)
        {
            List<string[]> tableList = new List<string[]>();
            switch (choice)
            {
                case "01":
                    break;
                case "02":
                    break;
                case "03":
                    break;
                case "12":
                    tableList = Authors.Read();
                    break;
                case "22":
                    break;
                case "32":
                    break;
            }
            return Templates.Enum(tableList);
        }
    }
    internal class CheckConstraints
    {
        public static bool CorrectName(string name, out string returned)
        {
            returned = "";
            string[] subs = name.Split(' ');
            foreach (string s in subs)
            {
                if (s == "")
                    continue;
                else if (s[0] == '-' & returned != "")
                {
                    for (int i = returned.Length - 1; i >= 0; i--)
                        if (returned[i] == '-' | returned[i] == ' ')
                            returned = returned.Remove(i);
                        else break;
                    for (int i = 0; i < s.Length; i++)
                        returned += s[i].ToString().ToLower();
                }
                else if (s[0] == '-' & returned == "")
                {
                    for (int i = 0; i < s.Length; i++)
                        if (s[i] != '-')
                        {
                            returned += s[i].ToString().ToUpper();
                            for (int k = i + 1; k < s.Length; k++)
                                returned += s[k].ToString().ToLower();
                            break;
                        }
                }
                else
                {
                    try
                    {
                        if (returned[returned.Length - 2] == '-')
                        {
                            returned = returned.Remove(returned.Length - 1);
                            for (int i = 0; i < s.Length; i++)
                                returned += s[i].ToString().ToLower();
                        }
                        else
                        {
                            returned += s[0].ToString().ToUpper();
                            for (int i = 1; i < s.Length; i++)
                                returned += s[i].ToString().ToLower();
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        returned += s[0].ToString().ToUpper();
                        for (int i = 1; i < s.Length; i++)
                            returned += s[i].ToString().ToLower();
                    }
                }
                returned += " ";
            }
            try
            {
                for (int i = 0; i < returned.Length; i++)
                    if (returned[i] == '-' & returned[i] == returned[i + 1])
                        returned = returned.Remove(i, 1);
            }
            catch (IndexOutOfRangeException)
            {

            }
            foreach (char c in name)
                if (!Strings.IsName(c))
                    return false;
            if (returned == "")
                return false;
            return true;
        }
        public static bool CorrectPrice(string price)
        {
            try
            {
                double priceDouble = Convert.ToDouble(price);
                if (priceDouble == Math.Round(priceDouble, 2) & priceDouble > 0)
                    return true;
            }
            catch (FormatException)
            {

            }
            return false;
        }
        public static bool CorrectYear(string year)
        {
            try
            {
                int yearInt = Convert.ToInt32(year);
                if (yearInt <= DateTime.Now.Year & yearInt > 0)
                    return true;
            }
            catch (FormatException)
            {

            }
            return false;
        }
        public static bool CorrectCount(string count)
        {
            try
            {
                int countInt = Convert.ToInt32(count);
                if (countInt > 0)
                    return true;
            }
            catch (FormatException)
            {

            }
            return false;
        }
    }
    internal class Authors
    {
        static List<string> authors = new List<string>();
        static string[] Element(string item) =>
            new string[] { IndexOf(item), item };
        public static bool Contains(string item) =>
            authors.Contains(item);
        static string IndexOf(string item) =>
            authors.IndexOf(item).ToString();
        public static void Import(string import) =>
            authors = Templates.ToImport(import);
        public static string Export() =>
            Templates.ToExport(authors);
        public static bool Add(string name)
        {
            if (CheckConstraints.CorrectName(name, out name) & !Contains(name))
            {
                authors.Add(name);
                return true;
            }
            return false;
        }
        public static List<string[]> Read() =>
            Select("", "");
        public static List<string[]> Select(string id, string set)
        {
            List<string[]> table = new List<string[]>() { authorsHeader };
            foreach (string item in authors)
                if (IndexOf(item).Contains(id) & Strings.Contains(item, set))
                    table.Add(Element(item));
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
        public static bool Contains(string item) =>
            persons.Contains(item);
        public static bool Add(string name)
        {
            if (CheckConstraints.CorrectName(name, out name) & !persons.Contains(name))
            {
                persons.Add(name);
                return true;
            }
            return false;
        }
        /*public static string Read() =>
            Select("", "");
        public static string Select(string id, string set)
        {
            string table = "";
            foreach (string item in persons)
                if (persons.IndexOf(item).ToString().Contains(id) & item.ToLower().Contains(set.ToLower()))
                    table += Templates.Enum(item, persons);
            return table;
        }*/
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
        public static bool Contains(string item) =>
            publishers.Contains(item);
        public static bool Add(string name)
        {
            if (!Contains(name))
            {
                publishers.Add(name);
                return true;
            }
            return false;
        }
        /*public static string Read() =>
            Select("", "");
        public static string Select(string id, string set)
        {
            string table = "";
            foreach (string item in publishers)
                if (publishers.IndexOf(item).ToString().Contains(id) & item.ToLower().Contains(set.ToLower()))
                    table += Templates.Enum(item, publishers);
            return table;
        }*/
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
    internal class Books
    {
        static List<string[]> books = new List<string[]>()
        {
            new string[] { "Название", "Автор", "Цена", "Издательство", "Год издание", "Количество страниц" }
        };
        public static bool CorrectEntry(string[] entry)
        {
            if (Authors.Contains(entry[1]) &
                CheckConstraints.CorrectPrice(entry[2]) &
                Publishers.Contains(entry[3]) &
                CheckConstraints.CorrectYear(entry[4]) &
                CheckConstraints.CorrectCount(entry[5]))
                return true;
            return false;
        }
        public static bool Add(string[] entry)
        {
            //if (CorrectEntry(entry))
            //{
            books.Add(entry);
            return true;
            //}
            //return false;
        }
        public static string Read() =>
            Select("", new string[] { "", "", "", "", "", "" });
        public static string Select(string id, string[] set)
        {
            string table = "";
            foreach (string[] item in books)
            {
                bool correct = true;
                foreach (string elem in item)
                {
                    if (!(books.IndexOf(item).ToString().Contains(id) & elem.ToLower().Contains(set[Array.IndexOf(item, elem)].ToLower())))
                        correct = false;
                }
                if (correct == true)
                    table += Templates.Books(item, books);
            }
            return table;
        }
        public static bool Change(string idString)
        {
            try
            {
                int id = int.Parse(idString);
                string[] item = books[id];
                /*for (int i = 0; i < item.Length; i++)
                    item[i] = Interface.Read(Interface.bookParams[i]);*/
                Console.WriteLine();
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
                books.RemoveAt(id);
                return true;
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return false;
        }
    }
}
