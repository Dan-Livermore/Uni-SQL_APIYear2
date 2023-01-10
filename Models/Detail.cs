using System;
using System.Collections.Generic;

namespace CW2_TrailService.Models;

public partial class Detail
{
    public int DetailsId { get; set; }

    public int? NumberOfMarkers { get; set; }

    public float? DistanceMiles { get; set; }

    public float? ElevationMeters { get; set; }

    public virtual ICollection<Place> Places { get; } = new List<Place>();
}
