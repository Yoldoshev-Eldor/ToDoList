using AutoMapper;
using FluentValidation;
using ToDoList.DataAccess.Entities;
using ToDoList.Repository.Services;
using ToDoList.Service.Dtos;

namespace ToDoList.Service.Services;

public class ToDoListService : IToDoListService
{
    private readonly IToDoListRepository _repository;
    private readonly IValidator<ToDoItemCreatDto> _toDoItemCreateDtoValidator;
    private readonly IValidator<ToDoItemUpdateDto> _toDoItemUpdateDtoValidator;
    private readonly IMapper _mapper;

    public ToDoListService(IToDoListRepository repository, IValidator<ToDoItemCreatDto> toDoItemCreateDtoValidator)
    {
        _repository = repository;
        _toDoItemCreateDtoValidator = toDoItemCreateDtoValidator;
    }

    public async Task<long> AddToDoItemAsync(ToDoItemCreatDto toDoItem)
    {
        var resultValidation = _toDoItemCreateDtoValidator.Validate(toDoItem);
        if (resultValidation.IsValid)
        {
            throw new Exception("Validation is invalid");
        }
        var convert = _mapper.Map<ToDoItem>(toDoItem);
        return await _repository.AddToDoItemAsync(convert);
    }

    public async Task DeleteToDoItemByIdAsync(long Id)
    {
        var toDoItem = await _repository.SelectToDoItemByIdAsync(Id);
        if (toDoItem == null)
        {
            throw new Exception("This id not found");
        }
        await _repository.DeleteToDoItemByIdAsync(Id);
    }

    public async Task<List<ToDoItemGetDto>> SelectAllToDoItemsAsync(int skip, int take)
    {
        var toDoItems = await _repository.SelectAllToDoItemsAsync(skip, take);

        var toDoItemDtos = toDoItems
            .Select(item => _mapper.Map<ToDoItemGetDto>(item))
            .ToList();

        return toDoItemDtos;
    }

    public async Task<List<ToDoItemGetDto>> SelectByDueDateAsync(DateTime dateTime)
    {
        var result = await _repository.SelectByDueDateAsync(dateTime);
        return result.Select(item => _mapper.Map<ToDoItemGetDto>(item)).ToList();
    }

    public async Task<List<ToDoItemGetDto>> SelectCompletedAsync(int skip, int take)
    {
        var completedItems = await _repository.SelectCompletedAsync(skip, take);

        return completedItems
                   .Select(item => _mapper.Map<ToDoItemGetDto>(item))
                   .ToList();
    }

    public async Task<List<ToDoItemGetDto>> SelectIncompletedAsync(int skip, int take)
    {
        var incompleteItems = await _repository.SelectIncompletedAsync(skip, take);

        var incompleteDtos = incompleteItems
            .Select(item => _mapper.Map<ToDoItemGetDto>(item))
            .ToList();

        return incompleteDtos;
    }

    public async Task<ToDoItemGetDto> SelectToDoItemByIdAsync(long Id)
    {
        var founded = await _repository.SelectToDoItemByIdAsync(Id);
        if (founded == null)
        {
            throw new Exception($"ToDoItem with id {Id} not found.");
        }
        return _mapper.Map<ToDoItemGetDto>(founded);
    }

    public async Task UpdateToDoItemAsync(ToDoItemUpdateDto toDoItem)
    {
        var validationResult = _toDoItemUpdateDtoValidator.Validate(toDoItem);
        if (!validationResult.IsValid)
        {
            throw new Exception("this item invalid");
        }

        await _repository.UpdateToDoItemAsync(_mapper.Map<ToDoItem>(toDoItem));
    }
}
