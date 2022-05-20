// <copyright file="EditorServiceViaWindow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.WPF.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AmmuNation.WPF.BL;
    using AmmuNation.WPF.Data;

    /// <summary>
    /// Editor service.
    /// </summary>
    public class EditorServiceViaWindow : IEditorService
    {
        /// <summary>
        /// Weapon editor dialog.
        /// </summary>
        /// <param name="weapon">weapon.</param>
        /// <returns>True/False.</returns>
        public bool EditWeapon(Weapon weapon)
        {
            EditorWindow win = new EditorWindow(weapon);

            return win.ShowDialog() ?? false;
        }
    }
}
