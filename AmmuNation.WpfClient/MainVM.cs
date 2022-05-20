// <copyright file="MainVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// Main view model.
    /// </summary>
    public class MainVM : ViewModelBase
    {
        private IMainLogic logic;
        private WeaponVM selectedWeapon;
        private ObservableCollection<WeaponVM> allWeapons;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        /// <param name="logic">logic.</param>
        public MainVM(IMainLogic logic)
        {
            this.logic = logic;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        public MainVM()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IMainLogic>())
        {
            this.LoadCmd = new RelayCommand(() => this.AllWeapons = new ObservableCollection<WeaponVM>(this.logic.ApiGetWeapons()));

            this.DelCmd = new RelayCommand(() => this.logic.ApiDelWeapon(this.SelectedWeapon));
            this.AddCmd = new RelayCommand(() => this.logic.AddWeapon());
            this.ModCmd = new RelayCommand(() => this.logic.EditWeapon(this.SelectedWeapon, this.EditorFunc));
        }

        /// <summary>
        /// Gets or sets all weapons.
        /// </summary>
        public ObservableCollection<WeaponVM> AllWeapons
        {
            get { return this.allWeapons; }
            set { this.Set(ref this.allWeapons, value); }
        }

        /// <summary>
        /// Gets or sets selected weapon.
        /// </summary>
        public WeaponVM SelectedWeapon
        {
            get { return this.selectedWeapon; }
            set { this.Set(ref this.selectedWeapon, value); }
        }

        /// <summary>
        /// Gets or sets editor function.
        /// </summary>
        public Func<WeaponVM, bool> EditorFunc { get; set; }

        /// <summary>
        /// Gets addcmd.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets delcmd.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// Gets modcmd.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets loadcmd.
        /// </summary>
        public ICommand LoadCmd { get; private set; }
    }
}
