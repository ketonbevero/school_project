// <copyright file="IManufacturerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.Logic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AmmuNation.Data.Models;

    /// <summary>
    /// The IManufacturerLogic interface presents the main functions of the manufacturer business logic.
    /// </summary>
    public interface IManufacturerLogic
    {
        /// <summary>
        /// Inserts a new manufacturer to the db.
        /// </summary>
        /// <param name="manufacturer">manufacturer.</param>
        void CreateManufacturer(Manufacturer manufacturer);

        /// <summary>
        /// Returns every entities of the given type from the database.
        /// </summary>
        /// <returns>IQueryable.</returns>
        IList<Manufacturer> GetAllManufacturer();

        /// <summary>
        /// Returns the chosen entity by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Manufacturer entity.</returns>
        Manufacturer GetOneManufacturer(int id);

        /// <summary>
        /// Updates manufacturer data to the specified parameters.
        /// </summary>
        /// <param name="id">modelid.</param>
        /// <param name="name">name.</param>
        /// <param name="origin">origin.</param>
        /// <returns>True/False.</returns>
        bool UpdateManufacturer(int id, string name, string origin);

        /// <summary>
        /// This method removes the chosen entity by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        bool DeleteManufacturer(int id);
    }
}