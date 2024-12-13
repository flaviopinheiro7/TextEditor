using System;
using System.IO;

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
                Console.WriteLine("Qual o caminho do arquivo para abrir?");
                string path = Console.ReadLine();
                string text = "";

                using ( var file = new StreamReader(path))
                {
                    text = file.ReadToEnd();
                }

                Console.WriteLine("");
                Console.WriteLine(text);
                Console.WriteLine("Pressione qualquer tecla para voltar pro menu");
                Console.ReadKey();
                Menu();
            }

            static void Create()
            {
                Console.WriteLine("Digite seu texto abaixo - Esc para sair");
                Console.WriteLine("---------------------------------------");

                string text = "";

                do
                {
                    text += Console.ReadLine();
                    text += Environment.NewLine;
                }
                while(Console.ReadKey().Key != ConsoleKey.Escape);

                Console.WriteLine("");
                Console.Write("Deseja salvar (s/n)? ");
                char save = char.Parse(Console.ReadLine().ToLower());
                
                if (save == 's')
                    Save(text);

                Menu();
            }

            static void Save(string text)
            {
                Console.Clear();
                Console.WriteLine("Qual o caminho para salvar?");
                string path = Console.ReadLine();

                using (var file = new StreamWriter(path))
                {
                    file.Write(text);
                }

                Console.Clear();
                Console.WriteLine($"Arquivo salvo com sucesso em {path}!");

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