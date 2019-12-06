// In app.config, to get a file from onedrive, it should be specified a download link to the file we want to check,
// its name and directory it will be downloaded to.
// To get a download link, open a file in a browser, copy the link and replace 'edit' to 'download' in the given uri.

namespace Workshop
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using Comparators;
    using Workshop.OneDriveHomework;
    using System.Diagnostics;

    public partial class WorkshopMain
    {
        static void OneDriveTask()
        {
            var appSettings = ConfigurationManager.GetSection("Hometask6/OneDriveHomework") as NameValueCollection;

            if (appSettings != null)
            {
                var notParsedLink = appSettings.Get("downloadLink");
                var fileName = appSettings.Get("fileName");
                var fileToSaveResult = appSettings.Get("result");
                var directory = appSettings.Get("directory");
                var ui = appSettings.Get("UI");
                var browser = appSettings.Get("browser");

                var userInterface = GetUserInteface(ui, fileToSaveResult);

                // Link specified in app.config cannot contain a symbol '&' so it is replaced by '???'
                // thus it need to be parsed to use it in the program.
                var parsedLink = OneDriveTaskAuxiliary.ParseLink(notParsedLink);

                // Open the browser to download the referenced file.
                var proc = Process.Start(browser, parsedLink);

                // Make sure the download is complete.
                proc.EnableRaisingEvents = true;
                proc.Exited += new EventHandler((sender, args) =>
                {
                    // This should be done to distinguish copies of the file which may differ
                    // by their names i. e. filename(_number_)
                    var downloadedFile = OneDriveTaskAuxiliary.GetLatestDownloadedFile(fileName, directory);

                    var listsComparator = new ExcelListsComparator(downloadedFile, ('A', 'B'), userInterface);

                    listsComparator.Compare();
                });

                // Wait here until all the operations are completed.
                while (!proc.HasExited)
                { }

                DelayAndClear();
            }
            else
            {
                Logger.Log(new SettingsPropertyNotFoundException());
            }
        }
    }
}
