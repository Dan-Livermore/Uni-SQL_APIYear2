using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CW2_TrailService.Models;

public partial class Place
{
    public int PlaceId { get; set; }

    public string? RouteType { get; set; } = null;
    [MaxLength(50)]
    [Unicode(false)]

    public string? Area { get; set; } = null;
    [MaxLength(255)]
    [Unicode(false)]

    public string? Difficulty { get; set; } = null;
    [MaxLength(50)]
    [Unicode(false)]

    public int? DetailsId { get; set; } = null;

    public virtual Detail? Details { get; set; }

    public virtual ICollection<Site> Sites { get; } = new List<Site>();
}
