// <copyright file="EditorServiceViaWindow.cs" company="PlaceholderCompany">
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
    /// IEditorService implement.
    /// </summary>
    public class EditorServiceViaWindow : IEditorService
    {
        /// <inheritdoc/>
        public bool EditWeapon(WeaponVM weapon)
        {
            EditorWindow win = new EditorWindow(weapon);
            return win.ShowDialog() ?? false;
        }
    }
}
