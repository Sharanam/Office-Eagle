using AutoMapper;
using Office_Eagle.DTOs;
using Office_Eagle.Models;

namespace Office_Eagle.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEmployeeDTO, User>();
            CreateMap<User, CreateEmployeeDTO>();

            CreateMap<ReadEmployeeDTO, User>();
            CreateMap<User, ReadEmployeeDTO>();

            CreateMap<UpdateEmployeeDTO, User>();
            CreateMap<User, UpdateEmployeeDTO>();

            CreateMap<User, UpdateUserDTO>();
            CreateMap<UpdateUserDTO, User>();

           
        }
    }
}
