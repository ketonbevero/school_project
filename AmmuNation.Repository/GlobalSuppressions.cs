// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Justification", Scope="type", Target = "~T:AmmuNation.Repository.IRepository`1")]
[assembly: SuppressMessage("Design", "CA1012:Abstract types should not have public constructors", Justification = "<Pending>", Scope = "type", Target = "~T:AmmuNation.Repository.BRepository`1")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1404:Code analysis suppression should have justification", Justification = "<Pending>")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "<Pending>", Scope = "member", Target = "~F:AmmuNation.Repository.BRepository`1.ctx")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant", Justification = "There are places where unsigned values are used, which is considered not Cls compliant.")]