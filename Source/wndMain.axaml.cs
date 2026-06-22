using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using SealCrashHandler.Source;
using System.Diagnostics;

namespace SealCrashHandler
{
    public partial class wndMain : Window
    {
        public wndMain()
        {
            InitializeComponent();

            if (CrashContent.hasVersion)
            {
                tblHeader.Text = $"Oh No! {CrashContent.applicationName} {CrashContent.applicationVersion} has crashed!";
            }
            else
            {
                tblHeader.Text = $"Oh No! {CrashContent.applicationName} has crashed!";
            }

            tblException.Text = CrashContent.exception;
            tbStacktrace.Text = CrashContent.stacktrace;
        }

        private void btnRestart_Click(object? sender, RoutedEventArgs e)
        {
            //Restarts the app that crashed. No additional check if the file actually exists will be made since there
            //was already a check when initializing

            if (CrashContent.hasPath)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = CrashContent.applicationExecPath,
                    UseShellExecute = true
                });
            }
        }

        private async void btnCopy_Click(object? sender, RoutedEventArgs e)
        {
            //Copies the name, version, exception and stacktrace into clipboard, overwriting previous content
            var data = new DataTransfer();
            data.Add(DataTransferItem.CreateText(
                    $"{CrashContent.applicationName} (Version {CrashContent.applicationVersion}) has crashed!" +
                    $"\n{CrashContent.exception}" +
                    $"\n{CrashContent.stacktrace}"));
            await Clipboard!.SetDataAsync(data);
        }

        private void btnClose_Click(object? sender, RoutedEventArgs e) => Close();
    }
}