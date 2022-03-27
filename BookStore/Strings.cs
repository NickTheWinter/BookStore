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
        public static List<string> ToImport(string import) =>
            import.Split(separator).ToList();
        public static string ToExport(List<string> list) =>
            string.Join(separator.ToString(), list);
        public static string ToExport(List<string[]> list)
        {
            string export = "";
            foreach (string[] item in list)
                export += $"{item}";
            return export;
        }
        public static string Enum(List<string[]> list)
        {
            string table = "";
            int longestId = Longest(list);
            foreach (string[] item in list)
                table += $"\t{Alignment.Id(item[0], longestId)}\t|\t{item[1]}\n";
            return table;
        }
        public static string Books(string[] item, List<string[]> list) =>
            $"\t{Alignment.Id(item, list)}\t|\t{item[0]}\t|\t{item[1]}\t|\t{item[2]}\t|\t{item[3]}\t|\t{item[4]}\t|\t{item[5]}\n";
        static int Longest(List<string[]> list)
        {
            int longest = 0;
            foreach (string[] item in list)
                if (item[0].ToString().Length > longest)
                    longest = item[0].ToString().Length;
            return longest;
        }
    }
}
