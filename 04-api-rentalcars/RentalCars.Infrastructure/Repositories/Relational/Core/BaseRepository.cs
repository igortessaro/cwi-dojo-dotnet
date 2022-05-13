using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RentalCars.Domain.Repositories.Core;
using System.Linq.Expressions;

namespace RentalCars.Infrastructure.Repositories.Relational.Core
{
    public abstract class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IMapper _mapper;
        private bool _disposed = false;
        private readonly RentalCarsContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(RentalCarsContext context, IMapper mapper)
        {
            this._context = context;
            this._dbSet = this._context.Set<TEntity>();
            this._mapper = mapper;
        }

        public IQueryable<TEntity> Query(int take = 100) => this._dbSet.AsNoTracking();

        public IQueryable<TEntity> QueryTracking(int take = 100) => this._dbSet;

        public IQueryable<TProjetion> Query<TProjetion>(Expression<Func<TEntity, bool>> predicate) where TProjetion : class
        {
            return this.Query()
                .Where(predicate)
                .ProjectTo<TProjetion>(this._mapper.ConfigurationProvider);
        }

        public IQueryable<TProjetion> Query<TProjetion>() where TProjetion : class
        {
            return this.Query()
                .ProjectTo<TProjetion>(this._mapper.ConfigurationProvider);
        }

        public void InsertBase(TEntity entity)
        {
            this._dbSet.Add(entity);
        }

        public void UpdateBase(TEntity entity)
        {
            this._dbSet.Update(entity);
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }

        public void DeleteBase(TEntity entity)
        {
            this._dbSet.Remove(entity);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (disposing)
            {
                this._context?.Dispose();
            }

            this._disposed = true;
        }
    }
}
