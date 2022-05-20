// <copyright file="IWeaponLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.WPF.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AmmuNation.WPF.Data;

    /// <summary>
    /// The interface of WeaponLogic.
    /// </summary>
    public interface IWeaponLogic
    {
        /// <summary>
        /// Add weapon method.
        /// </summary>
        /// <param name="list">weapon list.</param>
        void AddWeapon(IList<Weapon> list);

        /// <summary>
        /// Mod weapon method.
        /// </summary>
        /// <param name="weapon">weapon.</param>
        void ModWeapon(Weapon weapon);

        /// <summary>
        /// Delete weapon method.
        /// </summary>
        /// <param name="list">weapon list.</param>
        /// <param name="weapon">weapon.</param>
        void DeleteWeapon(IList<Weapon> list, Weapon weapon);

        /// <summary>
        /// Returns all models from the db.
        /// </summary>
        /// <returns>Models.</returns>
        IList<Weapon> GetAllModels();
    }
}
