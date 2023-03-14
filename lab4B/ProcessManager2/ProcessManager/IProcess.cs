using System;

namespace ProcessManager
{
    public interface IProcess
    {
        string Name { get; }
        
        int Priority { get; }

        public bool Accept(IManager visitor);
    }

    public interface IOperationProcess : IProcess
    {
        State State { get; set; }
        
        DateTime ExpectedEnd { get; }
    }
}