using System;
using System.Collections.Generic;

namespace IPBS2.SnakeApi.Database.AppDbContextModels;

public partial class Snake
{
    public int Id { get; set; }

    public string? Mmname { get; set; }

    public string? EngName { get; set; }

    public string? Detail { get; set; }

    public string? IsPoison { get; set; }

    public string? IsDanger { get; set; }
}
