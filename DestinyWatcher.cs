using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace D2CPShell
{
    public abstract class DestinyWatcher
    {
        public static void CheckScreenshots()
        {
            Bitmap previousScreenshot = null;
            while (true)
            {
                var destinyProcess = Process.GetProcessesByName("destiny2").FirstOrDefault();
                if (destinyProcess == null)
                {
                    Thread.Sleep(1000);
                    continue;
                }

                // Take a screenshot of the screen every five minutes
                var screenshot = CaptureScreen();
                if (previousScreenshot != null && ScreenshotsMatch(screenshot, previousScreenshot))
                {
                    // If both screenshots are exactly the same, end the destiny2 process
                    destinyProcess.Kill();
                }

                previousScreenshot = screenshot;
                Thread.Sleep(300000); // 5 minutes
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private static Bitmap CaptureScreen()
        {
            Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (var gfx = Graphics.FromImage(screenshot))
            {
                gfx.CopyFromScreen(Point.Empty, Point.Empty, Screen.PrimaryScreen.Bounds.Size);
            }
            return screenshot;
        }
        
        private static bool ScreenshotsMatch(Bitmap screenshot1, Bitmap screenshot2)
        {
            if (screenshot1.Width != screenshot2.Width || screenshot1.Height != screenshot2.Height)
            {
                return false;
            }

            for (int x = 0; x < screenshot1.Width; x++)
            {
                for (int y = 0; y < screenshot1.Height; y++)
                {
                    if (screenshot1.GetPixel(x, y) != screenshot2.GetPixel(x, y))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}