// <copyright file="WeaponVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AmmuNation.WPF.Data.Enums;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Weapon class for ui.
    /// </summary>
    public class WeaponVM : ObservableObject
    {
        private int id;

        private string name;

        private string manufacturer;

        private string type;

        private string caliber;

        private int weight;

        private int stability;

        private int accucary;

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
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.Set(ref this.manufacturer, value); }
        }

        /// <summary>
        /// Gets or sets type.
        /// </summary>
        public string Type
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
        public void CopyFrom(WeaponVM other)
        {
            if (other == null)
            {
                return;
            }
            else
            {
                this.Id = other.Id;
                this.Name = other.Name;
                this.Manufacturer = other.Manufacturer;
                this.Type = other.Type;
                this.Caliber = other.Caliber;
                this.Weight = other.Weight;
                this.Stability = other.Stability;
                this.Accuracy = other.Accuracy;
            }
        }
    }
}
