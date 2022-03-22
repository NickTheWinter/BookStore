using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    internal class Strings
    {
    }
    internal class Templates
    {
        public static string Enum(string item, List<string> list) =>
            $"\t{Alignment.Id(item, list)}\t|\t{item}\n";
    }
}
