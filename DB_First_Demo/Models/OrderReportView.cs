using System;
using System.Collections.Generic;

namespace DB_First_Demo.Models;

public partial class OrderReportView
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int ItemId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }
}
