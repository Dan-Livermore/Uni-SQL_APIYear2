using System;
using System.Collections.Generic;

namespace CW2_TrailService.Models;

public partial class Account
{
    public string Email { get; set; } = null!;

    public string? Username { get; set; }

    public virtual ICollection<Creator> Creators { get; } = new List<Creator>();
}
