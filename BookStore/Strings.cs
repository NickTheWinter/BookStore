using System;
using System.Collections.Generic;
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
    }
    internal class Templates
    {
        public static string Enum(string item, List<string> list) =>
            $"\t{Alignment.Id(item, list)}\t|\t{item}\n";
        public static string Books(string[] item, List<string[]> list) =>
            $"\t{Alignment.Id(item, list)}\t|\t{item[0]}\t|\t{item[1]}\t|\t{item[2]}\t|\t{item[3]}\t|\t{item[4]}\t|\t{item[5]}\n";
    }
}
