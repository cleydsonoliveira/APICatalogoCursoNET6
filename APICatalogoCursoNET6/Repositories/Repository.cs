﻿using APICatalogoCursoNET6.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APICatalogoCursoNET6.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _appDbContext;
        public Repository(AppDbContext appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public IQueryable<T> Get()
        {
            return _appDbContext.Set<T>().AsNoTracking();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _appDbContext.Set<T>().SingleOrDefault(predicate);
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
