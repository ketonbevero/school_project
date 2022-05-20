// <copyright file="WeaponLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.WPF.BL
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AmmuNation.Data.Models;
    using AmmuNation.Logic.Interfaces;
    using AmmuNation.Logic.Logic;
    using AmmuNation.WPF.Data;
    using AmmuNation.WPF.Data.Enums;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// The businesslogic of weapon models.
    /// </summary>
    public class WeaponLogic : IWeaponLogic
    {
        private IModelLogic modelLogic;
        private IEditorService editorService;
        private IMessenger messengerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponLogic"/> class.
        /// </summary>
        /// <param name="editorService">editorservice.</param>
        /// <param name="messengerService">messengerservice.</param>
        /// <param name="modelLogic">modellogic.</param>
        public WeaponLogic(IEditorService editorService, IMessenger messengerService, IModelLogic modelLogic)
        {
            this.editorService = editorService;
            this.messengerService = messengerService;
            this.modelLogic = modelLogic;
        }

        /// <summary>
        /// Add method for a new item.
        /// </summary>
        /// <param name="list">weapon list.</param>
        public void AddWeapon(IList<Weapon> list)
        {
            Weapon newWeapon = new Weapon();
            if (this.editorService.EditWeapon(newWeapon) == true)
            {
                list.Add(newWeapon);

                this.modelLogic.CreateModel(this.WeaponToModelEntity(newWeapon));

                this.messengerService.Send("Weapon added succesfully", "LogicResult");
            }
            else
            {
                this.messengerService.Send("Weapon add canceled", "LogicResult");
            }
        }

        /// <summary>
        /// Delete method for deleting an existing item.
        /// </summary>
        /// <param name="list">weapon list.</param>
        /// <param name="weapon">weapon.</param>
        public void DeleteWeapon(IList<Weapon> list, Weapon weapon)
        {
            if (weapon != null && list.Remove(weapon))
            {
                this.modelLogic.DeleteModel(weapon.Id);

                this.messengerService.Send("Weapon deleted succesfully", "LogicResult");
            }
            else
            {
                this.messengerService.Send("Weapon delete failed", "LogicResult");
            }
        }

        /// <summary>
        /// Modify and existing item.
        /// </summary>
        /// <param name="weapon">weapon.</param>
        public void ModWeapon(Weapon weapon)
        {
            if (weapon == null)
            {
                this.messengerService.Send("Weapon edit canceled", "LogicResult");
                return;
            }

            Weapon clone = new Weapon();

            clone.CopyFrom(weapon);

            if (this.editorService.EditWeapon(clone) == true)
            {
                weapon.CopyFrom(clone);

                this.modelLogic.UpdateModel(weapon.Id, weapon.Accuracy, weapon.Stability);

                this.messengerService.Send("Weapon modified succesflully", "LogicResult");
            }
            else
            {
                this.messengerService.Send("Weapon edit canceled", "LogicResult");
            }
        }

        /// <summary>
        /// Returns all models from the db.
        /// </summary>
        /// <returns>Models.</returns>
        public IList<Weapon> GetAllModels()
        {
            IList<Weapon> weapons = new ObservableCollection<Weapon>();

            var models = this.modelLogic.GetAllModel();

            foreach (var model in models)
            {
                weapons.Add(new Weapon()
                {
                    Id = model.ModelId,
                    Name = model.Nev,
                    Type = this.ToEnum<ModelType>(model.Tipus),
                    Manufacturer = this.ToEnum<WeaponManufacturer>(model.Manufacturer.Nev),
                    Caliber = model.Kaliber,
                    Weight = model.Suly,
                    Accuracy = model.Pontossag,
                    Stability = model.Stabilitas,
                });
            }

            return weapons;
        }

        /// <summary>
        /// Converts a ui weapon element to a real database entity.
        /// </summary>
        /// <returns>Model entity.</returns>
        /// <param name="weapon">weapon.</param>
        private Model WeaponToModelEntity(Weapon weapon)
        {
            Model newModel = new Model();

            int lastID = this.LastID();

            newModel.Nev = weapon.Name;
            newModel.Kaliber = weapon.Caliber;
            newModel.Pontossag = weapon.Accuracy;
            newModel.Stabilitas = weapon.Stability;
            newModel.Suly = weapon.Weight;
            newModel.Tipus = weapon.Type.ToString();
            newModel.ModelId = ++lastID;
            newModel.ManufacturerId = this.GetManufacturerID(weapon.Manufacturer);

            return newModel;
        }

        /// <summary>
        /// Gets the id by the name of the manufacturer.
        /// </summary>
        /// <param name="manufacturer">manufacturer.</param>
        /// <returns>ID.</returns>
        private int GetManufacturerID(WeaponManufacturer manufacturer)
        {
            switch (manufacturer)
            {
                case WeaponManufacturer.HecklerandKoch: return 1;
                case WeaponManufacturer.SIGSauer: return 2;
                case WeaponManufacturer.ColtDefense: return 3;
                case WeaponManufacturer.SpringfieldArmory: return 4;
                case WeaponManufacturer.FNHerstal: return 5;
                default: return 0;
            }
        }

        /// <summary>
        /// Gets the last model id.
        /// </summary>
        /// <returns>ID.</returns>
        private int LastID()
        {
            return this.modelLogic.GetAllModel().Max(x => x.ModelId);
        }

        /// <summary>
        /// Parse model type to ModelType enum.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">value.</param>
        /// <returns>Enum.</returns>
        private T ToEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
