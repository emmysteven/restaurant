using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Common.Interfaces;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Features.Shops.Commands.UpdateShop
{
    public class UpdateShopCommand : IRequest<Shop>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string LocalGovernmentArea { get; set; }
        public string Address { get; set; }
    }
    
    public class UpdateShopHandler : IRequestHandler<UpdateShopCommand, Shop>
    {
        private readonly IMapper _mapper;
        private readonly IShopRepository _shopRepository;

        public UpdateShopHandler(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public async Task<Shop> Handle(UpdateShopCommand request, CancellationToken cancellationToken)
        {
            var isShop = await _shopRepository.GetByIdAsync(request.Id);
            if (isShop == null) throw new ApiException("Product Not Found.");
            var shop = _mapper.Map<Shop>(request);

            return await _shopRepository.UpdateAsync(shop);
        }
    }
}