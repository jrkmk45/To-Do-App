using AutoMapper;
using ToDoApp.Application.Dto;
using ToDoApp.Domain.Models;

namespace ToDoApp.Application.MappingProfiles
{
    public class ToDoTaskMappingProfile : Profile
    {
        public ToDoTaskMappingProfile() 
        {
            CreateMap<ToDoTask, ToDoTaskDto>();

            CreateMap<CreateTaskDto, ToDoTask>();

            CreateMap<PatchTaskDto, ToDoTask>()
                .ForMember(prop => prop.Title, prop =>
                {
                    prop.PreCondition(v => !string.IsNullOrEmpty(v.Title));
                    prop.MapFrom(v => v.Title);
                })
                .ForMember(prop => prop.IsCompleted, prop =>
                {
                    prop.PreCondition(v => v.isCompleted != null);
                    prop.MapFrom(v => v.isCompleted);
                });
        }
    }
}
