// <copyright file="WeaponsApiController.cs" company="PlaceholderCompany">
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
    /// Weapons api controller.
    /// </summary>
    public class WeaponsApiController : Controller // [ApiController].
    {
        private IModelLogic logic;
        private IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponsApiController"/> class.
        /// </summary>
        /// <param name="logic">logic.</param>
        /// <param name="mapper">mapper.</param>
        public WeaponsApiController(IModelLogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets all model.
        /// </summary>
        /// <returns>Models.</returns>
        [HttpGet]
        [ActionName("all")]
        public IEnumerable<Models.Weapon> GetAll() // GET WeaponsApi/all.
        {
            var weaponsModels = this.logic.GetAllModel();

            return this.mapper.Map<IList<Data.Models.Model>, List<Models.Weapon>>(weaponsModels);
        }

        /// <summary>
        /// Deletes a weapon.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Apiresult.</returns>
        [HttpGet]
        [ActionName("del")]
        public ApiResult DelOneWeapon(int id) // GET WeaponsApi/del/5.
        {
            return new ApiResult() { OperationResult = this.logic.DeleteModel(id) };
        }

        /// <summary>
        /// Adds a weapon.
        /// </summary>
        /// <param name="weapon">weapon.</param>
        /// <returns>Apiresult.</returns>
        [HttpPost]
        [ActionName("add")]
        public ApiResult AddOneWeapon(Models.Weapon weapon)
        {
            bool success = true;

            try
            {
                int lastID = this.logic.LastID();

                Data.Models.Model model = new Data.Models.Model();
                model.Nev = weapon.Name;
                model.Kaliber = weapon.Caliber;
                model.Pontossag = weapon.Accuracy;
                model.Stabilitas = weapon.Stability;
                model.Suly = (int)weapon.Weight;
                model.Tipus = weapon.Type.ToString();
                model.ModelId = ++lastID;
                model.ManufacturerId = this.logic.GetManufacturerID(weapon.Manufacturer);

                this.logic.CreateModel(model);
            }
            catch (ArgumentException)
            {
                success = false;
            }

            return new ApiResult() { OperationResult = success };
        }

        /// <summary>
        /// Modes a weapon.
        /// </summary>
        /// <param name="weapon">weapon.</param>
        /// <returns>Apiresult.</returns>
        [HttpPost]
        [ActionName("mod")]
        public ApiResult ModeOneWeapon(Models.Weapon weapon)
        {
            return new ApiResult() { OperationResult = this.logic.UpdateModel(weapon.Id, weapon.Accuracy, weapon.Stability) };
        }

        // Teszt lehetőségek: Selenium, Postman
    }
}
