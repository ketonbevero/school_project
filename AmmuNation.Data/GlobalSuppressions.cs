// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant", Justification = "There are places where unsigned values are used, which is considered not Cls compliant.")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "this", Scope = "member", Target = "~M:AmmuNation.Data.Models.AmmuNationDebtContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "this", Scope = "member", Target = "~M:AmmuNation.Data.Models.AmmuNationDebtContext.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "this.", Scope = "member", Target = "~P:AmmuNation.Data.Models.Manufacturer.Models")]
