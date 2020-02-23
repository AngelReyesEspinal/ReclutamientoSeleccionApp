using ReclutamientoSeleccionApp.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Core.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAll();
        TEntity GetById(object id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task AddOrUpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteManyAsync(List<TEntity> entities);
    }

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly Contexto _context;

        private IDbSet<TEntity> Entities
        {
            get { return _context.Set<TEntity>(); }
        }

        public BaseRepository()
        {
            this._context = new Contexto();
        }

        public async Task<IQueryable<TEntity>>  GetAll()
        {
            return await Task.Run(() => {
                return Entities.AsQueryable();
            });
        }

        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return await Task.Run(() => {
                Entities.Add(entity);
                _context.SaveChanges();
                return entity;
            });
        }

        public async Task AddOrUpdateAsync(TEntity entity)
        {
            await Task.Run(() => {
                Entities.AddOrUpdate(entity);
                _context.SaveChanges();
            });
        }

        public void AddOrUpdate(TEntity entity)
        {
            Entities.AddOrUpdate(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => {
                Entities.Remove(entity);
                _context.SaveChanges();
            });
        }

        public async Task DeleteManyAsync(List<TEntity> entities)
        {
            await Task.Run(() => {
                foreach (var entity in  entities)
                {
                    Entities.Remove(entity);
                }
                _context.SaveChanges();
            });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                }
            }
        }
    }
}
