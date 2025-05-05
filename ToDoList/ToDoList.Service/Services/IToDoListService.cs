using ToDoList.DataAccess.Entities;
using ToDoList.Service.Dtos;

namespace ToDoList.Service.Services;

public interface IToDoListService
{
    Task<long> AddToDoItemAsync(ToDoItemCreatDto toDoItem);
    Task DeleteToDoItemByIdAsync(long Id);
    Task UpdateToDoItemAsync(ToDoItemUpdateDto toDoItem);
    Task<List<ToDoItemGetDto>> SelectAllToDoItemsAsync(int skip, int take);
    Task<ToDoItemGetDto> SelectToDoItemByIdAsync(long Id);
    Task<List<ToDoItemGetDto>> SelectByDueDateAsync(DateTime dateTime);
    Task<List<ToDoItemGetDto>> SelectCompletedAsync(int skip, int take);
    Task<List<ToDoItemGetDto>> SelectIncompletedAsync(int skip, int take);
}