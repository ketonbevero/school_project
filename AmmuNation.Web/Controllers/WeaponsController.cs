// <copyright file="WeaponsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AmmuNation.Logic.Interfaces;
    using AmmuNation.Web.Models;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Main controller of weapons.
    /// </summary>
    public class WeaponsController : Controller
    {
        private IModelLogic logic;
        private IMapper mapper;
        private WeaponListViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponsController"/> class.
        /// </summary>
        /// <param name="logic">logic.</param>
        /// <param name="mapper">mapper.</param>
        public WeaponsController(IModelLogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;

            this.vm = new WeaponListViewModel();
            this.vm.EditedWeapon = new Models.Weapon();

            var weapons = this.logic.GetAllModel();
            this.vm.WeaponList = this.mapper.Map<IList<Data.Models.Model>, List<Models.Weapon>>(weapons);
        }

        /// <summary>
        /// Index.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Index()
        {
            this.ViewData["editAction"] = "AddNew";
            return this.View("WeaponsIndex", this.vm);
        }

        /// <summary>
        /// Details of a weapon.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>IActionResult.</returns>
        public IActionResult Details(int id)
        {
            return this.View("WeaponsDetails", this.GetWeapon(id));
        }

        /// <summary>
        /// Removes a weapon by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>IActionResult.</returns>
        public IActionResult Remove(int id)
        {
            this.TempData["editResult"] = "Delete FAIL";
            if (this.logic.DeleteModel(id))
            {
                this.TempData["editResult"] = "Delete successful";
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Edits a weapons by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>IActionResult.</returns>
        public IActionResult Edit(int id)
        {
            this.ViewData["editAction"] = "Edit";
            this.vm.EditedWeapon = this.GetWeapon(id);

            return this.View("WeaponsIndex", this.vm);
        }

        /// <summary>
        /// This method creates a weapon instance and inserts to the Debt.
        /// </summary>
        /// <param name="weapon">a weapon.</param>
        /// <param name="editAction">editaction.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Edit(Models.Weapon weapon, string editAction)
        {
            if (this.ModelState.IsValid && weapon != null)
            {
                this.TempData["editResult"] = "Edit successful";
                if (editAction == "AddNew")
                {
                    try
                    {
                        this.logic.CreateModel(this.WeaponToModelEntity(weapon));
                    }
                    catch (ArgumentException ex)
                    {
                        this.TempData["editResult"] = "AddWeapon FAIL: " + ex.Message;
                    }
                    catch (KeyNotFoundException ex)
                    {
                        this.TempData["editResult"] = "AddWeapon FAIL. Cannot find manufacturer: " + ex.Message;
                    }
                }
                else
                {
                    if (!this.logic.UpdateModel(weapon.Id, weapon.Accuracy, weapon.Stability))
                    {
                        this.TempData["editResult"] = "Edit FAIL";
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                this.ViewData["editAction"] = "Edit";
                this.vm.EditedWeapon = weapon;
                return this.View("WeaponsIndex", this.vm);
            }
        }

        private Data.Models.Model WeaponToModelEntity(Weapon weapon)
        {
            Data.Models.Model newModel = new Data.Models.Model();

            int lastID = this.logic.LastID();

            newModel.Nev = weapon.Name;
            newModel.Kaliber = weapon.Caliber;
            newModel.Pontossag = weapon.Accuracy;
            newModel.Stabilitas = weapon.Stability;
            newModel.Suly = (int)weapon.Weight;
            newModel.Tipus = weapon.Type.ToString();
            newModel.ModelId = ++lastID;
            newModel.ManufacturerId = this.logic.GetManufacturerID(weapon.Manufacturer);

            return newModel;
        }

        private Models.Weapon GetWeapon(int id)
        {
            Data.Models.Model model = this.logic.GetOneModel(id);
            return this.mapper.Map<Data.Models.Model, Models.Weapon>(model);
        }
    }
}
