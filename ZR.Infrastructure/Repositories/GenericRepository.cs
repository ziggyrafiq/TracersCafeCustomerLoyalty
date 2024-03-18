/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 04 -  Loyalty Card Scheme
*  Date     :  	5th October 2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*  Version  :   0.0.1
************************************************************************************************************/


using ZR.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace ZR.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {

        internal DbEntities _Context;
        internal DbSet<TEntity> _DbSet;
        internal Expression<Func<TEntity, bool>> _GlobalFilter;
        internal Func<TEntity, bool> _MatchesFilter { get; private set; }

        public GenericRepository(DbEntities context)
        {
            _Context = context;
            _DbSet = context.Set<TEntity>();
        }

        public GenericRepository(DbEntities context, Expression<Func<TEntity, bool>> filter)
        {
            _Context = context;
            _DbSet = context.Set<TEntity>();
            _GlobalFilter = filter;
            _MatchesFilter = filter.Compile();
        }

        #region -- Public Methods --

        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "", int? skip = null, int? take = null)
        {
            IQueryable<TEntity> query = BuildQuery(filter, orderBy, includeProperties);

            if (skip.HasValue && skip.Value > 0)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }





        #region -- Async Methods --

        public virtual async Task<TEntity> AsyncGetByID(object id)
        {
            TEntity? entity = await _DbSet.FindAsync(id);
            ThrowIfEntityDoesNotMatchFilter(entity);
            return entity;
        }


        public virtual async Task<int> AsyncInsert(TEntity entity)
        {

            ThrowIfEntityDoesNotMatchFilter(entity);
            _DbSet.Add(entity);
            int result = await _Context.SaveChangesAsync();

            return result;
        }



        public virtual async Task<int> AsyncDelete(object id)
        {
            TEntity entityToDelete = _DbSet.Find(id);
            ThrowIfEntityDoesNotMatchFilter(entityToDelete);
            int result = await AsyncDelete(entityToDelete);

            return result;
        }

        public virtual async Task<int> AsyncDelete(TEntity entityToDelete)
        {
            ThrowIfEntityDoesNotMatchFilter(entityToDelete);
            if (_Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _DbSet.Attach(entityToDelete);
            }
            _DbSet.Remove(entityToDelete);

            return await _Context.SaveChangesAsync();
        }

        public virtual async Task<int> AsyncUpdate(TEntity entityToUpdate)
        {
            ThrowIfEntityDoesNotMatchFilter(entityToUpdate);
            _DbSet.Attach(entityToUpdate);

            _Context.Entry(entityToUpdate).State = EntityState.Modified;


            return await _Context.SaveChangesAsync();
        }



        #endregion

        #endregion

        #region -- Private Methods --


        private IQueryable<TEntity> BuildQuery(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _DbSet;

            if (_GlobalFilter != null)
            {
                query = query.Where(_GlobalFilter);
            }

            foreach (string? includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        private void ThrowIfEntityDoesNotMatchFilter(TEntity entity)
        {
            if (_GlobalFilter != null && !_MatchesFilter(entity))
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}
