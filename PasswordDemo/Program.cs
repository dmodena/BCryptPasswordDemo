using CryptoUtils;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var crypto = new Crypto();

            Console.WriteLine("Password test");

            Console.Write("Type in your test password: ");
            var plainPwd = Console.ReadLine();

            Console.WriteLine("\nHashing password...");
            var hashedPwd = crypto.HashPassword(plainPwd);

            Console.Write("Type in test password for validation: ");
            var validationPlainPwd = Console.ReadLine();

            var isPasswordValid = crypto.IsMatchPassword(validationPlainPwd, hashedPwd);

            if (isPasswordValid)
                Console.WriteLine("The passwords match!");
            else
                Console.WriteLine("Attention! The passwords DO NOT match!");
        }
    }
}
