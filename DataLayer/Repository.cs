﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace DataLayer
{
    public class Repository<TModel, TEntity> : IRepository<TModel, TEntity> where TEntity : class
    {
        private readonly OrderSystemContext _db;

        private readonly IMapper _mapper;

        public Repository(OrderSystemContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> ExistsAsync(object id)
        {
            return await _db.Set<TEntity>().FindAsync(id) != null;
        }

        public async Task<IList<TModel>> GetAllAsync()
        {
            var entities = await _db.Set<TEntity>().ToListAsync();

            return _mapper.Map<List<TModel>>(entities);
        }

        public async Task<IList<TModel>> QueryAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> query)
        {
            var queryResult = await query(_db.Set<TEntity>()).ToListAsync();

            return _mapper.Map<List<TModel>>(queryResult);
        }

        public async Task<TModel> QuerySingleAsync(Func<IQueryable<TEntity>, Task<TEntity>> query)
        {
            var queryResult = await query(_db.Set<TEntity>());

            return _mapper.Map<TModel>(queryResult);
        }

        public async Task<TModel?> QuerySingleOrDefaultAsync(Func<IQueryable<TEntity>, Task<TEntity?>> query)
        {
            var queryResult = await query(_db.Set<TEntity>());

            return queryResult == null ? default : _mapper.Map<TModel>(queryResult);
        }

        public async Task<TModel> GetByIdAsync(object id)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id) ??
                throw new EntityNotFoundException(typeof(TEntity).Name, id);

            return _mapper.Map<TModel>(entity);
        }

        public async Task<TModel> AddAsync(TModel item)
        {
            var entity = _mapper.Map<TEntity>(item);

            _db.Set<TEntity>().Update(entity);
            await _db.SaveChangesAsync();

            return _mapper.Map<TModel>(entity);
        }

        public async Task UpdateAsync(object id, TModel item)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id) ??
                throw new EntityNotFoundException(typeof(TEntity).Name, id);

            _mapper.Map(item, entity);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveAsync(object id)
        {
            var entity = _db.Set<TEntity>().Find(id) ??
                throw new EntityNotFoundException(typeof(TEntity).Name, id);

            _db.Set<TEntity>().Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
