using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TicTacService
{
    public class TicTac
    {
        private readonly Timer _timer;

        public TicTac()
        {
            _timer = new Timer(1000 * 1) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Users\T2S-JO~1\AppData\Local\Temp\Demos\TicTac.txt", lines);
        }
        // Method configured in class Program when service is Stated
        public void Start()
        {
            _timer.Start();
        }


        // Method configured in class Program when service is Stopped
        public void Stop()
        {
            _timer.Stop();
        }
    }
}
