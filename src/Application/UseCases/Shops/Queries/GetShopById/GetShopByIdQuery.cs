using MediatR;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Common.Interfaces;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.UseCases.Shops.Queries.GetShopById;

public class GetShopByIdQuery : IRequest<Shop>
{
    public GetShopByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; }
}
    

public class GetShopByIdHandler : IRequestHandler<GetShopByIdQuery, Shop>
{
    private readonly IShopRepository _shopRepository;

    public GetShopByIdHandler(IShopRepository shopRepository)
    {
        _shopRepository = shopRepository;
    }

    public async Task<Shop> Handle(GetShopByIdQuery request, CancellationToken cancellationToken)
    {
        var shop = await _shopRepository.GetByIdAsync(request.Id);
        if (shop == null) throw new ApiException($"Shop Not Found.");
        return shop;
    }
}