using System;
using System.Collections.Generic;

namespace CW2_TrailService.Models;

public partial class Place
{
    public int PlaceId { get; set; }

    public string? RouteType { get; set; }

    public string? Area { get; set; }

    public string? Difficulty { get; set; }

    public int? DetailsId { get; set; }

    public virtual Detail? Details { get; set; }

    public virtual ICollection<Site> Sites { get; } = new List<Site>();
}
