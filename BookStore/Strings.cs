using System;
using System.Collections.Generic;
using static BookStore.StoredData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    internal class Strings
    {
        static string nameChars = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю- ";
        public static bool IsName(char c)
        {
            if (nameChars.Contains(c.ToString()))
                return true;
            return false;
        }
        public static bool Contains(string item, string set) =>
            item.ToLower().Contains(set.ToLower());
    }
    internal class Templates
    {
        public static List<string> ToImport(string import)
        {
            List<string> toImport = import.Split(separator).ToList();
            toImport.Remove("");
            return toImport;
        }
        public static List<string[]> ToImport(string[] import)
        {
            List<string> listImport = import.ToList();
            listImport.Remove("");
            List<string[]> toImport = new List<string[]>();
            foreach (string item in listImport)
            {
                List<string> tmp = item.Split(separator).ToList();
                tmp.Remove("");
                toImport.Add(tmp.ToArray());
            }
            return toImport;
        }
        public static string ToExport(List<string> list) =>
            string.Join(separator.ToString(), list);
        public static string ToExport(List<string[]> list)
        {
            string export = "";
            foreach (string[] item in list)
                export += string.Join(separator.ToString(), item) + separatorRow;
            return export;
        }
        public static string Enum(List<string[]> list)
        {
            string table = "";
            foreach (string[] item in list)
                table += $"\t{Alignment(item[0], Longest(list, 0))}\t|\t{item[1]}\n";
            return table;
        }
        public static string Books(List<string[]> list)
        {
            string table = "";
            foreach (string[] item in list)
                table += $"\t{Alignment(item[0], Longest(list, 0))}\t|\t{Alignment(item[1], Longest(list, 1))}\t|" +
                         $"\t{Alignment(item[2], Longest(list, 2))}\t|\t{Alignment(item[3], Longest(list, 3))}\t|" +
                         $"\t{Alignment(item[4], Longest(list, 4))}\t|\t{Alignment(item[5], Longest(list, 5))}\t|" +
                         $"\t{Alignment(item[6], Longest(list, 6))}\n";
            return table;
        }
        public static string AddSucces(string name, string[] item)
        {
            string message = $"В таблицу {name} был добавлен элемент '";
            foreach (string s in item)
                message += $"{s}, ";
            return $"{message.Substring(0, message.Length - 2)}'.\n";
        }
        public static string ChangeSucces(string name, string[] pastItem, string[] item)
        {
            string message = $"Элемент '";
            foreach (string s in pastItem)
                message += $"{s}, ";
            message = $"{message.Substring(0, message.Length - 2)}' таблицы {name} был изменен на '";
            foreach (string s in item)
                message += $"{s}, ";
            return $"{message.Substring(0, message.Length - 2)}'.\n";
        }
        public static string RemoveSucces(string name, string[] item)
        {
            string message = $"Элемент '";
            foreach (string s in item)
                message += $"{s}, ";
            return $"{message.Substring(0, message.Length - 2)}' таблицы {name} был удален.\n";
        }
        static int Longest(List<string[]> list, int num)
        {
            int longest = 0;
            foreach (string[] item in list)
                if (item[num].ToString().Length > longest)
                    longest = item[num].ToString().Length;
            return longest;
        }
        public static string Alignment(string text, int length)
        {
            for (int i = text.Length; i<length; i++)
                text += " ";
            return text;
        }
}
}
