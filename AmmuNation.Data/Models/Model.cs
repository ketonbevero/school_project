// <copyright file="Model.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace AmmuNation.Data.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Model entity.
    /// </summary>
    public partial class Model
    {
        /// <summary>
        /// Gets or sets modelid.
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// Gets or sets manufacturerid.
        /// </summary>
        public int? ManufacturerId { get; set; }

        /// <summary>
        /// Gets or sets tipus.
        /// </summary>
        public string Tipus { get; set; }

        /// <summary>
        /// Gets or sets pontossag.
        /// </summary>
        public int Pontossag { get; set; }

        /// <summary>
        /// Gets or sets stabilitas.
        /// </summary>
        public int Stabilitas { get; set; }

        /// <summary>
        /// Gets or sets suly.
        /// </summary>
        public int Suly { get; set; }

        /// <summary>
        /// Gets or sets kaliber.
        /// </summary>
        public string Kaliber { get; set; }

        /// <summary>
        /// Gets or sets nev.
        /// </summary>
        public string Nev { get; set; }

        /// <summary>
        /// Gets or sets selected.
        /// </summary>
        public bool? Selected { get; set; }

        /// <summary>
        /// Gets or sets manufacturer.
        /// </summary>
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
