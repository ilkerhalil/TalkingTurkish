using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TalkingTurkishEf;
using TalkingTurkishEf.Entities;

namespace TalkingTurkishCore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TalkingTurkishDbContext _context;

        public UnitOfWork(TalkingTurkishDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public IRepository<TKey, TEntity> GetRepository<TKey, TEntity>() where TEntity : BaseEntity
        {
            var repository = new Repository<TKey,TEntity>(_context);
            return repository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RejectChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}