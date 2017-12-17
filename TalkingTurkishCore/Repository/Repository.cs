using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using TalkingTurkishEf;
using TalkingTurkishEf.Entities;

namespace TalkingTurkishCore.Repository
{
    public class Repository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity: BaseEntity
    {
        protected DbSet<TEntity> _table;
        private readonly TalkingTurkishDbContext _context;

        public Repository(TalkingTurkishDbContext context)
        {
            _context = context;
            _table = context.Set<TEntity>();
        }


        public IEnumerable<TEntity> GetAll()
        {
            return _table;
        }

        public TEntity GetById(TKey id)
        {
            return _table.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _table.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void Delete(TKey id)
        {
            var entity = _table.Find(id);
            Delete(entity);
        }

        public TEntity Get(Func<TEntity, bool> expression)
        {
            return _table.FirstOrDefault(expression);
        }
    }
}