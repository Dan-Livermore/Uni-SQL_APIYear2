using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CW2_TrailService.Models;

public partial class Account
{
    public string Email { get; set; } = "";
    [MaxLength(255)]
    [Unicode(false)]

    public string? Username { get; set; } = null;
    [MaxLength(100)]
    [Unicode(false)]

    public virtual ICollection<Creator> Creators { get; } = new List<Creator>();
}
