// <copyright file="BRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AmmuNation.Data.Models;

    /// <summary>
    /// Generic implementation of Repository.
    /// </summary>
    /// <typeparam name="T">Generic parameter.</typeparam>
    public abstract class BRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// The database context copy.
        /// </summary>
        private protected AmmuNationDebtContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRepository{T}"/> class.
        /// </summary>
        /// <param name="ctx">database context.</param>
        public BRepository(AmmuNationDebtContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// This method checks the entity (given by id) exists in the database.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool CheckIfIdExists(int id)
        {
            var entity = this.ctx.Set<T>().Find(id);

            if (this.ctx.Set<T>().Contains(entity))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method removes the chosen entity by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool Delete(int id)
        {
            var entity = this.ctx.Set<T>().Find(id);

            if (this.ctx.Set<T>().Contains(entity))
            {
                this.ctx.Set<T>().Remove(entity);
                this.ctx.SaveChanges();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns every entities of the given type from the database.
        /// </summary>
        /// <returns>List of chosen entities.</returns>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <summary>
        /// Returns the chosen entity by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Selected entity.</returns>
        public abstract T GetOne(int id);

        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        /// <param name="entity">new entity.</param>
        public void Insert(T entity)
        {
            if (!this.ctx.Set<T>().Contains(entity))
            {
                this.ctx.Set<T>().Add(entity);
                this.ctx.SaveChanges();
            }
        }
    }
}