namespace ToDoList.Service.Dtos;

public class ToDoItemUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
}
