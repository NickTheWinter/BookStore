using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    internal class Alignment
    {
        public static string Id(string text, int length)
        {
            for (int i = text.Length; i < length; i++)
                text += " ";
            return text;
        }
        public static string Id(string[] item, List<string[]> list)
        {
            string id = list.IndexOf(item).ToString();
            for (int i = id.Length; i < list.Count.ToString().Length; i++)
                id += " ";
            return id;
        }
    }
}
