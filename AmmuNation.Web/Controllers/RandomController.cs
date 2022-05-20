// <copyright file="RandomController.cs" company="PlaceholderCompany">
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
    /// Random controller.
    /// </summary>
    public class RandomController : Controller
    {
        private static Random rand = new Random();
        private IModelLogic logic;
        private IMapper mapper;
        private WeaponListViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomController"/> class.
        /// </summary>
        /// <param name="logic">logic.</param>
        /// <param name="mapper">mapper.</param>
        public RandomController(IModelLogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;

            this.vm = new WeaponListViewModel();

            var weapons = this.logic.GetAllModel();
            this.vm.WeaponList = this.mapper.Map<IList<Data.Models.Model>, List<Models.Weapon>>(weapons);
        }

        private int SelectedItemsCount
        {
            get
            {
                return this.logic.StatusNumber(true);
            }
        }

        private int NotSelectedItemsCount
        {
            get
            {
                return this.logic.StatusNumber(false);
            }
        }

        /// <summary>
        /// Index method.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Generates a random model entity and inserts it to the db.
        /// </summary>
        /// <returns>Json.</returns>
        [HttpGet]
        [ActionName("GetOne")]
        public IActionResult GetOne()
        {
            int lastId = this.logic.LastID();
            string[] manufacturers = { "HecklerandKoch", "SIGSauer", "ColtDefense", "SpringfieldArmory" };
            string[] types = { "SniperRifle", "HandGun", "SubmachineGun", "Rifle" };

            var weapon = new Models.Weapon()
            {
                Id = ++lastId,
                Name = "random" + rand.Next(100, 1000).ToString(),
                Manufacturer = manufacturers[rand.Next(0, manufacturers.Length)],
                Type = types[rand.Next(0, types.Length)],
                Caliber = "random" + rand.Next(100, 1000).ToString(),
                Weight = rand.Next(1, 10),
                Stability = rand.Next(0, 100),
                Accuracy = rand.Next(0, 100),
            };

            this.logic.CreateModel(this.WeaponToModelEntity(weapon));
            this.vm.WeaponList.Add(weapon);

            return this.Ok(weapon);
        }

        /// <summary>
        /// Sets the status of an entity by id.
        /// </summary>
        /// <param name="id">entity id.</param>
        /// <returns>Json.</returns>
        [HttpGet]
        [ActionName("Select")]
        public IActionResult Select(int id)
        {
            var model = this.logic.GetOneModel(id);
            bool result = this.logic.SetModelStatus(id, true);

            this.vm.WeaponList.Where(x => x.Id == id).FirstOrDefault().State = true;

            return this.Ok("Select progress: " + result + ", selected items: " + this.SelectedItemsCount);
        }

        /// <summary>
        /// Sets the status of an entity by id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Json.</returns>
        [HttpGet]
        [ActionName("Unselect")]
        public IActionResult Unselect(int id)
        {
            var model = this.logic.GetOneModel(id);
            bool result = this.logic.SetModelStatus(id, false);

            this.vm.WeaponList.Where(x => x.Id == id).FirstOrDefault().State = false;

            return this.Ok("Unselect progress: " + result + ", Unselected items: " + this.NotSelectedItemsCount);
        }

        /// <summary>
        /// Returns the selected and not selected items html.
        /// </summary>
        /// <returns>HTML.</returns>
        public IActionResult Selections()
        {
            return this.View("Selections", this.vm.WeaponList);
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
            newModel.Selected = null;

            return newModel;
        }
    }
}
