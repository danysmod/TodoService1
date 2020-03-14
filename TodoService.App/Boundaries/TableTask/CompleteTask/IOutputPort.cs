using System;
using System.Collections.Generic;
using System.Text;

namespace App.Boundaries.TableTask.CompleteTask
{
    public interface IOutputPort: IOutputPort<CompleteTaskOutput>, IOutputError
    {
    }
}
