using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Database;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<ToDoItem> ToDoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var categories = new[]
        {
            new Category {Id = -1, Name = "Einkaufen"},
            new Category {Id = -2, Name = "Putzen"},
            new Category {Id = -3, Name = "Sport"},
            new Category {Id = -4, Name = "Party"},
        };
        modelBuilder.Entity<Category>().HasData(categories);

        var toDoItems = new object[]
        {
            new {Id = -1, CategoryId = -1, Titel = "Montagseinkauf", Created = DateTime.Now.AddDays(-7), IsDone = true},
            new {Id = -2, CategoryId = -1, Titel = "Großeinkauf", Created = DateTime.Now, Due = DateTime.Now.AddDays(3), IsDone = false},
            new {Id = -3, CategoryId = -2, Titel = "Frühjahrsputz", Created = DateTime.Now, Due = new DateTime(2023,04,30), IsDone = false},
            new {Id = -4, CategoryId = -2, Titel = "Geschirrspüler ausräumen", Created = DateTime.Now.AddDays(-3),Due = DateTime.Now.AddDays(-2), IsDone = false},
            new {Id = -6, CategoryId =-3 , Titel = "Hanteltraining", Created = DateTime.Now, Due = DateTime.Now.AddDays(1), IsDone = false},
            new {Id = -7, CategoryId = -4, Titel = "Dekorieren", Created = DateTime.Now, Due = new DateTime(2023,08,23), IsDone = false},
            new {Id = -8, CategoryId = -4, Titel = "Getränke kaufen", Created = DateTime.Now, Due = new DateTime(2023,08,20), IsDone = false}
        };
        modelBuilder.Entity<ToDoItem>().HasData(toDoItems);
    }
}