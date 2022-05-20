// <copyright file="ModelRepository.cs" company="PlaceholderCompany">
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
    /// Model repository.
    /// </summary>
    public class ModelRepository : BRepository<Model>, IModelRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelRepository"/> class.
        /// </summary>
        /// <param name="ctx">Database context.</param>
        public ModelRepository(AmmuNationDebtContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Returns an element of the repository.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>The chosen Model entity.</returns>
        public override Model GetOne(int id)
        {
            if (this.CheckIfIdExists(id))
            {
                return this.ctx.Set<Model>().Find(id);
            }

            return null;
        }

        /// <summary>
        /// Updates model data to the specified parameters.
        /// </summary>
        /// <param name="id">modelid.</param>
        /// <param name="accuracy">accuracy.</param>
        /// <param name="stability">stability.</param>
        /// <returns>True/False.</returns>
        public bool Update(int id, int accuracy, int stability)
        {
            var model = this.GetOne(id);

            if (model != null)
            {
                model.Pontossag = accuracy;

                model.Stabilitas = stability;

                this.ctx.SaveChanges();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates model status whether it's selected or not.
        /// </summary>
        /// <param name="id">modelid.</param>
        /// <param name="status">status.</param>
        /// <returns>True/False.</returns>
        public bool UpdateStatus(int id, bool status)
        {
            var model = this.GetOne(id);

            if (model != null)
            {
                model.Selected = status;

                this.ctx.SaveChanges();

                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public int GetSelectedOrUnsceledtedItemsCount(bool status)
        {
            int modelsCount = this.GetAll().Where(x => x.Selected == status).Count();
            return modelsCount;
        }
    }
}
