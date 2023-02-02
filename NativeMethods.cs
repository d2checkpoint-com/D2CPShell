using System.Runtime.InteropServices;

namespace D2CPShell
{
    public abstract class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ExitWindowsEx(uint flags, uint reason);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool SystemShutdown(string lpMachineName, string lpMessage, uint dwTimeout, 
            bool bForceAppsClosed, bool bRebootAfterShutdown);

        private const uint LOGOFF = 0x00000002;
        private const uint SHUTDOWN_TIMEOUT = 0;

        /// <summary>
        /// Logs off the current user.
        /// </summary>
        public static void LogOffUser()
        {
            ExitWindowsEx(LOGOFF, 0);
        }

        /// <summary>
        /// Reboots the machine.
        /// </summary>
        public static void RebootMachine()
        {
            SystemShutdown(null, "The system is rebooting", SHUTDOWN_TIMEOUT, true, 
                true);
        }

        /// <summary>
        /// Shuts down the machine.
        /// </summary>
        public static void ShutDownMachine()
        {
            SystemShutdown(null, "The system is shutting down", SHUTDOWN_TIMEOUT, true, 
                false);
        }
    }
}