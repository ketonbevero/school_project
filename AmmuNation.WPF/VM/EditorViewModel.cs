// <copyright file="EditorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.WPF.VM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AmmuNation.WPF.Data;
    using AmmuNation.WPF.Data.Enums;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// EditorViewModel class.
    /// </summary>
    public class EditorViewModel : ViewModelBase
    {
        private Weapon weapon;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorViewModel"/> class.
        /// </summary>
        public EditorViewModel()
        {
            this.weapon = new Weapon();

            if (this.IsInDesignMode)
            {
                this.weapon.Name = "Ultimate Rifler";
                this.weapon.Caliber = "9mm";
                this.weapon.Weight = 5;
                this.weapon.Stability = 99;
                this.weapon.Accuracy = 99;
            }
        }

        /// <summary>
        /// Gets modelType.
        /// </summary>
        public static Array ModelType
        {
            get { return Enum.GetValues(typeof(ModelType)); }
        }

        /// <summary>
        /// Gets weaponmanufacturer.
        /// </summary>
        public static Array WeaponManufacturer
        {
            get { return Enum.GetValues(typeof(WeaponManufacturer)); }
        }

        /// <summary>
        /// Gets or sets weapon.
        /// </summary>
        public Weapon Weapon
        {
            get { return this.weapon; }
            set { this.Set(ref this.weapon, value); }
        }
    }
}
