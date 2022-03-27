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
        public static void Initialize()
        {
            string[] import = Files.Deinitialize();
            Authors.Import(import[0]);
            Persons.Import(import[1]);
            Publishers.Import(import[2]);
            Books.Import(import[3].Split(separatorRow));
            Buy.Import(import[4].Split(separatorRow));
            Sell.Import(import[5].Split(separatorRow));
        }
        public static void Deinitialize()
        {
            string[] export =
            {
                Authors.Export(),
                Persons.Export(),
                Publishers.Export(),
                Books.Export(),
                Buy.Export(),
                Sell.Export()
            };
            Files.Initialize(export);
        }
        public static string Add(string choice, List<string> entry)
        {
            switch (choice)
            {
                case "111":
                    return Authors.Add(entry[0]);
                case "121":
                    return Persons.Add(entry[0]);
                case "131":
                    return Publishers.Add(entry[0]);
                case "201":
                    return Books.Add(entry.ToArray());
                case "301":
                    return Buy.Add(entry.ToArray());
                case "401":
                    return Sell.Add(entry.ToArray());
            }
            return choice;
        }
        public static string Read(string choice)
        {
            switch (choice)
            {
                case "112":
                    return Templates.Enum(Authors.Read());
                case "122":
                    return Templates.Enum(Persons.Read());
                case "132":
                    return Templates.Enum(Publishers.Read());
                case "202":
                    return Templates.Books(Books.Read());
                case "302":
                    return Templates.Books(Buy.Read());
                case "402":
                    return Templates.Books(Sell.Read());
            }
            return choice;
        }
        public static string Select(string choice, List<string> entry)
        {
            switch (choice)
            {
                case "113":
                    return Templates.Enum(Authors.Select(entry[0], entry[1]));
                case "123":
                    return Templates.Enum(Persons.Select(entry[0], entry[1]));
                case "133":
                    return Templates.Enum(Publishers.Select(entry[0], entry[1]));
                case "203":
                    return Templates.Books(Books.Select(entry));
                case "303":
                    return Templates.Books(Buy.Read());
                case "403":
                    return Templates.Books(Sell.Read());
            }
            return choice;
        }
        public static string Change(string choice, List<string> entry)
        {
            switch (choice)
            {
                case "114":
                    return Authors.Change(entry[0], entry[1]);
                case "124":
                    return Persons.Change(entry[0], entry[1]);
                case "134":
                    return Publishers.Change(entry[0], entry[1]);
                case "204":
                    return Books.Change(entry);
                case "304":
                    return Buy.Change(entry);
                case "404":
                    return Sell.Change(entry);
            }
            return choice;
        }
        public static string Remove(string choice, string entry)
        {
            switch (choice)
            {
                case "115":
                    return Authors.Remove(entry);
                case "125":
                    return Persons.Remove(entry);
                case "135":
                    return Publishers.Remove(entry);
                case "205":
                    return Books.Remove(entry);
                case "305":
                    return Buy.Remove(entry);
                case "405":
                    return Sell.Remove(entry);
            }
            return choice;
        }
    }
    internal class CheckConstraints
    {
        public static bool CorrectPrice(string price)
        {
            try
            {
                double priceDouble = Convert.ToDouble(price);
                if (priceDouble == Math.Round(priceDouble, 2) & priceDouble > 0)
                    return true;
            }
            catch (FormatException) { }
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
            catch (FormatException) { }
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
            catch (FormatException) { }
            return false;
        }
        public static bool BookName(string name)
        {
            try
            {
                foreach (string[] item in Books.Read())
                    if (item[1] == name)
                        return true;
            }
            catch (IndexOutOfRangeException) { }
            return false;
        }
        public static string BookPrice(string name)
        {
            foreach (string[] item in Books.Read())
                if (item[1] == name)
                    return item[3];
            return "0";
        }
    }
    internal class Authors
    {
        static List<string> authors = new List<string>();
        static string name = "Авторы";
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
        public static string Add(string item)
        {
            if (!Contains(item) & item != "")
            {
                authors.Add(item);
                return Templates.AddSucces(name, Element(item));
            }
            return notEdited;
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
        public static string Change(string idString, string item)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                string pastItem = authors[id];
                string[] pastElement = Element(item);
                if (item != pastItem)
                {
                    authors[id] = item;
                    return Templates.ChangeSucces(name, pastElement, Element(item));
                }
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return notEdited;
        }
        public static string Remove(string idString)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                string[] item = Element(authors[id]);
                authors.RemoveAt(id);
                return Templates.RemoveSucces(name, item);
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return notEdited;
        }
    }
    internal class Persons
    {
        static List<string> persons = new List<string>();
        static string name = "Физические лица";
        static string[] Element(string item) =>
            new string[] { IndexOf(item), item };
        public static bool Contains(string item) =>
            persons.Contains(item);
        static string IndexOf(string item) =>
            persons.IndexOf(item).ToString();
        public static void Import(string import) =>
            persons = Templates.ToImport(import);
        public static string Export() =>
            Templates.ToExport(persons);
        public static string Add(string item)
        {
            if (!Contains(item) & item != "")
            {
                persons.Add(item);
                return Templates.AddSucces(name, Element(item));
            }
            return notEdited;
        }
        public static List<string[]> Read() =>
            Select("", "");
        public static List<string[]> Select(string id, string set)
        {
            List<string[]> table = new List<string[]>() { personsHeader };
            foreach (string item in persons)
                if (IndexOf(item).Contains(id) & Strings.Contains(item, set))
                    table.Add(Element(item));
            return table;
        }
        public static string Change(string idString, string item)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                string pastItem = persons[id];
                string[] pastElement = Element(item);
                if (item != pastItem)
                {
                    persons[id] = item;
                    return Templates.ChangeSucces(name, pastElement, Element(item));
                }
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return notEdited;
        }
        public static string Remove(string idString)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                string[] item = Element(persons[id]);
                persons.RemoveAt(id);
                return Templates.RemoveSucces(name, item);
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return notEdited;
        }
    }
    internal class Publishers
    {
        static List<string> publishers = new List<string>();
        static string name = "Издательства";
        static string[] Element(string item) =>
            new string[] { IndexOf(item), item };
        public static bool Contains(string item) =>
            publishers.Contains(item);
        static string IndexOf(string item) =>
            publishers.IndexOf(item).ToString();
        public static void Import(string import) =>
            publishers = Templates.ToImport(import);
        public static string Export() =>
            Templates.ToExport(publishers);
        public static string Add(string item)
        {
            if (!Contains(item) & item != "")
            {
                publishers.Add(item);
                return Templates.AddSucces(name, Element(item));
            }
            return notEdited;
        }
        public static List<string[]> Read() =>
            Select("", "");
        public static List<string[]> Select(string id, string set)
        {
            List<string[]> table = new List<string[]>() { publishersHeader };
            foreach (string item in publishers)
                if (IndexOf(item).Contains(id) & Strings.Contains(item, set))
                    table.Add(Element(item));
            return table;
        }
        public static string Change(string idString, string item)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                string pastItem = publishers[id];
                string[] pastElement = Element(item);
                if (item != pastItem)
                {
                    publishers[id] = item;
                    return Templates.ChangeSucces(name, pastElement, Element(item));
                }
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return notEdited;
        }
        public static string Remove(string idString)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                string[] item = Element(publishers[id]);
                publishers.RemoveAt(id);
                return Templates.RemoveSucces(name, item);
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return notEdited;
        }
    }
    internal class Books
    {
        static List<string[]> books = new List<string[]>();
        static string name = "Книги";
        static string[] Element(string[] item)
        {
            string[] element = new string[7];
            try
            {
                element[0] = IndexOf(item);
                for (int i = 0; i < 6; i++)
                    element[i + 1] = item[i];
            }
            catch (IndexOutOfRangeException) { }
            return element;
        }
        public static bool Contains(string[] item) =>
            books.Contains(item);
        static string IndexOf(string[] item) =>
            books.IndexOf(item).ToString();
        public static void Import(string[] import) =>
            books = Templates.ToImport(import);
        public static string Export() =>
            Templates.ToExport(books);
        public static bool CorrectEntry(string[] entry)
        {
            if (!Contains(entry) & Authors.Contains(entry[1]) &
                CheckConstraints.CorrectPrice(entry[2]) & Publishers.Contains(entry[3]) &
                CheckConstraints.CorrectYear(entry[4]) & CheckConstraints.CorrectCount(entry[5]))
                return true;
            return false;
        }
        public static string Add(string[] entry)
        {
            if (CorrectEntry(entry))
            {
                books.Add(entry);
                return Templates.AddSucces(name, Element(entry));
            }
            return notEdited;
        }
        public static List<string[]> Read() =>
            Select(new List<string> { "", "", "", "", "", "", "" });
        public static List<string[]> Select(List<string> set)
        {
            List<string[]> table = new List<string[]>() { booksHeader };
            foreach (string[] item in books)
            {
                bool correct = true;
                foreach (string elem in item)
                    if (!(books.IndexOf(item).ToString().Contains(set[0]) & elem.ToLower().Contains(set[Array.IndexOf(item, elem) + 1].ToLower())))
                        correct = false;
                if (correct == true)
                    table.Add(Element(item));
            }
            return table;
        }
        public static string Change(List<string> item)
        {
            try
            {
                int id = Convert.ToInt32(item[0]);
                string[] pastItem = books[id];
                string[] pastElement = Element(pastItem.ToArray());
                for (int i = 1; i < pastItem.Length; i++)
                    if (item[i] != pastItem[i - 1] & item[i] != "")
                    {
                        books[id][i - 1] = item[i];
                        return Templates.ChangeSucces(name, pastElement, Element(books[id]));
                    }
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return notEdited;
        }
        public static string Remove(string idString)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                string[] item = Element(books[id]);
                books.RemoveAt(id);
                return Templates.RemoveSucces(name, item);
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return notEdited;
        }
    }
    internal class Buy
    {
        static List<string[]> buy = new List<string[]>();
        static string name = "Приобретение книг";
        static string[] Element(string[] item)
        {
            string[] element = new string[7];
            try
            {
                element[0] = IndexOf(item);
                for (int i = 0; i < 6; i++)
                    element[i + 1] = item[i];
            }
            catch (IndexOutOfRangeException) { }
            return element;
        }
        public static bool Contains(string[] item) =>
            buy.Contains(item);
        static string IndexOf(string[] item) =>
            buy.IndexOf(item).ToString();
        public static void Import(string[] import) =>
            buy = Templates.ToImport(import);
        public static string Export() =>
            Templates.ToExport(buy);
        public static bool CorrectEntry(string[] entry)
        {
            if (!Contains(entry) & Persons.Contains(entry[0]) &
                CheckConstraints.BookName(entry[1]) &
                CheckConstraints.CorrectCount(entry[2]))
                return true;
            return false;
        }
        public static string Add(string[] entry)
        {
            string[] tmp = new string[6];
            for (int i = 0; i < entry.Length; i++)
                tmp[i] = entry[i];
            tmp[3] = CheckConstraints.BookPrice(tmp[1]);
            tmp[4] = (Convert.ToDouble(tmp[2]) * Convert.ToDouble(tmp[3])).ToString();
            tmp[5] = DateTime.Now.ToString();
            if (CorrectEntry(tmp))
            {
                buy.Add(tmp);
                return Templates.AddSucces(name, Element(tmp));
            }
            return notEdited;
        }
        public static List<string[]> Read() =>
            Select(new List<string> { "", "", "", "", "", "", "" });
        public static List<string[]> Select(List<string> set)
        {
            List<string[]> table = new List<string[]>() { movesHeader };
            foreach (string[] item in buy)
            {
                bool correct = true;
                foreach (string elem in item)
                    if (!(buy.IndexOf(item).ToString().Contains(set[0]) &
                        elem.ToLower().Contains(set[Array.IndexOf(item, elem) + 1].ToLower())))
                        correct = false;
                if (correct == true)
                    table.Add(Element(item));
            }
            return table;
        }
        public static string Change(List<string> item)
        {
            try
            {
                int id = Convert.ToInt32(item[0]);
                string[] pastItem = buy[id];
                string[] pastElement = Element(pastItem.ToArray());
                for (int i = 1; i < item.Count; i++)
                    if (item[i] != pastItem[i - 1] & item[i] != "")
                    {
                        buy[id][i - 1] = item[i];
                        return Templates.ChangeSucces(name, pastElement, Element(buy[id]));
                    }
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return notEdited;
        }
        public static string Remove(string idString)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                string[] item = Element(buy[id]);
                buy.RemoveAt(id);
                return Templates.RemoveSucces(name, item);
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return notEdited;
        }
    }
    internal class Sell
    {
        static List<string[]> sell = new List<string[]>();
        static string name = "Продажа книг";
        static string[] Element(string[] item)
        {
            string[] element = new string[7];
            try
            {
                element[0] = IndexOf(item);
                for (int i = 0; i < 6; i++)
                    element[i + 1] = item[i];
            }
            catch (IndexOutOfRangeException) { }
            return element;
        }
        public static bool Contains(string[] item) =>
            sell.Contains(item);
        static string IndexOf(string[] item) =>
            sell.IndexOf(item).ToString();
        public static void Import(string[] import) =>
            sell = Templates.ToImport(import);
        public static string Export() =>
            Templates.ToExport(sell);
        public static bool CorrectEntry(string[] entry)
        {
            if (!Contains(entry) & Persons.Contains(entry[0]) &
                CheckConstraints.BookName(entry[1]) &
                CheckConstraints.CorrectCount(entry[2]))
                return true;
            return false;
        }
        public static string Add(string[] entry)
        {
            string[] tmp = new string[6];
            for (int i = 0; i < entry.Length; i++)
                tmp[i] = entry[i];
            tmp[3] = (Convert.ToDouble(CheckConstraints.BookPrice(tmp[1])) * 1.1).ToString();
            tmp[4] = (Convert.ToDouble(tmp[2]) * Convert.ToDouble(tmp[3])).ToString();
            tmp[5] = DateTime.Now.ToString();
            if (CorrectEntry(tmp))
            {
                sell.Add(tmp);
                return Templates.AddSucces(name, Element(tmp));
            }
            return notEdited;
        }
        public static List<string[]> Read() =>
            Select(new List<string> { "", "", "", "", "", "", "" });
        public static List<string[]> Select(List<string> set)
        {
            List<string[]> table = new List<string[]>() { movesHeader };
            foreach (string[] item in sell)
            {
                bool correct = true;
                foreach (string elem in item)
                    if (!(sell.IndexOf(item).ToString().Contains(set[0]) &
                        elem.ToLower().Contains(set[Array.IndexOf(item, elem) + 1].ToLower())))
                        correct = false;
                if (correct == true)
                    table.Add(Element(item));
            }
            return table;
        }
        public static string Change(List<string> item)
        {
            try
            {
                int id = Convert.ToInt32(item[0]);
                string[] pastItem = sell[id];
                string[] pastElement = Element(pastItem.ToArray());
                for (int i = 1; i < item.Count; i++)
                    if (item[i] != pastItem[i - 1] & item[i] != "")
                    {
                        sell[id][i - 1] = item[i];
                        return Templates.ChangeSucces(name, pastElement, Element(sell[id]));
                    }
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return notEdited;
        }
        public static string Remove(string idString)
        {
            try
            {
                int id = Convert.ToInt32(idString);
                string[] item = Element(sell[id]);
                sell.RemoveAt(id);
                return Templates.RemoveSucces(name, item);
            }
            catch (FormatException) { }
            catch (ArgumentOutOfRangeException) { }
            return notEdited;
        }
    }
}
