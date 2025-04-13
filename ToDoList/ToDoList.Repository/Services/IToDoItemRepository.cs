using ToDoList.DataAccess.Entities;
namespace ToDoList.Repository.Services;

public interface IToDoItemRepository
{
    Task DeleteToDoItemByIdAsync(long Id);
    Task UpdateToDoItemAsync(ToDoItem toDoItem);
    Task<List<ToDoItem>> SelectAllToDoItemsAsync(int skip, int take);
    Task<ToDoItem> SelectToDoItemByIdAsync(long Id);
    Task<List<ToDoItem>> SelectByDueDateAsync(DateTime dateTime);
    Task<List<ToDoItem>> SelectCompletedAsync(int skip, int take);
    Task<List<ToDoItem>> SelectIncompletedAsync(int skip, int take);




}