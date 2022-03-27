﻿using System;
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
            Database.Initialize();
            Interface.Initialize();
            Database.Deinitialize();
        }
    }
}
