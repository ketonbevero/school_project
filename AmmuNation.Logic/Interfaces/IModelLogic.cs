// <copyright file="IModelLogic.cs" company="PlaceholderCompany">
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
    /// The IModelLogic interface presents the main functions of the model logic.
    /// </summary>
    public interface IModelLogic
    {
        /// <summary>
        /// Inserts a new model to the db.
        /// </summary>
        /// <param name="model">model.</param>
        void CreateModel(Model model);

        /// <summary>
        /// Returns every entities of the given type from the database.
        /// </summary>
        /// <returns>IList.</returns>
        IList<Model> GetAllModel();

        /// <summary>
        /// Returns the chosen entity by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Model entity.</returns>
        Model GetOneModel(int id);

        /// <summary>
        /// Updates model data to the specified parameters.
        /// </summary>
        /// <param name="id">modelid.</param>
        /// <param name="accuracy">accuracy.</param>
        /// <param name="stability">stability.</param>s
        /// <returns>True/False.</returns>
        bool UpdateModel(int id, int accuracy, int stability);

        /// <summary>
        /// This method removes the chosen entity by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        bool DeleteModel(int id);

        /// <summary>
        /// Returns the lasd ID of debt.
        /// </summary>
        /// <returns>ID.</returns>
        int LastID();

        /// <summary>
        /// Gets the id of the right manufacturer by it's name.
        /// </summary>
        /// <param name="manufacturername">manufacturer name.</param>
        /// <returns>ID.</returns>
        int GetManufacturerID(string manufacturername);

        /// <summary>
        /// Updates model status whether it's selected or not.
        /// </summary>
        /// <param name="id">modelid.</param>
        /// <param name="status">status.</param>
        /// <returns>True/False.</returns>
        bool SetModelStatus(int id, bool status);

        /// <summary>
        /// Returns the count of models with specified status.
        /// </summary>
        /// <param name="status">status.</param>
        /// <returns>models count.</returns>
        int StatusNumber(bool status);
    }
}
