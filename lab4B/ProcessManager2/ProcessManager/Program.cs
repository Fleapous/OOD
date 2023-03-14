using System;
using ProcessManager.Processes;

namespace ProcessManager
{
    class Program
    {
        static void Manage(IProcess process,  IManager visitor)
        {
            process.Accept(visitor);
        }

        static void Main(string[] args)
        {
            var processTree = new RootProcess(
                new ExclusiveProcess("Editor",
                                new UnitProcess("Vim", 10, new DateTime(1999, 1, 1)),
                                new UnitProcess("Nano", 5, new DateTime(2040, 12, 31))),
                new UnitProcess("Cat", 54, new DateTime(2000, 5, 2)),
                new CompoundProcess("Browser", 100, new DateTime(2022, 12, 2),
                                    new UnitProcess("Websocket", 7, new DateTime(3000, 1, 1)),
                                    new ExclusiveProcess("Script",
                                                    new UnitProcess("Javascript", 101, new DateTime(2025, 6, 4)),
                                                    new UnitProcess("Boo", 110, DateTime.UnixEpoch)
                                    )
                ),
                new ExclusiveProcess("Explorer",
                                new GroupProcess("Local", 55,
                                                 new UnitProcess("Qt", 105, new DateTime(2064, 2, 2)),
                                                 new UnitProcess("Preview", 10, DateTime.Today)
                                ),
                                new GroupProcess("Remote", 8,
                                                 new UnitProcess("TCP", 65, DateTime.MinValue),
                                                 new UnitProcess("UDP", 22, DateTime.MaxValue)
                                )
                )
            );

            Console.WriteLine("\nStarting processes with priority 88 -------------\n");
            Starting visitor1 = new Starting(88);
            Manage(processTree, visitor1);

            Console.WriteLine("\nTimeout processes -------------\n");
            TimeOut visitor2 = new TimeOut();
            Manage(processTree, visitor2);

            Console.WriteLine("\nPrinting processes -------------\n");
            Printing visitor3 = new Printing();
            Manage(processTree, visitor3);
        }
    }
}