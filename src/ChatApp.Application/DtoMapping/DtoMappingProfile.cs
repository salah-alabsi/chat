using AutoMapper;
using ChatApp.Chat;
using ChatApp.Chat.Dto;

namespace ChatApp.Application.DtoMapping
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            // Group mappings
            CreateMap<Group, GroupDto>();

            // Message mappings
            CreateMap<Message, MessageDto>();
            CreateMap<Message, ResponseMessageDto>();
        }
    }
}
