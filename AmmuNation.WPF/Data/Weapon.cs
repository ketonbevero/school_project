// <copyright file="Weapon.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.WPF.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AmmuNation.Data.Models;
    using AmmuNation.WPF.Data.Enums;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Weapon class for ui.
    /// </summary>
    public class Weapon : ObservableObject
    {
        private int id;

        private string name;

        private WeaponManufacturer manufacturer;

        private ModelType type;

        private string caliber;

        private int weight;

        private int stability;

        private int accucary;

        /// <summary>
        /// Gets or Sets name.
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.Set(ref this.id, value); }
        }

        /// <summary>
        /// Gets or Sets name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.Set(ref this.name, value); }
        }

        /// <summary>
        /// Gets or sets manufacturer.
        /// </summary>
        public WeaponManufacturer Manufacturer
        {
            get { return this.manufacturer; }
            set { this.Set(ref this.manufacturer, value); }
        }

        /// <summary>
        /// Gets or sets type.
        /// </summary>
        public ModelType Type
        {
            get { return this.type; }
            set { this.Set(ref this.type, value); }
        }

        /// <summary>
        /// Gets or sets caliber.
        /// </summary>
        public string Caliber
        {
            get { return this.caliber; }
            set { this.Set(ref this.caliber, value); }
        }

        /// <summary>
        /// Gets or sets weight.
        /// </summary>
        public int Weight
        {
            get { return this.weight; }
            set { this.Set(ref this.weight, value); }
        }

        /// <summary>
        /// Gets or sets stability.
        /// </summary>
        public int Stability
        {
            get { return this.stability; }
            set { this.Set(ref this.stability, value); }
        }

        /// <summary>
        /// Gets or sets accuracy.
        /// </summary>
        public int Accuracy
        {
            get { return this.accucary; }
            set { this.Set(ref this.accucary, value); }
        }

        /// <summary>
        /// Shallow copy for editing.
        /// </summary>
        /// <param name="other">weapon.</param>
        public void CopyFrom(Weapon other)
        {
            this.GetType().GetProperties().ToList().ForEach(
                property => property.SetValue(this, property.GetValue(other)));
        }
    }
}
