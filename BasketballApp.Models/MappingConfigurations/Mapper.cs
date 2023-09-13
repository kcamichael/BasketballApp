using AutoMapper;
using BasketballApp.Data.Entities;
using BasketballApp.Models.CoachModels;
using BasketballApp.Models.CollegeModels;
using BasketballApp.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BasketballApp.Models.MappingConfigurations
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CollegeEntity, CollegeCreate>().ReverseMap();
            CreateMap<CollegeEntity, CollegeDetail>().ReverseMap();
            CreateMap<CollegeEntity, CollegeListItem>().ReverseMap();
            CreateMap<CollegeEntity, CollegeEdit>().ReverseMap();

            CreateMap<CoachEntity, CoachCreate>().ReverseMap();
            CreateMap<CoachEntity, CoachListItem>().ReverseMap();
            CreateMap<CoachEntity, CoachEdit>().ReverseMap();
            CreateMap<CoachEntity, CoachDetail>().ReverseMap();

            CreateMap<PlayerEntity, PlayerCreate>().ReverseMap();
            CreateMap<PlayerEntity, PlayerListItem>().ReverseMap();
            CreateMap<PlayerEntity, PlayerDetail>().ReverseMap();
            CreateMap<PlayerEntity, PlayerEdit>().ReverseMap();
        }
    }
}
