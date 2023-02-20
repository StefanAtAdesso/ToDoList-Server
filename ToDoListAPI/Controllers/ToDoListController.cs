using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Database;
using ToDoListAPI.Repositories;

namespace ToDoListAPI.Controllers;

[ApiController]
[Route("/api")]
public class ToDoListController : ControllerBase
{
    private readonly ToDoListRepository _repository;

    public ToDoListController(ToDoListRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IReadOnlyCollection<Category>>> GetCategories()
    {
        return Ok(await _repository.GetAllCategories());
    }

    [HttpPost("categories")]
    public async Task<ActionResult<IReadOnlyCollection<Category>>> NewCategory(
        [Required][StringLength(100, MinimumLength = 1)][FromBody] string name)
    {
        name = name.Trim();
        if (string.IsNullOrEmpty(name))
        {
            return BadRequest("Name zu kurz");
        }

        await _repository.InsertCategory(name);

        return Ok(await _repository.GetAllCategories());
    }

    [HttpGet("todo_items")]
    public async Task<ActionResult<IReadOnlyCollection<ToDoItem>>> GetToDoItems()
    {
        return Ok(await _repository.GetAllToDoItems());
    }

    [HttpGet("todo_items/{id:int}")]
    public async Task<ActionResult<ToDoItem>> GetToDoItem(int id)
    {
        var result = await _repository.GetToDoItem(id);
        return result == null
            ? NotFound()
            : Ok(result);
    }
    
    [HttpDelete("todo_items/{id:int}")]
    public async Task<ActionResult> DeleteToDoItem(int id)
    {
        var result = await _repository.DeleteToDoItem(id);
        return result
            ? NoContent()
            : NotFound();
    }

    [HttpGet("todo_items/search")]
    public async Task<ActionResult<IReadOnlyCollection<ToDoItem>>> SearchToDoItems(string pattern)
    {
        return Ok(await _repository.SearchToDoItems(pattern));
    }

    [HttpPut("todo_items")]
    public async Task<ActionResult<ToDoItem>> UpdateToDoItem(ToDoItem updatedItem)
    {
        var newItem = await _repository.UpdateToDoItem(updatedItem);
        return newItem == null
            ? NotFound()
            : Ok(newItem);
    }

    [HttpPost("todo_items")]
    public async Task<ActionResult<ToDoItem>> InsertToDoItem(ToDoItem newToDoItem)
    {
        var newItem = await _repository.InsertToDoItem(newToDoItem);
        return Ok(newItem);
    }
}