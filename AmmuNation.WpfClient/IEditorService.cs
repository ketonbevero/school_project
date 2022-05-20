// <copyright file="IEditorService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Service to edit weapon.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// Declare that the Edit ends with OK or Cancel.
        /// </summary>
        /// <param name="weapon">weapon.</param>
        /// <returns>True/False.</returns>
        bool EditWeapon(WeaponVM weapon);
    }
}
