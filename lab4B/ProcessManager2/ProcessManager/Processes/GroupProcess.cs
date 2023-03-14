using System.Collections.Generic;
using System.Linq;

namespace ProcessManager.Processes
{
    public class GroupProcess : IProcess
    {
        public string Name { get; }
        public int Priority { get; }

        public List<IProcess> Subprocesses { get; }
        
        public GroupProcess(string name, int priority, params IProcess[] subprocesses)
        {
            Name = name;
            Priority = priority;
            Subprocesses = subprocesses.ToList();
        }
        
        public bool Accept(IManager visitor)
        {
            return visitor.VisitGroup(this);
        }
    }
}