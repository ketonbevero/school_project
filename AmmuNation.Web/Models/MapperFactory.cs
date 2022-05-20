// <copyright file="MapperFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;

    /// <summary>
    /// Mapper for vm to entity model.
    /// </summary>
    public class MapperFactory
    {
        /// <summary>
        /// Initialize mapper.
        /// </summary>
        /// <returns>Mapper.</returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Data.Models.Model, Web.Models.Weapon>().
                ForMember(dest => dest.Id, map => map.MapFrom(src => src.ModelId)).
                ForMember(dest => dest.Name, map => map.MapFrom(src => src.Nev)).
                ForMember(dest => dest.Manufacturer, map => map.MapFrom(src => src.Manufacturer.Nev)).
                ForMember(dest => dest.Type, map => map.MapFrom(src => src.Tipus)).
                ForMember(dest => dest.Caliber, map => map.MapFrom(src => src.Kaliber)).
                ForMember(dest => dest.Weight, map => map.MapFrom(src => src.Suly)).
                ForMember(dest => dest.Stability, map => map.MapFrom(src => src.Stabilitas)).
                ForMember(dest => dest.Accuracy, map => map.MapFrom(src => src.Pontossag)).
                ForMember(dest => dest.State, map => map.MapFrom(src => src.Selected)).
                ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
