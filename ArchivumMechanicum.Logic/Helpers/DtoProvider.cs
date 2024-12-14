using ArchivumMechanicum.Data;
using ArchivumMechanicum.Entities.Dtos.LocationDtos;
using ArchivumMechanicum.Entities.Dtos.RecordDtos;
using ArchivumMechanicum.Entities.Dtos.RelicDtos;
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
                //User
                cfg.CreateMap<AppUser, UserViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.IsAdmin = userManager.IsInRoleAsync(src, "Admin").Result;
                });

                //Location
                cfg.CreateMap<LocationCreateDto, Location>();
                cfg.CreateMap<Location, LocationShortViewDto>()
                .AfterMap((src, dest) =>
                {
                    if (src.Relics != null)
                    {
                        dest.NumberOfRelics = src.Relics.Count;
                    }
                });
                cfg.CreateMap<LocationUpdateDto, Location>();
                cfg.CreateMap<Location, LocationViewDto>();

                //Relic
                cfg.CreateMap<RelicCreateDto, Relic>();
                cfg.CreateMap<Relic, RelicShortViewDto>();
                cfg.CreateMap<Relic, RelicViewDto>()
                .AfterMap((src,dest) =>
                {
                    if (src.Location != null)
                { 
                        dest.FoundLocationName = src.Location.Name;
                }
                });
                cfg.CreateMap<RelicUpdateDto, Relic>();

                //Record
                cfg.CreateMap<RecordCreateDto, Record>();
                cfg.CreateMap<Record, RecordShortViewDto>();
                cfg.CreateMap<RecordUpdateDto, Record>();
                cfg.CreateMap<Record, RecordViewDto>()
                .AfterMap((src,dest) =>
                {
                    if (src.Location != null)
                    {
                        dest.OriginLocationName= src.Location.Name;
                    }
                    if (src.Relic != null)
                    {
                        dest.TiedRelicName = src.Relic.Designation;
                    }
                });
            });

            Mapper = new Mapper(config);
        }
    }
}
