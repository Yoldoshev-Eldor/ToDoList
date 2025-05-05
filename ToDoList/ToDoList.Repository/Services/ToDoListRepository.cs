using Microsoft.EntityFrameworkCore;
using System;
using ToDoList.DataAccess;
using ToDoList.DataAccess.Entities;

namespace ToDoList.Repository.Services;

public class ToDoListRepository : IToDoListRepository
{
    private readonly MainContext mainContext;

    public ToDoListRepository(MainContext mainContext)
    {
        this.mainContext = mainContext;
    }

    public async Task<long> AddToDoItemAsync(ToDoItem toDoItem)
    {
        await mainContext.ToDoItems.AddAsync(toDoItem);
        await mainContext.SaveChangesAsync();
        return toDoItem.Id;
    }

    public async Task DeleteToDoItemByIdAsync(long Id)
    {
        var deleteItem = await SelectToDoItemByIdAsync(Id);
        if (deleteItem == null)
        {
            throw new Exception("deletable item not found");
        }
        mainContext.ToDoItems.Remove(deleteItem);
        await mainContext.SaveChangesAsync();
    }

    public async Task<List<ToDoItem>> SelectAllToDoItemsAsync(int skip, int take)
    {
        if (skip < 0 || take <= 0)
        {
            throw new ArgumentOutOfRangeException("Skip and take must be non-negative and take must be greater than zero.");
        }
        return await mainContext.ToDoItems
              .Skip(skip)
              .Take(take)
              .ToListAsync();
    }

    public async Task<List<ToDoItem>> SelectByDueDateAsync(DateTime dateTime)
    {
        var query = mainContext.ToDoItems
            .Where(t => t.DueDate.Date == dateTime);
        return await query.ToListAsync();
    }

    public async Task<List<ToDoItem>> SelectCompletedAsync(int skip, int take)
    {
        if (skip < 0 || take <= 0)
        {
            throw new ArgumentOutOfRangeException("Skip and take must be non-negative and take must be greater than zero.");
        }

        var query = mainContext.ToDoItems
            .Where(t => t.IsCompleted)
            .Skip(skip)
            .Take(take);

        return await query.ToListAsync();
    }

    public async Task<List<ToDoItem>> SelectIncompletedAsync(int skip, int take)
    {
        if (skip < 0 || take <= 0)
        {
            throw new ArgumentOutOfRangeException("Skip and take must be non-negative and take must be greater than zero.");
        }
        var query = mainContext.ToDoItems
            .Where(t => !t.IsCompleted)
            .Skip(skip)
            .Take(take);

        return await query.ToListAsync();
    }

    public async Task<ToDoItem> SelectToDoItemByIdAsync(long id)
    {
        var toDoItem = await mainContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);

        return toDoItem;
    }

    public async Task UpdateToDoItemAsync(ToDoItem toDoItem)
    {
        mainContext.ToDoItems.Update(toDoItem);
        await mainContext.SaveChangesAsync();
    }
}
