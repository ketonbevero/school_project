// <copyright file="ModelLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.Logic.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AmmuNation.Data.Models;
    using AmmuNation.Logic.Interfaces;
    using AmmuNation.Repository;

    /// <summary>
    /// The ModelLogic.
    /// </summary>
    public class ModelLogic : IModelLogic
    {
        private IModelRepository modelRepository;
        private IManufacturerRepository manufacturerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelLogic"/> class.
        /// </summary>
        /// <param name="modelRepository">modelrepository.</param>
        /// <param name="manuRepository">manurepository.</param>
        public ModelLogic(IModelRepository modelRepository, IManufacturerRepository manuRepository)
        {
            this.modelRepository = modelRepository;
            this.manufacturerRepository = manuRepository;
        }

        /// <summary>
        /// Creates a new model and inserts it to the db.
        /// </summary>
        /// <param name="model">model.</param>
        public void CreateModel(Model model)
        {
            this.modelRepository.Insert(model);
        }

        /// <summary>
        /// Deletes an entity from the db.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>True/False.</returns>
        public bool DeleteModel(int id)
        {
            return this.modelRepository.Delete(id);
        }

        /// <summary>
        /// Gets all model from the db.
        /// </summary>
        /// <returns>IList.</returns>
        public IList<Model> GetAllModel()
        {
            return this.modelRepository.GetAll().ToList();
        }

        /// <summary>
        /// Gets an entity chosen by id from the db.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Model entity.</returns>
        public Model GetOneModel(int id)
        {
            return this.modelRepository.GetOne(id);
        }

        /// <summary>
        /// Updates a model chosen by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="accuracy">accuracy.</param>
        /// <param name="stability">stability.</param>
        /// <returns>True/False.</returns>
        public bool UpdateModel(int id, int accuracy, int stability)
        {
            return this.modelRepository.Update(id, accuracy, stability);
        }

        /// <summary>
        /// Updates model status whether it's selected or not.
        /// </summary>
        /// <param name="id">modelid.</param>
        /// <param name="status">status.</param>
        /// <returns>True/False.</returns>
        public bool SetModelStatus(int id, bool status)
        {
            return this.modelRepository.UpdateStatus(id, status);
        }

        /// <inheritdoc/>
        public int StatusNumber(bool status)
        {
            return this.modelRepository.GetSelectedOrUnsceledtedItemsCount(status);
        }

        /// <summary>
        /// Returns the last used id of the debt.
        /// </summary>
        /// <returns>ID.</returns>
        public int LastID()
        {
            return this.GetAllModel().Max(x => x.ModelId);
        }

        /// <summary>
        /// Gets the id of the right manufacturer by it's name.
        /// </summary>
        /// <param name="manufacturername">manufacturer name.</param>
        /// <returns>ID.</returns>
        public int GetManufacturerID(string manufacturername)
        {
            var id = this.manufacturerRepository.GetAll().Where(x => x.Nev == manufacturername).Select(manu => manu.ManufacturerId);
            if (id.SingleOrDefault() == 0)
            {
                throw new KeyNotFoundException(manufacturername);
            }
            else
            {
                return id.Single();
            }
        }
    }
}
