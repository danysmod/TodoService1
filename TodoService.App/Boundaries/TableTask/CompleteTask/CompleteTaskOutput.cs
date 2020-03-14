namespace App.Boundaries.TableTask.CompleteTask
{
    using TodoService.Domain;

    public sealed class CompleteTaskOutput
    {
        public CompleteTaskOutput(ITableTask tableTask)
        {
            TableTask = (TableTask)tableTask;
        }

        public TableTask TableTask { get; }
    }
}
