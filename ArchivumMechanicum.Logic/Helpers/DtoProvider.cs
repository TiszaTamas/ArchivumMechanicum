using ArchivumMechanicum.Data;
using ArchivumMechanicum.Entities.Dtos.LocationDtos;
using ArchivumMechanicum.Entities.Dtos.UserDtos;
using ArchivumMechanicum.Entities.Entity_Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivumMechanicum.Logic.Helpers
{
    public class DtoProvider
    {
        UserManager<AppUser> userManager;

        public Mapper Mapper { get; }

        public DtoProvider(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Location, LocationShortViewDto>()
                .AfterMap((src, dest) =>
                {
                    if (src.Relics!=null)
                    {
                        dest.NumberOfRelics = src.Relics.Count;
                    }
                });

                cfg.CreateMap<AppUser, UserViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.IsAdmin = userManager.IsInRoleAsync(src, "Admin").Result;
                });


                cfg.CreateMap<Location, LocationViewDto>();
                cfg.CreateMap<LocationCreateDto, Location>();
            });

            Mapper = new Mapper(config);
        }
    }
}
