using System;
using System.Collections.Generic;
using System.Text;

namespace App.Boundaries.TableTask.ChangeTitleTask
{
    public interface IOutputPort : IOutputPort<ChangeTitleTaskOutput>, IOutputError
    {
    }
}
