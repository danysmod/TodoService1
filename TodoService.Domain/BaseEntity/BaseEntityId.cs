namespace TodoService.Domain
{
    using System;
    
    public readonly struct BaseEntityId
    {
        private readonly Guid _guid;

        public BaseEntityId(Guid guid)
        {
            if (Guid.Empty == guid)
            {
                throw new Exception("");
            }

            _guid = guid;
        }

        public override string ToString() => _guid.ToString();

        public Guid ToGuid() => _guid;
    }
}