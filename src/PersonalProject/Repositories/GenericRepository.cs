using Microsoft.EntityFrameworkCore;
using PersonalProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PersonalProject.Repositories.GenericRepository;

namespace PersonalProject.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _db.Set<T>().AsQueryable();
        }

        public void Update<T>(T entityToUpdate) where T : class
        {
            _db.Set<T>().Update(entityToUpdate);
            this.SaveChanges();
        }

        public void Delete<T>(T entityToDelete) where T : class
        {
            _db.Set<T>().Remove(entityToDelete);
            this.SaveChanges();
        }

        public IQueryable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class
        {
            return _db.Set<T>().FromSql(sql, parameters);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Add<T>(T entityToCreate) where T : class
        {
            _db.Set<T>().Add(entityToCreate);
            _db.SaveChanges();
        }

        public interface IGenericRepository
        {
            void Add<T>(T entityToCreate) where T : class;
            void Delete<T>(T entityToDelete) where T : class;
            IQueryable<T> Query<T>() where T : class;
            void SaveChanges();
            IQueryable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class;
            void Update<T>(T entityToUpdate) where T : class;
        }
    }
}
