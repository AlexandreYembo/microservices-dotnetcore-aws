using AdvertModel;
using AutoMapper;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class AdvertProfile : Profile
    {
        public AdvertProfile(){
            CreateMap<Advert, AdvertDbModel>();
        }   
    }
}