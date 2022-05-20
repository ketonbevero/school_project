// <copyright file="ManufacturerRepository.cs" company="PlaceholderCompany">
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
    /// Manufacturer repository.
    /// </summary>
    public class ManufacturerRepository : BRepository<Manufacturer>, IManufacturerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturerRepository"/> class.
        /// </summary>
        /// <param name="ctx">Database context.</param>
        public ManufacturerRepository(AmmuNationDebtContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Returns an element of the repository.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>The chosen Manufacturer entity.</returns>
        public override Manufacturer GetOne(int id)
        {
            if (this.CheckIfIdExists(id))
            {
                return this.ctx.Set<Manufacturer>().Find(id);
            }

            return null;
        }

        /// <summary>
        /// Updates manufacturer data to the specified parameters.
        /// </summary>
        /// <param name="id">modelid.</param>
        /// <param name="name">name.</param>
        /// <param name="origin">origin.</param>
        /// <returns>True/False.</returns>
        public bool Update(int id, string name, string origin)
        {
            var manufacturer = this.GetOne(id);

            if (manufacturer != null)
            {
                manufacturer.Nev = name;

                manufacturer.SzarmazasiHely = origin;

                this.ctx.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
