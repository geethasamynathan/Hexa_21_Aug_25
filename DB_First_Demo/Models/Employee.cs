using System;
using System.Collections.Generic;

namespace DB_First_Demo.Models;

public partial class Employee
{
    public int Empid { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public int? Salary { get; set; }

    public string? City { get; set; }
}
