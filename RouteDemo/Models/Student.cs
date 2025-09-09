using System;
using System.Collections.Generic;

namespace RouteDemo.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentEmail { get; set; } = null!;

    public int Age { get; set; }

    public string Gender { get; set; } = null!;

    public string City { get; set; } = null!;

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;
}
