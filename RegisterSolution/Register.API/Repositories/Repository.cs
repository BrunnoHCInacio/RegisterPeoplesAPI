using Microsoft.EntityFrameworkCore;
using Register.API.Context;
using Register.API.Interfaces;
using Register.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Register.API.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(AppDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
