using System;
using System.Collections.Generic;
using TalkingTurkishEf.Entities;

namespace TalkingTurkishCore.Repository
{
    public interface IRepository<in TKey, TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(TKey id);
        TEntity Get(Func<TEntity, bool> expression);
    }
}
