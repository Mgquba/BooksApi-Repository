﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }
        void Add(T entity);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Remove(T entity);

    }
}
