using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Authors.Add("педик"));
            Console.WriteLine(Authors.Add("педик-вф"));
            Console.WriteLine(Authors.Add("педик)("));
            Console.WriteLine(Authors.Add("педик  вф "));
            Console.WriteLine(Authors.Add("педик, вф"));
            Console.WriteLine(Authors.Add("педик,вф"));
            Console.WriteLine(Authors.Add("педик вф"));
            Console.WriteLine(Authors.Add("педик! вф"));
            Console.WriteLine(Authors.Add("педик !-вф"));
            Console.WriteLine(Authors.Add("педик -вф"));
            Console.WriteLine(Authors.Add("педик--вф"));
            Console.WriteLine(Authors.Add("педик--вф цуфа"));
            Console.WriteLine(Authors.Add("педик- -вф"));
            Console.WriteLine(Authors.Add("педик- вф"));
            Console.WriteLine(Authors.Add("педик- -вф  вуф"));
            Console.WriteLine(Authors.Add("----педик вф"));
            Console.WriteLine(Authors.Read());
            Console.ReadKey();
        }
    }
}
