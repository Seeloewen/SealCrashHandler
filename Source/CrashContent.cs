using Avalonia.Automation;
using System.IO;

namespace SealCrashHandler.Source
{
    public static class CrashContent
    {
        private const int ARGS_AMOUNT = 5;
        public static bool hasVersion = false;
        public static bool hasPath = false;

        //Args: Have to be supplied in the order that they are listed here
        public static string applicationName = "Unknown Application";
        public static string applicationVersion = "";
        public static string exception = "Unknown Exception";
        public static string stacktrace = "No Stacktrace available";
        public static string applicationExecPath = "";

        public static void HandleContent(string[] args)
        {
            if (args.Length < ARGS_AMOUNT) return;

            applicationName = args[0];

            applicationVersion = args[1];
            hasVersion = true;

            exception = args[2];
            stacktrace = args[3];

            if (File.Exists(args[4]))
            {
                applicationExecPath = args[4];
                hasPath = true;
            }
        }
    }
}