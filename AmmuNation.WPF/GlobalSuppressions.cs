// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant", Justification = "There are places where unsigned values are used, which is considered not Cls compliant.")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "CA1812:Avoid uninstantiated internal classes", Justification ="this", Scope = "module")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "this", Scope = "member", Target = "~M:AmmuNation.WPF.BL.WeaponLogic.AddWeapon(System.Collections.Generic.IList{AmmuNation.WPF.Data.Weapon})")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "this", Scope = "member", Target = "~M:AmmuNation.WPF.BL.WeaponLogic.DeleteWeapon(System.Collections.Generic.IList{AmmuNation.WPF.Data.Weapon},AmmuNation.WPF.Data.Weapon)")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "this", Scope = "member", Target = "~M:AmmuNation.WPF.BL.WeaponLogic.GetManufacturerID(AmmuNation.WPF.Data.Enums.WeaponManufacturer)~System.Int32")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "this", Scope = "member", Target = "~M:AmmuNation.WPF.VM.MainViewModel.#ctor(AmmuNation.WPF.BL.IWeaponLogic)")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "this", Scope = "member", Target = "~M:AmmuNation.WPF.App.#ctor")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "this", Scope = "member", Target = "~M:AmmuNation.WPF.BL.WeaponLogic.ToEnum``1(System.String)~``0")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "this", Scope = "member", Target = "~M:AmmuNation.WPF.BL.WeaponLogic.WeaponToModelEntity(AmmuNation.WPF.Data.Weapon)~AmmuNation.Data.Models.Model")]
