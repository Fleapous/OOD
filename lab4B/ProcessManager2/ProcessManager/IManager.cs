using System;
using ProcessManager.Processes;

namespace ProcessManager
{
    public interface IManager //
    {
        bool VisitCompound(CompoundProcess element);
        bool VisitExclusive(ExclusiveProcess element);
        bool VisitGroup(GroupProcess element);
        bool VisitRoot(RootProcess element);
        bool VisitUnit(UnitProcess element);
    }

    public class Starting : IManager
    {
        public int Priority { get; set; }

        public Starting(int pri)
        {
            Priority = pri;
        }
        public bool VisitCompound(CompoundProcess element)
        {
            if (element.State != State.Running && element.Priority < Priority)//add priotory too
            {
                element.State = State.Running;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VisitExclusive(ExclusiveProcess element)
        {
            if (element.Priority > Priority)
            {
                if (element.First.Priority > element.Second.Priority)
                {
                    return element.First.Accept(this);
                }
                else if (element.First.Priority < element.Second.Priority)
                {
                    return element.Second.Accept(this);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool VisitGroup(GroupProcess element)
        {
            foreach (var process in element.Subprocesses)
            {
                if (element.Priority > process.Priority)
                {
                    element.Accept(this);
                }
            }

            return true;
        }

        public bool VisitRoot(RootProcess element)
        {
            foreach (var process in element.Subprocesses)
            {
                process.Accept(this);
            }

            return true;
        }

        public bool VisitUnit(UnitProcess element)
        {
            if (element.Priority > Priority)
            {
                element.State = State.Running;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class TimeOut : IManager
    {
        public bool VisitCompound(CompoundProcess element)
        {
            foreach (var process in element.Subprocesses)
            {
                process.Accept(this);
            }

            if (element.ExpectedEnd > DateTime.Now)
            {
                element.State = State.Finished;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VisitExclusive(ExclusiveProcess element)
        {
            if (element.First.Accept(this))
            {
                element.Accept(this);
                return true;
            }
            else
            {
                element.Second.Accept(this);
                return true;
            }
        }

        public bool VisitGroup(GroupProcess element)
        {
            foreach (var process in element.Subprocesses)
            {
                process.Accept(this);
            }

            return true;
        }

        public bool VisitRoot(RootProcess element)
        {
            foreach (var process in element.Subprocesses)
            {
                process.Accept(this);
            }
            return true;
        }

        public bool VisitUnit(UnitProcess element)
        {
            if (element.ExpectedEnd > DateTime.Now)
            {
                element.State = State.Finished;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Printing : IManager
    {
        public bool VisitCompound(CompoundProcess element)
        {
            Console.WriteLine(element.Name);
            foreach (var process in element.Subprocesses)
            {
                process.Accept(this);
            }

            return true;
        }

        public bool VisitExclusive(ExclusiveProcess element)
        {
            if (element.First.Accept(this))
            {
                Console.WriteLine(element.First.Name);
            }
            else
            {
                Console.WriteLine(element.Second.Name);
            }

            return true;
        }

        public bool VisitGroup(GroupProcess element)
        {
            foreach (var process in element.Subprocesses)
            {
                Console.WriteLine($"    {element.Name}");
                process.Accept(this);
            }

            return true;
        }

        public bool VisitRoot(RootProcess element)
        {
            Console.WriteLine(element.Name);
            foreach (var process in element.Subprocesses)
            {
                process.Accept(this);
            }

            return true;
        }

        public bool VisitUnit(UnitProcess element)
        {
            Console.WriteLine($"    {element.Name}");
            return true;
        }
    }
}