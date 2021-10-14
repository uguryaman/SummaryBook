﻿using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public T Settings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object DelegateSettings => throw new NotImplementedException();

        public string Type => throw new NotImplementedException();

        public void Delete(T p)
        {
            var Deleted = c.Entry(p);
            Deleted.State = EntityState.Deleted;
            // _object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var Added = c.Entry(p);
            Added.State = EntityState.Added;
            // _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void right(T p)
        {
            throw new NotImplementedException();
        }

        public void Update(T p)
        {
            var Edited = c.Entry(p);
            Edited.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}