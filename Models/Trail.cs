using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CW2_TrailService.Models;

public partial class Trail
{
    public int TrailId { get; set; }

    public string TrailName { get; set; } = "";
    [MaxLength(100)]
    [Unicode(false)]

    public string TrailDescription { get; set; } = "";
    [MaxLength(255)]
    [Unicode(false)]

    public string Photos { get; set; } = "";
    [MaxLength(255)]
    [Unicode(false)]

    public virtual ICollection<Creator> Creators { get; } = new List<Creator>();

    public virtual ICollection<Site> Sites { get; } = new List<Site>();
}
