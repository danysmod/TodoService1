namespace App.Boundaries.Table.AddTask
{
    using TodoService.Domain;
    public sealed class AddTaskInput
    {
        public AddTaskInput(BaseEntityId tableId, TaskText taskText)
        {
            TableId = tableId;
            TaskText = taskText;
        }

        public BaseEntityId TableId { get; }

        public TaskText TaskText { get; }
    }
}
