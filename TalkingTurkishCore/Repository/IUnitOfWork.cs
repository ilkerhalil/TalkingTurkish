using System;
using TalkingTurkishEf.Entities;

namespace TalkingTurkishCore.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TKey, TEntity> GetRepository<TKey, TEntity>()
            where TEntity : BaseEntity;

        void Commit();

        void RejectChanges();
    }
}