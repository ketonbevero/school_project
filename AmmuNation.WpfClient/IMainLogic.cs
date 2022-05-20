// <copyright file="IMainLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Main logic interface.
    /// </summary>
    public interface IMainLogic
    {
        /// <summary>
        /// Message sender method.
        /// </summary>
        /// <param name="success">success.</param>
        void SendMessage(bool success);

        /// <summary>
        /// Returns all weapons.
        /// </summary>
        /// <returns>Weapons list.</returns>
        IList<WeaponVM> ApiGetWeapons();

        /// <summary>
        /// Deletes specified weapon.
        /// </summary>
        /// <param name="weapon">A weapon.</param>
        void ApiDelWeapon(WeaponVM weapon);

        /// <summary>
        /// Edits a weapon.
        /// </summary>
        /// <param name="weapon">A weapon.</param>
        /// <param name="isEditing">Editor mode.</param>
        /// <returns>True/False.</returns>
        bool ApiEditWeapon(WeaponVM weapon, bool isEditing);

        /// <summary>
        /// Edits a weapon.
        /// </summary>
        /// <param name="weapon">A weapons.</param>
        /// <param name="editorFunc">Function for editing.</param>
        void EditWeapon(WeaponVM weapon, Func<WeaponVM, bool> editorFunc);

        /// <summary>
        /// Add a new weapon.
        /// </summary>
        void AddWeapon();

        /// <summary>
        /// Generates a new random entity.
        /// </summary>
        /// <param name="quantity">quantity.</param>
        /// <returns>WeaponVMs.</returns>
        IList<WeaponVM> ForGetOne(int quantity);

        /// <summary>
        /// Selects a weapon and sets its status.
        /// </summary>
        /// <param name="weapon">weapon.</param>
        /// <returns>Output.</returns>
        string RandomSelection(WeaponVM weapon);

        /// <summary>
        /// Deletes all randomly generated weapon.
        /// </summary>
        /// <param name="weapons">weapons.</param>
        void DeleteRandomItems(IList<WeaponVM> weapons);
    }
}
