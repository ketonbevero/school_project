// <copyright file="MainViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.WPF.VM
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using AmmuNation.Logic.Interfaces;
    using AmmuNation.WPF.BL;
    using AmmuNation.WPF.Data;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// MainViewModel class.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IWeaponLogic logic;

        private Weapon weaponSelected;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="logic">logic.</param>
        public MainViewModel(IWeaponLogic logic)
        {
            this.logic = logic;
            this.Weapons = new ObservableCollection<Weapon>();

            if (this.IsInDesignMode)
            {
                Weapon w1 = new Weapon() { Name = "Teszt weapon 1", Manufacturer = Data.Enums.WeaponManufacturer.FNHerstal, Accuracy = 1, Caliber = "9mm", Stability = 1, Type = Data.Enums.ModelType.Rifle, Weight = 2 };
                Weapon w2 = new Weapon() { Name = "Teszt weapon 2", Manufacturer = Data.Enums.WeaponManufacturer.SIGSauer, Accuracy = 99, Caliber = "7.62x51mm", Stability = 99, Type = Data.Enums.ModelType.SniperRifle, Weight = 99 };
                this.Weapons.Add(w1);
                this.Weapons.Add(w2);
            }
            else
            {
                this.Weapons = (ObservableCollection<Weapon>)logic.GetAllModels();
            }

            this.AddCmd = new RelayCommand(() => this.logic.AddWeapon(this.Weapons));

            this.ModCmd = new RelayCommand(() => this.logic.ModWeapon(this.WeaponSelected));

            this.DelCmd = new RelayCommand(() => this.logic.DeleteWeapon(this.Weapons, this.WeaponSelected));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IWeaponLogic>())
        {
        }

        /// <summary>
        /// Gets weapons.
        /// </summary>
        public ObservableCollection<Weapon> Weapons { get; private set; }

        /// <summary>
        /// Gets or sets weaponSelected.
        /// </summary>
        public Weapon WeaponSelected
        {
            get { return this.weaponSelected; }
            set { this.Set(ref this.weaponSelected, value); }
        }

        /// <summary>
        /// Gets ts AddCmd.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets modify command.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets delete command.
        /// </summary>
        public ICommand DelCmd { get; private set; }
    }
}
