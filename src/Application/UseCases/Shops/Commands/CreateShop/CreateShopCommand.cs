using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Restaurant.Application.Common.Interfaces;
using Restaurant.Application.Common.Wrappers;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.UseCases.Shops.Commands.CreateShop;

public class CreateShopCommand : IRequest<Response<int>>
{
    public string Name { get; set; }
    public string Website { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string State { get; set; }
    public string LocalGovernmentArea { get; set; }
    public string Address { get; set; }
    public IFormFile ImageFile { get; set; }
}
    
public class CreateShopHandler : IRequestHandler<CreateShopCommand, Response<int>>
{
    private readonly IMapper _mapper;
    private readonly IShopRepository _shopRepository;
    private readonly IFileService _fileService;

    public CreateShopHandler( IMapper mapper,
        IShopRepository shopRepository,
        IFileService fileService)
    {
        _mapper = mapper;
        _shopRepository = shopRepository;
        _fileService = fileService;
    }

    public async Task<Response<int>> Handle(CreateShopCommand request, CancellationToken cancellationToken)
    {
        var imagePath = _fileService.UploadFile(request.ImageFile);
        var vendor = _mapper.Map<Shop>(request);
        vendor.ImagePath = imagePath;
        await _shopRepository.CreateAsync(vendor);
        return new Response<int>(vendor.Id);
    }
}