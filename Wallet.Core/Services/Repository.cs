﻿using Microsoft.EntityFrameworkCore;
using Wallet.Core.Constants;
using Wallet.Infrastructure.Data;

namespace Wallet.Core.Contracts
{
    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(WalletDbContext context)
        {
            dbContext = context;
        }

        private DbSet<T> DbSet<T>() 
            where T : class
        {
            return dbContext.Set<T>();
        }

        public void Add<T>(T entity)
            where T : class
        {
            DbSet<T>().Add(entity);
        }

        public void Remove<T>(T entity)
            where T : class
        {
            DbSet<T>().Remove(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}
