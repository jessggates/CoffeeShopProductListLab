﻿using System;
using System.Collections.Generic;

namespace CoffeeShopProductList.Models;

public partial class ProductViewModel
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? Category { get; set; }
}
