using AutoMapper;
using Backend.Me.Contracts;
using System;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PedidoModel, PedidoRequestVM>().ReverseMap();
        CreateMap<ItemModel, ItemVM>().ReverseMap();
    }
}