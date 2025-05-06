using Microsoft.AspNetCore.Mvc;
using ToDoList.Service.Dtos;
using ToDoList.Service.Services;

namespace ToDoList.Server.Controllers
{
    [Route("api/ToDoItem")]
    [ApiController]
    public class ToDoItem : ControllerBase
    {
        private readonly IToDoListService toDoListService;

        public ToDoItem(IToDoListService toDoListService)
        {
            this.toDoListService = toDoListService;
        }

        [HttpPost("add")]
        public async Task<long> Add(ToDoItemCreatDto toDoItemCreatDto)
        {
            var id = await toDoListService.AddToDoItemAsync(toDoItemCreatDto);
            return id;
        }

        [HttpDelete("delete")]
        public async Task Delete(long id)
        {
            await toDoListService.DeleteToDoItemByIdAsync(id);
        }

        [HttpGet("getCompleted")]
        public async Task<List<ToDoItemGetDto>> GetCompleted(int skip, int take)
        {
            return await toDoListService.SelectCompletedAsync(skip, take);
        }

        [HttpGet("getInCompleted")]
        public async Task<List<ToDoItemGetDto>> GetInCompleted(int skip, int take)
        {
            return await toDoListService.SelectIncompletedAsync(skip, take);
        }

        [HttpGet("getAll")]
        public async Task<List<ToDoItemGetDto>> GetAll(int skip, int take)
        {
            return await toDoListService.SelectAllToDoItemsAsync(skip, take);
        }

        [HttpGet("getById")]
        public async Task<ToDoItemGetDto> GetById(long id)
        {
            return await toDoListService.SelectToDoItemByIdAsync(id);
        }

        [HttpGet("getByDueDate")]
        public async Task<List<ToDoItemGetDto>> GetByDueDate(DateTime dateTime)
        {
            return await toDoListService.SelectByDueDateAsync(dateTime);
        }

        [HttpPut("update")]
        public async Task Update(ToDoItemUpdateDto toDoItemUpdateDto)
        {
            await toDoListService.UpdateToDoItemAsync(toDoItemUpdateDto);
        }
    }
}
