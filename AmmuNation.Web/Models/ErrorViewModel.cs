// <copyright file="ErrorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.Web.Models
{
    using System;

    /// <summary>
    /// Error vm.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or Sets requestId.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether requst id.
        /// </summary>
        /// <return>True/False.</return>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
