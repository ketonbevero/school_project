// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant", Justification = "There are places where unsigned values are used, which is considered not Cls compliant.")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "this", Scope = "member", Target = "~M:AmmuNation.WpfClient.MainLogic.EditWeapon(AmmuNation.WpfClient.WeaponVM,System.Func{AmmuNation.WpfClient.WeaponVM,System.Boolean})")]
[assembly: SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "this", Scope = "type", Target = "~T:AmmuNation.WpfClient.MainLogic")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "this", Scope = "member", Target = "~P:AmmuNation.WpfClient.MainVM.AllWeapons")]
[assembly: SuppressMessage("Security", "CA5394:Do not use insecure randomness", Justification = "this", Scope = "member", Target = "~M:AmmuNation.WpfClient.MainLogic.RandomSelection(AmmuNation.WpfClient.WeaponVM)~System.String")]
