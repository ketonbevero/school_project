// <copyright file="Manufacturer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace AmmuNation.Data.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Manufacturer.
    /// </summary>
    public partial class Manufacturer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manufacturer"/> class.
        /// </summary>
        public Manufacturer()
        {
            this.Models = new HashSet<Model>();
        }

        /// <summary>
        /// Gets or sets manufacturerId.
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// Gets or sets Nev.
        /// </summary>
        public string Nev { get; set; }

        /// <summary>
        /// Gets or sets szarmazasihely.
        /// </summary>
        public string SzarmazasiHely { get; set; }

        /// <summary>
        /// Gets or sets models.
        /// </summary>
        public virtual ICollection<Model> Models { get; set; }
    }
}
