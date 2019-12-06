namespace Workshop
{
    using System;
    using Streams;
    using Streams.Interfaces;
    using Comparators;
    using System.Configuration;
    using System.Collections.Specialized;

    partial class WorkshopMain
    {
        static void Hometask6()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var settings = ConfigurationManager.GetSection("Hometask6/DirectoriesComparator") as NameValueCollection;

            if (settings != null)
            {
                var firstDir = settings.Get("firstDir");
                var secondDir = settings.Get("secondDir");
                var result = settings.Get("Result");
                var ui = settings.Get("UI");
                var userInterface = GetUserInteface(ui, result);
                try
                {
                    var comparator = new DirectoriesComparator(firstDir, secondDir, userInterface);
                    comparator.Compare();
                }
                catch (ArgumentException e)
                {
                    Logger.Log(e);
                }
                catch (UnauthorizedAccessException e)
                {
                    Logger.Log(e);
                }
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

        static IInteractable GetUserInteface(string ui, string fileToSaveResult)
        {
            if (ui.ToLower().Equals("file"))
            {
                return new FileUI(fileToSaveResult);
            }
            else if (ui.ToLower().Equals("excel"))
            {
                return new FileXlsxUI("file", fileToSaveResult, 1, 'A');
            }
            else
            {
                return new ConsoleUI();
            }
        }
    }
}
