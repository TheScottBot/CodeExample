namespace FineTuning
{
    using System.Linq;
    using System;
    using System.Configuration;
    class Program
    {
        private const int _numberOfScriptsToAllowProcessing = 2;
        static void Main(string[] args)
        {
            var settings = ConfigurationManager.AppSettings;

            var stringFinder = new DirectoryFileParser.StringFinder(settings["directoryToSearch"], settings["targetedFile"]);

            var count = stringFinder.FindStringInFiles(settings["searchFor"], stringFinder.GetFiles());

            if (count == _numberOfScriptsToAllowProcessing)
            {
                var scriptExecutor = new ScriptExecutor.ExecutePythonScript();
                var scriptToExecute = settings["scirptToExecure"];

                foreach (var file in stringFinder.GetFiles().Where(file => file == scriptToExecute))
                {
                    scriptExecutor.ExecuteScript(settings["pathToExe"], file);
                }
            }
        }
    }

}
