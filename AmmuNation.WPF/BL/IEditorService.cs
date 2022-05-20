// <copyright file="IEditorService.cs" company="PlaceholderCompany">
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
    /// EditorService interface.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// Editing weapon.
        /// </summary>
        /// <param name="weapon">weapon.</param>
        /// <returns>True/False.</returns>
        bool EditWeapon(Weapon weapon);
    }
}
