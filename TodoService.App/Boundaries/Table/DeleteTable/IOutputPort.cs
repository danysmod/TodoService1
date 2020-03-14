using System;
using System.Collections.Generic;
using System.Text;

namespace App.Boundaries.Table.DeleteTable
{
    public interface IOutputPort : IOutputPort<DeleteTableOutput>, IOutputError
    {
    }
}
