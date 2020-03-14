using System;
using System.Collections.Generic;
using System.Text;

namespace App.Boundaries.TableTask.DeleteTask
{
    public interface IOutputPort : IOutputPort<DeleteTaskOutput>, IOutputError
    {
    }
}
