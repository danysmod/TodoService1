using System;
using System.Collections.Generic;
using System.Text;

namespace TodoService.Domain
{
    public readonly struct TableTitle
    {
        private readonly string _text;

        public TableTitle(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("");
            }

            _text = name;
        }

        public override string ToString() => _text;
    }
}
