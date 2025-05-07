using Microsoft.AspNetCore.Mvc.Filters;
using ToDoList.Service.Services;

namespace ToDoList.Server.Filters;

public class ToDoListCountHeaderFilter : IAsyncResultFilter
{

    private readonly IToDoListService _toDoItemService;

    public ToDoListCountHeaderFilter(IToDoListService toDoItemService)
    {
        _toDoItemService = toDoItemService;
    }

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var totalCount = 12;

        context.HttpContext.Response.Headers.Add("X-Total-Count", totalCount.ToString());

        await next();
    }
}


