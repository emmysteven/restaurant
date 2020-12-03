using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Shops.Commands.CreateShop
{
    public class CreateShopCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string LocalGovernmentArea { get; set; }
        public string Address { get; set; }
    }
    
    public class CreateShopHandler : IRequestHandler<CreateShopCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IShopRepository _shopRepository;

        public CreateShopHandler(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {
            var vendor = _mapper.Map<Shop>(request);
            await _shopRepository.CreateAsync(vendor);
            return new Response<int>(vendor.Id);
        }
    }
}