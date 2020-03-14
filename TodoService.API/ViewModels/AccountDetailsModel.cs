using System;
using System.Collections.Generic;

namespace API.ViewModels
{
    public class AccountDetailsModel
    {
        public AccountDetailsModel(string name, List<TableModel> tables)
        {
            Tables = tables;
            Name = name;
        }

        public string Name { get; }

        public List<TableModel> Tables { get; }
    }
}
