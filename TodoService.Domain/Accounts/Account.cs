namespace TodoService.Domain
{
    public abstract class Account : BaseEntity, IAccount
    {
        public TableCollection Tables { get; protected set; }

        public ITable AddTable ()
        {
            return new Table();
        }
    }
}
