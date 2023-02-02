using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace D2CPShell
{
    internal static class Program
    {
        private static MainForm _mainForm;
        
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _mainForm = new MainForm();

            // Start a new thread to monitor the status of destiny2.exe
            var hideThread = new Thread(MainWindowHider);
            hideThread.Start();

            // Start a new thread to make sure destiny2.exe hasn't frozen
            var destinyWatcher = new Thread(DestinyWatcher.CheckScreenshots);
            destinyWatcher.Start();

            Application.Run(_mainForm);
        }

        private static void MainWindowHider()
        {
            while (true)
            {
                var destinyProcess = Process.GetProcessesByName("destiny2").FirstOrDefault();
                
                if (destinyProcess != null)
                {
                    _mainForm.Invoke((MethodInvoker)delegate
                    {
                        _mainForm.Hide();
                    });
                }
                else
                {
                    _mainForm.Invoke((MethodInvoker)delegate
                    {
                        _mainForm.Show();
                    });
                }
                
                Thread.Sleep(500);
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}