using AutoMapper;
using rentalmovie.DTO;
using rentalmovie.Models;

namespace rentalmovie
{
    public class AutoMapperMapping : Profile
    {
        public AutoMapperMapping()
        {
            CreateMap<Register, User>();
            CreateMap<MembershipType, MembershipTypeItem>();
        }
    }
}
