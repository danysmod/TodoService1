using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UI.Table.ChangeTableTitle
{
    public class ChangeTableTitleResponse
    {
        public ChangeTableTitleResponse(TableModel table)
        {
            Table = table;
        }

        public TableModel Table { get; }
    }
}
