using message_service;
using message_service.Models;
using System;

namespace display_lamps_console
{
    class Program
    {
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/
        // https://docs.microsoft.com/en-us/dotnet/api/system.console.backgroundcolor?view=netframework-4.8
        static void Main(string[] args)
        {
            MQTTClient _mqttClient = new MQTTClient();
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
            // Topic: **pncGroup/lampId/color**
            //_mqttClient.Connect("192.168.101.233", $"pncGroup/{_name}/color");
            _mqttClient.Connect("test.mosquitto.org", $"pncGroup/{_name}/color");
            _mqttClient.ReceivedMessage += (sender, e) => {
                Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), e.Lamp.Color);
                Console.WriteLine($"received by: {e.Lamp.Name} at {e.TimeStamp}, color = {e.Lamp.Color}");
            };


                //	Black	0
                //	DarkBlue	1
                //	DarkGreen	2
                //	DarkCyan	3
                //	DarkRed	4
                //	DarkMagenta	5
                //	DarkYellow	6
                //	Gray	7
                //	DarkGray	8
                //	Blue	9
                //	Green	10
                //	Cyan	11
                //	Red	12
                //	Magenta	13
                //	Yellow	14
                //	White	15

                // equivalente di Console.ReadKey()
                // esce solo con la pressione del tasto X
                bool exitCode = false;
            do
            {
                if (Console.KeyAvailable)
                {
                    var cki = Console.ReadKey(true);
                    //Console.WriteLine("You pressed the '{0}' key.", cki.Key);
                    if (cki.Key == ConsoleKey.X)
                        exitCode = true;

                    if (cki.Key == ConsoleKey.D0)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "Black" });
                    }
                    if (cki.Key == ConsoleKey.D0)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "Black" });
                    }
                    if (cki.Key == ConsoleKey.D1)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "DarkBlue" });
                    }
                    if (cki.Key == ConsoleKey.D2)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "DarkGreen" });
                    }
                    if (cki.Key == ConsoleKey.D3)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "DarkCyan" });
                    }
                    if (cki.Key == ConsoleKey.D4)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "DarkRed" });
                    }
                    if (cki.Key == ConsoleKey.D5)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "DarkMagenta" });
                    }
                    if (cki.Key == ConsoleKey.D6)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "DarkYellow" });
                    }
                    if (cki.Key == ConsoleKey.D7)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "Gray" });
                    }
                    if (cki.Key == ConsoleKey.D8)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "DarkGray" });
                    }
                    if (cki.Key == ConsoleKey.D9)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "Blue" });
                    }
                    if (cki.Key == ConsoleKey.A)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "Green" });
                    }
                    if (cki.Key == ConsoleKey.B)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "Cyan" });
                    }
                    if (cki.Key == ConsoleKey.C)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "Red" });
                    }
                    if (cki.Key == ConsoleKey.D)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "Magenta" });
                    }
                    if (cki.Key == ConsoleKey.E)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "Yellow" });
                    }
                    if (cki.Key == ConsoleKey.F)
                    {
                        _mqttClient.Publish($"pncGroup/{_name}/color", new Lamp { Name = _name, Color = "White" });
                    }

                }
            } while (!exitCode);
        }
    }
}
