namespace App.Boundaries.TableTask.AddTask
{
    using TodoService.Domain;
    public sealed class AddTaskInput
    {
        public AddTaskInput(
            BaseEntityId accountId, 
            BaseEntityId tableId, 
            TaskText taskText)
        {
            TableId = tableId;
            TaskText = taskText;
            AccountId = accountId;
        }
        public BaseEntityId AccountId { get; }

        public BaseEntityId TableId { get; }

        public TaskText TaskText { get; }
    }
}
