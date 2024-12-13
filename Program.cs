using System;
using Microsoft.VisualBasic;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar arquivo");
            Console.WriteLine("0 - Sair");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: Exit(); break;
                case 1: Open(); break;
                case 2: Create(); break;
                default: Menu(); break;
            }

            static void Open()
            {
                Console.WriteLine("Abrir");
                Menu();
            }

            static void Create()
            {
                Console.WriteLine("Criar");
                Menu();
            }

            static void Exit()
            {
                Console.Clear();
                Console.WriteLine("Saindo...");
                System.Environment.Exit(0);
            }

        }

    }
}