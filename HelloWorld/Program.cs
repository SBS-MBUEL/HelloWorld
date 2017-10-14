using HelloWorld.eAccounting_API;
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to start.");
            Console.ReadLine();
            var authHandler = new AuthHandler();
            var token = authHandler.ProvideToken();

            //Insert code here, have fun :)

            Console.Read();
        }
    }
}
