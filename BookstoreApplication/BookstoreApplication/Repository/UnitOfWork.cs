using BookstoreApplication.Data;
using BookstoreApplication.Service.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookstoreApplication.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeafDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(LeafDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await SaveAsync();
            await _transaction.CommitAsync();
            _transaction.Dispose();
            _transaction = null;
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            _transaction.Dispose();
            _transaction = null;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
