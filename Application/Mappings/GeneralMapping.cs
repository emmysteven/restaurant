using Application.DTOs.Account;
using Application.Features.Shops.Commands.CreateShop;
using Application.Features.Shops.Commands.UpdateShop;
using Application.Features.Shops.Queries.GetAllShops;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateShopCommand, Shop>();
            CreateMap<UpdateShopCommand, Shop>();
            
            CreateMap<RegisterRequest, User>();
            
            CreateMap<GetAllShopsQuery, GetAllShopsParameter>();
            CreateMap<Shop, GetAllShopsVm>().ReverseMap();
        }
    }
}