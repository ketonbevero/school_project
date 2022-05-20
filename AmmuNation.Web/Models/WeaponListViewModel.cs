// <copyright file="WeaponListViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// List of weapons.
    /// </summary>
    public class WeaponListViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponListViewModel"/> class.
        /// </summary>
        public WeaponListViewModel()
        {
            this.WeaponList = new List<Weapon>();
        }

        /// <summary>
        /// Gets or Sets WeaponList.
        /// </summary>
        public List<Weapon> WeaponList { get; set; }

        /// <summary>
        /// Gets or Sets EditedWeapon.
        /// </summary>
        public Weapon EditedWeapon { get; set; }
    }
}
