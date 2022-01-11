using AutoMapper;
using Restaurant.Application.DTOs.Account;
using Restaurant.Application.UseCases.Shops.Commands.CreateShop;
using Restaurant.Application.UseCases.Shops.Commands.UpdateShop;
using Restaurant.Application.UseCases.Shops.Queries.GetAllShops;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Mappings;

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