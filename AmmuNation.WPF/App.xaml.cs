// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.WPF
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using AmmuNation.Data.Models;
    using AmmuNation.Logic.Interfaces;
    using AmmuNation.Logic.Logic;
    using AmmuNation.Repository;
    using AmmuNation.WPF.BL;
    using AmmuNation.WPF.UI;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Messaging;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            AmmuNationDebtContext ctx = new AmmuNationDebtContext();

            ServiceLocator.SetLocatorProvider(() => MyIoc.Instance);

            MyIoc.Instance.Register<IEditorService, EditorServiceViaWindow>();

            MyIoc.Instance.Register<IMessenger>(() => Messenger.Default);

            MyIoc.Instance.Register<IWeaponLogic, WeaponLogic>();

            MyIoc.Instance.Register<IModelLogic, ModelLogic>();

            MyIoc.Instance.Register<IModelRepository, ModelRepository>();

            MyIoc.Instance.Register<IManufacturerRepository, ManufacturerRepository>();

            MyIoc.Instance.Register<AmmuNationDebtContext>(() => ctx);
        }
    }
}
