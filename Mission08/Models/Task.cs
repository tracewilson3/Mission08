using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Task
{
    [Key]
    public int TaskId { get; set; }

    [Required]
    public string TaskName { get; set; }

    public DateTime? DueDate { get; set; } 

    public int? Completed { get; set; } 

    // Foreign Key for Quadrant
    public int QuadrantId { get; set; }
    [ForeignKey("QuadrantId")]
    public Quadrant Quadrant { get; set; }

    // Foreign Key for Category
    public int? CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }
}