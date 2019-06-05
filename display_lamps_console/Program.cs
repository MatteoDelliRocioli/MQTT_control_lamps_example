using System;

namespace display_lamps_console
{
    class Program
    {
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/
        // https://docs.microsoft.com/en-us/dotnet/api/system.console.backgroundcolor?view=netframework-4.8

        static void Main(string[] args)
        {
            string _name;
            string _color= "Black";
            Console.WriteLine($"args.Length {args.Length}");
            switch (args.Length)
            {
                case 0:// ask user for the console name
                    Console.WriteLine("Please provide a name for this console:");
                    _name = Console.ReadLine();
                    break;
                case 1:// first argument is name
                    _name = args[0];
                    break;
                default:// first is name, second is color, other don't care
                    _name = args[0];
                    _color = args[1];
                    break;
            }
            Console.Write("this console is ");
            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), _color)  ;

            Console.WriteLine(_name);
            Console.Read();
        }
    }
}
