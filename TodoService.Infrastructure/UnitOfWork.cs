namespace TodoService.Infrastructure
{
    using System;
    using System.Threading.Tasks;
    using TodoService.Domain.Services;

    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TodoServiceContext context;
        private bool disposed;

        public UnitOfWork(TodoServiceContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            var affectedRows = await this.context.SaveChangesAsync();
            return affectedRows;
        }

        private void Dispose(bool dis)
        {
            if (!this.disposed)
            {
                if (dis)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}
