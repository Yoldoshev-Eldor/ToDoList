using System.Net.Mail;
using ToDoList.DataAccess;
using ToDoList.DataAccess.Entities;

namespace ToDoList.Repository.Services;

public class ToDoItemRepository : IToDoItemRepository
{
    private readonly MainContext MainContext;

    public ToDoItemRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<long> AddToDoItemAsync(ToDoItem toDoItem)
    {
        await MainContext.ToDoItems.AddAsync(toDoItem);
        await MainContext.SaveChangesAsync();
        return toDoItem.Id;
    }

    public Task DeleteToDoItemByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItem>> SelectAllToDoItemsAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItem>> SelectByDueDateAsync(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItem>> SelectCompletedAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItem>> SelectIncompletedAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItem> SelectToDoItemByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateToDoItemAsync(ToDoItem toDoItem)
    {
        throw new NotImplementedException();
    }
}
