using System.Collections.Generic;
using System.Linq;

namespace ProcessManager.Processes
{
    public class RootProcess : IProcess
    {
        public string Name => "init";
        public int Priority => 0;

        public List<IProcess> Subprocesses { get; }

        public RootProcess(params IProcess[] subprocesses)
        {
            Subprocesses = subprocesses.ToList();
        }
        
        public bool Accept(IManager visitor)
        {
            return visitor.VisitRoot(this);
        }
    }
}