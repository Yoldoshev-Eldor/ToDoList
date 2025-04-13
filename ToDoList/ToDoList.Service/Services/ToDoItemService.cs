using ToDoList.DataAccess.Entities;
using ToDoList.Repository.Services;
using ToDoList.Service.DTOs;
using ToDoList.Service.FluentValidation;

namespace ToDoList.Service.Services;

public class ToDoItemService : IToDoItemService
{
    private readonly IToDoItemRepository ToDoItemRepository;

    public ToDoItemService(IToDoItemRepository toDoItemRepository)
    {
        ToDoItemRepository = toDoItemRepository;
    }

    public async Task<long> AddToDoItemAsync(ToDoItemCreateDto toDoItemDto)
    {
        var validator = new ToDoItemCreateDtoValidator();
        var result = validator.Validate(toDoItemDto);

        if (!result.IsValid)
            throw new Exception(string.Join("; ", result.Errors.Select(e => e.ErrorMessage)));

        var toDoItem = ConvertToDoItemCreateDtoToToDoItem(toDoItemDto);
        var toDoItemId = await ToDoItemRepository.AddToDoItemAsync(toDoItem);
        return toDoItemId;
    }

    private ToDoItem ConvertToDoItemCreateDtoToToDoItem(ToDoItemCreateDto toDoItemDto)
    {
        return new ToDoItem()
        {
            Title = toDoItemDto.Title,
            Description = toDoItemDto.Description,
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow,
            DueDate = toDoItemDto.DueDate,
        };
    }

    public Task DeleteToDoItemByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItemGetDto>> SelectAllToDoItemsAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItemGetDto>> SelectByDueDateAsync(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItemGetDto>> SelectCompletedAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItemGetDto>> SelectIncompletedAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItemGetDto> SelectToDoItemByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateToDoItemAsync(ToDoItemUpdateDto toDoItem)
    {
        throw new NotImplementedException();
    }
}
