namespace Domain.Task
{
    using System;
    
    public readonly struct TaskText
    {
        private readonly string _text;

        public TaskText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new Exception("");
            }

            _text = text;
        }

        public override string ToString() => _text;
    }
}