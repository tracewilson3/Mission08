using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Quadrant
{
    [Key]
    public int QuadrantId { get; set; }

    public string? QuadrantName { get; set; }

    // Navigation Property (One Quadrant -> Many Tasks)
    public ICollection<Task> Tasks { get; set; }
}