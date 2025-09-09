using System;
using System.Collections.Generic;

namespace DB_First_Demo.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Name { get; set; }

    public long? Mobile { get; set; }

    public string? Location { get; set; }
}
