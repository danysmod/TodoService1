using System;

namespace API.UI.Task.DeleteTask
{
    public sealed class DeleteTaskResponse
    {
        public DeleteTaskResponse(Guid taskId)
        {
            TaskId = taskId;
        }

        public Guid TaskId { get; }
    }
}
