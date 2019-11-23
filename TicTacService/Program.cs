using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TicTacService
{
    public class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(config =>
            {
                config.Service<TicTac>(service =>
               {
                   service.ConstructUsing(tictac => new TicTac());
                   service.WhenStarted(tictac => tictac.Start());
                   service.WhenStopped(tictac => tictac.Stop());
               });

                config.RunAsLocalSystem();

                config.SetServiceName("TicTacService");
                config.SetDisplayName("TicTac Service");
                config.SetDescription("This is sample tictac service for let's working with a Services Windows with a TopShelf");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetType());
            Environment.ExitCode = exitCodeValue;

        }
    }
}
