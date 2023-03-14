namespace ProcessManager.Processes
{
    public class ExclusiveProcess : IProcess
    {
        public string Name { get; }
        public int Priority => 0;

        public IProcess First { get; }
        public IProcess Second { get; }

        public ExclusiveProcess(string name, IProcess first, IProcess second)
        {
            Name = name;
            First = first;
            Second = second;
        }
        
        public bool Accept(IManager visitor)
        {
            return visitor.VisitExclusive(this);
        }
    }
}