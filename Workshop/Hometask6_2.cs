namespace Workshop
{
    using System;
    using Streams.Interfaces;
    using System.Configuration;
    using System.Collections.Specialized;
    using Comparators;

    public partial class WorkshopMain
    {
        static void Hometask6_2()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var appSettings = ConfigurationManager.GetSection("Hometask6/ExcelFileComparator") as NameValueCollection;
            if (appSettings != null)
            {
                var file = appSettings.Get("File");
                var fileToSaveResult = appSettings.Get("Result");
                var ui = appSettings.Get("UI");
                var userInterface = GetUserInteface(ui, fileToSaveResult);
                var listsComparator = new ExcelListsComparator(file, ('A', 'B'), userInterface);
                listsComparator.Compare();
            }
            else
            {
                Logger.Log(new SettingsPropertyNotFoundException());
            }

            watch.Stop();
            var elapsedSeconds = (watch.ElapsedMilliseconds / 1000.0);
            Console.WriteLine("Execution time: " + elapsedSeconds);
            DelayAndClear();
        }
    }
}
