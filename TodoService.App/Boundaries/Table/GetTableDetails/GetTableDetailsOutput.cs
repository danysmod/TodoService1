using System;
using System.Collections.Generic;
using System.Text;

namespace App.Boundaries.Table.GetTableDetails
{
    using TodoService.Domain;

    public sealed class GetTableDetailsOutput
    {
        public GetTableDetailsOutput(ITable table)
        {
            Table = (Table)table;
        }

        public Table Table { get; }
    }
}
