// See https://aka.ms/new-console-template for more information
using System;
using VS_UML2;

namespace UML2
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.Test();
            Console.Write("Hit any key to continue with user dialog");
            Console.ReadKey();
            store.Run();
        }
    }
}