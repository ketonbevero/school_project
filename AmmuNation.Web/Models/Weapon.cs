// <copyright file="Weapon.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Weapon model.
    /// </summary>
    public class Weapon
    {
        /// <summary>
        /// Gets or Sets id.
        /// </summary>
        [Display(Name = "Weapon Id")]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets name.
        /// </summary>
        [Display(Name = "Weapon Name")]
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets manufacturer.
        /// </summary>
        [Display(Name = "Weapon Manufacturer")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or Sets type.
        /// </summary>
        [Display(Name = "Weapon Type")]
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets caliber.
        /// </summary>
        [Display(Name = "Weapon Caliber")]
        [Required]
        public string Caliber { get; set; }

        /// <summary>
        /// Gets or Sets weight.
        /// </summary>
        [Display(Name = "Weapon Weight")]
        [Required]
        public double Weight { get; set; }

        /// <summary>
        /// Gets or Sets stability.
        /// </summary>
        [Display(Name = "Weapon Stability")]
        [Required]
        public int Stability { get; set; }

        /// <summary>
        /// Gets or Sets accuracy.
        /// </summary>
        [Display(Name = "Weapon Accuracy")]
        [Required]
        public int Accuracy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets state.
        /// </summary>
        [Display(Name = "State")]
        public bool State { get; set; }
    }
}
