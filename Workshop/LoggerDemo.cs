using System;
using System.IO;
using Logger;
namespace Workshop
{
    partial class WorkshopMain
    {
        static void LoggerDemo()
        {
            var config = new Configuration(LevelOfDetalization.INFO, (Directory.GetCurrentDirectory() + "\\TestLogger.txt"));
            var logger = new MyLogger(config);

            try
            {
                int a = 1;
                int b = 0;
                int c = a / b;
            }catch(ArithmeticException e)
            {
                logger.Log(e);
            }

            //logger.TurnOff();
            try
            {
                string str = null;
                StreamWriter writer = new StreamWriter(str);
            }
            catch(Exception e)
            {
                logger.Log(e);
            }

            //logger.TurnOn();
            try
            {
                int[] arr = new int[3];
                arr[3] = 3;
            }
            catch (Exception e)
            {
                logger.Log(e);
            }
            string errors = logger.ReadLog();
            Console.WriteLine(errors);
        }
            
    }
}
