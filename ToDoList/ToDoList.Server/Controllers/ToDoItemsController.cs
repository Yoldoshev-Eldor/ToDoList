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
    public async Task AddTask(ToDoItemCreateDto toDoItemCreateDto)
    {
        await ToDoItemService.AddToDoItemAsync(toDoItemCreateDto);
    }
    [HttpDelete("delete")]
    public async Task DeleteItem(long id)
    {
        await ToDoItemService.DeleteToDoItemByIdAsync(id);
    }
    public async Task<ToDoItemGetDto>GetById(long id)
    {
        return await ToDoItemService.SelectToDoItemByIdAsync(id);
    }
}
