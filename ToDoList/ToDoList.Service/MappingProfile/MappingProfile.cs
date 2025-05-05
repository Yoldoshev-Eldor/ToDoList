using AutoMapper;
using ToDoList.DataAccess.Entities;
using ToDoList.Service.Dtos;
namespace ToDoList.Service.MappingProfile;

public class MappingProFile : Profile
{
    public MappingProFile()
    {
        CreateMap<ToDoItem, ToDoItemCreatDto>().ReverseMap();
        CreateMap<ToDoItem, ToDoItemGetDto>().ReverseMap();
        CreateMap<ToDoItem, ToDoItemUpdateDto>().ReverseMap();
    }
}