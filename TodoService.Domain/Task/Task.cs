namespace Domain.Task
{
    using System;
    public class Task : BaseEntity, ITask
    {
        public TaskText Text { get; protected set; }
        public TaskState State { get; protected set; }

        public void Delete()
        {
            //TODO реализовать удаление через смену стейта аля State = State.Delete 
        }

        public void Complete()
        {
            //TODO аналогично с удалением через смену стейта State = States.Complete
        }
    }
}