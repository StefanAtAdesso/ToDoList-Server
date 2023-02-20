using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Database;

public class ToDoItem
{
    public int Id { get; set; }

    [Required]
    public Category Category { get; set; }

    [Required]
    [MaxLength(200)]
    public string Titel { get; set; }
        
    public DateTime Created { get; set; } = DateTime.Now;

    public DateTime? Due { get; set; }

    public bool IsDone { get; set; }

}