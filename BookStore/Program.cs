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
            Console.SetWindowSize(150, 30);
            Authors.Add("Дебил");
            Books.Add(new string[] { "Название", "Автор", "Цена", "Издатель", "Год", "Кол-во страниц" });
            Interface.MainWrite();
            //Console.WriteLine(Authors.Add("педик"));
            //Console.WriteLine(Authors.Add("педик-вф"));
            //Console.WriteLine(Authors.Add("педик)("));
            //Console.WriteLine(Authors.Add("педик  вф "));
            //Console.WriteLine(Authors.Add("педик, вф"));
            //Console.WriteLine(Authors.Add("педик,вф"));
            //Console.WriteLine(Authors.Add("педик вф"));
            //Console.WriteLine(Authors.Add("педик! вф"));
            //Console.WriteLine(Authors.Add("педик !-вф"));
            //Console.WriteLine(Authors.Add("педик -вф"));

            //Console.WriteLine(Authors.Add("педик--вф"));
            //Console.WriteLine(Authors.Add("педик--вф цуфа"));
            //Console.WriteLine(Authors.Add("педик- -вф"));
            //Console.WriteLine(Authors.Add("педик- вф"));
            //Console.WriteLine(Authors.Add("педик- -вф  вуф"));
            //Console.WriteLine(Authors.Add("----педик вф"));
            //Console.WriteLine(Authors.Add("----педик вф-"));
            //Console.WriteLine(Authors.Read());
            //Console.WriteLine(Books.Add(new string[] { "asd", "da", "daf", "adsa", "dfsa", "daf" }));
            //Console.WriteLine(Books.Read());
            //Random random = new Random();
            //for (int i = 0; i < 25; i++)
            //{
            //    Console.WriteLine(Books.Add(new string[] {random.Next(1000).ToString(), random.Next(1000).ToString(), random.Next(1000).ToString(), random.Next(1000).ToString(), random.Next(1000).ToString(), random.Next(1000).ToString()}));
            //}
            Console.WriteLine(Books.Read());
            Console.ReadLine();
        }
    }
}
