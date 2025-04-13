using Microsoft.EntityFrameworkCore;
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

    public async Task DeleteToDoItemByIdAsync(long Id)
    {
        var deleteItem = await SelectToDoItemByIdAsync(Id);
        if (deleteItem == null)
        {
            throw new Exception("deleted item not found");
        }
        MainContext.ToDoItems.Remove(deleteItem);
        await MainContext.SaveChangesAsync();
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

    public async Task<ToDoItem> SelectToDoItemByIdAsync(long Id)
    {
        var item = await MainContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == Id);
        if (item == null)
        {
            throw new Exception("not found");
        }
        return item;
    }

    public Task UpdateToDoItemAsync(ToDoItem toDoItem)
    {
        throw new NotImplementedException();
    }
}
