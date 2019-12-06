namespace Workshop
{
    using System;
    using Logger;
    using System.Configuration;

    public partial class WorkshopMain
    {
        static MyLogger Logger;

        public static void Main(string[] args)
        {
            var appSettings = ConfigurationManager.AppSettings;
            var LoggerLocation = appSettings.Get("LoggerLocation");
            var configuration = new Logger.Configuration(LevelOfDetalization.INFO, LoggerLocation);
            Logger = new MyLogger(configuration);
            bool stop = false;
            while (!stop)
            {
                Menu();
                if (Int32.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            Hometask1();
                            DelayAndClear();
                            break;
                        case 2:
                            Hometask2();
                            DelayAndClear();
                            break;
                        case 3:
                            Hometask3();
                            DelayAndClear();
                            break;
                        case 4:
                            Hometask4();
                            DelayAndClear();
                            break;
                        case 5:
                            Hometask5();
                            break;
                        case 6:
                            Hometask6();
                            break;
                        case 7:
                            Hometask6_2();
                            break;
                        case 8:
                            LoggerDemo();
                            break;
                        case 9:
                            DoSomeCalculation();
                            break;
                        case 10:
                            ThreadsPractise();
                            break;
                        case 11:
                            DependencyInjectionDemo();
                            break;
                        case 12:
                            OneDriveTask();
                            break;
                        case 0:
                            stop = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Try again!");
                    Console.Clear();
                }
            }

        }
        static void Menu()
        {
            Console.WriteLine("Available options:");
            Console.WriteLine("Hometask #1 (Structures and Enums) - press 1");
            Console.WriteLine("Hometask #2 (Exceptions)           - press 2");
            Console.WriteLine("Hometask #3 (Streams)              - press 3");
            Console.WriteLine("Hometask #4 (Serialization)        - press 4");
            Console.WriteLine("Hometask #5 (Reflection)           - press 5");
            Console.WriteLine("Hometask #6.1                      - press 6");
            Console.WriteLine("Hometask #6.2                      - press 7");
            Console.WriteLine("LoggerDemo                         - press 8");
            Console.WriteLine("Do some Calculation                - press 9");
            Console.WriteLine("Practising threads using TPL       - press 10");
            Console.WriteLine("IoC container                      - press 11");
            Console.WriteLine("OneDrive homework                  - press 12");
            Console.WriteLine("Exit                               - press 0");
        }
        static void DelayAndClear()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
