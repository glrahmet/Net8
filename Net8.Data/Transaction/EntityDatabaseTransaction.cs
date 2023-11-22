using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Net8.Data.Transaction
{
    public class EntityDatabaseTransaction : IDatabaseTransaction
    {
        private IDbContextTransaction _transaction;
        public EntityDatabaseTransaction(DbContext context)
        {
            _transaction = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
        }
        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
