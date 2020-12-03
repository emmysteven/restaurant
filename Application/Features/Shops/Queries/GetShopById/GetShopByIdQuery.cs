using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Shops.Queries.GetShopById
{
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
}