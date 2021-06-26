using System;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PedidoModel, PedidoVM>().ReverseMap();
        CreateMap<ItemModel, ItemVM>().ReverseMap();
    }
}