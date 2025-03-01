using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08.Models;

public class Task
{
    [Key]
    public int TaskId { get; set; }

    [Required]
    public string TaskName { get; set; }

    public DateTime? DueDate { get; set; } 

    public bool? Completed { get; set; } 

    // Foreign Key for Quadrant
    public int QuadrantId { get; set; }
    [ForeignKey("QuadrantId")]
    public Quadrant Quadrant { get; set; }

    // Foreign Key for Category
    public int? CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }
}