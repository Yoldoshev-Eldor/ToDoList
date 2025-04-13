using Microsoft.AspNetCore.Mvc;
using ToDoList.Service.DTOs;
using ToDoList.Service.Services;

namespace ToDoList.Server.Controllers;

[Route("api/toDoItem")]
[ApiController]
public class ToDoItemsController : ControllerBase
{
    private readonly ToDoItemService ToDoItemService;

    public ToDoItemsController(ToDoItemService toDoItemService)
    {
        ToDoItemService = toDoItemService;
    }
    [HttpPost("add")]
    private async Task AddTask(ToDoItemCreateDto toDoItemCreateDto)
    {
        await ToDoItemService.AddToDoItemAsync(toDoItemCreateDto);
    }
}
