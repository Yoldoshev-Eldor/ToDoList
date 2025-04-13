using ToDoList.Service.DTOs;

namespace ToDoList.Service.Services;

public class ToDoItemService : IToDoItemService
{
    public Task AddToDoItemAsync(ToDoItemCreateDto toDoItem)
    {
        throw new NotImplementedException();
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
