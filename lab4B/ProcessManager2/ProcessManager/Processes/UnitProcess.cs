using System;

namespace ProcessManager.Processes
{
    public class UnitProcess : IOperationProcess
    {
        public string Name { get; }
        public int Priority { get; }
        public State State { get; set; } = State.Created;
        public DateTime ExpectedEnd { get; }

        public UnitProcess(string name, int priority, DateTime expectedEnd)
        {
            Name = name;
            Priority = priority;
            ExpectedEnd = expectedEnd;
        }
        
        public bool Accept(IManager visitor)
        {
            return visitor.VisitUnit(this);
        }
    }
}