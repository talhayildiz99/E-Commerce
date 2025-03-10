﻿using AutoMapper;
using E_Commerce.Message.DAL.Entities;
using E_Commerce.Message.Dtos;

namespace E_Commerce.Message.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserMessage, ResultMessageDto>().ReverseMap();
            CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
            CreateMap<UserMessage, UpdateMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultInboxMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultSendboxMessageDto>().ReverseMap();
            CreateMap<UserMessage, GetByIdMessageDto>().ReverseMap();
        }
    }
}
