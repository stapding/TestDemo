﻿using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Point
{
    public int PointId { get; set; }

    public int? Postcode { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
