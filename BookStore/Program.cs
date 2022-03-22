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
            Random random = new Random();
            for (int i = 0; i < 25; i++)
                Console.WriteLine(Authors.Add(random.Next(0, 100).ToString()));
            Console.WriteLine(Authors.Read());
            Console.Write("Какой изменить: ");
            Console.WriteLine(Authors.Change(Console.ReadLine(), Console.ReadLine()));
            Console.Write("Какой удалить: ");
            Console.WriteLine(Authors.Remove(Console.ReadLine()));
            Console.WriteLine(Authors.Select("22", "122"));
            Console.WriteLine(Authors.Read());
            Console.ReadKey();
        }
    }
}
