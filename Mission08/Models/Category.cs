using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    // Navigation Property (One Category -> Many Tasks)
    public ICollection<Task> Tasks { get; set; }
}