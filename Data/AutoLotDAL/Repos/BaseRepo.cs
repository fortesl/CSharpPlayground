using AutoLotDAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AutoLotDAL.Repos
{
    public class BaseRepo<T> : IRepo<T> where T: class
    {
        private readonly AutoLotEntities _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepo(AutoLotEntities context)
        {

        }
        public int Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int AddRange(IList<T> entities)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id, byte[] timeStamp)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> ExecuteQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetOne(int? id)
        {
            throw new NotImplementedException();
        }

        public int Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
