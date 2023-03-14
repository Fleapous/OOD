using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessManager.Processes
{
    public class CompoundProcess : IOperationProcess
    {
        public string Name { get; }
        public int Priority { get; }

        public State State { get; set; } = State.Created;
        public DateTime ExpectedEnd { get; }
        public List<IProcess> Subprocesses { get; }

        public CompoundProcess(string name, int priority, DateTime expectedEnd,
                               params IProcess[] subprocesses)
        {
            Name = name;
            Priority = priority;
            ExpectedEnd = expectedEnd;
            Subprocesses = subprocesses.ToList();
        }
        
        public bool Accept(IManager visitor)
        {
            return visitor.VisitCompound(this);
        }
    }
}