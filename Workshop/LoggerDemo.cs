using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Logger;
namespace Workshop
{
    partial class WorkshopMain
    {
        static void LoggerDemo()
        {
            try
            {
                int a = 1;
                int b = 0;
                int c = a / b;
            }catch(ArithmeticException e)
            {
                Logger.Log(e);
            }
            //mylogger.TurnOff();
            try
            {
                string str = null;
                StreamWriter writer = new StreamWriter(str);
            }
            catch(Exception e)
            {
                Logger.Log(e);
            }
            //mylogger.TurnOn();
            try
            {
                int[] arr = new int[3];
                arr[3] = 3;
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }
            string errors = Logger.ReadLog();
            Console.WriteLine(errors);
        }
            
    }
}
