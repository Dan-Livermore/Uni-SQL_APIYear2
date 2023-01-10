using System;
using System.Collections.Generic;

namespace CW2_TrailService.Models;

public partial class Trail
{
    public int TrailId { get; set; }

    public string? TrailName { get; set; }

    public string? TrailDescription { get; set; }

    public string? Photos { get; set; }

    public virtual ICollection<Creator> Creators { get; } = new List<Creator>();

    public virtual ICollection<Site> Sites { get; } = new List<Site>();
}
