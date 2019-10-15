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
            Configuration config = new Configuration(LevelOfDetalization.INFO, string.Empty);
            MyLogger mylogger = new MyLogger(config);
            try
            {
                int a = 1;
                int b = 0;
                int c = a / b;
            }catch(ArithmeticException e)
            {
                
                mylogger.WriteMessage(e);
            }
            try
            {
                string str = null;
                StreamWriter writer = new StreamWriter(str);
            }
            catch(Exception e)
            {
                mylogger.WriteMessage(e);
            }
            try
            {
                int[] arr = new int[3];
                arr[3] = 3;
            }
            catch (Exception e)
            {
                mylogger.WriteMessage(e);
            }
            string errors = mylogger.ReadMessage();
            Console.WriteLine(errors);
        }
            
    }
}
