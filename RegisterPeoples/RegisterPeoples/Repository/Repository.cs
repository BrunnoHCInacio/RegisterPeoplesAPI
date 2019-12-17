using Microsoft.EntityFrameworkCore;
using RegisterPeoples.Context;
using RegisterPeoples.Interfaces;
using RegisterPeoples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        private readonly AppDbContext _db;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        protected virtual async Task Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        protected void Dispose()
        {
            _db.Dispose();
        }

        private async Task<int> SaveChanges()
        {
           return await _db.SaveChangesAsync();
        }

       
}
