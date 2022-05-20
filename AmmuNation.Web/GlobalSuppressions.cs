// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant", Justification = "There are places where unsigned values are used, which is considered not Cls compliant.")]
[assembly: SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "this", Scope = "type", Target = "~T:AmmuNation.Web.Program")]
[assembly: SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "this", Scope = "type", Target = "~T:AmmuNation.Web.Models.MapperFactory")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "this", Scope = "member", Target = "~P:AmmuNation.Web.Models.WeaponListViewModel.WeaponList")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "this", Scope = "member", Target = "~P:AmmuNation.Web.Models.WeaponListViewModel.WeaponList")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "this", Scope = "member", Target = "~M:AmmuNation.Web.Controllers.WeaponsApiController.AddOneCars(AmmuNation.Web.Models.Weapon)~AmmuNation.Web.Controllers.WeaponsApiController.ApiResult")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "this", Scope = "member", Target = "~M:AmmuNation.Web.Controllers.WeaponsApiController.AddOneWeapon(AmmuNation.Web.Models.Weapon)~AmmuNation.Web.Controllers.WeaponsApiController.ApiResult")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "this", Scope = "member", Target = "~M:AmmuNation.Web.Controllers.WeaponsApiController.ModeOneWeapon(AmmuNation.Web.Models.Weapon)~AmmuNation.Web.Controllers.WeaponsApiController.ApiResult")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "this", Scope = "member", Target = "~M:AmmuNation.Web.Controllers.WeaponsApiController.ModeOneWeapon(AmmuNation.Web.Models.Weapon)~AmmuNation.Web.Models.ApiResult")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "this", Scope = "member", Target = "~M:AmmuNation.Web.Controllers.WeaponsApiController.AddOneWeapon(AmmuNation.Web.Models.Weapon)~AmmuNation.Web.Models.ApiResult")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "this", Scope = "member", Target = "~P:AmmuNation.Web.Models.WeaponListViewModel.SelectedWeapons")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "this", Scope = "member", Target = "~P:AmmuNation.Web.Models.WeaponListViewModel.SelectedWeapons")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "this", Scope = "member", Target = "~P:AmmuNation.Web.Models.WeaponListViewModel.UnselectedWeapons")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "this", Scope = "member", Target = "~P:AmmuNation.Web.Models.WeaponListViewModel.UnselectedWeapons")]
[assembly: SuppressMessage("Security", "CA5394:Do not use insecure randomness", Justification = "this", Scope = "member", Target = "~M:AmmuNation.Web.Controllers.RandomController.GetOne~Microsoft.AspNetCore.Mvc.IActionResult")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "this.", Scope = "member", Target = "~M:AmmuNation.Web.Controllers.RandomController.GetOne~Microsoft.AspNetCore.Mvc.IActionResult")]
