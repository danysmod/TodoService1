using System;
using System.Collections.Generic;
using System.Text;

namespace TodoService.Domain
{
    public readonly struct TableName
    {
        private readonly string _text;

        public TableName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("");
            }

            _text = name;
        }
    }
}
