namespace App.Boundaries.TableTask.AddTask
{
    using TodoService.Domain;
    public sealed class AddTaskOutput
    {
        public AddTaskOutput(ITableTask task)
        {
            TableTask = (TableTask)task;
        }

        public TableTask TableTask { get; }
    }
}
