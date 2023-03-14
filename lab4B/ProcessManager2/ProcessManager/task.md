# Managing processes

We have a system composed of processes used for specific operations. Processes structure resembles that of processes in
UNIX operating systems:

- There is one root process called "init".
- Process can have children.
- All processes except init are direct or indirect children of init process (subprocesses).

## Processes

Every process implements `IProcess` interface.

- `RootProcess` - parent process of whole system. Has list of subprocesses. Doesn't run any operation.
- `GroupProcess` - process representing a group of subprocesses. Doesn't run any operation.
- `CompoundProcess` - analogous to GroupProcess but runs it's own operation in addition to storing subprocesses.
- `UnitProcess` - process with no subprocesses. Represents a baseline process.
- `ExclusiveProcess` - process representing a pair of processes that cannot both be processed at once. This mean if any
  operation succeeds for first one, it is not performed for second (Only immediate subprocess is counted).

Every process with operation has status and expected end time. All operation processes start in state `Created`.
Additionally all processes have priority, even ones without operation.

## Managers

Having process structure implemented and knowing it won't change, we want to add a mechanism allowing us to manage them.
Current scope requires:

1. Starting process - We need to have manager that will start all operation processes with priority higher than
   specified and status different than `Running`. Additionally grouping processes allow only activation of subprocesses
   with priority higher than their own.
2. Timeout process - We need a way to timeout all processes, that are running longer than expected. If expected end time
   is before current time then process needs to be closed by setting appropriate status. When parent is timed out all
   subprocesses need to be closed as well. Closed processes need to be also removed from process tree.
3. Printing processes - For monitoring purposes we want to be able to visualise process tree. Processes need to be
   printed in a depth first manner, where all subprocesses of a process need to be printed immediately after it.
   Printing should represent depth of a process with indentation. Only name of process needs to be printed.

All operations need to be reported by writing appropriate message to console.

For time comparison use current time.

## Task

1. Implement logic for managing processes.
2. Fill in method `Manage` in `Program.cs` that will run manager on specified process tree.

## Requirements

**We want to be able to easily add new managers with minimal to no modifications nor extensions of existing classes.**

1. Types of objects cannot be explicitly checked and compared. Use of `if`, `switch` on types and reflection mechanism
   is not allowed.
2. Solution must be extendable. Adding new managers and processes should not require modifying already created methods.
3. You are allowed to add new fields/properties to provided classes and interfaces.
4. Modification of already created elements of classes is not allowed.