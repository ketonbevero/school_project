// <copyright file="IRepository.cs" company="PlaceholderCompany">
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
    /// Collective interface of the repo classes.
    /// </summary>
    /// <typeparam name="T">Generic parameter.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Returns an element of the repository.
        /// </summary>
        /// <returns>T type query.</returns>
        /// <param name="id" >id.</param>
        T GetOne(int id);

        /// <summary>
        /// Returns all the elements of the repository.
        /// </summary>
        /// <returns>T type query.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Deletes the specific element.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        bool Delete(int id);

        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        /// <param name="entity">new entity.</param>
        void Insert(T entity);

        /// <summary>
        /// Checks if the given id is exists in the database.
        /// </summary>
        /// <param name="id">id of the entity.</param>
        /// <returns>True/False.</returns>
        bool CheckIfIdExists(int id);
    }

    /// <summary>
    /// Initialization interface for the ManufacturerRepository.
    /// </summary>
    public interface IManufacturerRepository : IRepository<Manufacturer>
    {
        /// <summary>
        /// Update's mmanufacturer data to the specified parameters.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="origin">origin.</param>
        /// <returns>True/False.</returns>
        bool Update(int id, string name, string origin);
    }

    /// <summary>
    /// Initialization interface for the ModelRepository.
    /// </summary>
    public interface IModelRepository : IRepository<Model>
    {
        /// <summary>
        /// Update's model data to the specified parameters.
        /// </summary>
        /// <param name="id">modelid.</param>
        /// <param name="accuracy">accuracy.</param>
        /// <param name="stability">stability.</param>s
        /// <returns>True/False.</returns>
        bool Update(int id, int accuracy, int stability);

        /// <summary>
        /// Updates model status whether it's selected or not.
        /// </summary>
        /// <param name="id">modelid.</param>
        /// <param name="status">status.</param>
        /// <returns>True/False.</returns>
        bool UpdateStatus(int id, bool status);

        /// <summary>
        /// Returns the count of the models with specified status.
        /// </summary>
        /// <param name="status">status.</param>
        /// <returns>model number.</returns>
        int GetSelectedOrUnsceledtedItemsCount(bool status);
    }
}