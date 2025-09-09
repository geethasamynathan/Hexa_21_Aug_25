using System;
using System.Collections.Generic;

namespace RouteDemo.Models;

public partial class Course
{
    public int Id { get; set; }

    public string CourseName { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
